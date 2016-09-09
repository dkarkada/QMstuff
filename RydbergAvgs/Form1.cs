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
			SetSizeAndControls();

			clock = new System.Timers.Timer(100);
			clock.Elapsed += new System.Timers.ElapsedEventHandler(PlayStep);

			stopwatch = new System.Diagnostics.Stopwatch();

			DoubleBuffered = true;
			c.ReRender();
		}
		private void SetSizeAndControls() {
			Size = Screen.FromControl(this).WorkingArea.Size;
			splitPanel.SplitterDistance = ClientSize.Width - splitPanel.Panel2.Height - splitPanel.SplitterWidth;

			c = new Canvas(this, new Size(splitPanel.Panel2.Width, splitPanel.Panel2.Height));
			c.Dock = DockStyle.Fill;
			splitPanel.Panel2.Controls.Add(c);
			splitPanel.Panel2.BackColor = c.gs.bgBrush.Color;

			Resize += FrameResizing;
			splitPanel.SplitterMoved += SplitPanelResized;
		}
		private void FrameResizing(object sender, EventArgs e) {
			if (WindowState!=FormWindowState.Minimized)
				splitPanel.SplitterDistance = Math.Max(0, ClientSize.Width - splitPanel.Panel2.Height - splitPanel.SplitterWidth);
			c.SetSize(new Size(splitPanel.Panel2.Width, splitPanel.Panel2.Height));
			c.ReRender();
		}
		private void SplitPanelResized(object sender, SplitterEventArgs e) {
			c.SetSize(new Size(splitPanel.Panel2.Width, splitPanel.Panel2.Height));
			c.ReRender();
		}

		private void GenerateButton_Click(object sender, EventArgs e) {
			c.lat = new Lattice((int)(LatSizeValue.Value), (int)stepCounter.Maximum);
			c.lat.aSize = 10 * c.gs.zoom;

			BackgroundWorker worker = new BackgroundWorker();
			worker.WorkerReportsProgress = true;
			worker.DoWork += Worker_DoWork1;
			worker.ProgressChanged += Worker_ProgressChanged1;
			worker.RunWorkerCompleted += Worker_RunWorkerCompleted1;
			pf = new QMStuff_v2.ProgressForm();
			pf.Show();
			double[] args = { (double)(ProbBar.Value)/100, (double)(gammaBar.Value)/100, (double)(thresholdValue.Value)/100 };
			worker.RunWorkerAsync(args);
		}
		private void Worker_DoWork1(object sender, DoWorkEventArgs e) {
			BackgroundWorker worker = sender as BackgroundWorker;
			double[] args = (double[])e.Argument;
			c.lat.GenerateChanges(worker, (int)stepCounter.Maximum,
				args[0], args[1], args[2]);
		}
		private void Worker_ProgressChanged1(object sender, ProgressChangedEventArgs e) {
			pf.SetValue(e.ProgressPercentage);
		}
		private void Worker_RunWorkerCompleted1(object sender, RunWorkerCompletedEventArgs e) {
			pf.Close();
			c.ReRender();
			playGroup.Enabled = true;
			probGroup.Enabled = false;
		}

		private void PlayStep(object source, System.Timers.ElapsedEventArgs e) {
			Action a = delegate () {
				stopwatch.Start();
				if (stepCounter.Value!= stepCounter.Maximum)
					stepCounter.Value++;
				else {
					clock.Stop();
					playButton.Text = "Play";
					speedBar.Visible = false;
				}
				stopwatch.Stop();
			};
			Action updateSpeedBar = delegate () {
				speedBar.Value = Math.Max(0, (int)(140 - clock.Interval));
			};

			BeginInvoke(a);
			if (stopwatch.ElapsedMilliseconds + 10 > clock.Interval) {
				clock.Interval += 15;
				BeginInvoke(updateSpeedBar);
			}
			stopwatch.Reset();
		}
		private void skipToBeginningButton_Click(object sender, EventArgs e) {
			stepCounter.Value = 1;
		}
		private void backButton_Click(object sender, EventArgs e) {
			stepCounter.Value = Math.Max(1, stepCounter.Value-1);
		}
		private void fwdButton_Click(object sender, EventArgs e) {
			if (stepCounter.Value!= stepCounter.Maximum)
				stepCounter.Value++;
		}
		private void skipToEndButton_Click(object sender, EventArgs e) {
			stepCounter.Value = c.lat.mats.GetLength(0);
		}
		private void playButton_Click(object sender, EventArgs e) {
			if (!clock.Enabled) {
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
			c.ind = 0;
			stepCounter.Value = 1;
			c.ReRender();

			probGroup.Enabled=true;
			GenerateButton.Focus();
			playGroup.Enabled=false;
		}
		private void ProbBar_Scroll(object sender, EventArgs e) {
			ProbValue.Value = ProbBar.Value;
		}
		private void gammaBar_Scroll(object sender, EventArgs e) {
			gammaValue.Value = gammaBar.Value;
		}
		private void speedBar_Scroll(object sender, EventArgs e) {
			clock.Interval = 140 - (speedBar.Value * 1);
		}
		private void ProbValue_ValueChanged(object sender, EventArgs e) {
			ProbBar.Value = (int)ProbValue.Value;
		}
		private void gammaValue_ValueChanged(object sender, EventArgs e) {
			gammaBar.Value = (int)gammaValue.Value;
		}
		private void stepCounter_ValueChanged(object sender, EventArgs e) {
			int oldInd = c.ind;
			stepCounter.Value = Math.Min(
				(int)stepCounter.Value,
				c.lat.mats.GetLength(0));
			c.ind = (int)stepCounter.Value - 1;
			int diff = c.ind - oldInd;
			if (diff == 1)
				c.ind++;
			else if (diff == -1)
				c.ind--;
			else if (diff == 0) {
				clock.Stop();
				playButton.Text = "Play";
				speedBar.Visible = false;
			}
			c.ReRender();
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
		private Form form;
		public Bitmap bmp { get; set; }
		public Lattice lat { get; set; }
		public QMStuff_v2.GraphicsSettings gs { get; set; }
		public int ind { get; set; }

		public Canvas(Form f, Size s) {
			form = f;
			lat = new Lattice(200, 1000);
			bmp = new Bitmap(s.Width, s.Height);
			gs = new QMStuff_v2.GraphicsSettings();
			ind = 0;
			AutoSize = true;
			DoubleBuffered = true;
		}

		public void SetSize(Size s) {
			bmp = new Bitmap(s.Width, s.Height);
		}
		protected override void OnPaint(PaintEventArgs e) {
			Graphics g = e.Graphics;
			g.DrawImage(bmp, 0, 0);
		}
		public void ReRender() {
			using (var g = Graphics.FromImage(bmp)) {
				Color col = Color.FromArgb(220, 240, 255);
				SolidBrush br;
				for(int r=1; r<lat.mats.GetLength(1); r++) {
					for(int c=1; c<lat.mats.GetLength(1); c++) {
						double a = lat.mats[ind, r, c];
						br = new SolidBrush(Color.FromArgb((int)(a*220), (int)(a*240), (int)(a*255)));
						g.FillRectangle(br,
							(float)(bmp.Width/2 + lat.aSize * (c-1)),
							(float)(bmp.Height/2 - lat.aSize * (r-1)),
							(int)lat.aSize, (int)lat.aSize);
						g.FillRectangle(br,
							(float)(bmp.Width/2 - lat.aSize * (c-1)),
							(float)(bmp.Height/2 - lat.aSize * (r-1)),
							(int)lat.aSize, (int)lat.aSize);
						g.FillRectangle(br,
							(float)(bmp.Width/2 + lat.aSize * (c-1)),
							(float)(bmp.Height/2 + lat.aSize * (r-1)),
							(int)lat.aSize, (int)lat.aSize);
						g.FillRectangle(br,
							(float)(bmp.Width/2 - lat.aSize * (c-1)),
							(float)(bmp.Height/2 + lat.aSize * (r-1)),
							(int)lat.aSize, (int)lat.aSize);
					}
				}
			}
			Invalidate();
		}
		public void Restart() {
			ind = 0;
		}		
	}
	public class Lattice {
		public double[,,] mats { get; set; }
		public double aSize { get; set; }
		public int sz { get; set; }

		public Lattice(int s, int maxtime) {
			aSize = 10;
			sz = s;
			mats = new double[maxtime, sz, sz];
		}
		public void GenerateChanges(BackgroundWorker worker, int maxtime, double P, double gamma, double threshold) {
			bool done = false;
			mats[0, 1, 1] = 1;
			int time = 2;
			int sz = mats.GetLength(1);
			while (time<maxtime && !done) {
				int ind = time-1;
				for(int r=1; r<sz; r++) {
					for (int c=1; c<sz; c++) {
						double n1 = r+1<sz-1 ? 1-mats[ind-1, r+1, c] : 1;
						double n2 = c+1<sz-1 ? 1-mats[ind-1, r, c+1] : 1;
						double n3 = 1-mats[ind-1, r-1, c];
						double n4 = 1-mats[ind-1, r, c-1];
						double N = (1-n1)*n2*n3*n4 + (1-n2)*n1*n3*n4 + (1-n3)*n2*n1*n4 + (1-n4)*n2*n3*n1;
						double a = mats[ind-1, r, c];
						mats[ind, r, c] = a - a*gamma +(1-a)*P*N;
					}
				}
				for (int r = 1; r<sz; r++)
					mats[ind, r, 0] = mats[ind, r, 2];
				for (int c = 1; c<sz; c++)
					mats[ind, 0, c] = mats[ind, 2, c];
				if (time==200) {
					for (int r = 0; r<15; r++) {
						for (int c = 0; c<15; c++) {
							Console.Write(Math.Round(mats[ind, r, c], 10) + " ");
						}
						Console.WriteLine();
					}
				}
				worker.ReportProgress((int)(100.0 * time/maxtime));
				time++;
			}
			Console.WriteLine();
		}
		public int ConvertX(int x) { return x + sz/2; }
		public int ConvertY(int y) { return sz/2 - y; }
	}
}
