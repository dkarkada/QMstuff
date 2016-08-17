using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows;
using System.Drawing;
using System.IO;

namespace Test1 {
	public partial class Form1 : Form {
		Bitmap bmp;
		Dictionary<DPoint, double> vals;
		Dictionary<DPoint, double> interpolVals;
		List<DPoint> emptyPts = new List<DPoint>();
		double dist = 100/64.0;

		public Form1() {
			InitializeComponent();
			DoubleBuffered = true;
			vals = new Dictionary<DPoint, double>();
			interpolVals = new Dictionary<DPoint, double>();
			emptyPts = new List<DPoint>();
			bmp = new Bitmap(Width, Height-100);
			String path = "C:\\Users\\dkarkada\\Documents\\data100-50.txt";
			StreamReader scan = new StreamReader(@path);
			string line;
			while ((line = scan.ReadLine()) != null) {
				char[] delimiters = { ' ', '\t' };
				String[] arr = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
				DPoint p = new DPoint(Double.Parse(arr[0]), Double.Parse(arr[1]));
				double avg=0;
				for(int i=2; i<arr.Length; i++) {
					int unit = Double.Parse(arr[i])>0 ? 1 : 0;
					avg += (double)unit / (arr.Length-2);
				}
				if(p.x <=100 && p.x>=0 && p.y<=100 && p.y>=0)
					vals.Add(p, avg);
			}
			for (double x = 0; x<=100; x+=dist) {
				double start = x%(2*dist)==0 ? 0 : dist;
				for (double y = start; y<=100; y+=2*dist) {
					DPoint t = new DPoint(x, y);
					if (!vals.ContainsKey(t))
						emptyPts.Add(t);
				}
			}
			Draw(false);
		}
		protected override void OnPaint(PaintEventArgs e) {
			Graphics g = e.Graphics;
			g.DrawImage(bmp, 0, 50);
		}
		private void Draw(bool drawinterpol) {
			using (Graphics g = Graphics.FromImage(bmp)) {
				g.Clear(Color.White);
				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
				SolidBrush br = new SolidBrush(Color.Blue);
				foreach (DPoint p in vals.Keys) {
					double val = vals[p];
					br.Color = Color.FromArgb(0, (int)(val*191), (int)(val*255));
					double d = (bmp.Width-100) / 64.0;
					PointF[] pts = {new PointF((float) convertX(p.x), (float) (convertY(p.y)+d)),
									new PointF((float) (convertX(p.x)+d), (float) convertY(p.y)),
									new PointF((float) convertX(p.x), (float) (convertY(p.y)-d)),
									new PointF((float) (convertX(p.x)-d), (float) convertY(p.y))};
					g.FillPolygon(br, pts);
				}
				if (drawinterpol) {
					foreach (DPoint p in interpolVals.Keys) {
						double val = interpolVals[p];
						br.Color = Color.FromArgb(0, (int)(val*191), (int)(val*255));
						double d = (bmp.Width-100) / 64.0;
						PointF[] pts = {new PointF((float) convertX(p.x), (float) (convertY(p.y)+d)),
									new PointF((float) (convertX(p.x)+d), (float) convertY(p.y)),
									new PointF((float) convertX(p.x), (float) (convertY(p.y)-d)),
									new PointF((float) (convertX(p.x)-d), (float) convertY(p.y))};
						g.FillPolygon(br, pts);
					}
				}
			}
			Invalidate();
		}
		private double convertX(double x) {
			int sz = bmp.Width;
			return (sz-100) * (x/100) + 50;
		}
		private double convertY(double y) {
			int sz = bmp.Height;
			return sz - ((sz-100) * (y/100) + 50);
		}
		private void next_Click(object sender, EventArgs e) {
			while (emptyPts.Count>0) {
				DPoint p = emptyPts[emptyPts.Count-1];
				List<Tuple<double, double>> neighborVals = new List<Tuple<double, double>>();
				double minDist = 1000;
				foreach(DPoint n in vals.Keys) {
					double d = Math.Sqrt(Math.Pow(n.x-p.x, 2) + Math.Pow(n.y-p.y, 2));
					if (d<minDist*Math.Sqrt(2))
						neighborVals.Add(new Tuple<double, double>(vals[n], d));
					if (d<minDist) {
						minDist = d;
						for (int i = 0; i<neighborVals.Count; i++) {
							Tuple<double, double> t = neighborVals[i];
							if (t.Item2 > minDist*Math.Sqrt(2)) {
								neighborVals.RemoveAt(i);
								i--;
							}
						}
					}
				}
				double sum = 0;
				double totalDist = 0;
				foreach (Tuple<double, double> t in neighborVals) {
					sum += t.Item1/Math.Pow(t.Item2/minDist, 2);
					totalDist += 1/Math.Pow(t.Item2/minDist, 2);
				}
				emptyPts.RemoveAt(emptyPts.Count-1);
				interpolVals.Add(p, sum/totalDist);
			}
			Draw(true);
		}

		private void backbutton_Click(object sender, EventArgs e) {
			Draw(false);
		}
	}
	public class DPoint {
		public double x;
		public double y;

		public DPoint(double a, double b) {
			x=a; y=b;
		}
		public override bool Equals(object obj) {
			return obj is DPoint && ((DPoint)obj).x==x && ((DPoint)obj).y==y;
		}
		public override int GetHashCode() {
			double hash = 13;
			hash += x;
			hash = 7*hash + y;
			return (int)(hash*100);
		}
	}
}
