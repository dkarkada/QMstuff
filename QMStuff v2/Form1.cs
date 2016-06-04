using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

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
				zoomTitle.ForeColor = Color.White;

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
			Console.WriteLine(c.lat.stopwatch.ElapsedMilliseconds/1000);
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
					foreach(Atom a in lc.on) {
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
		public List<Atom> nextAtomsX { get; set; }
		public List<Atom> nextAtomsY { get; set; }
		public List<Atom> allExcited { get; set; }
		public Random rnd { get; set; }
		public System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

		public Lattice(){
            Xprobability = Yprobability = 1;
			gamma = 0;
            aSize = 10;
            sz = 400;
			mat = new Atom[sz, sz];
			changes = new List<LatticeChange>();
			nextAtomsX = new List<Atom>();
			nextAtomsY = new List<Atom>();
			allExcited = new List<Atom>();
			rnd = new Random();
			
			for (int r = 0; r < sz; r++)
            {
                for (int c = 0; c < sz; c++)
                {
                    mat[r, c] = new Atom(c - sz / 2, r - sz / 2, 0);
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
		public List<Atom> GetNeighbors(Atom a) {
			List<Atom> neighbors = new List<Atom>();
			neighbors.AddRange(GetXNeighbors(a));
			neighbors.AddRange(GetYNeighbors(a));
			return neighbors.ToList();
		}
		private List<Atom> GetXNeighbors(Atom a) {
			List<Atom> Xneighbors = new List<Atom>();
			int c = a.x + sz/2;
			int r = a.y + sz/2;
			if (c>0)
				Xneighbors.Add(mat[r, c-1]);
			if (c<sz-1)
				Xneighbors.Add(mat[r, c+1]);
			return Xneighbors;
		}
		private List<Atom> GetYNeighbors(Atom a) {
			List<Atom> Yneighbors = new List<Atom>();
			int c = a.x + sz/2;
			int r = a.y + sz/2;
			if (r>0)
				Yneighbors.Add(mat[r-1, c]);
			if (r<sz-1)
				Yneighbors.Add(mat[r+1, c]);
			return Yneighbors;

		}
		public int NumExcitedNeighbors(Atom a) {
			int count = 0;
			foreach (Atom at in GetNeighbors(a))
				if (at.excited)
					count++;
			return count;
		}
		public void GenerateChanges(BackgroundWorker worker, int bound) {
			Boolean done = false;
			LatticeChange lc = new LatticeChange();
			int cnt = 0;
			foreach(Atom a in nextAtomsX.ToList()) {
				if (rnd.NextDouble() < Xprobability) {
					stopwatch.Start();
					nextAtomsX.Remove(a);
					stopwatch.Stop();
					a.excited=true;
					lc.AddOn(a);
					bound = Math.Max(bound, Math.Abs(a.x));
					cnt++;
				}
			}
			foreach(Atom a in nextAtomsY.ToList()) {
				if(rnd.NextDouble() < Yprobability) {
					stopwatch.Start();
					nextAtomsY.Remove(a);
					stopwatch.Stop();
					a.excited=true;
					lc.AddOn(a);
					bound = Math.Max(bound, Math.Abs(a.y));
				}
			}
			stopwatch.Start();
			for(int i = 0; i<gamma*allExcited.Count; i++) {
				int tempInd = (int)(rnd.NextDouble()*allExcited.Count);
				Atom a = allExcited[tempInd];
				allExcited.RemoveAt(tempInd);
				a.excited=false;
				lc.AddOff(a);
			}
			stopwatch.Stop();
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
			stopwatch.Start();
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
			stopwatch.Stop();
			changes.Add(lc);
			worker.ReportProgress(100*bound/(sz/2));
			if (!done && changes.Count<1000) GenerateChanges(worker, bound);
		}
    }
    public class Atom
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        public bool excited { get; set; }

        public Atom(int x1, int y1, int z1)
        {
            x = x1;
            y = y1;
            z = z1;
            excited = false;
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
