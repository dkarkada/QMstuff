using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QMStuff_v2{
	public partial class Form1 : Form {
		Canvas c;
		ProgressForm pf;
		System.Timers.Timer clock;
		System.Diagnostics.Stopwatch stopwatch;

		public Form1() {
			InitializeComponent();
			SetSizeAndControls();

			clock = new System.Timers.Timer(100);
			clock.Elapsed += new System.Timers.ElapsedEventHandler(PlayStep);

			stopwatch = new System.Diagnostics.Stopwatch();

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

			FpsChooser.SelectedIndex = 0;
			ResChooser.SelectedIndex = 0;
			IndVarChooser.SelectedIndex = 0;
			TimePeriodChooser.SelectedIndex = 1;
			TightnessChooser.SelectedIndex = 3;
			DepVarChooser.SelectedIndex = 0;

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
		public void UpdateMousePos(double x, double y) {
			String xs = x.ToString("F0");
			String ys = y.ToString("F0");
			MouseLabel.Text = String.Format("({0}, {1})", xs, ys);
			MouseLabel.Invalidate();
		}

		private void GenerateButton_Click(object sender, EventArgs e) {
			c.lat = new Lattice((int)(LatSizeValue.Value));
			c.lat.aSize = 10 * c.gs.zoom;

			BackgroundWorker worker = new BackgroundWorker();
			worker.WorkerReportsProgress = true;
			worker.DoWork += Worker_DoWork;
			worker.ProgressChanged += Worker_ProgressChanged;
			worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
			pf = new ProgressForm();
			pf.Show();
			double[] args = { (double)(xProbBar.Value)/100, (double)(yProbBar.Value)/100, (double)(gammaBar.Value)/100 };
			worker.RunWorkerAsync(args);
		}
		private void Worker_DoWork(object sender, DoWorkEventArgs e) {
			BackgroundWorker worker = sender as BackgroundWorker;
			double[] args = (double[]) e.Argument;
			c.lat.GenerateChanges(worker, (int) stepCounter.Maximum,
				args[0], args[1], args[2]);
		}
		private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			pf.SetValue(e.ProgressPercentage);
		}
		private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			pf.Close();
			c.ReRender();
			playGroup.Enabled = true;
			ExportButton.Enabled = true;
			probGroup.Enabled = false;
			AnalyticsTab.Enabled = true;
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
				AnalyticsTab.Enabled = false;
            }
            else {
                clock.Stop();
                playButton.Text = "Play";
                speedBar.Visible = false;
				AnalyticsTab.Enabled = true;
            }
        }
		private void restartButton_Click(object sender, EventArgs e) {
			clock.Stop();
			playButton.Text = "Play";
			speedBar.Visible = false;
			c.ind = 0;
			stepCounter.Value = 1;
			c.ReRender();
			c.RenderNext();

			probGroup.Enabled=true;
            GenerateButton.Focus();
            playGroup.Enabled=false;
			ExportButton.Enabled = false;
			AnalyticsTab.Enabled = false;
		}
		private void ExportButton_Click(object sender, EventArgs e) {
			int res = 800;
			switch(ResChooser.SelectedIndex) {
				case 0:
					res = 800;
					break;
				case 1:
					res = 600;
					break;
				case 2:
					res = 400;
					break;
			}
			int fps = 24;
			switch(FpsChooser.SelectedIndex) {
				case 0:
					fps = 24;
					break;
				case 1:
					fps = 10;
					break;
				case 2:
					fps = 5;
					break;
				case 3:
					fps = 2;
					break;
			}
			c.ExportVideo(res, fps);
		}
		private void xProbBar_Scroll(object sender, EventArgs e) {
			xProbValue.Value = xProbBar.Value;
		}
		private void yProbBar_Scroll(object sender, EventArgs e) {
			yProbValue.Value = yProbBar.Value;
		}
		private void gammaBar_Scroll(object sender, EventArgs e) {
			gammaValue.Value = gammaBar.Value;
		}
		private void speedBar_Scroll(object sender, EventArgs e){
            clock.Interval = 140 - (speedBar.Value * 1);
		}
		private void xProbValue_ValueChanged(object sender, EventArgs e) {
			xProbBar.Value = (int) xProbValue.Value;
		}
		private void yProbValue_ValueChanged(object sender, EventArgs e) {
			yProbBar.Value = (int)yProbValue.Value;
		}
		private void gammaValue_ValueChanged(object sender, EventArgs e) {
			gammaBar.Value = (int)gammaValue.Value;
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

		private void AnalysisStartButton_Click(object sender, EventArgs e) {
			switch (IndVarChooser.SelectedIndex) {
				case 0:
					c.lat.StartSpatialAnalysis((int)(stepCounter.Value));
					Graph.ChartAreas[0].AxisX.Title = "Tightness";
					break;
				case 1:
					int[] periods = { 10, 20, 50, 100 };
					int[] boxSizes = { 1, 2, 3, 4, 5, 6, 8, 10, 20, 50 };
					c.lat.StartTemporalAnalysis(periods[TimePeriodChooser.SelectedIndex],
						boxSizes[TightnessChooser.SelectedIndex]);
					Graph.ChartAreas[0].AxisX.Title = "Time";
					break;
				case 2:
					c.lat.StartManyRunAnalysis();
					break;
			}
			if(IndVarChooser.SelectedIndex<2) {
				Graph.ChartAreas[0].AxisY.Title = (string)DepVarChooser.Items[DepVarChooser.SelectedIndex];
				int depVarInd = DepVarChooser.SelectedIndex;
				Graph.Series[0].Points.Clear();
				foreach(Tuple<int, double[]> info in c.lat.data) {
					DataPoint dp = new DataPoint(info.Item1, info.Item2[depVarInd]);
					Graph.Series[0].Points.Add(dp);
				}
			}
			else {
				Graph.ChartAreas[0].AxisX.Title = "P";
				Graph.ChartAreas[0].AxisY.Title = "Γ";
			}
			Graph.Invalidate();
		}
		private void IndVarChooser_SelectedIndexChanged(object sender, EventArgs e) {
			if (IndVarChooser.SelectedIndex == 1)
				TimePeriodChooser.Visible = SampPeriodLabel.Visible = TightnessChooser.Visible =
					TightnessLabel.Visible = true;
			else
				TimePeriodChooser.Visible = SampPeriodLabel.Visible = TightnessChooser.Visible =
					TightnessLabel.Visible = false;
			if(IndVarChooser.SelectedIndex == 2) {
				DepVarChooser.Items.Add("Success Rate");
				DepVarChooser.SelectedIndex = 4;
				DepVarChooser.Enabled = false;
			}
			else if(DepVarChooser.Items.Count == 5) {
				DepVarChooser.Items.RemoveAt(4);
				DepVarChooser.SelectedIndex = 0;
				DepVarChooser.Enabled = true;
			}
		}
		private void DepVarChooser_SelectedIndexChanged(object sender, EventArgs e) {
			int depVarInd = DepVarChooser.SelectedIndex;
			if (c.lat.data != null && depVarInd<2) {
				Graph.ChartAreas[0].AxisY.Title = (string)DepVarChooser.Items[DepVarChooser.SelectedIndex];
				Graph.Series[0].Points.Clear();
				foreach (Tuple<int, double[]> info in c.lat.data) {
					DataPoint dp = new DataPoint(info.Item1, info.Item2[depVarInd]);
					Graph.Series[0].Points.Add(dp);
				}
				Graph.Invalidate();
			}
		}
	}
	public class Canvas : Panel {
		private Form1 form;
		public Bitmap bmp { get; set; }
		public Lattice lat { get; set; }
		public GraphicsSettings gs { get; set; }
		public int ind { get; set; }
		public bool ctrlPressed { get; set; }
		ProgressForm exportPF;
		SaveFileDialog saver;

		public Canvas(Form1 f, Size s) {
			form = f;
			lat = new Lattice(400);
			bmp = new Bitmap(s.Width, s.Height);
			gs = new GraphicsSettings();
			ind = 0;
			AutoSize = true;
			DoubleBuffered = true;

			this.MouseWheel += Canvas_MouseWheel;
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
		public void RenderNext() {
			using(var g = Graphics.FromImage(bmp)) {
				if(ind < lat.changes.Count) {
					LatticeChange lc = lat.changes[ind];
					SolidBrush br = gs.fgBrush;
					foreach (Atom a in lc.on) {
						g.FillRectangle(br,
							(float)(bmp.Width / 2 + lat.aSize * (a.x - .5)),
							(float)(bmp.Height / 2 - lat.aSize * (a.y + .5)),
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
				SolidBrush br = gs.fgBrush;
				Tuple<List<Atom>, int> result = lat.latFrameList.GetNearestFrame(ind);
				foreach (Atom a in result.Item1) {
					g.FillRectangle(br,
						(float)(bmp.Width / 2 + lat.aSize * (a.x - .5)),
						(float)(bmp.Height / 2 - lat.aSize * (a.y + .5)),
						(int)lat.aSize, (int)lat.aSize);
				}
				if (result.Item2 < ind) {
					for (int i = result.Item2; i <= ind; i++) {
						LatticeChange lc = lat.changes[i];
						br = gs.fgBrush;
						foreach (Atom a in lc.on) {
							g.FillRectangle(br,
								(float)(bmp.Width / 2 + lat.aSize * (a.x - .5)),
								(float)(bmp.Height / 2 - lat.aSize * (a.y + .5)),
								(int)lat.aSize, (int)lat.aSize);
						}
						br = gs.bgBrush;
						foreach (Atom a in lc.off) {
							g.FillRectangle(br,
								(float)(bmp.Width / 2 + lat.aSize * (a.x - .5)),
								(float)(bmp.Height / 2 - lat.aSize * (a.y + .5)),
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
								(float)(bmp.Width / 2 + lat.aSize * (a.x - .5)),
								(float)(bmp.Height / 2 - lat.aSize * (a.y + .5)),
								(int)lat.aSize, (int)lat.aSize);
						}
						br = gs.bgBrush;
						foreach (Atom a in lc.on) {
							g.FillRectangle(br,
								(float)(bmp.Width / 2 + lat.aSize * (a.x - .5)),
								(float)(bmp.Height / 2 - lat.aSize * (a.y + .5)),
								(int)lat.aSize, (int)lat.aSize);
						}
					}
				}
			}
			Invalidate();
		}
		public void RenderPerim() {
			//Pen perimPen = new Pen(Color.Red, (float)lat.aSize / 2);
			//using (Graphics g = Graphics.FromImage(bmp)) {
			//	Point[] points = new Point[lat.analytics.vertices.Count];
			//	for (int i = 0; i < points.GetLength(0); i++) {
			//		Point p = lat.analytics.vertices[i];
			//		points[i] = new Point((int)(bmp.Width / 2 + lat.aSize * (p.X)),
			//				(int)(bmp.Height / 2 - lat.aSize * (p.Y)));
			//	}
			//	g.DrawPolygon(perimPen, points);
			//}
			//Invalidate();
		}
		public void Restart() {
			ind = 0;
			lat.ClearChanges();
		}

		public void ExportVideo(int bmpSz, int fps) {
			//Create save dialog
			saver = new SaveFileDialog();
			saver.Filter = "AVI video|*.avi";
			saver.Title = "Save Your Video";
			saver.ShowDialog();
			
			BackgroundWorker worker = new BackgroundWorker();
			worker.WorkerReportsProgress = true;
			worker.DoWork += Worker_DoWork;
			worker.ProgressChanged += Worker_ProgressChanged;
			worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
			exportPF = new ProgressForm();
			exportPF.Text = "Exporting Video...";
			exportPF.Show();
			worker.RunWorkerAsync(new Tuple<int,int>(bmpSz, fps));
			
		}
		private void Worker_DoWork(object sender, DoWorkEventArgs e) {
			BackgroundWorker worker = sender as BackgroundWorker;

			//INIT
			int bmpSz = ((Tuple<int, int>)(e.Argument)).Item1;
			int fps = ((Tuple<int, int>)(e.Argument)).Item2;
			String path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\RENDER-TEMP\\";
			Directory.CreateDirectory(path);
			var qualityEncoder = System.Drawing.Imaging.Encoder.Quality;
			long quality = 30;
			var ratio = new EncoderParameter(qualityEncoder, quality);
			var codecParams = new EncoderParameters(1);
			codecParams.Param[0] = ratio;
			var jpegCodecInfo = ImageCodecInfo.GetImageEncoders()[0];
			foreach(ImageCodecInfo ici in ImageCodecInfo.GetImageEncoders()) {
				if(ici.MimeType == "image/jpeg")
					jpegCodecInfo = ici;
			}
			Bitmap VBmp = new Bitmap(bmpSz, bmpSz);

			//Draw and save all frames
			using(var g = Graphics.FromImage(VBmp)) {
				if(gs.axes) {
					int w = VBmp.Width;
					int h = VBmp.Height;
					g.DrawLine(gs.axisPen, w / 2, 0, w / 2, h);
					g.DrawLine(gs.axisPen, 0, h / 2, w, h / 2);
				}

				SolidBrush br = gs.fgBrush;
				int cnt = 0;
				foreach(LatticeChange lc in lat.changes) {
					cnt++;
					br = gs.fgBrush;
					foreach(Atom a in lc.on) {
						g.FillRectangle(br,
							(float)(VBmp.Width / 2 + lat.aSize * (a.x - .5)),
							(float)(VBmp.Height / 2 - lat.aSize * (a.y + .5)),
							(int)lat.aSize, (int)lat.aSize);
					}
					br = gs.bgBrush;
					foreach(Atom a in lc.off) {
						g.FillRectangle(br,
							(float)(VBmp.Width/2 + lat.aSize*(a.x - .5)),
							(float)(VBmp.Height/2 - lat.aSize*(a.y + .5)),
							(int)lat.aSize, (int)lat.aSize);
					}
					worker.ReportProgress(100*cnt/(lat.changes.Count));
					VBmp.Save(path + cnt + ".jpg", jpegCodecInfo, codecParams);
				}
			}

			//Stitch videos from frames
			if(saver.FileName != "") {
				DotImaging.ImageStreamWriter vwriter = new DotImaging.VideoWriter(saver.FileName,
				new DotImaging.Primitives2D.Size(bmpSz, bmpSz), fps, true);
				DotImaging.ImageStreamReader ir =
					new DotImaging.ImageDirectoryCapture(path, "*.jpg");
				while(ir.Position < ir.Length) {
					DotImaging.IImage i = ir.Read();
					vwriter.Write(i);
					worker.ReportProgress((int)(95*ir.Position/(ir.Length)));
				}
				vwriter.Close();
			}

			//Delete frames
			Directory.Delete(path, true);
		}
		private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			exportPF.SetValue(e.ProgressPercentage);
		}
		private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			exportPF.Close();
		}
		
		private void Canvas_MouseClick(object sender, EventArgs e) {
			this.Focus();
		}
		private void Canvas_MouseWheel(object sender, MouseEventArgs e) {
			if(ctrlPressed) {
				form.zoom(e.Delta);
			}
		}
		private void Canvas_MouseMove(object sender, MouseEventArgs e) {
			double x = (e.X - bmp.Width/2) / lat.aSize;
			double y = (bmp.Height/2 - e.Y) / lat.aSize;
			form.UpdateMousePos(x, y);
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
