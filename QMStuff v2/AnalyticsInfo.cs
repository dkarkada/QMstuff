using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMStuff_v2 {
	public class AnalyticsInfo {
		public FitBox box;
		public List<Point> vertices;
		public double area;
		public double perim;

		public AnalyticsInfo(int size, int[,] mat) {
			box = new FitBox(size, mat);
			box.CalcVerts();
			vertices = box.vertices;
			CalcArea();
			CalcPerim();
		}
		private void CalcArea() {
			int sum = 0;
			for (int i=0; i<vertices.Count; i++) {
				Point p1 = vertices[i];
				Point p2 = vertices[i+1==vertices.Count ? 0 : i+1];
				sum += Determinant(p1.X, p1.Y, p2.X, p2.Y);
			}
			area = sum/2.0;
		}
		private void CalcPerim() {
			double sum = 0;
			for(int i = 0; i<vertices.Count; i++) {
				Point p1 = vertices[i];
				Point p2 = vertices[i+1==vertices.Count ? 0 : i+1];
				sum += Distance(p1.X, p1.Y, p2.X, p2.Y);
			}
			perim = sum;
		}
		private int Determinant(int x1, int y1, int x2, int y2) {
			return x1 * y2 - x2 * y1;
		}
		private double Distance(int x1, int y1, int x2, int y2) {
			double a = Math.Pow(x1-x2, 2);
			double b = Math.Pow(y1-y2, 2);
			return Math.Sqrt(a + b);
		}
	}
	public class FitBox {
		public int size, x, y, dir, edge;
		public int[,] latState;
		public List<Point> vertices;
		Point start;

		public FitBox(int s, int[,] mat) {
			size = s;
			latState = mat;
			dir = 3;
			edge = 2;
			vertices = new List<Point>();
			int r = 0;
			int c = 0;
			int mSz = latState.GetLength(0);
			while ((latState[r, c])==0) {
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
				if (latState[indexVals.Item2, indexVals.Item1] == 1)
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
