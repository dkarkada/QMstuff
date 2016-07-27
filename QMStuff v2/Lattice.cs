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
		public double Xprobability { get; set; }
		public double Yprobability { get; set; }
		public double gamma { get; set; }
		public double aSize { get; set; }
		public int sz { get; set; }
		public List<LatticeChange> changes { get; set; }
		public AtomsLinkedList nextAtomsX { get; set; }
		public AtomsLinkedList nextAtomsY { get; set; }
		public AtomsLinkedList allExcited { get; set; }
		public Random rnd { get; set; }
		public AnalyticsInfo analytics { get; set; }

		public Lattice(int s) {
			Xprobability = Yprobability = 1;
			gamma = 0;
			aSize = 10;
			sz = s;
			mat = new Atom[sz, sz];
			latFrameList = new LatticeFrameList();
			changes = new List<LatticeChange>();
			nextAtomsX = new AtomsLinkedList();
			nextAtomsY = new AtomsLinkedList();
			allExcited = new AtomsLinkedList();
			rnd = new Random();

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
			LatticeChange lc = new LatticeChange();
			lc.AddOn(mat[sz / 2, sz / 2]);
			changes.Add(lc);
			mat[sz / 2, sz / 2].excited = true;
			mat[sz / 2, sz / 2].isSource = true;
			nextAtomsX.Add(mat[sz / 2, sz / 2 + 1]);
			mat[sz / 2, sz / 2 + 1].node.isNextX = true;
			nextAtomsX.Add(mat[sz / 2, sz / 2 - 1]);
			mat[sz / 2, sz / 2 - 1].node.isNextX = true;
			nextAtomsY.Add(mat[sz / 2 + 1, sz / 2]);
			mat[sz / 2 + 1, sz / 2].node.isNextY = true;
			nextAtomsY.Add(mat[sz / 2 - 1, sz / 2]);
			mat[sz / 2 - 1, sz / 2].node.isNextY = true;
			latFrameList.Add(mat, 0);
		}
		public void GenerateChanges(BackgroundWorker worker, int bound, int step) {
			Boolean done = false;
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
				if (rnd.NextDouble() < Xprobability && rnd.NextDouble() > gamma) {
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
				if (rnd.NextDouble() < Yprobability && rnd.NextDouble() > gamma) {
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
			changes.Add(lc);
			if (step % 50 == 0 || done || changes.Count==1000)
				latFrameList.Add(mat, step);
			worker.ReportProgress(100 * bound / (sz / 2));
			if (!done && changes.Count < 1000)
				GenerateChanges(worker, bound, ++step);
		}
		public void ClearChanges() {
			changes = new List<LatticeChange>();
		}
		public void StartAnalysis(int boxSz, int ind) {
			int[,] boxMat = new int[sz + 2 * boxSz, sz + 2 * boxSz];
			Tuple<List<Atom>, int> result = latFrameList.GetNearestFrame(ind);
			foreach(Atom a in result.Item1) {
				int r = ConvertY(a.y);
				int c = ConvertX(a.x);
				boxMat[r + boxSz, c + boxSz] = 1;
			}
			if(result.Item2 < ind) {
				for(int i = result.Item2; i < ind; i++) {
					LatticeChange lc = changes[i];
					foreach(Atom a in lc.on) {
						int r = ConvertY(a.y);
						int c = ConvertX(a.x);
						boxMat[r + boxSz, c + boxSz] = 1;
					}
					foreach(Atom a in lc.off) {
						int r = ConvertY(a.y);
						int c = ConvertX(a.x);
						boxMat[r + boxSz, c + boxSz] = 0;
					}
				}
			}
			else {
				for(int i = result.Item2; i >= ind; i--) {
					LatticeChange lc = changes[i];
					foreach(Atom a in lc.off) {
						int r = ConvertY(a.y);
						int c = ConvertX(a.x);
						boxMat[r + boxSz, c + boxSz] = 1;
					}
					foreach(Atom a in lc.on) {
						int r = ConvertY(a.y);
						int c = ConvertX(a.x);
						boxMat[r + boxSz, c + boxSz] = 0;
					}
				}
			}
			analytics = new AnalyticsInfo(boxSz, boxMat);
		}
		public int ConvertX(int x) { return x + sz / 2; }
		public int ConvertY(int y) { return sz / 2 - y; }
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
		public bool isSource { get; set; }
        public bool excited { get; set; }
        public AtomNode node { get; set; }
		public Atom[] locale { get; set; }

        public Atom(int x1, int y1, int z1) {
            x = x1;
            y = y1;
            z = z1;
            excited = false;
			isSource = false;
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
