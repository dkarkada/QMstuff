using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RydbergAvgs {
	public partial class Form : System.Windows.Forms.Form {
		Canvas c;
		System.Timers.Timer clock;
		System.Diagnostics.Stopwatch stopwatch;
		QMStuff_v2.ProgressForm pf;

		public Form() {
			InitializeComponent();
		}
	}
	public class Canvas : Panel {
		private Form form;
		public Bitmap bmp { get; set; }
		public Lattice lat { get; set; }
		public QMStuff_v2.GraphicsSettings gs { get; set; }
		public int ind { get; set; }
		public bool ctrlPressed { get; set; }
		SaveFileDialog saver;

		public Canvas(Form f, Size s) {
			form = f;
			lat = new Lattice(400);
			bmp = new Bitmap(s.Width, s.Height);
			gs = new QMStuff_v2.GraphicsSettings();
			ind = 0;
			AutoSize = true;
			DoubleBuffered = true;
			
			this.MouseClick += Canvas_MouseClick;
			this.MouseMove  += Canvas_MouseMove;
		}

		public void SetSize(Size s) {
			bmp = new Bitmap(s.Width, s.Height);
		}
		protected override void OnPaint(PaintEventArgs e) {
			Graphics g = e.Graphics;
			g.DrawImage(bmp, 0, 0);
		}
		public void ReRender() {
			if (lat.changes.Count > 1) {
				using (var g = Graphics.FromImage(bmp)) {
					g.Clear(Color.Transparent);
					if (gs.axes) {
						int w = bmp.Width;
						int h = bmp.Height;
						g.DrawLine(gs.axisPen, w/2, 0, w/2, h);
						g.DrawLine(gs.axisPen, 0, h/2, w, h/2);
					}
					SolidBrush br = gs.fgBrush;
					Tuple<List<Atom>, int> result = lat.latFrameList.GetNearestFrame(ind);
					foreach (Atom a in result.Item1) {
						g.FillRectangle(br,
							(float)(bmp.Width/2 + lat.aSize * (a.x - .5)),
							(float)(bmp.Height/2 - lat.aSize * (a.y + .5)),
							(int)lat.aSize, (int)lat.aSize);
					}
					if (result.Item2 < ind) {
						for (int i = result.Item2; i <= ind; i++) {
							LatticeChange lc = lat.changes[i];
							br = gs.fgBrush;
							foreach (Atom a in lc.on) {
								g.FillRectangle(br,
									(float)(bmp.Width/2 + lat.aSize * (a.x - .5)),
									(float)(bmp.Height/2 - lat.aSize * (a.y + .5)),
									(int)lat.aSize, (int)lat.aSize);
							}
							br = gs.bgBrush;
							foreach (Atom a in lc.off) {
								g.FillRectangle(br,
									(float)(bmp.Width/2 + lat.aSize * (a.x - .5)),
									(float)(bmp.Height/2 - lat.aSize * (a.y + .5)),
									(int)lat.aSize, (int)lat.aSize);
							}
						}
					}
					else {
						for (int i = result.Item2; i > ind; i--) {
							LatticeChange lc = lat.changes[i];
							br = gs.fgBrush;
							foreach (Atom a in lc.off) {
								g.FillRectangle(br,
									(float)(bmp.Width/2 + lat.aSize * (a.x - .5)),
									(float)(bmp.Height/2 - lat.aSize * (a.y + .5)),
									(int)lat.aSize, (int)lat.aSize);
							}
							br = gs.bgBrush;
							foreach (Atom a in lc.on) {
								g.FillRectangle(br,
									(float)(bmp.Width/2 + lat.aSize * (a.x - .5)),
									(float)(bmp.Height/2 - lat.aSize * (a.y + .5)),
									(int)lat.aSize, (int)lat.aSize);
							}
						}
					}
				}
				Invalidate();
			}
		}
		public void Restart() {
			ind = 0;
			lat.ClearChanges();
		}		
		private void Canvas_MouseClick(object sender, EventArgs e) {
			this.Focus();
		}
		private void Canvas_MouseMove(object sender, MouseEventArgs e) {
			double x = (e.X - bmp.Width/2)/lat.aSize;
			double y = (bmp.Height/2 - e.Y)/lat.aSize;
			form.UpdateMousePos(x, y);
		}
	}
	public class Lattice {
		public Atom[,] mat { get; set; }
		public LatticeFrameList latFrameList { get; set; }
		public double aSize { get; set; }
		public int sz { get; set; }
		public List<LatticeChange> changes { get; set; }
		AnalysisCalc analytics { get; set; }
		public List<Tuple<int, double[]>> data { get; set; }

		public Lattice(int s) {
			aSize = 10;
			sz = s;
			mat = new Atom[sz, sz];
			latFrameList = new LatticeFrameList();
			changes = new List<LatticeChange>();
			analytics = new AnalysisCalc();

			for(int r = 0; r < sz; r++) {
				for(int c = 0; c < sz; c++) {
					mat[r, c] = new Atom(c - sz / 2, sz / 2 - r, 0);
				}
			}
			for(int r = 0; r < sz; r++) {
				for(int c = 0; c < sz; c++) {
					mat[r, c].SetLocale(
						c > 0 ? mat[r, c - 1] : null,
						c < sz - 1 ? mat[r, c + 1] : null,
						r > 0 ? mat[r - 1, c] : null,
						r < sz - 1 ? mat[r + 1, c] : null);
				}
			}
		}
		public void GenerateChanges(BackgroundWorker worker, int maxstep, double Px, double Py, double gamma) {
			AtomsLinkedList nextAtomsX = new AtomsLinkedList();
			AtomsLinkedList nextAtomsY = new AtomsLinkedList();
			AtomsLinkedList allExcited = new AtomsLinkedList();

			List<Atom> seeds = new List<Atom>();
			LatticeChange init = new LatticeChange();
			int o = sz/2;
			int[] colVals = { o };
			int[] rowVals = { o };
			for(int i = 0; i<rowVals.Count(); i++) {
				int c = colVals[i];
				int r = rowVals[i];
				allExcited.Add(mat[r, c]);
				mat[r, c].excited = true;
				if(mat[r, c + 1].node == null) {
					nextAtomsX.Add(mat[r, c + 1]);
					mat[r, c + 1].node.isNextX = true;
				}
				if(mat[r, c - 1].node == null) {
					nextAtomsX.Add(mat[r, c - 1]);
					mat[r, c - 1].node.isNextX = true;
				}
				if(mat[r + 1, c].node == null) {
					nextAtomsY.Add(mat[r + 1, c]);
					mat[r + 1, c].node.isNextY = true;
				}
				if(mat[r - 1, c].node == null) {
					nextAtomsY.Add(mat[r - 1, c]);
					mat[r - 1, c].node.isNextY = true;
				}
				init.AddOn(mat[r, c]);
			}
			changes.Add(init);

			latFrameList.Add(mat, 0);
			Random rnd = new Random();
			Boolean done = false;
			int bound = 0;
			int totalExcited = 1;
			while(!done && changes.Count < maxstep) {
				LatticeChange lc = new LatticeChange();
				HashSet<Atom> maybeNext = new HashSet<Atom>();
				HashSet<Atom> maybeRemoveXNext = new HashSet<Atom>();
				HashSet<Atom> maybeRemoveYNext = new HashSet<Atom>();
				foreach(AtomNode node in allExcited) {
					if(rnd.NextDouble() < gamma) {
						allExcited.Remove(node);
						node.atom.excited = false;
						lc.AddOff(node.atom);
						foreach(Atom a in node.atom.locale) {
							if(a != null && a.node == null) //means that it is not excited and not next; will check neighbor's neighbors later
								maybeNext.Add(a);
							if(a != null && !a.Equals(node.atom)) {
								if(a.IsXNext())
									maybeRemoveXNext.Add(a);
								else if(a.IsYNext())
									maybeRemoveYNext.Add(a);
							}
						}
					}
				}
				foreach(AtomNode node in nextAtomsX) {
					if(rnd.NextDouble() < Px) {// && rnd.NextDouble() > gamma) {
						nextAtomsX.Remove(node);
						//no need to say node isnext is false since node is discarded and replaced	
						node.atom.excited = true;
						allExcited.Add(node.atom);
						lc.AddOn(node.atom);
						bound = Math.Max(bound, Math.Abs(node.atom.x));
						for(int i = 1; i < 5; i++) {
							Atom neighbor = node.atom.locale[i];
							if(neighbor != null) {
								if(neighbor.IsXNext())
									maybeRemoveXNext.Add(neighbor);
								else if(neighbor.IsYNext())
									maybeRemoveYNext.Add(neighbor);
								else if(neighbor.IsValid())
									maybeNext.Add(neighbor);
							}
							else
								done = true;
						}
					}
				}
				foreach(AtomNode node in nextAtomsY) {
					if(rnd.NextDouble() < Py) {// && rnd.NextDouble() > gamma) {
						nextAtomsY.Remove(node);
						node.atom.excited = true;
						allExcited.Add(node.atom);
						lc.AddOn(node.atom);
						bound = Math.Max(bound, Math.Abs(node.atom.y));
						for(int i = 1; i < 5; i++) {
							Atom neighbor = node.atom.locale[i];
							if(neighbor != null) {
								if(neighbor.IsXNext())
									maybeRemoveXNext.Add(neighbor);
								else if(neighbor.IsYNext())
									maybeRemoveYNext.Add(neighbor);
								else if(neighbor.IsValid())
									maybeNext.Add(neighbor);
							}
							else
								done = true;
						}
					}
				}
				foreach(Atom a in maybeRemoveXNext) {
					if(!a.excited && !a.IsValid() && a.IsXNext()) {
						nextAtomsX.Remove(a.node);
					}
				}
				foreach(Atom a in maybeRemoveYNext) {
					if(!a.excited && !a.IsValid() && a.IsYNext())
						nextAtomsY.Remove(a.node);
				}
				foreach(Atom a in maybeNext) {
					if(a.IsValid()) {
						if((a.locale[1] != null && a.locale[1].excited) || (a.locale[2] != null && a.locale[2].excited)) {
							nextAtomsX.Add(a);
							a.node.isNextX = true;
						}
						else {
							nextAtomsY.Add(a);
							a.node.isNextY = true;
						}
					}
				}
				lc.bound = bound;
				totalExcited += lc.on.Count - lc.off.Count;
				lc.totalExcited = totalExcited;
				changes.Add(lc);
				if(changes.Count-1 % 50 == 0 || done || changes.Count == maxstep)
					latFrameList.Add(mat, changes.Count-1);
				if(worker!=null)
					worker.ReportProgress((int)(100 * Math.Pow((double)bound/(sz/2), 2)));
			}
		}
		public void ClearChanges() {
			changes = new List<LatticeChange>();
		}
		public void StartSpatialAnalysis(int ind) {
			int offset = 50;
			bool[,] boxMat = new bool[sz + offset*2, sz + offset*2];
			Tuple<List<Atom>, int> result = latFrameList.GetNearestFrame(ind);
			foreach(Atom a in result.Item1) {
				int r = ConvertY(a.y);
				int c = ConvertX(a.x);
				boxMat[r + offset, c + offset] = true;
			}
			if(result.Item2 < ind) {
				for(int i = result.Item2; i < ind; i++) {
					LatticeChange lc = changes[i];
					foreach(Atom a in lc.on) {
						int r = ConvertY(a.y);
						int c = ConvertX(a.x);
						boxMat[r + offset, c + offset] = true;
					}
					foreach(Atom a in lc.off) {
						int r = ConvertY(a.y);
						int c = ConvertX(a.x);
						boxMat[r + offset, c + offset] = false;
					}
				}
			}
			else {
				for(int i = result.Item2; i >= ind; i--) {
					LatticeChange lc = changes[i];
					foreach(Atom a in lc.off) {
						int r = ConvertY(a.y);
						int c = ConvertX(a.x);
						boxMat[r + offset, c + offset] = true;
					}
					foreach(Atom a in lc.on) {
						int r = ConvertY(a.y);
						int c = ConvertX(a.x);
						boxMat[r + offset, c + offset] = false;
					}
				}
			}
			int bound = changes[ind-1].bound;
			int total = changes[ind-1].totalExcited;
			int[] boxSizes = { 1, 2, 3, 4, 5, 6, 8, 10, 20, 50 };
			data = new List<Tuple<int, double[]>>();
			foreach(int s in boxSizes)
				data.Add(new Tuple<int, double[]>(s, analytics.GetInfo(s, boxMat, bound, total)));
		}
		public int ConvertX(int x) { return x + sz/2; }
		public int ConvertY(int y) { return sz/2 - y; }
	}
}
