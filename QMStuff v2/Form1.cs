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

namespace QMStuff_v2
{
	enum direction { N, E, S, W };

	public partial class Form1 : Form {
		Canvas c;
		Lattice lat;
		List<LatticeChange> latChanges;
		int step = 1;
		Random rnd = new Random();
		GraphicsSettings gs;
		System.Timers.Timer clock;

		public Form1() {
			InitializeComponent();
			gs = new GraphicsSettings();
			SetSizeAndControls();

			lat = new Lattice();
			latChanges = new List<LatticeChange>();
			clock = new System.Timers.Timer(500);
			clock.AutoReset = true;
			clock.Elapsed += new System.Timers.ElapsedEventHandler(PlayStep);


			foreach(Atom a in lat.mat) {
				if(a.x == 0 && a.y == 0) {
					LatticeChange lc = new LatticeChange();
					lc.AddOn(a);
					latChanges.Add(lc);
					a.excited = true;
				}
			}
			DoubleBuffered = true;
			PaintImage(true);
		}
		private void SetSizeAndControls() {
			Size = Screen.FromControl(this).WorkingArea.Size;

			splitPanel.SplitterDistance = ClientSize.Width - splitPanel.Panel2.Height - splitPanel.SplitterWidth;

			c = new Canvas(new Bitmap(splitPanel.Panel2.Width, splitPanel.Panel2.Height));
			c.Dock = DockStyle.Fill;
			splitPanel.Panel2.Controls.Add(c);

			splitPanel.Panel2.BackColor = gs.bgBrush.Color;
			splitPanel.Panel1.BackColor = Color.FromArgb(60, 60, 75);
			playSpeedLabel.ForeColor = xProbLabel.ForeColor = yProbLabel.ForeColor
				= Color.White;

			Resize += FrameResizing;
			splitPanel.SplitterMoved += SplitPanelResized;
		}
		private void FrameResizing(object sender, EventArgs e) {
			splitPanel.SplitterDistance = Math.Max(0, ClientSize.Width - splitPanel.Panel2.Height - splitPanel.SplitterWidth);
			c.image = new Bitmap(splitPanel.Panel2.Width, splitPanel.Panel2.Height);
			Redraw();
		}
		private void SplitPanelResized(object sender, SplitterEventArgs e) {
			c.image = new Bitmap(splitPanel.Panel2.Width, splitPanel.Panel2.Height);
			Redraw();
		}
		private void PaintImage(Boolean fwd) {
			Graphics g = Graphics.FromImage(c.image);
			g.SmoothingMode = SmoothingMode.AntiAlias;
			if(gs.axes) {
				int w = splitPanel.Panel2.Width;
				int h = splitPanel.Panel2.Height;
				g.DrawLine(gs.axisPen, w / 2, 0, w / 2, h);
				g.DrawLine(gs.axisPen, 0, h / 2, w, h / 2);
			}
			if(latChanges.Count > 0) {
				LatticeChange lc = latChanges[latChanges.Count - 1];
				int sz = lat.aSize;
				SolidBrush br = gs.fgBrush;
				if(!fwd) {
					br = gs.bgBrush;
					latChanges.Remove(lc);
					foreach(Atom a in lc.on) {
						a.excited = false;
					}
				}
				foreach(Atom a in lc.on) {
					g.FillRectangle(br, GetCanvXPos(a.x) - sz / 2, GetCanvYPos(a.y) - sz / 2, sz, sz);
				}
			}
			c.Invalidate();
		}
		private void Redraw() {
			Graphics g = Graphics.FromImage(c.image);
			g.Clear(Color.Transparent);
			g.SmoothingMode = SmoothingMode.AntiAlias;
			if(gs.axes) {
				int w = splitPanel.Panel2.Width;
				int h = splitPanel.Panel2.Height;
				g.DrawLine(gs.axisPen, w / 2, 0, w / 2, h);
				g.DrawLine(gs.axisPen, 0, h / 2, w, h / 2);
			}
			foreach(LatticeChange lc in latChanges) {
				int sz = lat.aSize;
				SolidBrush br = gs.fgBrush;
				foreach(Atom a in lc.on) {
					g.FillRectangle(br, GetCanvXPos(a.x) - sz / 2, GetCanvYPos(a.y) - sz / 2, sz, sz);
				}
			}
			c.Invalidate();
		}
		private void Step() {
			step++;
			LatticeChange lc = new LatticeChange();
			for(int r = 1; r < lat.mat.GetLength(0) - 1; r++) {
				for(int c = 1; c < lat.mat.GetLength(1) - 1; c++) {
					Atom a = lat.mat[r, c];
					if(!a.excited) {
						int numActiveNeighbors = 0;
						int dir = 0;
						if(lat.mat[r + 1, c].excited) {
							numActiveNeighbors++;
							dir = (int)direction.S;
						}
						if(lat.mat[r, c + 1].excited) {
							numActiveNeighbors++;
							dir = (int)direction.E;
						}
						if(lat.mat[r - 1, c].excited) {
							numActiveNeighbors++;
							dir = (int)direction.N;
						}
						if(lat.mat[r, c - 1].excited) {
							numActiveNeighbors++;
							dir = (int)direction.W;
						}
						if(numActiveNeighbors == 1) {
							if((dir == (int)direction.N || dir == (int)direction.S) && rnd.NextDouble() < lat.Yprobability)
								lc.AddOn(a);
							if((dir == (int)direction.E || dir == (int)direction.W) && rnd.NextDouble() < lat.Xprobability)
								lc.AddOn(a);
						}
					}
                }
            }
            stepCounter.Value = step;
            foreach (Atom a in lc.on)
                a.excited = true;
            latChanges.Add(lc);
            PaintImage(true);
        }
        private void PlayStep(object source, System.Timers.ElapsedEventArgs e)
        {
            BeginInvoke(new Action(Step), null);
        }
        private void StepBack()
        {
            if (step > 1) step--;
            stepCounter.Value = step;
            PaintImage(false);
        }
        private int GetCanvXPos(int x)
        {
            return splitPanel.Panel2.ClientSize.Width / 2 + lat.aSize * x;
        }
        private int GetCanvYPos(int y)
        {
            return splitPanel.Panel2.ClientSize.Height / 2 - lat.aSize * y;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            StepBack();
        }
        private void fwdButton_Click(object sender, EventArgs e) {
			Step();
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
        private void xProbBar_Scroll(object sender, EventArgs e) {
            lat.Xprobability = (double)(xProbBar.Value) / 100;
			xProbValue.Value = xProbBar.Value;
		}
		private void yProbBar_Scroll(object sender, EventArgs e) {
			lat.Yprobability = (double)(yProbBar.Value) / 100;
			yProbValue.Value = yProbBar.Value;
		}
		private void speedBar_Scroll(object sender, EventArgs e)
        {
            clock.Interval = 900 - (speedBar.Value * 8);
        }
        private void restartButton_Click(object sender, EventArgs e)
        {
            step = 1;
            clock.Stop();
			playButton.Text = "Play";
			speedBar.Visible = playSpeedLabel.Visible = false;
			lat = new Lattice();
			lat.Xprobability = (double)(xProbBar.Value) / 100;
			lat.Yprobability = (double)(yProbBar.Value) / 100;
			latChanges = new List<LatticeChange>();
            foreach (Atom a in lat.mat)
            {
                if (a.x == 0 && a.y == 0)
                {
                    LatticeChange lc = new LatticeChange();
                    lc.AddOn(a);
                    latChanges.Add(lc);
                    a.excited = true;
                }
            }
            stepCounter.Value = 1;
            Redraw();
        }
		private void xProbValue_ValueChanged(object sender, EventArgs e) {
			xProbBar.Value = (int) xProbValue.Value;
			lat.Xprobability = (double)(xProbBar.Value) / 100;
		}
		private void yProbValue_ValueChanged(object sender, EventArgs e) {
			yProbBar.Value = (int)yProbValue.Value;
			lat.Yprobability = (double)(yProbBar.Value) / 100;
		}
	}
	public class Canvas : Panel {
		public Bitmap image { get; set; }

		public Canvas(Bitmap b) {
			image = b;
			AutoSize = true;
			DoubleBuffered = true;
		}
		protected override void OnPaint(PaintEventArgs e) {
			Graphics g = e.Graphics;
			g.DrawImage(image, 0, 0);
		}
	}
	public class Lattice
    {
        public Atom[,] mat { get; set; }
        public double Xprobability { get; set; }
		public double Yprobability { get; set; }
		public int aSize { get; set; }


        public Lattice()
        {
            Xprobability = Yprobability = 1;
            aSize = 10;
            mat = new Atom[256, 256];
            int xsz = mat.GetLength(1);
            int ysz = mat.GetLength(0);
            for (int i = 0; i < xsz; i++)
            {
                for (int j = 0; j < ysz; j++)
                {
                    mat[j, i] = new Atom(i - xsz / 2, j - ysz / 2, 0);
                }
            }
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

        public GraphicsSettings()
        {
            bgBrush = new SolidBrush(Color.Black);
            fgBrush = new SolidBrush(Color.PaleTurquoise);
            axisPen = new Pen(Color.PaleTurquoise, 1);
            axes = true;
        }
    }
}
