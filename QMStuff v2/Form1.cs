using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QMStuff_v2
{

	public partial class Form1 : Form {
		Canvas c;
		ProgressForm pf;
		System.Timers.Timer clock;

		public Form1() {
			InitializeComponent();
			SetSizeAndControls();

			clock = new System.Timers.Timer(100);
			clock.Elapsed += new System.Timers.ElapsedEventHandler(PlayStep);

			DoubleBuffered = true;
			c.RenderNext();
		}
		private void SetSizeAndControls() {
			Size = Screen.FromControl(this).WorkingArea.Size;
			splitPanel.SplitterDistance = ClientSize.Width - splitPanel.Panel2.Height - splitPanel.SplitterWidth;

			c = new Canvas(this, new Size(splitPanel.Panel2.Width, splitPanel.Panel2.Height));
			c.Dock = DockStyle.Fill;
			splitPanel.Panel2.Controls.Add(c);

			splitPanel.Panel2.BackColor = c.gs.bgBrush.Color;
			splitPanel.Panel1.BackColor = Color.FromArgb(60, 60, 75);
			xProbLabel.ForeColor = yProbLabel.ForeColor = gammaLabel.ForeColor =
				zoomTitle.ForeColor = initTitle.ForeColor = Color.White;

			Resize += FrameResizing;
			splitPanel.SplitterMoved += SplitPanelResized;
		}
		public void zoom(int d) {
			if(d>0 && c.gs.zoom!=1) {
				zoomButton4.Checked = true;
				c.gs.zoom = 1;
				c.lat.aSize = (int)(10*c.gs.zoom);
				c.ReRender();
			}
			else if(d<0 && c.gs.zoom!=0.125) {
				zoomButton1.Checked = true;
				c.gs.zoom = .125;
				c.lat.aSize = (int)(10*c.gs.zoom);
				c.ReRender();
			}
		}
		private void FrameResizing(object sender, EventArgs e) {
			if(WindowState!=FormWindowState.Minimized)
				splitPanel.SplitterDistance = Math.Max(0, ClientSize.Width - splitPanel.Panel2.Height - splitPanel.SplitterWidth);
			c.SetSize(new Size(splitPanel.Panel2.Width, splitPanel.Panel2.Height));
			c.ReRender();
		}
		private void SplitPanelResized(object sender, SplitterEventArgs e) {
			c.SetSize(new Size(splitPanel.Panel2.Width, splitPanel.Panel2.Height));
			c.ReRender();
		}

		private void GenerateButton_Click(object sender, EventArgs e) {
			BackgroundWorker worker = new BackgroundWorker();
			worker.WorkerReportsProgress = true;
			worker.DoWork += Worker_DoWork;
			worker.ProgressChanged += Worker_ProgressChanged;
			worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
			pf = new ProgressForm();
			pf.Show();
			worker.RunWorkerAsync();
		}
		private void Worker_DoWork(object sender, DoWorkEventArgs e) {
			BackgroundWorker worker = sender as BackgroundWorker;
			c.lat.GenerateChanges(worker, 1);
		}
		private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			pf.SetValue(e.ProgressPercentage);
		}
		private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			pf.Close();
	//		Console.WriteLine(c.lat.stopwatch.ElapsedMilliseconds/1000);
			playGroup.Enabled = true;
			probGroup.Enabled = false;
		}
		private void Form1_KeyDown(object sender, KeyEventArgs e) {
			if(e.KeyCode == Keys.ControlKey)
				c.ctrlPressed = true;
			if(e.KeyCode == Keys.Space && playButton.Enabled) {
				if(!clock.Enabled) {
					clock.Start();
					playButton.Text = "Pause";
					speedBar.Visible = true;
				}
				else {
					clock.Stop();
					playButton.Text = "Play";
					speedBar.Visible = false;
				}
			}
		}
		private void Form1_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.ControlKey)
				c.ctrlPressed = false;
		}
		private void PlayStep(object source, System.Timers.ElapsedEventArgs e) {
			Action a = delegate () {
				if(stepCounter.Value!= stepCounter.Maximum)
					stepCounter.Value++;
				else {
					clock.Stop();
					playButton.Text = "Play";
					speedBar.Visible = false;
				}
			};
			BeginInvoke(a);
		}
        private void helpButton_Click(object sender, EventArgs e){
            String msg = QMStuff_v2.Properties.Resources.helpmsg;
            MessageBox.Show(msg, "Help");
        }
        private void skipToBeginningButton_Click(object sender, EventArgs e) {
			stepCounter.Value = 1;
		}
		private void backButton_Click(object sender, EventArgs e)
        {
			stepCounter.Value = Math.Max(1, stepCounter.Value-1);
        }
        private void fwdButton_Click(object sender, EventArgs e) {
			if(stepCounter.Value!= stepCounter.Maximum)
				stepCounter.Value++;
		}
		private void skipToEndButton_Click(object sender, EventArgs e) {
			stepCounter.Value = c.lat.changes.Count;
		}
		private void playButton_Click(object sender, EventArgs e)
        {
            if (!clock.Enabled)
            {
                clock.Start();
                playButton.Text = "Pause";
                speedBar.Visible = true;
            }
            else {
                clock.Stop();
                playButton.Text = "Play";
                speedBar.Visible = false;
            }
        }
		private void restartButton_Click(object sender, EventArgs e) {
			clock.Stop();
			playButton.Text = "Play";
			speedBar.Visible = false;
			c.Restart();
			c.lat.Xprobability = (double)(xProbBar.Value) / 100;
			c.lat.Yprobability = (double)(yProbBar.Value) / 100;
			stepCounter.Value = 1;
			c.ReRender();
			c.RenderNext();

			probGroup.Enabled=true;
            GenerateButton.Focus();
            playGroup.Enabled=false;
		}
		private void xProbBar_Scroll(object sender, EventArgs e) {
            c.lat.Xprobability = (double)(xProbBar.Value) / 100;
			xProbValue.Value = xProbBar.Value;
		}
		private void yProbBar_Scroll(object sender, EventArgs e) {
			c.lat.Yprobability = (double)(yProbBar.Value) / 100;
			yProbValue.Value = yProbBar.Value;
		}
		private void gammaBar_Scroll(object sender, EventArgs e) {
			c.lat.gamma = (double)(gammaBar.Value) / 100;
			gammaValue.Value = gammaBar.Value;
		}
		private void speedBar_Scroll(object sender, EventArgs e){
            clock.Interval = 140 - (speedBar.Value * 1);
		}
		private void xProbValue_ValueChanged(object sender, EventArgs e) {
			xProbBar.Value = (int) xProbValue.Value;
			c.lat.Xprobability = (double)(xProbBar.Value) / 100;
		}
		private void yProbValue_ValueChanged(object sender, EventArgs e) {
			yProbBar.Value = (int)yProbValue.Value;
			c.lat.Yprobability = (double)(yProbBar.Value) / 100;
		}
		private void gammaValue_ValueChanged(object sender, EventArgs e) {
			gammaBar.Value = (int)gammaValue.Value;
			c.lat.gamma = (double)(gammaBar.Value) / 100;
		}
		private void stepCounter_ValueChanged(object sender, EventArgs e) {
			int oldInd = c.ind;
			stepCounter.Value = Math.Min(
				(int)stepCounter.Value,
				c.lat.changes.Count);
			c.ind = (int) stepCounter.Value - 1;
			int diff = c.ind - oldInd;
			if(diff == 1)
				c.RenderNext();
			else if(diff == -1)
				c.RenderPrev();
			else if (diff == 0){
				clock.Stop();
				playButton.Text = "Play";
				speedBar.Visible = false;
			}
			else {
				c.ReRender();
			}
		}
		private void zoomButton1_CheckedChanged(object sender, EventArgs e) {
			c.gs.zoom = .125;
			c.lat.aSize = (int)(10*c.gs.zoom);
			c.ReRender();
        }
		private void zoomButton2_CheckedChanged(object sender, EventArgs e) {
			c.gs.zoom = .25;
			c.lat.aSize = (int)(10*c.gs.zoom);
			c.ReRender();
		}
		private void zoomButton3_CheckedChanged(object sender, EventArgs e) {
			c.gs.zoom = .5;
			c.lat.aSize = (int)(10*c.gs.zoom);
			c.ReRender();
		}
		private void zoomButton4_CheckedChanged(object sender, EventArgs e) {
			c.gs.zoom = 1;
			c.lat.aSize = (int)(10*c.gs.zoom);
			c.ReRender();
		}
    }
    public class Canvas : Panel {
		private Form1 form;
		public Bitmap bmp { get; set; }
		public Lattice lat { get; set; }
		public GraphicsSettings gs { get; set; }
		public int ind { get; set; }
		public bool ctrlPressed { get; set; }

		public Canvas(Form1 f, Size s) {
			form = f;
			lat = new Lattice();
			bmp = new Bitmap(s.Width, s.Height);
			gs = new GraphicsSettings();
			ind = 0;
			AutoSize = true;
			DoubleBuffered = true;

			this.MouseWheel += Canvas_MouseWheel;
			this.MouseEnter += Canvas_MouseEnter;
			this.MouseLeave += Canvas_MouseLeave;
		}

		public void SetSize(Size s) {
			bmp = new Bitmap(s.Width, s.Height);
		}
		protected override void OnPaint(PaintEventArgs e) {
			Graphics g = e.Graphics;
			g.DrawImage(bmp, 0, 0);
		}
		public void RenderNext() {
			using(var g = Graphics.FromImage(bmp)) {
				if(ind < lat.changes.Count) {
					LatticeChange lc = lat.changes[ind];
					SolidBrush br = gs.fgBrush;
					if(ind!=0)
						foreach (Atom a in lat.changes[ind - 1].on) {
							g.FillRectangle(br,
								(float)(bmp.Width / 2 + lat.aSize * (a.x - .5)),
								(float)(bmp.Height / 2 - lat.aSize * (a.y + .5)),
								(int)lat.aSize, (int)lat.aSize);
						}
					br = new SolidBrush(Color.Red);
					foreach (Atom a in lc.on) {
						g.FillRectangle(br,
							(float)(bmp.Width/2 + lat.aSize*(a.x - .5)),
							(float)(bmp.Height/2 - lat.aSize*(a.y + .5)),
							(int)lat.aSize, (int)lat.aSize);
					}
					br = gs.bgBrush;
					foreach(Atom a in lc.off) {
						g.FillRectangle(br,
							(float)(bmp.Width/2 + lat.aSize*(a.x - .5)),
							(float)(bmp.Height/2 - lat.aSize*(a.y + .5)),
							(int)lat.aSize, (int)lat.aSize);
					}
				}
			}
			Invalidate();
		}
		public void RenderPrev() {
			using(var g = Graphics.FromImage(bmp)) {
				if(ind+1 < lat.changes.Count) {
					LatticeChange lc = lat.changes[ind+1];
					SolidBrush br = gs.bgBrush;
					foreach(Atom a in lc.on) {
						g.FillRectangle(br,
							(float)(bmp.Width/2 + lat.aSize*(a.x - .5)),
							(float)(bmp.Height/2 - lat.aSize*(a.y + .5)),
							(int)lat.aSize, (int)lat.aSize);
					}
					br = gs.fgBrush;
					foreach(Atom a in lc.off) {
						g.FillRectangle(br,
							(float)(bmp.Width/2 + lat.aSize*(a.x - .5)),
							(float)(bmp.Height/2 - lat.aSize*(a.y + .5)),
							(int)lat.aSize, (int)lat.aSize);
					}
				}
				if(gs.axes) {
					int w = bmp.Width;
					int h = bmp.Height;
					g.DrawLine(gs.axisPen, w / 2, 0, w / 2, h);
					g.DrawLine(gs.axisPen, 0, h / 2, w, h / 2);
				}
			}
			Invalidate();
		}
		public void ReRender() {
			using(var g = Graphics.FromImage(bmp)) {
				g.Clear(Color.Transparent);
				if(gs.axes) {
					int w = bmp.Width;
					int h = bmp.Height;
					g.DrawLine(gs.axisPen, w / 2, 0, w / 2, h);
					g.DrawLine(gs.axisPen, 0, h / 2, w, h / 2);
				}
				for(int i = 0; i<=ind; i++) {
					LatticeChange lc = lat.changes[i];
					SolidBrush br = gs.fgBrush;
					foreach(Atom a in lc.on) {
						g.FillRectangle(br,
							(float)(bmp.Width/2 + lat.aSize*(a.x - .5)),
							(float)(bmp.Height/2 - lat.aSize*(a.y + .5)),
							(int)lat.aSize, (int)lat.aSize);
					}
				}
			}
			Invalidate();
		}
		public void Restart() {
			ind = 0;
			lat = new Lattice();
			lat.aSize = 10 * gs.zoom;
		}

		private void Canvas_MouseEnter(object sender, EventArgs e) {
			this.Focus();
		}
		private void Canvas_MouseLeave(object sender, EventArgs e) {
			this.Parent.Focus();
		}
		private void Canvas_MouseWheel(object sender, MouseEventArgs e) {
			if(ctrlPressed) {
				form.zoom(e.Delta);
			}
		}
	}
	public class Lattice {
		public Atom[,] mat { get; set; }
		public double Xprobability { get; set; }
		public double Yprobability { get; set; }
		public double gamma { get; set; }
		public double aSize { get; set; }
		public int sz { get; set; }
		public List<LatticeChange> changes { get; set; }
		public AtomsLinkedList nextAtomsX { get; set; }
		public AtomsLinkedList nextAtomsY { get; set; }
		public AtomsLinkedList allExcited { get; set; }
		public Random rnd { get; set; }
		public System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

		public Lattice(){
            Xprobability = Yprobability = 1;
			gamma = 0;
            aSize = 10;
            sz = 100;
			mat = new Atom[sz, sz];
			changes = new List<LatticeChange>();
			nextAtomsX = new AtomsLinkedList();
			nextAtomsY = new AtomsLinkedList();
			allExcited = new AtomsLinkedList();
			rnd = new Random();
			
			for (int r = 0; r < sz; r++){
                for (int c = 0; c < sz; c++) {
                    mat[r, c] = new Atom(c - sz / 2, sz / 2 - r, 0);
				}
            }
			for (int r = 0; r < sz; r++) {
				for (int c = 0; c < sz; c++) {
					mat[r, c].SetLocale(
						c > 0 ? mat[r, c - 1] : null,
						c < sz - 1 ? mat[r, c + 1] : null,
						r > 0 ? mat[r - 1, c] : null,
						r < sz - 1 ? mat[r + 1, c] : null);
				}
			}
			LatticeChange lc = new LatticeChange();
			lc.AddOn(mat[sz/2, sz/2]);
			changes.Add(lc);
			mat[sz/2, sz/2].excited = true;
			nextAtomsX.Add(mat[sz/2, sz/2 + 1]);
			nextAtomsX.Add(mat[sz/2, sz/2 - 1]);
			nextAtomsY.Add(mat[sz/2 + 1, sz/2]);
			nextAtomsY.Add(mat[sz/2 - 1, sz/2]);
		}
		public void GenerateChanges(BackgroundWorker worker, int bound) {
			Boolean done = false;
			LatticeChange lc = new LatticeChange();
			HashSet<Atom> maybeNext = new HashSet<Atom>();
			HashSet<Atom> maybeRemoveXNext = new HashSet<Atom>();
			HashSet<Atom> maybeRemoveYNext = new HashSet<Atom>();
			int count = 0;
			foreach (AtomNode node in allExcited) {
				if (rnd.NextDouble() < gamma) {
					allExcited.Remove(node);
					node.atom.excited = false;
					lc.AddOff(node.atom);
					foreach(Atom a in node.atom.locale) {
						if (a!=null && a.node==null) //means that it is not excited and not next; will check neighbor's neighbors later
							maybeNext.Add(a);
					}
				}
			}
			foreach (AtomNode node in nextAtomsX) {
				if (rnd.NextDouble() < Xprobability && rnd.NextDouble() > gamma) {
					nextAtomsX.Remove(node);
					//no need to say node isnext is false since node is discarded and replaced	
					node.atom.excited = true;
					allExcited.Add(node.atom);
					lc.AddOn(node.atom);
					;
					bound = Math.Max(bound, Math.Abs(node.atom.x));
					for (int i = 1; i < 5; i++) {
						Atom neighbor = node.atom.locale[i];
						if (neighbor != null) {
							if (neighbor.IsXNext())
								maybeRemoveXNext.Add(neighbor);
							else if (neighbor.IsYNext())
								maybeRemoveYNext.Add(neighbor);
							else if (neighbor.IsValid())
								maybeNext.Add(neighbor);
						}
						else
							done = true;
					}
				}
			}
			foreach (AtomNode node in nextAtomsY) {
				if (rnd.NextDouble() < Yprobability && rnd.NextDouble() > gamma) {
					nextAtomsY.Remove(node);
					node.atom.excited = true;
					allExcited.Add(node.atom);
					lc.AddOn(node.atom);
					bound = Math.Max(bound, Math.Abs(node.atom.y));
					for (int i = 1; i < 5; i++) {
						Atom neighbor = node.atom.locale[i];
						if (neighbor != null) {
							if (neighbor.IsXNext())
								maybeRemoveXNext.Add(neighbor);
							else if (neighbor.IsYNext())
								maybeRemoveYNext.Add(neighbor);
							else if (neighbor.IsValid())
								maybeNext.Add(neighbor);
						}
						else
							done = true;
					}
				}
			}
			foreach (Atom a in maybeRemoveXNext) {
				if (!a.excited && !a.IsValid() && a.IsXNext())
					nextAtomsX.Remove(a.node);
			}
			foreach (Atom a in maybeRemoveYNext) {
				if (!a.excited && !a.IsValid() && a.IsYNext())
					nextAtomsY.Remove(a.node);
			}
			foreach (Atom a in maybeNext) {
				if (a.IsValid()) {
					if ((a.locale[1] != null && a.locale[1].excited) || (a.locale[2] != null && a.locale[2].excited)) {
						nextAtomsX.Add(a);
						a.node.isNextX = true;
					}
					else {
						nextAtomsY.Add(a);
						a.node.isNextY = true;
					}
				}
			}	
			changes.Add(lc);
			worker.ReportProgress(100*bound/(sz/2));
			if (!done && changes.Count<1000) GenerateChanges(worker, bound);
		}
		public void blaghcode() {
			/*
			foreach(Atom a in nextAtomsX.ToList()) {
				if (rnd.NextDouble() < Xprobability && rnd.NextDouble() > gamma) {
					a.excited=true;
					lc.AddOn(a);
					bound = Math.Max(bound, Math.Abs(a.x));
				}
			}
			foreach(Atom a in nextAtomsY.ToList()) {
				if(rnd.NextDouble() < Yprobability && rnd.NextDouble() > gamma) {
					a.excited=true;
					lc.AddOn(a);
					bound = Math.Max(bound, Math.Abs(a.y));
				}
			}
			for(int i = 0; i<gamma*allExcited.Count; i++) {
				int tempInd = (int)(rnd.NextDouble()*allExcited.Count);
				Atom a = allExcited[tempInd];
				allExcited.RemoveAt(tempInd);
				a.excited=false;
				lc.AddOff(a);
			}
			foreach (Atom a in lc.on) {
				allExcited.Add(a);
				foreach (Atom neighbor in GetXNeighbors(a)) {
					if (!neighbor.excited && NumExcitedNeighbors(neighbor)==1)
						nextAtomsX.Add(neighbor);
				}
				foreach (Atom neighbor in GetYNeighbors(a))
					if (!neighbor.excited && NumExcitedNeighbors(neighbor)==1)
						nextAtomsY.Add(neighbor);
				if (GetNeighbors(a).Count!=4)
					done = true;
			}
			for (int k=0; k<nextAtomsX.Count; k++) {
				if (nextAtomsX[k].excited || NumExcitedNeighbors(nextAtomsX[k])!=1) {
					nextAtomsX.RemoveAt(k);
					k--;
				}
			}
			for (int k=0; k<nextAtomsY.Count; k++) {
				if (nextAtomsY[k].excited || NumExcitedNeighbors(nextAtomsY[k])!=1) {
					nextAtomsY.RemoveAt(k);
					k--;
				}
			}
			*/
		}
	}
	public class AtomsLinkedList : IEnumerable, IEnumerator {
		AtomNode head, tail, current;
		public int count { get; set; }

		public AtomsLinkedList() {
			count = 0;
			head = tail = current = new AtomNode(null);
		}
		public void Add(Atom at) {
			if (at.node == null) {
				count++;
				AtomNode a = new AtomNode(at);
				at.node = a;
				a.prev = tail;
				tail.next = a;
				tail = a;
			}
		}
		public void Remove(AtomNode a) {
			if (a != null && !head.Equals(a)) {
				count--;
				a.atom.node = null;
				if (tail.Equals(a))
					tail = a.prev;
				if (a.prev != null)
					a.prev.next = a.next;
				if (a.next != null)
					a.next.prev = a.prev;
				if (current.Equals(a))
					current = a.prev;
				a.prev = null;
				a.next = null;
			}
		}

		public int GetCount() {
			AtomNode an = head;
			int c = 0;
			while (an.next != null) {
				c++;
				an = an.next;
			}
			return c;
		}

		public bool MoveNext() {
			bool valid = (current != null && current.next != null);
			if (valid)
				current = current.next;
			else
				current = head;
			return valid;
		}
		public void Reset() {
			current = head;
		}
		public object Current {
			get {
				return current;
			}
		}
		public IEnumerator GetEnumerator() {
			return (IEnumerator)this;
		}
	}
	public class LatticeChange
    {
        public List<Atom> on { get; set; }
        public List<Atom> off { get; set; }

        public LatticeChange()
        {
            on = new List<Atom>();
            off = new List<Atom>();
        }
        public void AddOn(Atom a)
        {
            on.Add(a);
        }
        public void AddOff(Atom a)
        {
            off.Add(a);
        }
    }
    public class Atom {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        public bool excited { get; set; }
        public AtomNode node { get; set; }
		public Atom[] locale { get; set; }

        public Atom(int x1, int y1, int z1) {
            x = x1;
            y = y1;
            z = z1;
            excited = false;
        }
		public void SetLocale(Atom left, Atom right, Atom top, Atom bottom) {
			locale = new Atom[5];
			locale[0] = this;
			if (left != null)
				locale[1] = left;
			if (right != null)
				locale[2] = right;
			if (top != null)
				locale[3] = top;
			if (bottom != null)
				locale[4] = bottom;
		}
		public bool IsXNext() {
			return node != null && node.isNextX;
		}
		public bool IsYNext() {
			return node != null && node.isNextY;
		}
		public bool IsValid() {
			int cnt = 0;
			foreach (Atom a in locale)
				if (a!=null && a.excited)
					cnt++;
			return cnt==1 && !excited;
		}
    }
    public class AtomNode {
        public AtomNode next { get; set; }
        public AtomNode prev { get; set; }
		public bool isNextX { get; set; }
		public bool isNextY { get; set; }
		public Atom atom { get; set; }

        public AtomNode(Atom a) {
            atom = a;
			isNextX = isNextY = false;
        }
    }
    public class GraphicsSettings
    {
        public SolidBrush bgBrush { get; set; }
        public SolidBrush fgBrush { get; set; }
        public Pen axisPen { get; set; }
        public bool axes { get; set; }
		public double zoom { get; set; }

        public GraphicsSettings()
        {
            bgBrush = new SolidBrush(Color.Black);
            fgBrush = new SolidBrush(Color.PaleTurquoise);
            axisPen = new Pen(Color.PaleTurquoise, 1);
            axes = false;
			zoom = 1;
        }
    }
}
