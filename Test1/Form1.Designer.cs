namespace Test1 {
	partial class Form1 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.next = new System.Windows.Forms.Button();
			this.backbutton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// next
			// 
			this.next.Location = new System.Drawing.Point(12, 14);
			this.next.Name = "next";
			this.next.Size = new System.Drawing.Size(75, 23);
			this.next.TabIndex = 1;
			this.next.Text = "Interpolate";
			this.next.UseVisualStyleBackColor = true;
			this.next.Click += new System.EventHandler(this.next_Click);
			// 
			// backbutton
			// 
			this.backbutton.Location = new System.Drawing.Point(93, 14);
			this.backbutton.Name = "backbutton";
			this.backbutton.Size = new System.Drawing.Size(75, 23);
			this.backbutton.TabIndex = 4;
			this.backbutton.Text = "Back";
			this.backbutton.UseVisualStyleBackColor = true;
			this.backbutton.Click += new System.EventHandler(this.backbutton_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 861);
			this.Controls.Add(this.backbutton);
			this.Controls.Add(this.next);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button next;
		private System.Windows.Forms.Button backbutton;
	}
}

