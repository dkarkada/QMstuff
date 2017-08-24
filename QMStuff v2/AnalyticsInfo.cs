using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMStuff_v2 {
	public class AnalysisCalc {
		public FitBox box;
		bool[,] latState;
		public List<List<Point>> perims;
		public int bound;
		public int totalExcited;

		public double[] GetInfo(int size, bool[,] mat, int b, int t) {
			bound = b;
			totalExcited = t;
			latState = mat;
			box = new FitBox(size, latState);
			box.CalcVerts();
			perims = box.perimList;
			double perim = CalcPerim();
			double area = CalcArea();
			double density = Math.Min(totalExcited / area, 1);
			double avgRad = ExpectedRadius();
			double[] info = { perim, area, density, avgRad };
			return info;
		}
		public SlidingDotData SlideDot(SlidingDotData data, double[,] state, String type, Rectangle frame, int o) {
			List<Point> list;
			switch(type) {
				case "horizontal":
					list = data.horizontal;
					break;
				case "vertical":
					list = data.vertical;
					break;
				case "convolvedHoriz":
					list = data.convolvedHoriz;
					break;
				default:
					list = data.horizontal;
					break;
			}
			list.Clear();
			int rshift = 0;
			while(rshift<=o) {
				double C = 0;
				for(int col = frame.X; col<frame.Width + frame.X; col++) {
					for(int row = frame.Y; row<frame.Height + frame.Y; row++) {
						C+= state[row, col] * state[row, col+rshift];
					}
				}
				list.Add(new Point(rshift, (int)C));
				rshift++;
			}
			return data;
		}
		private double CalcPerim() {
			double sum = 0;
			foreach(List<Point> vertices in perims) {
				for(int i = 0; i < vertices.Count; i++) {
					Point p1 = vertices[i];
					Point p2 = vertices[i + 1 == vertices.Count ? 0 : i + 1];
					sum += Distance(p1.X, p1.Y, p2.X, p2.Y);
				}
			}
			return sum;
		}
		private double CalcArea() {
			int sum = 0;
			foreach(List<Point> vertices in perims) {
				for(int i = 0; i < vertices.Count; i++) {
					Point p1 = vertices[i];
					Point p2 = vertices[i + 1 == vertices.Count ? 0 : i + 1];
					sum += Determinant(p1.X, p1.Y, p2.X, p2.Y);
				}
			}
			return sum / 2.0;
		}
		private double ExpectedRadius() {
			List<double> radii = new List<double>();
			double avg = 0;
			int sz = latState.GetLength(0);
			for (int r = 0; r < sz; r++)
				for (int c = 0; c < sz; c++)
					if (latState[r, c]) {
						double dist = Math.Sqrt(
							Math.Pow(sz / 2 - r, 2) +
							Math.Pow(c - sz / 2, 2));
						radii.Add(dist);
						avg += dist;
					}
			avg /= (double)(radii.Count);
			return avg;
		}
		private int Determinant(int x1, int y1, int x2, int y2) {
			return x1 * y2 - x2 * y1;
		}
		private double Distance(int x1, int y1, int x2, int y2) {
			double a = Math.Pow(x1 - x2, 2);
			double b = Math.Pow(y1 - y2, 2);
			return Math.Sqrt(a + b);
		}
	}
	public class SlidingDotData {
		public List<Point> horizontal;
		public List<Point> vertical;
		public List<Point> convolvedHoriz;

		public SlidingDotData() {
			horizontal = new List<Point>();
			vertical = new List<Point>();
			convolvedHoriz = new List<Point>();
		}
	}
	public class FitBox {
		public int size, x, y, dir, edge;
		public bool[,] latState;
		private List<Point> vertices;
		public List<List<Point>> perimList;
		Point start;

		public FitBox(int s, bool[,] mat) {
			size = s;
			latState = mat;
			perimList = new List<List<Point>>();
			init();
		}
		private void init() {
			dir = 3;
			edge = 2;
			int r = 0;
			int c = 0;
			int mSz = latState.GetLength(0);
			while((latState[r, c])==false) {
				c++;
				if(c >= mSz) {
					c = 0;
					r++;
				}
			}
			x = ConvertCol(c);
			y = ConvertRow(r) + this.size;
			start = new Point(x, y);
		}
		public void CalcVerts() {
			bool done = false;
			int perimCount = 0;
			while(!done) {
				init();
				perimList.Add(new List<Point>());
				vertices = perimList[perimCount];
				do {
					Next();
				} while(!(x == start.X && y == start.Y));

				for(int i = 0; i<vertices.Count-1; i++) {
					while(i<vertices.Count-1 && vertices[i].Equals(vertices[i+1]))
						vertices.RemoveAt(i+1);
				}

				int unaccounted = 0;
				for(int r = 0; r<latState.GetLength(0); r++) {
					for(int c = 0; c<latState.GetLength(1); c++) {
						int x = ConvertCol(c);
						int y = ConvertRow(r);
						if(latState[r, c]) {
							if(withinPolygon(vertices, x, y))
								latState[r, c]=false;
							else {
								unaccounted++;
							}
						}
					}
				}
				done = (unaccounted==0);
				perimCount++;
			}
		}
		public void Next() {
			bool turnedConvex = false;
			if (traverseEdge(edge, dir) == null) {
				int temp = dir;
				dir = edge;
				edge = (temp + 2) % 4;
				turnedConvex = true;
			}
			else {
				while (traverseEdge(dir, edge) != null) {
					Tuple<int, int> t = traverseEdge(edge, dir);
					vertices.Add(new Point(ConvertCol(t.Item1), ConvertRow(t.Item2)));
					int temp = edge;
					edge = dir;
					dir = (temp + 2) % 4;
					t = traverseEdge(edge, (dir+2)%4);
					vertices.Add(new Point(ConvertCol(t.Item1), ConvertRow(t.Item2)));
				}
			}
			move();
			if (turnedConvex) {
				Tuple<int,int> t = GetIndexVals(edge, dir, 0);
				vertices.Add(new Point(ConvertCol(t.Item1), ConvertRow(t.Item2)));
			}
		}
		private Tuple<int,int> traverseEdge(int edgeNum, int dirNum) {
			for (int i = 0; i < size; i++) {
				Tuple<int, int> indexVals = GetIndexVals(edgeNum, dirNum, i);
				if (latState[indexVals.Item2, indexVals.Item1])
					return indexVals;
			}
			return null;
		}
		private void move() {
			switch (dir) {
				case 0:
					y += 1;
					break;
				case 1:
					x += 1;
					break;
				case 2:
					y -= 1;
					break;
				case 3:
					x -= 1;
					break;
			}
		}
		public Tuple<int, int> GetIndexVals(int edgeNum, int dirNum, int traverseInd) {
			int[] XOffsets = { 0, size, 0, -1 };
			int[] YOffsets = { -1, 0, size, 0 };
			int[] dampOffsets = { size - 1, size - 1, 0, 0 };
			int dampInd = edgeNum;
			if (dirNum == (edgeNum + 3) % 4)
				dampInd = (edgeNum + 2) % 4;
			if (dampOffsets[dampInd] == size - 1)
				traverseInd *= -1;
			int px = ConvertX(x) + (XOffsets[edgeNum] == 0 ? dampOffsets[dampInd] + traverseInd : XOffsets[edgeNum]);
			int py = ConvertY(y) + (YOffsets[edgeNum] == 0 ? dampOffsets[dampInd] + traverseInd : YOffsets[edgeNum]);
			return new Tuple<int,int>(px, py);
		}
		public int ConvertX(int x) { return x + latState.GetLength(0) / 2; }
		public int ConvertY(int y) { return latState.GetLength(0) / 2 - y; }
		public int ConvertRow(int r) { return latState.GetLength(0) / 2 - r; }
		public int ConvertCol(int c) { return c - latState.GetLength(0) / 2; }
		private bool withinPolygon(List<Point> polygon, int px, int py) {
			double error = 0.1;
			int max_point = polygon.Count - 1;
			if(px==polygon[max_point].X && py==polygon[max_point].Y) //if point is a vertex, on perim
				return true;
			float total_angle = GetAngle(
				polygon[max_point].X, polygon[max_point].Y,
				px, py,
				polygon[0].X, polygon[0].Y);
			if(Math.Abs(Math.Abs(total_angle) - Math.PI) < error) //if angle close to 180, on perim
				return true;
			for(int i = 0; i < max_point; i++) {
				if(px==polygon[i].X && py==polygon[i].Y)
					return true;
				float angle = GetAngle(
					polygon[i].X, polygon[i].Y,
					px, py,
					polygon[i + 1].X, polygon[i + 1].Y);
				if(Math.Abs(Math.Abs(angle) - Math.PI) < error)
					return true;
				total_angle += angle;
			}
			return (Math.Abs(total_angle) > error);
		}
		public static float GetAngle(float Ax, float Ay, float Bx, float By, float Cx, float Cy) {
			float dot_product = DotProduct(Ax, Ay, Bx, By, Cx, Cy);
			float cross_product = CrossProductLength(Ax, Ay, Bx, By, Cx, Cy);
			return (float)Math.Atan2(cross_product, dot_product);
		}
		private static float DotProduct(float Ax, float Ay,	float Bx, float By, float Cx, float Cy) {
			float BAx = Ax - Bx;
			float BAy = Ay - By;
			float BCx = Cx - Bx;
			float BCy = Cy - By;
			
			return (BAx * BCx + BAy * BCy);
		}
		public static float CrossProductLength(float Ax, float Ay, float Bx, float By, float Cx, float Cy) {
			float BAx = Ax - Bx;
			float BAy = Ay - By;
			float BCx = Cx - Bx;
			float BCy = Cy - By;
			
			return (BAx * BCy - BAy * BCx);
		}
	}
}
