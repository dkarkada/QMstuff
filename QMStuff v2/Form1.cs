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
		System.Timers.Timer clock;

		public Form1() {
			InitializeComponent();
			SetSizeAndControls();

			clock = new System.Timers.Timer(500);
			clock.AutoReset = true;
			clock.Elapsed += new System.Timers.ElapsedEventHandler(PlayStep);

			DoubleBuffered = true;
			c.RenderNext();
		}
		private void SetSizeAndControls() {
			Size = Screen.FromControl(this).WorkingArea.Size;

			splitPanel.SplitterDistance = ClientSize.Width - splitPanel.Panel2.Height - splitPanel.SplitterWidth;

			c = new Canvas(	new Size(splitPanel.Panel2.Width, splitPanel.Panel2.Height));
			c.Dock = DockStyle.Fill;
			splitPanel.Panel2.Controls.Add(c);

			splitPanel.Panel2.BackColor = c.gs.bgBrush.Color;
			splitPanel.Panel1.BackColor = Color.FromArgb(60, 60, 75);
			playSpeedLabel.ForeColor = xProbLabel.ForeColor = yProbLabel.ForeColor
				= zoomLabel.ForeColor = Color.White;

			Resize += FrameResizing;
			splitPanel.SplitterMoved += SplitPanelResized;
		}
		private void FrameResizing(object sender, EventArgs e) {
			if(WindowState!=FormWindowState.Minimized)
				splitPanel.SplitterDistance = Math.Max(0, ClientSize.Width - splitPanel.Panel2.Height - splitPanel.SplitterWidth);
			c.sz = new Size(splitPanel.Panel2.Width, splitPanel.Panel2.Height);
			c.ReRender();
		}
		private void SplitPanelResized(object sender, SplitterEventArgs e) {
			c.sz = new Size(splitPanel.Panel2.Width, splitPanel.Panel2.Height);
			c.ReRender();
		}
		private void GenerateButton_Click(object sender, EventArgs e) {
			c.lat.GenerateChanges();
			playGroup.Enabled = true;
			probGroup.Enabled = false;
		}
		private void PlayStep(object source, System.Timers.ElapsedEventArgs e)
        {
            BeginInvoke(new Action(c.RenderNext), null);
			Action a = delegate () { stepCounter.Value++; };
			BeginInvoke(a);
		}
        private void backButton_Click(object sender, EventArgs e)
        {
            
        }
        private void fwdButton_Click(object sender, EventArgs e) {
			c.RenderNext();
			stepCounter.Value++;
		}
        private void playButton_Click(object sender, EventArgs e)
        {
            if (!clock.Enabled)
            {
                clock.Start();
                playButton.Text = "Pause";
                speedBar.Visible = playSpeedLabel.Visible = true;
            }
            else {
                clock.Stop();
                playButton.Text = "Play";
                speedBar.Visible = playSpeedLabel.Visible = false;
            }
        }
		private void resetZoomButton_Click(object sender, EventArgs e) {
			zoomBar.Value = 75;
			c.gs.zoom = 1;
			c.lat.aSize = 10;
			zoomLabel.Text = Math.Round(c.gs.zoom, 3) + "x";
			c.ReRender();
		}
		private void zoomOutButton_Click(object sender, EventArgs e) {
			if(zoomBar.Value >= 5) zoomBar.Value -= 5;
			else zoomBar.Value = 0;
			c.gs.zoom = Math.Pow(2, (zoomBar.Value - 75) / 25.0);
			zoomLabel.Text = Math.Round(c.gs.zoom, 3) + "x";
	//		c.lat.aSize = (int)(10 * c.gs.zoom);
			c.ReRender();
		}
		private void zoomInButton_Click(object sender, EventArgs e) {
			if(zoomBar.Value <= 95) zoomBar.Value += 5;
			else zoomBar.Value = 100;
			c.gs.zoom = Math.Pow(2, (zoomBar.Value - 75) / 25.0);
			zoomLabel.Text = Math.Round(c.gs.zoom, 3) + "x";
	//		c.lat.aSize = (int)(10 * c.gs.zoom);
			c.ReRender();
		}
		private void xProbBar_Scroll(object sender, EventArgs e) {
            c.lat.Xprobability = (double)(xProbBar.Value) / 100;
			xProbValue.Value = xProbBar.Value;
		}
		private void yProbBar_Scroll(object sender, EventArgs e) {
			c.lat.Yprobability = (double)(yProbBar.Value) / 100;
			yProbValue.Value = yProbBar.Value;
		}
		private void speedBar_Scroll(object sender, EventArgs e){
            clock.Interval = 900 - (speedBar.Value * 8);
		}
		private void zoomBar_Scroll(object sender, EventArgs e) {
			c.gs.zoom = Math.Pow(2, (zoomBar.Value-75)/25.0);
			zoomLabel.Text = Math.Round(c.gs.zoom, 3) + "x";
			c.lat.aSize = (int)(10 * c.gs.zoom);
			c.ReRender();
		}
		private void restartButton_Click(object sender, EventArgs e)
        {
            clock.Stop();
			playButton.Text = "Play";
			speedBar.Visible = playSpeedLabel.Visible = false;
			c.Restart();
			c.lat.Xprobability = (double)(xProbBar.Value) / 100;
			c.lat.Yprobability = (double)(yProbBar.Value) / 100;
            stepCounter.Value = 1;
            c.ReRender();

			probGroup.Enabled=true;
			playGroup.Enabled=false;
        }

		private void xProbValue_ValueChanged(object sender, EventArgs e) {
			xProbBar.Value = (int) xProbValue.Value;
			c.lat.Xprobability = (double)(xProbBar.Value) / 100;
		}
		private void yProbValue_ValueChanged(object sender, EventArgs e) {
			yProbBar.Value = (int)yProbValue.Value;
			c.lat.Yprobability = (double)(yProbBar.Value) / 100;
		}
	}
	public class Canvas : Panel {
		public Bitmap bmp { get; set; }
		public Lattice lat { get; set; }
		public Size sz { get; set; }
		public GraphicsSettings gs { get; set; }
		public int ind { get; set; }

		public Canvas(Size s) {
			lat = new Lattice();
			bmp = new Bitmap((int)(Math.Sqrt(lat.mat.Length)), (int)(Math.Sqrt(lat.mat.Length)));
			gs = new GraphicsSettings();
			sz = s;
			ind = 0;
			AutoSize = true;
			DoubleBuffered = true;
		}
		protected override void OnPaint(PaintEventArgs e) {
			Graphics g = e.Graphics;
			Rectangle r = new Rectangle(
				((int)(bmp.Width-this.Width/gs.zoom)/2),
				(int)((bmp.Height-this.Height/gs.zoom)/2),
				(int)(this.Width/gs.zoom),
				(int)(this.Height/gs.zoom));
			PixelFormat pf = bmp.PixelFormat;
			Console.WriteLine(r.Width + " " + bmp.Width);
			Bitmap asd = bmp.Clone(r, pf);
	//		Bitmap scaled = new Bitmap(
	//			bmp.Clone(r,pf),
	//			new Size(this.Width, this.Height));

			g.DrawImage(bmp, 0, 0);
//			scaled.Dispose();
		}
		public void RenderNext() {
			Graphics g = Graphics.FromImage(bmp);
			g.SmoothingMode = SmoothingMode.AntiAlias;
			if(gs.axes) {
				int w = bmp.Width;
				int h = bmp.Height;
				g.DrawLine(gs.axisPen, w / 2, 0, w / 2, h);
				g.DrawLine(gs.axisPen, 0, h / 2, w, h / 2);
			}
			if(ind < lat.changes.Count) {
				LatticeChange lc = lat.changes[ind];
				SolidBrush br = gs.fgBrush;
				foreach(Atom a in lc.on) {
					g.FillRectangle(br,
						(float) (bmp.Width/2 + lat.aSize*(a.x - .5)),
						(float) (bmp.Height/2 - lat.aSize*(a.y + .5)),
						lat.aSize, lat.aSize);
				}
				ind++;
			}
			Invalidate();
		}
		public void ReRender() {
			Graphics g = Graphics.FromImage(bmp);
			g.Clear(Color.Transparent);
			g.SmoothingMode = SmoothingMode.AntiAlias;
			if(gs.axes) {
				int w = bmp.Width;
				int h = bmp.Height;
				g.DrawLine(gs.axisPen, w / 2, 0, w / 2, h);
				g.DrawLine(gs.axisPen, 0, h / 2, w, h / 2);
			}
			for(int i=0; i<ind; i++) {
				LatticeChange lc = lat.changes[i];
				SolidBrush br = gs.fgBrush;
				foreach(Atom a in lc.on) {
					g.FillRectangle(br,
						(float)(bmp.Width/2 + lat.aSize*(a.x - .5)),
						(float)(bmp.Height/2 - lat.aSize*(a.y + .5)),
						lat.aSize, lat.aSize);
				}
			}
			Invalidate();
		}
		public void Restart() {
			ind = 0;
			lat = new Lattice();
	//		lat.aSize = (int)(10 * gs.zoom);
		}
	}
	public class Lattice {
		public Atom[,] mat { get; set; }
		public double Xprobability { get; set; }
		public double Yprobability { get; set; }
		public int aSize { get; set; }
		public int sz { get; set; }
		public List<LatticeChange> changes { get; set; }
		public List<Atom> nextAtomsX { get; set; }
		public List<Atom> nextAtomsY { get; set; }
		public Random rnd { get; set; }

		public Lattice(){
            Xprobability = Yprobability = 1;
            aSize = 15;
            sz = 800;
			mat = new Atom[sz, sz];
			changes = new List<LatticeChange>();
			nextAtomsX = new List<Atom>();
			nextAtomsY = new List<Atom>();
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
		public void GenerateChanges() {
			Boolean done = false;
			LatticeChange lc = new LatticeChange();
			foreach(Atom a in nextAtomsX.ToList()) {
				if (rnd.NextDouble() < Xprobability) {
					a.excited=true;
					lc.AddOn(a);
				}
			}
			foreach (Atom a in nextAtomsY.ToList()) {
				if (rnd.NextDouble() < Yprobability) {
					a.excited=true;
					lc.AddOn(a);
				}
			}
			foreach(Atom a in lc.on) {
				foreach (Atom neighbor in GetXNeighbors(a)) {
					if (!neighbor.excited && NumExcitedNeighbors(neighbor)==1) {
						nextAtomsX.Add(neighbor);
					}
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
			changes.Add(lc);
			if (!done) GenerateChanges();
		}
    }
    public class Atom
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        public Boolean excited { get; set; }

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
        public Boolean axes { get; set; }
		public double zoom { get; set; }

        public GraphicsSettings()
        {
            bgBrush = new SolidBrush(Color.Black);
            fgBrush = new SolidBrush(Color.PaleTurquoise);
            axisPen = new Pen(Color.PaleTurquoise, 1);
            axes = true;
			zoom = 1;
        }
    }
}
