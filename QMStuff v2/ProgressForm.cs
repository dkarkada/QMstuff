using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QMStuff_v2 {
	public partial class ProgressForm : Form {
		public ProgressForm() {
			InitializeComponent();
			this.ClientSize = new System.Drawing.Size(300, 75);
		}
		public void SetValue(int progress) {
			if(progressBar1.Value<=progressBar1.Maximum)
				progressBar1.Value = progress;
			progressBar1.Invalidate();
		}
	}
}
