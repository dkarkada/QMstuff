using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QMStuff_v2{
	public partial class Form1 : Form {
		Canvas c;
		PGGraph pgGraph;
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
			pgGraph = new PGGraph(tabControl1.Width, (int)(tabControl1.Height * 3.0/5), this);
			pgGraph.Draw();
			tabControl1.TabPages[2].Controls.Add(pgGraph);
			Graph.Series[0].Points.AddXY(0,0);

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
		public void UpdatePGVals(PointF p) {
			PGProbValueLabel.Text = "P = " + p.X;
			PGSuccessValueLabel.Text = "% Success = " + p.Y;
			PGRatioValueLabel.Text = "P/Γ = " + p.X / ((float)PGGammaValue.Value/100);
		}
		private void StartManyRunAnalysis(BackgroundWorker worker) {
			String path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ resources\\";
			Directory.CreateDirectory(path);
			double margin = 0.4;
			double subdivs = 5;
			double dist = 50;
			int lsize = 50;
			int numRuns = 50;
			Dictionary<CPoint, CPoint> vals = new Dictionary<CPoint, CPoint>();
			HashSet<CPoint> currentPts = new HashSet<CPoint>();
			currentPts.Add(new CPoint(50, 50, f(50, 50, vals, lsize, numRuns)));
			for(int i=0; i<subdivs; i++) {
				double newdist = dist/2;
				double max = 0;
				HashSet<CPoint> addPts = new HashSet<CPoint>();
				HashSet<CPoint> removePts = new HashSet<CPoint>();
				foreach (CPoint p in currentPts) {
					p.segments[0] = p.y + dist <= 100 ? 
						(f(p.x, p.y + dist, vals, lsize, numRuns) - p.val) : 0;
					p.segments[1] = p.x + dist <= 100 ?
						(f(p.x + dist, p.y, vals, lsize, numRuns) - p.val) : 0;
					p.segments[2] = p.y - dist >= 0 ?
						(f(p.x, p.y - dist, vals, lsize, numRuns) - p.val) : 0;
					p.segments[3] = p.x - dist >= 0 ?
						(f(p.x - dist, p.y, vals, lsize, numRuns) - p.val) : 0;
					max = Math.Max(max,
						Math.Max(Math.Abs(p.segments[0]), 
						Math.Max(Math.Abs(p.segments[1]),
						Math.Max(Math.Abs(p.segments[2]), Math.Abs(p.segments[3])))));
				}
				if (max>0) {
					double cnt = 0;
					foreach (CPoint p in currentPts) {
						bool kill = true;
						for (int j = 0; j<4; j++) {
							if (Math.Abs(p.segments[j]) > margin*max) {
								kill=false;
								double val;
								switch (j) {
									case 0:
										val = f(p.x + newdist, p.y + newdist, vals, lsize, numRuns);
										addPts.Add(new CPoint(p.x + newdist, p.y + newdist, val));
										val = f(p.x - newdist, p.y + newdist, vals, lsize, numRuns);
										addPts.Add(new CPoint(p.x - newdist, p.y + newdist, val));
										val = p.segments[j] + p.val;
										addPts.Add(new CPoint(p.x, p.y + dist, val));
										break;
									case 2:
										val = f(p.x + newdist, p.y - newdist, vals, lsize, numRuns);
										addPts.Add(new CPoint(p.x + newdist, p.y - newdist, val));
										val = f(p.x - newdist, p.y - newdist, vals, lsize, numRuns);
										addPts.Add(new CPoint(p.x - newdist, p.y - newdist, val));
										val = p.segments[j] + p.val;
										addPts.Add(new CPoint(p.x, p.y - dist, val));
										break;
									case 1:
										val = f(p.x + newdist, p.y + newdist, vals, lsize, numRuns);
										addPts.Add(new CPoint(p.x + newdist, p.y + newdist, val));
										val = f(p.x + newdist, p.y - newdist, vals, lsize, numRuns);
										addPts.Add(new CPoint(p.x + newdist, p.y - newdist, val));
										val = p.segments[j] + p.val;
										addPts.Add(new CPoint(p.x + dist, p.y, val));
										break;
									case 3:
										val = f(p.x - newdist, p.y + newdist, vals, lsize, numRuns);
										addPts.Add(new CPoint(p.x - newdist, p.y + newdist, val));
										val = f(p.x - newdist, p.y - newdist, vals, lsize, numRuns);
										addPts.Add(new CPoint(p.x - newdist, p.y - newdist, val));
										val = p.segments[j] + p.val;
										addPts.Add(new CPoint(p.x - dist, p.y, val));
										break;
								}
							}
						}
						if (kill)
							removePts.Add(p);
						cnt++;
						worker.ReportProgress((int)(100 * (i/subdivs + (cnt/currentPts.Count)/subdivs)));
					}
				}
				foreach (CPoint p in addPts)
					currentPts.Add(p);
				foreach (CPoint p in removePts) {
					currentPts.Remove(p);
				}
				dist = newdist;
			}
			List<CPoint> emptyPts = new List<CPoint>();
			for(double x=0; x<=100; x+=dist) {
				double start = x%(2*dist)==0 ? 0 : dist;
				for(double y=start; y<=100; y+=2*dist) {
					CPoint t = new CPoint(x, y);
					if (!vals.ContainsKey(t))
						emptyPts.Add(t);
				}
			}
			for (int threshold = 4; threshold>0; threshold--) {
				for(int k=0; k<emptyPts.Count; k++) {
					int before = emptyPts.Count;
					FillSpace(emptyPts[k], threshold, emptyPts, vals, dist);
					k-= before - emptyPts.Count;
					if (k<0) k=0;
				}
			}
			foreach (CPoint p in vals.Values) {
				DataPoint dp = new DataPoint(p.x, p.y);
				double val = p.val;
				dp.MarkerColor = Color.FromArgb(0, (int)(val*191), (int)(val*255));
				Action ac = delegate { Graph.Series[1].Points.Add(dp); };
				BeginInvoke(ac);
			}
		}
		private double f(double prob, double gamma, Dictionary<CPoint, CPoint> vals, int lsize, int numRuns) {
			CPoint temp = new CPoint(prob, gamma);
			if (vals.ContainsKey(temp)){
				return vals[temp].val;
			}
			else {
				string writeStr = prob + "\t" + gamma + "\t\t";
				double sum = 0;
				for (int i = 0; i<numRuns; i++) {
					Lattice tLat = new Lattice(lsize);
					tLat.GenerateChanges(null, 250, prob/100, prob/100, gamma/100);
					int finalNum = tLat.changes[tLat.changes.Count-1].totalExcited;
					writeStr += finalNum + " ";
					double val = finalNum>0 ? 1 : 0;
					sum+=val;
				}
				double result = sum/numRuns;
				temp.val = result;
				vals.Add(temp, temp);
				String path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ resources\\data.txt";
				using (System.IO.StreamWriter file = new System.IO.StreamWriter(@path, true)) {
					file.WriteLine(writeStr);
				}
				return result;
			}
		}
		private List<double> GetAvgGrowth(double prob, double gamma, int lsize, int numRuns) {
			int maxTime = 500;
			int numTimeSamples = PGTimeSlider.Maximum + 1;
			int timeInterval = maxTime / PGTimeSlider.Maximum;
			double[,] mat = new double[numRuns, numTimeSamples];
			for (int i = 0; i<numRuns; i++) {
				Lattice tLat = new Lattice(lsize);
				tLat.GenerateChanges(null, 500, prob, prob, gamma);
				for(int j=0; j<numTimeSamples; j++) {
					int ind = j*timeInterval+1 < tLat.changes.Count ? j*timeInterval+1 : tLat.changes.Count-1;
					int numExcited = tLat.changes[ind].totalExcited;
					double val = numExcited>0 ? 1 : 0;
					mat[i, j] = val;
				}
			}
			List<double> result = new List<double>();
			for (int j = 0; j<numTimeSamples; j++) {
				double avg = 0;
				for (int i = 0; i<numRuns; i++) {
					avg += mat[i, j] / numRuns;
					if (j==numTimeSamples-1)
						;
				}
				result.Add(avg);
			}
			return result;
		}
		private void FillSpace(CPoint p, int threshold, List<CPoint> emptyPts, Dictionary<CPoint, CPoint> vals, double dist) {
			if (!vals.ContainsKey(p)) {
				List<CPoint> neighbors = new List<CPoint>(4);
				if (p.x - dist >= 0) {
					if (p.y - dist >= 0)
						neighbors.Add(new CPoint(p.x-dist, p.y-dist));
					if (p.y + dist <= 100)
						neighbors.Add(new CPoint(p.x-dist, p.y+dist));
				}
				if (p.x + dist <= 100) {
					if (p.y - dist >= 0)
						neighbors.Add(new CPoint(p.x+dist, p.y-dist));
					if (p.y + dist <= 100)
						neighbors.Add(new CPoint(p.x+dist, p.y+dist));
				}
				List<CPoint> on = new List<CPoint>(4);
				List<CPoint> off = new List<CPoint>(4);
				foreach (CPoint n in neighbors) {
					if (vals.ContainsKey(n))
						on.Add(vals[n]);
					else
						off.Add(n);
				}
				if (on.Count >= threshold) {
					double avg = 0;
					foreach (CPoint n in on)
						avg += n.val / on.Count;
					p.val = avg;
					vals.Add(p, p);
					emptyPts.Remove(p);
					if (threshold<3)
						foreach (CPoint n in off)
							FillSpace(n, threshold, emptyPts, vals, dist);
				}
			}
		}
		private void GraphToPlot() {
			Graph.Series[0].Enabled = false;
			Graph.Series[1].Enabled = true;
			Graph.ChartAreas[0].Axes[0].Maximum = 100;
			Graph.ChartAreas[0].Axes[1].Maximum = 100;
		}
		private void PlotToGraph() {
			Graph.Series[0].Enabled = true;
			Graph.Series[1].Enabled = false;
		}
		private void StartPGAnalysis(BackgroundWorker worker) {
			double gamma = (double)PGGammaValue.Value / 100;
			int lsize = (int)PGLatticeSizeValue.Value;
			int sampleNum = (int)PGSamplingValue.Value;
			int numRuns = (int)PGRunNumberValue.Value;
			double interval = (pgGraph.end-pgGraph.start)/sampleNum;
			for (double prob=pgGraph.start; prob<pgGraph.end + 0.0001; prob+= interval) {
				List<double> result = GetAvgGrowth(prob, gamma, lsize, numRuns);
				if (pgGraph.data.ContainsKey(prob))
					pgGraph.data.Remove(prob);
				pgGraph.data.Add(prob, result);
				worker.ReportProgress((int)(100 * (prob-pgGraph.start)/(pgGraph.end - pgGraph.start)));
			}
			pgGraph.sort();
			pgGraph.timeInd = PGTimeSlider.Maximum;
			pgGraph.Draw();
		}

		private void GenerateButton_Click(object sender, EventArgs e) {
			c.lat = new Lattice((int)(LatSizeValue.Value));
			c.lat.aSize = 10 * c.gs.zoom;

			BackgroundWorker worker = new BackgroundWorker();
			worker.WorkerReportsProgress = true;
			worker.DoWork += Worker_DoWork1;
			worker.ProgressChanged += Worker_ProgressChanged1;
			worker.RunWorkerCompleted += Worker_RunWorkerCompleted1;
			pf = new ProgressForm();
			pf.Show();
			double[] args = { (double)(xProbBar.Value)/100, (double)(yProbBar.Value)/100, (double)(gammaBar.Value)/100 };
			worker.RunWorkerAsync(args);
		}
		private void GenerateFullButton_Click(object sender, EventArgs e) {
			c.lat = new Lattice((int)(LatSizeValue.Value));
			c.lat.aSize = 10 * c.gs.zoom;

			BackgroundWorker worker = new BackgroundWorker();
			worker.WorkerReportsProgress = true;
			worker.DoWork += Worker_DoWork4;
			worker.ProgressChanged += Worker_ProgressChanged1;
			worker.RunWorkerCompleted += Worker_RunWorkerCompleted1;
			pf = new ProgressForm();
			pf.Show();
			double[] args = { (double)(xProbBar.Value)/100, (double)(yProbBar.Value)/100, (double)(gammaBar.Value)/100 };
			worker.RunWorkerAsync(args);
		}
		private void Worker_DoWork1(object sender, DoWorkEventArgs e) {
			BackgroundWorker worker = sender as BackgroundWorker;
			double[] args = (double[])e.Argument;
			c.lat.GenerateChanges(worker, (int)stepCounter.Maximum,
				args[0], args[1], args[2]);
		}
		private void Worker_DoWork4(object sender, DoWorkEventArgs e) {
			BackgroundWorker worker = sender as BackgroundWorker;
			double[] args = (double[])e.Argument;
			c.lat.GuaranteeGenChanges(worker, (int)stepCounter.Maximum,
				args[0], args[1], args[2]);
		}
		private void Worker_ProgressChanged1(object sender, ProgressChangedEventArgs e) {
			pf.SetValue(e.ProgressPercentage);
		}
		private void Worker_RunWorkerCompleted1(object sender, RunWorkerCompletedEventArgs e) {
			pf.Close();
			c.ReRender();
			playGroup.Enabled = true;
			ExportButton.Enabled = true;
			probGroup.Enabled = false;
			AnalyticsTab.Enabled = true;
		}
		private void Worker_DoWork2(object sender, DoWorkEventArgs e) {
			BackgroundWorker worker = sender as BackgroundWorker;
			StartManyRunAnalysis(worker);
		}
		private void Worker_RunWorkerCompleted2(object sender, RunWorkerCompletedEventArgs e) {
			pf.Close();
			Graph.Invalidate();
		}
		private void Worker_DoWork3(object sender, DoWorkEventArgs e) {
			BackgroundWorker worker = sender as BackgroundWorker;
			StartPGAnalysis(worker);
		}
		private void Worker_RunWorkerCompleted3(object sender, RunWorkerCompletedEventArgs e) {
			pf.Close();
			pgGraph.Draw();
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
					PlotToGraph();
					if (c.lat.changes.Count > 1)
						c.lat.StartSpatialAnalysis((int)(stepCounter.Value));
					Graph.ChartAreas[0].AxisX.Title = "Tightness";
					break;
				case 1:
					PlotToGraph();
					int[] periods = { 10, 20, 50, 100 };
					int[] boxSizes = { 1, 2, 3, 4, 5, 6, 8, 10, 20, 50 };
					if (c.lat.changes.Count > 1)
						c.lat.StartTemporalAnalysis(periods[TimePeriodChooser.SelectedIndex],
							boxSizes[TightnessChooser.SelectedIndex]);
					Graph.ChartAreas[0].AxisX.Title = "Time";
					break;
				case 2:
					GraphToPlot();
					Graph.Series[1].Points.Clear();
					Graph.ChartAreas[0].AxisX.Title = "P";
					Graph.ChartAreas[0].AxisY.Title = "Γ";
					BackgroundWorker worker = new BackgroundWorker();
					worker.WorkerReportsProgress = true;
					worker.DoWork += Worker_DoWork2;
					worker.ProgressChanged += Worker_ProgressChanged1;
					worker.RunWorkerCompleted += Worker_RunWorkerCompleted2;
					pf = new ProgressForm();
					pf.Show();
					worker.RunWorkerAsync();
					break;
			}
			if(IndVarChooser.SelectedIndex<2 && c.lat.changes.Count > 1) {
				Graph.ChartAreas[0].AxisY.Title = (string)DepVarChooser.Items[DepVarChooser.SelectedIndex];
				int depVarInd = DepVarChooser.SelectedIndex;
				Graph.Series[0].Points.Clear();
				foreach(Tuple<int, double[]> info in c.lat.data) {
					DataPoint dp = new DataPoint(info.Item1, info.Item2[depVarInd]);
					Graph.Series[0].Points.Add(dp);
				}
				Graph.ChartAreas[0].RecalculateAxesScale();
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
			if (c.lat.data != null && depVarInd<4) {
				Graph.ChartAreas[0].AxisY.Title = (string)DepVarChooser.Items[DepVarChooser.SelectedIndex];
				Graph.Series[0].Points.Clear();
				foreach (Tuple<int, double[]> info in c.lat.data) {
					DataPoint dp = new DataPoint(info.Item1, info.Item2[depVarInd]);
					Graph.Series[0].Points.Add(dp);
				}
				Graph.Invalidate();
			}
		}

		private void PGDomainResetButton_Click(object sender, EventArgs e) {
			pgGraph.ResetDomain();
		}
		private void PGAnalysisButton_Click(object sender, EventArgs e) {
			PGGammaValue.Enabled = false;
			BackgroundWorker worker = new BackgroundWorker();
			worker.WorkerReportsProgress = true;
			worker.DoWork += Worker_DoWork3;
			worker.ProgressChanged += Worker_ProgressChanged1;
			worker.RunWorkerCompleted += Worker_RunWorkerCompleted3;
			pf = new ProgressForm();
			pf.Show();
			worker.RunWorkerAsync();
		}
		private void PGDataResetButton_Click(object sender, EventArgs e) {
			PGGammaValue.Enabled = true;
			pgGraph.data.Clear();
			pgGraph.timeInd = 0;
			pgGraph.Draw();
		}
		private void PGTimeSlider_Scroll(object sender, EventArgs e) {
			pgGraph.timeInd = PGTimeSlider.Value;
			pgGraph.Draw();
		}

		private void SlidingDotStartButton_Click(object sender, EventArgs e) {
			if(c.lat.changes.Count > 1) {
				c.lat.StartSlideDot((int)(stepCounter.Value));
				CCGraph.ChartAreas[0].AxisX.Title = "r";
				CCGraph.ChartAreas[0].AxisY.Title = "C";
				CCGraph.Series[0].Points.Clear();
				CCGraph.Series[1].Points.Clear();
				foreach (Point p in c.lat.SlideData.horizontal) {
					DataPoint dp = new DataPoint(p.X, p.Y);
					CCGraph.Series[0].Points.Add(dp);
				}
				if(c.lat.convolveMat!=null) {
					c.lat.StartSlideDotConvolved();
					foreach(Point p in c.lat.SlideData.convolvedHoriz) {
						DataPoint dp = new DataPoint(p.X, p.Y);
						CCGraph.Series[1].Points.Add(dp);
					}
				}
				SDPDomainEndCounter.Value = CCGraph.Series[0].Points.Count;
				SDPDomainStartCounter.Value = 0;
				CCGraph.ChartAreas[0].RecalculateAxesScale();
				CCGraph.Invalidate();
			}
		}
		private void SDPDomainEndCounter_ValueChanged(object sender, EventArgs e) {
			if (SDPDomainEndCounter.Value < CCGraph.Series[0].Points.Count)
				CCGraph.ChartAreas[0].AxisX.Maximum = (double) SDPDomainEndCounter.Value;
			else
				SDPDomainEndCounter.Value = CCGraph.Series[0].Points.Count-1;
			if(SDPAutoRangeCheckbox.Checked) {
				double maxC = 0;
				for(int i = (int)CCGraph.ChartAreas[0].AxisX.Minimum; i <= (int)CCGraph.ChartAreas[0].AxisX.Maximum; i++)
					maxC = Math.Max(maxC, CCGraph.Series[0].Points[i].YValues[0]);
				int interval = (int)Math.Pow(10, Math.Floor(Math.Log10(maxC))); //greatest 10^n smaller than maxC
				int rangeMax = (int)Math.Ceiling(maxC/interval)*interval; //least multiple of interval greater than maxC
				CCGraph.ChartAreas[0].AxisY.Maximum = rangeMax;
			}			
		}
		private void SDPDomainStartCounter_ValueChanged(object sender, EventArgs e) {
			if(SDPDomainStartCounter.Value < SDPDomainEndCounter.Value)
				CCGraph.ChartAreas[0].AxisX.Minimum = (double)SDPDomainStartCounter.Value;
			else
				SDPDomainStartCounter.Value = SDPDomainEndCounter.Value-1;
			if(SDPAutoRangeCheckbox.Checked) {
				double maxC = 0;
				for(int i = (int)CCGraph.ChartAreas[0].AxisX.Minimum; i <= (int)CCGraph.ChartAreas[0].AxisX.Maximum; i++)
					maxC = Math.Max(maxC, CCGraph.Series[0].Points[i].YValues[0]);
				int interval = (int)Math.Pow(10, Math.Floor(Math.Log10(maxC))); //greatest 10^n smaller than maxC
				int rangeMax = (int)Math.Ceiling(maxC/interval)*interval; //least multiple of interval greater than maxC
				CCGraph.ChartAreas[0].AxisY.Maximum = rangeMax;
			}
		}
		private void SDPAutoRangeCheckbox_CheckedChanged(object sender, EventArgs e) {
			if(SDPAutoRangeCheckbox.Checked) {
				double maxC = 0;
				for(int i = (int)CCGraph.ChartAreas[0].AxisX.Minimum; i <= (int)CCGraph.ChartAreas[0].AxisX.Maximum; i++)
					maxC = Math.Max(maxC, CCGraph.Series[0].Points[i].YValues[0]);
				int interval = (int)Math.Pow(10, Math.Floor(Math.Log10(maxC))); //greatest 10^n smaller than maxC
				int rangeMax = (int)Math.Ceiling(maxC/interval)*interval; //least multiple of interval greater than maxC
				CCGraph.ChartAreas[0].AxisY.Maximum = rangeMax;
			}
			else
				CCGraph.ChartAreas[0].AxisY.Maximum = Double.NaN;
		}
		private void ConvolveButton_Click(object sender, EventArgs e) {
			if(c.lat.changes.Count>1 && StDevValue.Value!=0) {
				double stdev = StDevValue.Value / 20.0;
				c.lat.StartConvolve(stdev, (int)(stepCounter.Value));
				ShowConvolveCheckbox.Checked = true;
				c.RenderConvolve();
			}
		}
		private void StDevValue_Scroll(object sender, EventArgs e) {
			double stdev = StDevValue.Value / 20.0;
			StDevLabel.Text = "σ = " + Math.Round(stdev, 4);
		}
		private void ShowConvolveCheckbox_CheckedChanged(object sender, EventArgs e) {
			if(ShowConvolveCheckbox.Checked) {
				if(c.lat.convolveMat==null) ShowConvolveCheckbox.Checked = false;
				else c.RenderConvolve();
			}
			else c.ReRender();
		}
		private void ConvolveBrightnessBar_Scroll(object sender, EventArgs e) {
			if(c.lat.convolveMat!=null) {
				double exp = 10.0/ConvolveBrightnessBar.Value; //value from 10 to 50, exp from 1 to 0.2
				for(int r = 0; r<c.lat.sz; r++) {
					for(int col = 0; col<c.lat.sz; col++) {
						c.lat.convolveMatPP[r, col] = Math.Pow(c.lat.convolveMat[r, col], exp);
					}
				}
				c.RenderConvolve();
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
							(float)(bmp.Width/2 + lat.aSize * (a.x - .5)),
							(float)(bmp.Height/2 - lat.aSize * (a.y + .5)),
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
					g.DrawLine(gs.axisPen, w/2, 0, w/2, h);
					g.DrawLine(gs.axisPen, 0, h/2, w, h/2);
				}
			}
			Invalidate();
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
		public void RenderConvolve() {
			if(lat.changes.Count > 1) {
				using(var g = Graphics.FromImage(bmp)) {
					g.Clear(Color.Transparent);
					if(gs.axes) {
						int w = bmp.Width;
						int h = bmp.Height;
						g.DrawLine(gs.axisPen, w/2, 0, w/2, h);
						g.DrawLine(gs.axisPen, 0, h/2, w, h/2);
					}
					SolidBrush br;
					for(int r = 0; r<lat.sz; r++) {
						for(int c = 0; c<lat.sz; c++) {
							double v = lat.convolveMatPP[r, c];
							br = new SolidBrush(Color.FromArgb((int)(175*v), (int)(238*v), (int)(238*v)));
							int x = c - lat.sz/2;
							int y = lat.sz/2 - r;
							g.FillRectangle(br,
								(float)(bmp.Width/2 + lat.aSize * (x - .5)),
								(float)(bmp.Height/2 - lat.aSize * (y + .5)),
								(int)lat.aSize, (int)lat.aSize);
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
					g.DrawLine(gs.axisPen, w/2, 0, w/2, h);
					g.DrawLine(gs.axisPen, 0, h/2, w, h/2);
				}

				SolidBrush br = gs.fgBrush;
				int cnt = 0;
				foreach(LatticeChange lc in lat.changes) {
					cnt++;
					br = gs.fgBrush;
					foreach(Atom a in lc.on) {
						g.FillRectangle(br,
							(float)(VBmp.Width/2 + lat.aSize * (a.x - .5)),
							(float)(VBmp.Height/2 - lat.aSize * (a.y + .5)),
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
			double x = (e.X - bmp.Width/2)/lat.aSize;
			double y = (bmp.Height/2 - e.Y)/lat.aSize;
			form.UpdateMousePos(x, y);
		}
	}
	public class PGGraph : Panel {
		public Bitmap bmp { get; set; }
		public Bitmap bmpMouse { get; set; }
		public Dictionary<double, List<double>> data;
		public double start { get; set; }
		public double end { get; set; }
		public int timeInd;
		Form1 form;
		int MouseDownX;
		int h, w, Ox, Oy;

		public PGGraph(int width, int height, Form1 f) {
			form = f;
			h = height-100;
			w = width-200;
			Ox = 100;
			Oy = height-50;
			bmp = new Bitmap(width, height);
			bmpMouse = new Bitmap(width, height);
			this.Height = height;
			data = new Dictionary<double, List<double>>();
			start = 0;
			end = 1;
			timeInd = 0;
			Dock = DockStyle.Bottom;
			DoubleBuffered = true;
			MouseMove += PGGraph_MouseMove;
			MouseDown += PGGraph_MouseDown;
			MouseUp += PGGraph_MouseUp;
			Draw();
		}

		private void PGGraph_MouseUp(object sender, MouseEventArgs e) {
			int x1 = Math.Min(MouseDownX, e.X);
			int x2 = Math.Max(MouseDownX, e.X);
			double st = Math.Round(ConvertToDP(new PointF(x1, 0)).X, 4);
			double en = Math.Round(ConvertToDP(new PointF(x2, 0)).X, 4);
			if(en-st > .0002) {
				start = st;
				end = en;
			}
			Draw();
		}
		private void PGGraph_MouseDown(object sender, MouseEventArgs e) {
			MouseDownX = e.X;
		}
		private void PGGraph_MouseMove(object sender, MouseEventArgs e) {
			using (Graphics g = Graphics.FromImage(bmpMouse)) {
				if (e.X>Ox && e.X<Ox+w) {
					PointF data = ConvertToNearestDP(e.Location);
					form.UpdatePGVals(data);
					g.Clear(Color.Transparent);
					g.DrawLine(Pens.Red, e.X, Oy, e.X, Oy-h);
					if (e.Button == MouseButtons.Left) {
						SolidBrush br = new SolidBrush(Color.FromArgb(50, Color.CornflowerBlue));
						int rw = e.X - MouseDownX;
						int s = MouseDownX;
						if (rw<0) {
							rw*=-1;
							s = e.X;
						}
						g.FillRectangle(br, s, Oy-h, rw, h);
					}
				}
				else {
					g.Clear(Color.Transparent);
				}
			}
			Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e) {
			Graphics g = e.Graphics;
			g.DrawImage(bmp, 0, 0);
			g.DrawImage(bmpMouse, 0, 0);
		}
		public void Draw() {
			Pen axesPen = new Pen(Color.Black, 3);
			SolidBrush br = new SolidBrush(Color.Blue);
			SolidBrush textBr = new SolidBrush(Color.Black);
			Font textFont = new Font("Arial", 16);
			using (Graphics g = Graphics.FromImage(bmp)) {
				g.Clear(Color.White);
				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
				g.DrawLine(axesPen, Ox-8, Oy, Ox+w, Oy);
				g.DrawLine(axesPen, Ox, Oy+8, Ox, Oy-h);
				g.DrawString("P", textFont, textBr, Ox+w+30, Oy-10);
				g.DrawString("% Growth", textFont, textBr, Ox-50, Oy-h-40);
				g.DrawString(end+"", textFont, textBr, Ox+w-10, Oy+15);
				g.DrawLine(axesPen, Ox+w, Oy-8, Ox+w, Oy+8);
				g.DrawString(start+"", textFont, textBr, Ox-10, Oy+15);
				g.DrawString("100", textFont, textBr, Ox-60, Oy-h-10);
				g.DrawLine(axesPen, Ox-8, Oy-h, Ox+8, Oy-h);
				g.DrawString("0", textFont, textBr, Ox-35, Oy-10);
				List<PointF> dataptsList = new List<PointF>();
				foreach (double prob in data.Keys) {
					if (prob>=start && prob<=end) {
						PointF pf = ConvertToPix(new PointF((float)prob, (float)data[prob][timeInd]));
						g.FillEllipse(br, pf.X-4, pf.Y-4, 8, 8);
						dataptsList.Add(pf);
					}
				}
				if(dataptsList.Count>1)
					g.DrawLines(axesPen, dataptsList.ToArray());
			}
			Invalidate();
		}
		private PointF ConvertToPix(PointF dp) {
			float x = (float) ((dp.X-start)/(end-start) * w + Ox);
			float y = Oy - dp.Y * h;
			return new PointF(x, y);
		}
		private PointF ConvertToNearestDP(PointF pix) {
			if (data.Count==0)
				return new PointF(0, 0);
			double x = ((pix.X - Ox) / w)*(end-start) + start;
			double mindist = 1;
			double nearestProb = 0;
			foreach(double prob in data.Keys) {
				double dist = Math.Abs(prob-x);
				if (dist<mindist){
					mindist = dist;
					nearestProb = prob;
				}
			}
			return new PointF((float)nearestProb, (float)data[nearestProb][timeInd]);
		}
		private PointF ConvertToDP(PointF pix) {
			float x = (float)(((pix.X - Ox) / w)*(end-start) + start);
			float y = (Oy - pix.Y) / h;
			return new PointF(x, y);
		}
		public void sort() {
			List<double> l = data.Keys.ToList();
			l.Sort();
			Dictionary<double, List<double>> temp = new Dictionary<double, List<double>>();
			foreach(double d in l) {
				temp.Add(d, data[d]);
			}
			data = temp;
		}
		public void ResetDomain() {
			start = 0;
			end = 1;
			Draw();
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
	public class CPoint {
		public double[] segments;
		public double x { get; }
		public double y { get; }
		public double val;

		public CPoint(double xv, double yv, double v) {
			x=xv;
			y=yv;
			val = v;
			segments = new double[4];
		}
		public CPoint(double xv, double yv) {
			x = xv;
			y = yv;
			segments = new double[4];
		}
		public override bool Equals(object obj) {
			return obj is CPoint && ((CPoint)obj).x == x && ((CPoint)obj).y == y;
		}
		public override int GetHashCode() {
			double hash = 13;
			hash += x;
			hash = 7*hash + y;
			return (int) (hash*100);
		}
	}
}
