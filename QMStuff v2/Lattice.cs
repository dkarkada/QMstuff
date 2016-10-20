using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMStuff_v2 {
	public class Lattice {
		public Atom[,] mat { get; set; }
		public LatticeFrameList latFrameList { get; set; }
		public double aSize { get; set; }
		public int sz { get; set; }
		public List<LatticeChange> changes { get; set; }
		AnalysisCalc analytics { get; set;}
		public List<Tuple<int, double[]>> data { get; set; }
		public SlidingDotData SlideData { get; set; }

		public Lattice(int s) {
			aSize = 10;
			sz = s;
			mat = new Atom[sz, sz];
			latFrameList = new LatticeFrameList();
			changes = new List<LatticeChange>();
			analytics = new AnalysisCalc();
			data = new List<Tuple<int, double[]>>();

			for (int r = 0; r < sz; r++) {
				for (int c = 0; c < sz; c++) {
					mat[r, c] = new Atom(c - sz / 2, sz / 2 - r, 0);
				}
			}
			for (int r = 0; r < sz; r++) {
				for (int c = 0; c < sz; c++) {
					mat[r, c].SetLocale(
						c > 0 ? mat[r, c - 1] : null,
						c < sz - 1 ? mat[r, c + 1] : null,
						r > 0 ? mat[r - 1, c] : null,
						r < sz - 1 ? mat[r + 1, c] : null);
				}
			}
		}
		public void GenerateChanges(BackgroundWorker worker, int maxstep, double Px, double Py, double gamma) {
			AtomsLinkedList nextAtomsX = new AtomsLinkedList();
			AtomsLinkedList nextAtomsY = new AtomsLinkedList();
			AtomsLinkedList allExcited = new AtomsLinkedList();

			List<Atom> seeds = new List<Atom>();
			LatticeChange init = new LatticeChange();
			int o = sz/2;
			int[] colVals = { o };
			int[] rowVals = { o };
			for (int i = 0; i<rowVals.Count(); i++) {
				int c = colVals[i];
				int r = rowVals[i];
				allExcited.Add(mat[r, c]);
				mat[r, c].excited = true;
				if (mat[r, c + 1].node == null) {
					nextAtomsX.Add(mat[r, c + 1]);
					mat[r, c + 1].node.isNextX = true;
				}
				if (mat[r, c - 1].node == null) {
					nextAtomsX.Add(mat[r, c - 1]);
					mat[r, c - 1].node.isNextX = true;
				}
				if (mat[r + 1, c].node == null) {
					nextAtomsY.Add(mat[r + 1, c]);
					mat[r + 1, c].node.isNextY = true;
				}
				if (mat[r - 1, c].node == null) {
					nextAtomsY.Add(mat[r - 1, c]);
					mat[r - 1, c].node.isNextY = true;
				}
				init.AddOn(mat[r, c]);
			}
			changes.Add(init);

			latFrameList.Add(mat, 0);
			Random rnd = new Random();
			Boolean done = false;
			int bound = 0;
			int totalExcited = 1;
			while (!done && changes.Count < maxstep) {
				LatticeChange lc = new LatticeChange();
				HashSet<Atom> maybeNext = new HashSet<Atom>();
				HashSet<Atom> maybeRemoveXNext = new HashSet<Atom>();
				HashSet<Atom> maybeRemoveYNext = new HashSet<Atom>();
				foreach (AtomNode node in allExcited) {
					if (rnd.NextDouble() < gamma) {
						allExcited.Remove(node);
						node.atom.excited = false;
						lc.AddOff(node.atom);
						foreach (Atom a in node.atom.locale) {
							if (a != null && a.node == null) //means that it is not excited and not next; will check neighbor's neighbors later
								maybeNext.Add(a);
							if (a != null && !a.Equals(node.atom)) {
								if (a.IsXNext())
									maybeRemoveXNext.Add(a);
								else if (a.IsYNext())
									maybeRemoveYNext.Add(a);
							}
						}
					}
				}
				foreach (AtomNode node in nextAtomsX) {
					if (rnd.NextDouble() < Px) {// && rnd.NextDouble() > gamma) {
						nextAtomsX.Remove(node);
						//no need to say node isnext is false since node is discarded and replaced	
						node.atom.excited = true;
						allExcited.Add(node.atom);
						lc.AddOn(node.atom);
						bound = Math.Max(bound, Math.Abs(node.atom.x));
						for (int i = 1; i < 5; i++) {
							Atom neighbor = node.atom.locale[i];
							if (neighbor != null) {
								if (neighbor.IsXNext())
									maybeRemoveXNext.Add(neighbor);
								else if (neighbor.IsYNext())
									maybeRemoveYNext.Add(neighbor);
								else if (neighbor.IsValid())
									maybeNext.Add(neighbor);
							}
							else
								done = true;
						}
					}
				}
				foreach (AtomNode node in nextAtomsY) {
					if (rnd.NextDouble() < Py) {// && rnd.NextDouble() > gamma) {
						nextAtomsY.Remove(node);
						node.atom.excited = true;
						allExcited.Add(node.atom);
						lc.AddOn(node.atom);
						bound = Math.Max(bound, Math.Abs(node.atom.y));
						for (int i = 1; i < 5; i++) {
							Atom neighbor = node.atom.locale[i];
							if (neighbor != null) {
								if (neighbor.IsXNext())
									maybeRemoveXNext.Add(neighbor);
								else if (neighbor.IsYNext())
									maybeRemoveYNext.Add(neighbor);
								else if (neighbor.IsValid())
									maybeNext.Add(neighbor);
							}
							else
								done = true;
						}
					}
				}
				foreach (Atom a in maybeRemoveXNext) {
					if (!a.excited && !a.IsValid() && a.IsXNext()) {
						nextAtomsX.Remove(a.node);
					}
				}
				foreach (Atom a in maybeRemoveYNext) {
					if (!a.excited && !a.IsValid() && a.IsYNext())
						nextAtomsY.Remove(a.node);
				}
				foreach (Atom a in maybeNext) {
					if (a.IsValid()) {
						if ((a.locale[1] != null && a.locale[1].excited) || (a.locale[2] != null && a.locale[2].excited)) {
							nextAtomsX.Add(a);
							a.node.isNextX = true;
						}
						else {
							nextAtomsY.Add(a);
							a.node.isNextY = true;
						}
					}
				}
				lc.bound = bound;
				totalExcited += lc.on.Count - lc.off.Count;
				lc.totalExcited = totalExcited;
				changes.Add(lc);
				if(changes.Count>1 && totalExcited == 0)
					done = true;
				if((changes.Count-1) % 50 == 0 || done || changes.Count == maxstep) {
					latFrameList.Add(mat, changes.Count-1);
					Console.WriteLine(latFrameList.inds);
				}
				if(worker!=null)
					worker.ReportProgress((int) (100 * Math.Pow((double)bound/(sz/2), 2)));
			}
		}
		public void GuaranteeGenChanges(BackgroundWorker worker, int maxstep, double Px, double Py, double gamma) {
			int count = 0;
			bool done = false;
			while(count<1000 && !done) {
				GenerateChanges(worker, maxstep, Px, Py, gamma);
				if(changes.Count > Math.Min(sz/2 - 2, 150))
					done=true;
				else {
					latFrameList = new LatticeFrameList();
					changes = new List<LatticeChange>();
					mat = new Atom[sz, sz];
					for(int r = 0; r < sz; r++) {
						for(int c = 0; c < sz; c++) {
							mat[r, c] = new Atom(c - sz / 2, sz / 2 - r, 0);
						}
					}
					for(int r = 0; r < sz; r++) {
						for(int c = 0; c < sz; c++) {
							mat[r, c].SetLocale(
								c > 0 ? mat[r, c - 1] : null,
								c < sz - 1 ? mat[r, c + 1] : null,
								r > 0 ? mat[r - 1, c] : null,
								r < sz - 1 ? mat[r + 1, c] : null);
						}
					}
				}
				count++;
			}
		}
		public void ClearChanges() {
			changes = new List<LatticeChange>();
		}
		public void StartSpatialAnalysis(int ind) {
			int offset = 50;
			bool[,] boxMat = new bool[sz + offset*2, sz + offset*2];
			Tuple<List<Atom>, int> result = latFrameList.GetNearestFrame(ind);
			foreach(Atom a in result.Item1) {
				int r = ConvertY(a.y);
				int c = ConvertX(a.x);
				boxMat[r + offset, c + offset] = true;
			}
			if(result.Item2 < ind) {
				for(int i = result.Item2; i < ind; i++) {
					LatticeChange lc = changes[i];
					foreach(Atom a in lc.on) {
						int r = ConvertY(a.y);
						int c = ConvertX(a.x);
						boxMat[r + offset, c + offset] = true;
					}
					foreach(Atom a in lc.off) {
						int r = ConvertY(a.y);
						int c = ConvertX(a.x);
						boxMat[r + offset, c + offset] = false;
					}
				}
			}
			else {
				for(int i = result.Item2; i >= ind; i--) {
					LatticeChange lc = changes[i];
					foreach(Atom a in lc.off) {
						int r = ConvertY(a.y);
						int c = ConvertX(a.x);
						boxMat[r + offset, c + offset] = true;
					}
					foreach(Atom a in lc.on) {
						int r = ConvertY(a.y);
						int c = ConvertX(a.x);
						boxMat[r + offset, c + offset] = false;
					}
				}
			}
			int bound = changes[ind-1].bound;
			int total = changes[ind-1].totalExcited;
			int[] boxSizes = { 1, 2, 3, 4, 5, 6, 8, 10, 20, 50 };
			data = new List<Tuple<int, double[]>>();
			foreach (int s in boxSizes)
				data.Add(new Tuple<int, double[]>(s, analytics.GetInfo(s, boxMat, bound, total)));
		}
		public void StartTemporalAnalysis(int period, int boxSz) {
			data = new List<Tuple<int, double[]>>();
			int ind = 1;
			while (ind<changes.Count) {
				int offset = boxSz;
				bool[,] boxMat = new bool[sz + offset*2, sz + offset*2];
				Tuple<List<Atom>, int> result = latFrameList.GetNearestFrame(ind);
				foreach (Atom a in result.Item1) {
					int r = ConvertY(a.y);
					int c = ConvertX(a.x);
					boxMat[r + offset, c + offset] = true;
				}
				if (result.Item2 < ind) {
					for (int i = result.Item2; i < ind; i++) {
						LatticeChange lc = changes[i];
						foreach (Atom a in lc.on) {
							int r = ConvertY(a.y);
							int c = ConvertX(a.x);
							boxMat[r + offset, c + offset] = true;
						}
						foreach (Atom a in lc.off) {
							int r = ConvertY(a.y);
							int c = ConvertX(a.x);
							boxMat[r + offset, c + offset] = false;
						}
					}
				}
				else {
					for (int i = result.Item2; i >= ind; i--) {
						LatticeChange lc = changes[i];
						foreach (Atom a in lc.off) {
							int r = ConvertY(a.y);
							int c = ConvertX(a.x);
							boxMat[r + offset, c + offset] = true;
						}
						foreach (Atom a in lc.on) {
							int r = ConvertY(a.y);
							int c = ConvertX(a.x);
							boxMat[r + offset, c + offset] = false;
						}
					}
				}
				int bound = changes[ind-1].bound;
				int total = changes[ind-1].totalExcited;
				data.Add(new Tuple<int, double[]>(ind, analytics.GetInfo(boxSz, boxMat, bound, total)));
				ind+=period;
			}
		}
		public void StartSlideDot(int ind) {
			Tuple<List<Atom>, int> result = latFrameList.GetNearestFrame(ind);
			List<Point> excited = new List<Point>();
			foreach(Atom a in result.Item1) {
				excited.Add(new Point(a.x, a.y));
			}
			if(result.Item2 < ind) {
				for(int i = result.Item2; i < ind; i++) {
					LatticeChange lc = changes[i];
					foreach(Atom a in lc.on)
						excited.Add(new Point(a.x, a.y));
					foreach(Atom a in lc.off) 
						excited.Remove(new Point(a.x, a.y));
				}
			}
			else {
				for(int i = result.Item2; i >= ind; i--) {
					LatticeChange lc = changes[i];
					foreach(Atom a in lc.off) 
						excited.Add(new Point(a.x, a.y));
					foreach(Atom a in lc.on) 
						excited.Remove(new Point(a.x, a.y));
				}
			}
			//excited is updated to index
			int maxX = int.MinValue; int minX = int.MaxValue; int maxY = int.MinValue; int minY = int.MaxValue;
			foreach(Point p in excited) {
				maxX = Math.Max(maxX, p.X);
				minX = Math.Min(minX, p.X);
				maxY = Math.Max(maxY, p.Y);
				minY = Math.Min(minY, p.Y);
			}
			int[,] state = new int[maxY-minY+1, maxX-minX+1];
			//for(int row = 0; row<state.GetLength(0); row++)  {
			//	for(int col = 0; col<state.GetLength(1); col++)
			//		state[row, col] = -1;
			//}
			foreach(Point p in excited) {
				int r = maxY - p.Y;
				int c = p.X - minX;
				state[r, c] = 1;
			}

			SlideData = analytics.SlideDot(state);
		}
		public int ConvertX(int x) { return x + sz/2; }
		public int ConvertY(int y) { return sz/2 - y; }
	}
	public class LatticeChange{
        public List<Atom> on { get; set; }
        public List<Atom> off { get; set; }
		public int bound;
		public int totalExcited;

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
	public class LatticeFrameList {
		public List<List<Atom>> latFrames { get; set; }
		public List<int> inds { get; set; }

		public LatticeFrameList() {
			latFrames = new List<List<Atom>>();
			inds = new List<int>();
		}
		public void Add(Atom[,] mat, int ind) {
			List<Atom> frame = new List<Atom>();
			foreach(Atom a in mat) {
				if (a.excited)
					frame.Add(a);
			}
			latFrames.Add(frame);
			inds.Add(ind);
		}
		public Tuple<List<Atom>,int> GetNearestFrame(int ind) {
			for(int i=0; i<inds.Count-1; i++) {
				int curInd = inds[i];
				int nextInd = inds[i + 1];
				if(curInd<=ind && ind<=nextInd) {
					if (nextInd - ind < ind - curInd)
						return Tuple.Create(latFrames[i+1], nextInd);
					else
						return Tuple.Create(latFrames[i], curInd);
				}
			}
			return Tuple.Create(latFrames[0], 0);
		}
	}
    public class Atom {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        public bool excited { get; set; }
        public AtomNode node { get; set; }
		public Atom[] locale { get; set; }

        public Atom(int x1, int y1, int z1) {
            x = x1;
            y = y1;
            z = z1;
            excited = false;
        }
		public void SetLocale(Atom left, Atom right, Atom top, Atom bottom) {
			locale = new Atom[5];
			locale[0] = this;
			if (left != null)
				locale[1] = left;
			if (right != null)
				locale[2] = right;
			if (top != null)
				locale[3] = top;
			if (bottom != null)
				locale[4] = bottom;
		}
		public bool IsXNext() {
			return node != null && node.isNextX;
		}
		public bool IsYNext() {
			return node != null && node.isNextY;
		}
		public bool IsValid() {
			int cnt = 0;
			foreach (Atom a in locale)
				if (a!=null && a.excited)
					cnt++;
			return cnt==1 && !excited;
		}
    }
    public class AtomNode {
        public AtomNode next { get; set; }
        public AtomNode prev { get; set; }
		public bool isNextX { get; set; }
		public bool isNextY { get; set; }
		public Atom atom { get; set; }

        public AtomNode(Atom a) {
            atom = a;
			isNextX = isNextY = false;
        }
	}
	public class AtomsLinkedList : IEnumerable, IEnumerator {
		AtomNode head, tail, current;
		public int count { get; set; }

		public AtomsLinkedList() {
			count = 0;
			head = tail = current = new AtomNode(null);
		}
		public void Add(Atom at) {
			if (at.node == null) {
				count++;
				AtomNode a = new AtomNode(at);
				at.node = a;
				a.prev = tail;
				tail.next = a;
				tail = a;
			}
		}
		public void Remove(AtomNode a) {
			if (a != null && !head.Equals(a)) {
				count--;
				a.atom.node = null;
				if (tail.Equals(a))
					tail = a.prev;
				if (a.prev != null)
					a.prev.next = a.next;
				if (a.next != null)
					a.next.prev = a.prev;
				if (current.Equals(a))
					current = a.prev;
				a.prev = null;
				a.next = null;
			}
		}

		public int GetCount() {
			AtomNode an = head;
			int c = 0;
			while (an.next != null) {
				c++;
				an = an.next;
			}
			return c;
		}

		public bool MoveNext() {
			bool valid = (current != null && current.next != null);
			if (valid)
				current = current.next;
			else
				current = head;
			return valid;
		}
		public void Reset() {
			current = head;
		}
		public object Current {
			get {
				return current;
			}
		}
		public IEnumerator GetEnumerator() {
			return (IEnumerator)this;
		}
	}
}
