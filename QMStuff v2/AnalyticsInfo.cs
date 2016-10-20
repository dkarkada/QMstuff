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
		public List<Point> vertices;
		public int bound;
		public int totalExcited;

		public double[] GetInfo(int size, bool[,] mat, int b, int t) {
			bound = b;
			totalExcited = t;
			latState = mat;
			box = new FitBox(size, latState);
			box.CalcVerts();
			vertices = box.vertices;
			double perim = CalcPerim();
			double area = CalcArea();
			double density = Math.Min(totalExcited / area, 1);
			double avgRad = ExpectedRadius();
			double[] info = { perim, area, density, avgRad };
			return info;
		}
		public SlidingDotData SlideDot(int[,] state) {
			SlidingDotData data = new SlidingDotData();
			int width = state.GetLength(1);
			int height = state.GetLength(0);
			int rshift = 0;
			while(rshift<=width) {
				int C = 0;
				for(int col = 0; col<width; col++) {
					if(col-rshift >=0 && col-rshift <width) {
						for(int row = 0; row<state.GetLength(0); row++)
							C+= state[row, col] * state[row, col-rshift];
					}
				}
				data.horizontal.Add(new Point(rshift, C));
				rshift++;
			}
			return data;
		}
		private double CalcPerim() {
			double sum = 0;
			for (int i = 0; i < box.vertices.Count; i++) {
				Point p1 = box.vertices[i];
				Point p2 = box.vertices[i + 1 == box.vertices.Count ? 0 : i + 1];
				sum += Distance(p1.X, p1.Y, p2.X, p2.Y);
			}
			return sum;
		}
		private double CalcArea() {
			int sum = 0;
			for (int i = 0; i < vertices.Count; i++) {
				Point p1 = vertices[i];
				Point p2 = vertices[i + 1 == vertices.Count ? 0 : i + 1];
				sum += Determinant(p1.X, p1.Y, p2.X, p2.Y);
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

		public SlidingDotData() {
			horizontal = new List<Point>();
			vertical = new List<Point>();
		}
	}
	public class FitBox {
		public int size, x, y, dir, edge;
		public bool[,] latState;
		public List<Point> vertices;
		Point start;

		public FitBox(int s, bool[,] mat) {
			size = s;
			latState = mat;
			dir = 3;
			edge = 2;
			vertices = new List<Point>();
			int r = 0;
			int c = 0;
			int mSz = latState.GetLength(0);
			while ((latState[r, c])==false) {
				c++;
				if (c >= mSz) {
					c = 0;
					r++;
				}
			}
			x = ConvertCol(c);
			y = ConvertRow(r) + this.size;
			start = new Point(x, y);
		}
		public void CalcVerts() {
			do {
				Next();
			} while (!(x == start.X && y == start.Y));
			
			for(int i=0; i<vertices.Count-1; i++) {
				while(i<vertices.Count-1 && vertices[i].Equals(vertices[i+1]))
					vertices.RemoveAt(i+1);
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

	}
}
