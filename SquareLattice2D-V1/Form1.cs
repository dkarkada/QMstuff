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

namespace SquareLattice2D_V1
{
    public partial class Form1 : Form
    {
        Canvas c;
        Bitmap image;
        Lattice lat;
        List<LatticeChange> latChanges;
        int step = 1;
        Random rnd = new Random();
        GraphicsSettings gs;
        System.Timers.Timer clock;

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        public Form1()
        {
            InitializeComponent();
            gs = new GraphicsSettings();
            Size = Screen.FromControl(this).WorkingArea.Size;
            image = new Bitmap(panel3.Width, panel3.Height);
            SetControls();

            lat = new Lattice();
            latChanges = new List<LatticeChange>();
            clock = new System.Timers.Timer(500);
            clock.AutoReset = true;
            clock.Elapsed += new System.Timers.ElapsedEventHandler(PlayStep);
            

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
            DoubleBuffered = true;
            PaintImage(true);
        }
        private void SetControls()
        {
            c = new Canvas(image);
            c.Dock = DockStyle.Fill;
            panel3.Controls.Add(c);

            BackColor = gs.bgBrush.Color;
            panel1.BackColor = Color.FromArgb(80, 80, 80);
            colorChooser.ForeColor = panel2.BackColor = label1.ForeColor = label2.ForeColor = stepLabel.ForeColor = Color.White;

            Resize += new EventHandler(Resized);
            System.EventHandler eh = new System.EventHandler(ColorChanged);
            blueRadioButton.CheckedChanged += eh;
            whiteRadioButton.CheckedChanged += eh;
            pinkRadioButton.CheckedChanged += eh;
        }
        private void Resized(object sender, EventArgs e)
        {
            Redraw();
        }
        private void PaintImage(Boolean fwd)
        {
            Graphics g = Graphics.FromImage(image);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (gs.axes)
            {
                g.DrawLine(gs.axisPen, c.Width / 2, 0, c.Width / 2, c.Height);
                g.DrawLine(gs.axisPen, 0, c.Height / 2, c.Width, c.Height / 2);
            }
            if (latChanges.Count > 0)
            {
                LatticeChange lc = latChanges[latChanges.Count - 1];
                int sz = lat.aSize;
                SolidBrush br = gs.fgBrush;
                if (!fwd)
                {
                    br = gs.bgBrush;
                    latChanges.Remove(lc);
                    foreach (Atom a in lc.on)
                    {
                        a.excited = false;
                    }
                }
                foreach (Atom a in lc.on)
                {
                    g.FillRectangle(br, GetCanvXPos(a.x) - sz / 2, GetCanvYPos(a.y) - sz / 2, sz, sz);
                }
            }
            c.Invalidate();
            Refresh();
        }
        private void Redraw()
        {
            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.Transparent);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (gs.axes)
            {
                g.DrawLine(gs.axisPen, c.Width / 2, 0, c.Width / 2, c.Height);
                g.DrawLine(gs.axisPen, 0, c.Height / 2, c.Width, c.Height / 2);
            }
            foreach (LatticeChange lc in latChanges)
            {
                int sz = lat.aSize;
                SolidBrush br = gs.fgBrush;
                foreach (Atom a in lc.on)
                {
                    g.FillRectangle(br, GetCanvXPos(a.x) - sz / 2, GetCanvYPos(a.y) - sz / 2, sz, sz);
                }
            }
            c.Invalidate();
            Refresh();
        }
        private void Step()
        {
            step++;
            LatticeChange lc = new LatticeChange();
            for (int r = 1; r < lat.mat.GetLength(0) - 1; r++)
            {
                for (int c = 1; c < lat.mat.GetLength(1) - 1; c++)
                {
                    Atom a = lat.mat[r, c];
                    if (!a.excited)
                    {
                        int numActiveNeighbors = 0;
                        if (lat.mat[r + 1, c].excited) numActiveNeighbors++;
                        if (lat.mat[r, c + 1].excited) numActiveNeighbors++;
                        if (lat.mat[r - 1, c].excited) numActiveNeighbors++;
                        if (lat.mat[r, c - 1].excited) numActiveNeighbors++;
                        if (numActiveNeighbors == 1 && rnd.NextDouble() < lat.probability)
                            lc.AddOn(a);
                    }
                }
            }
            stepLabel.Text = "" + step;
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
            stepLabel.Text = "" + step;
            PaintImage(false);
        }
        private int GetCanvXPos(int x)
        {
            return c.Width / 2 + lat.aSize * x;
        }
        private int GetCanvYPos(int y)
        {
            return c.ClientSize.Height / 2 - lat.aSize * y;
        }
        private void ColorChanged(object sender, EventArgs e)
        {
            Color c = Color.PaleTurquoise;
            if (whiteRadioButton.Checked) c = Color.Ivory;
            if (pinkRadioButton.Checked) c = Color.Pink;
            gs.fgBrush.Color = gs.axisPen.Color = c;
            Redraw();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            StepBack();
        }
        private void fwdButton_Click(object sender, EventArgs e)
        {
            Step();
        }
        private void playButton_Click(object sender, EventArgs e)
        {
            if (!clock.Enabled)
            {
                clock.Start();
                playButton.Text = "Pause";
                speedBar.Visible = label1.Visible = true;
            }
            else {
                clock.Stop();
                playButton.Text = "Play";
                speedBar.Visible = label1.Visible = false;
            }
        }
        private void xProbBar_Scroll(object sender, EventArgs e)
        {
            lat.probability = (double)(xProbBar.Value) / 100;
        }
        private void speedBar_Scroll(object sender, EventArgs e)
        {
            clock.Interval = 900 - (speedBar.Value * 8);
        }
        private void restartButton_Click(object sender, EventArgs e)
        {
            step = 1;
            clock.Stop();
            lat = new Lattice();
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
            stepLabel.Text = "1";
            Redraw();
        }

    }
    public class Canvas : Panel
    {
        Bitmap image;

        public Canvas(Bitmap b)
        {
            image = b;
            AutoSize = true;
            DoubleBuffered = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(image, 0, 0);
        }
    }
    public class Lattice
    {
        public Atom[,] mat { get; set; }
        public double probability { get; set; }
        public int aSize { get; set; }


        public Lattice()
        {
            probability = 1;
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
