namespace RydbergAvgs {
	partial class Form {
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
			this.splitPanel = new System.Windows.Forms.SplitContainer();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.probGroup = new System.Windows.Forms.Panel();
			this.MaxTimeLabel = new System.Windows.Forms.Label();
			this.LatSizeValue = new System.Windows.Forms.NumericUpDown();
			this.initTitle = new System.Windows.Forms.Label();
			this.gammaLabel = new System.Windows.Forms.Label();
			this.gammaValue = new System.Windows.Forms.NumericUpDown();
			this.gammaBar = new System.Windows.Forms.TrackBar();
			this.GenerateButton = new System.Windows.Forms.Button();
			this.ProbBar = new System.Windows.Forms.TrackBar();
			this.ProbValue = new System.Windows.Forms.NumericUpDown();
			this.ProbLabel = new System.Windows.Forms.Label();
			this.zoomGroup = new System.Windows.Forms.Panel();
			this.zoomTitle = new System.Windows.Forms.Label();
			this.zoomButton4 = new System.Windows.Forms.RadioButton();
			this.zoomButton3 = new System.Windows.Forms.RadioButton();
			this.zoomButton2 = new System.Windows.Forms.RadioButton();
			this.zoomButton1 = new System.Windows.Forms.RadioButton();
			this.playGroup = new System.Windows.Forms.Panel();
			this.skipToEndButton = new System.Windows.Forms.Button();
			this.skipToBeginningButton = new System.Windows.Forms.Button();
			this.speedBar = new System.Windows.Forms.TrackBar();
			this.stepCounter = new System.Windows.Forms.NumericUpDown();
			this.fwdButton = new System.Windows.Forms.Button();
			this.restartButton = new System.Windows.Forms.Button();
			this.playButton = new System.Windows.Forms.Button();
			this.backButton = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.RoundThresholdLabel = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.splitPanel)).BeginInit();
			this.splitPanel.Panel1.SuspendLayout();
			this.splitPanel.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.probGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LatSizeValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gammaValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gammaBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ProbBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ProbValue)).BeginInit();
			this.zoomGroup.SuspendLayout();
			this.playGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stepCounter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// splitPanel
			// 
			this.splitPanel.BackColor = System.Drawing.Color.Black;
			this.splitPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitPanel.Location = new System.Drawing.Point(0, 0);
			this.splitPanel.Name = "splitPanel";
			// 
			// splitPanel.Panel1
			// 
			this.splitPanel.Panel1.Controls.Add(this.tabControl1);
			this.splitPanel.Panel1.Padding = new System.Windows.Forms.Padding(10, 10, 0, 10);
			this.splitPanel.Size = new System.Drawing.Size(1904, 1041);
			this.splitPanel.SplitterDistance = 873;
			this.splitPanel.SplitterWidth = 8;
			this.splitPanel.TabIndex = 0;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabControl1.Location = new System.Drawing.Point(10, 10);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(863, 1021);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(75)))));
			this.tabPage1.Controls.Add(this.probGroup);
			this.tabPage1.Controls.Add(this.zoomGroup);
			this.tabPage1.Controls.Add(this.playGroup);
			this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(10);
			this.tabPage1.Size = new System.Drawing.Size(855, 992);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Parameters";
			// 
			// probGroup
			// 
			this.probGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
			this.probGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.probGroup.Controls.Add(this.numericUpDown1);
			this.probGroup.Controls.Add(this.RoundThresholdLabel);
			this.probGroup.Controls.Add(this.MaxTimeLabel);
			this.probGroup.Controls.Add(this.LatSizeValue);
			this.probGroup.Controls.Add(this.initTitle);
			this.probGroup.Controls.Add(this.gammaLabel);
			this.probGroup.Controls.Add(this.gammaValue);
			this.probGroup.Controls.Add(this.gammaBar);
			this.probGroup.Controls.Add(this.GenerateButton);
			this.probGroup.Controls.Add(this.ProbBar);
			this.probGroup.Controls.Add(this.ProbValue);
			this.probGroup.Controls.Add(this.ProbLabel);
			this.probGroup.Location = new System.Drawing.Point(30, 30);
			this.probGroup.Margin = new System.Windows.Forms.Padding(20);
			this.probGroup.Name = "probGroup";
			this.probGroup.Padding = new System.Windows.Forms.Padding(20);
			this.probGroup.Size = new System.Drawing.Size(643, 214);
			this.probGroup.TabIndex = 32;
			// 
			// MaxTimeLabel
			// 
			this.MaxTimeLabel.BackColor = System.Drawing.Color.Transparent;
			this.MaxTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaxTimeLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.MaxTimeLabel.Location = new System.Drawing.Point(23, 170);
			this.MaxTimeLabel.Name = "MaxTimeLabel";
			this.MaxTimeLabel.Size = new System.Drawing.Size(100, 22);
			this.MaxTimeLabel.TabIndex = 30;
			this.MaxTimeLabel.Text = "Lattice Size";
			this.MaxTimeLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// LatSizeValue
			// 
			this.LatSizeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.LatSizeValue.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.LatSizeValue.Location = new System.Drawing.Point(129, 169);
			this.LatSizeValue.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
			this.LatSizeValue.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.LatSizeValue.Name = "LatSizeValue";
			this.LatSizeValue.Size = new System.Drawing.Size(49, 23);
			this.LatSizeValue.TabIndex = 29;
			this.LatSizeValue.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// initTitle
			// 
			this.initTitle.AutoSize = true;
			this.initTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.initTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.initTitle.Location = new System.Drawing.Point(266, 20);
			this.initTitle.Name = "initTitle";
			this.initTitle.Size = new System.Drawing.Size(117, 17);
			this.initTitle.TabIndex = 28;
			this.initTitle.Text = "Initial Parameters";
			// 
			// gammaLabel
			// 
			this.gammaLabel.AutoSize = true;
			this.gammaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gammaLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.gammaLabel.Location = new System.Drawing.Point(23, 108);
			this.gammaLabel.Name = "gammaLabel";
			this.gammaLabel.Size = new System.Drawing.Size(16, 17);
			this.gammaLabel.TabIndex = 16;
			this.gammaLabel.Text = "Γ";
			// 
			// gammaValue
			// 
			this.gammaValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.gammaValue.Location = new System.Drawing.Point(53, 108);
			this.gammaValue.Name = "gammaValue";
			this.gammaValue.Size = new System.Drawing.Size(49, 23);
			this.gammaValue.TabIndex = 15;
			// 
			// gammaBar
			// 
			this.gammaBar.Location = new System.Drawing.Point(108, 108);
			this.gammaBar.Maximum = 100;
			this.gammaBar.Name = "gammaBar";
			this.gammaBar.Size = new System.Drawing.Size(197, 45);
			this.gammaBar.TabIndex = 14;
			this.gammaBar.TickFrequency = 10;
			// 
			// GenerateButton
			// 
			this.GenerateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.GenerateButton.Location = new System.Drawing.Point(341, 57);
			this.GenerateButton.Name = "GenerateButton";
			this.GenerateButton.Size = new System.Drawing.Size(131, 40);
			this.GenerateButton.TabIndex = 13;
			this.GenerateButton.Text = "Generate";
			this.GenerateButton.UseVisualStyleBackColor = true;
			// 
			// ProbBar
			// 
			this.ProbBar.Location = new System.Drawing.Point(108, 57);
			this.ProbBar.Maximum = 100;
			this.ProbBar.Name = "ProbBar";
			this.ProbBar.Size = new System.Drawing.Size(197, 45);
			this.ProbBar.TabIndex = 8;
			this.ProbBar.TickFrequency = 10;
			this.ProbBar.Value = 100;
			// 
			// ProbValue
			// 
			this.ProbValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.ProbValue.Location = new System.Drawing.Point(53, 57);
			this.ProbValue.Name = "ProbValue";
			this.ProbValue.Size = new System.Drawing.Size(49, 23);
			this.ProbValue.TabIndex = 11;
			this.ProbValue.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// ProbLabel
			// 
			this.ProbLabel.AutoSize = true;
			this.ProbLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ProbLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.ProbLabel.Location = new System.Drawing.Point(23, 57);
			this.ProbLabel.Name = "ProbLabel";
			this.ProbLabel.Size = new System.Drawing.Size(17, 17);
			this.ProbLabel.TabIndex = 9;
			this.ProbLabel.Text = "P";
			// 
			// zoomGroup
			// 
			this.zoomGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.zoomGroup.Controls.Add(this.zoomTitle);
			this.zoomGroup.Controls.Add(this.zoomButton4);
			this.zoomGroup.Controls.Add(this.zoomButton3);
			this.zoomGroup.Controls.Add(this.zoomButton2);
			this.zoomGroup.Controls.Add(this.zoomButton1);
			this.zoomGroup.Location = new System.Drawing.Point(30, 284);
			this.zoomGroup.Margin = new System.Windows.Forms.Padding(20);
			this.zoomGroup.Name = "zoomGroup";
			this.zoomGroup.Padding = new System.Windows.Forms.Padding(10);
			this.zoomGroup.Size = new System.Drawing.Size(302, 187);
			this.zoomGroup.TabIndex = 34;
			// 
			// zoomTitle
			// 
			this.zoomTitle.AutoSize = true;
			this.zoomTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.zoomTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.zoomTitle.Location = new System.Drawing.Point(105, 21);
			this.zoomTitle.Name = "zoomTitle";
			this.zoomTitle.Size = new System.Drawing.Size(93, 17);
			this.zoomTitle.TabIndex = 27;
			this.zoomTitle.Text = "Zoom Control";
			// 
			// zoomButton4
			// 
			this.zoomButton4.Appearance = System.Windows.Forms.Appearance.Button;
			this.zoomButton4.Checked = true;
			this.zoomButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.zoomButton4.Location = new System.Drawing.Point(225, 66);
			this.zoomButton4.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
			this.zoomButton4.Name = "zoomButton4";
			this.zoomButton4.Size = new System.Drawing.Size(60, 60);
			this.zoomButton4.TabIndex = 26;
			this.zoomButton4.TabStop = true;
			this.zoomButton4.Text = "1.0";
			this.zoomButton4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.zoomButton4.UseVisualStyleBackColor = true;
			// 
			// zoomButton3
			// 
			this.zoomButton3.Appearance = System.Windows.Forms.Appearance.Button;
			this.zoomButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.zoomButton3.Location = new System.Drawing.Point(155, 66);
			this.zoomButton3.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
			this.zoomButton3.Name = "zoomButton3";
			this.zoomButton3.Size = new System.Drawing.Size(60, 60);
			this.zoomButton3.TabIndex = 25;
			this.zoomButton3.TabStop = true;
			this.zoomButton3.Text = "0.5";
			this.zoomButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.zoomButton3.UseVisualStyleBackColor = true;
			// 
			// zoomButton2
			// 
			this.zoomButton2.Appearance = System.Windows.Forms.Appearance.Button;
			this.zoomButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.zoomButton2.Location = new System.Drawing.Point(85, 66);
			this.zoomButton2.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
			this.zoomButton2.Name = "zoomButton2";
			this.zoomButton2.Size = new System.Drawing.Size(60, 60);
			this.zoomButton2.TabIndex = 24;
			this.zoomButton2.TabStop = true;
			this.zoomButton2.Text = "0.25";
			this.zoomButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.zoomButton2.UseVisualStyleBackColor = true;
			// 
			// zoomButton1
			// 
			this.zoomButton1.Appearance = System.Windows.Forms.Appearance.Button;
			this.zoomButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.zoomButton1.Location = new System.Drawing.Point(15, 66);
			this.zoomButton1.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
			this.zoomButton1.Name = "zoomButton1";
			this.zoomButton1.Size = new System.Drawing.Size(60, 60);
			this.zoomButton1.TabIndex = 23;
			this.zoomButton1.TabStop = true;
			this.zoomButton1.Text = "0.125";
			this.zoomButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.zoomButton1.UseVisualStyleBackColor = true;
			// 
			// playGroup
			// 
			this.playGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.playGroup.Controls.Add(this.skipToEndButton);
			this.playGroup.Controls.Add(this.skipToBeginningButton);
			this.playGroup.Controls.Add(this.speedBar);
			this.playGroup.Controls.Add(this.stepCounter);
			this.playGroup.Controls.Add(this.fwdButton);
			this.playGroup.Controls.Add(this.restartButton);
			this.playGroup.Controls.Add(this.playButton);
			this.playGroup.Controls.Add(this.backButton);
			this.playGroup.Enabled = false;
			this.playGroup.Location = new System.Drawing.Point(372, 284);
			this.playGroup.Margin = new System.Windows.Forms.Padding(20);
			this.playGroup.Name = "playGroup";
			this.playGroup.Padding = new System.Windows.Forms.Padding(20);
			this.playGroup.Size = new System.Drawing.Size(301, 187);
			this.playGroup.TabIndex = 33;
			// 
			// skipToEndButton
			// 
			this.skipToEndButton.Location = new System.Drawing.Point(236, 66);
			this.skipToEndButton.Name = "skipToEndButton";
			this.skipToEndButton.Size = new System.Drawing.Size(40, 40);
			this.skipToEndButton.TabIndex = 16;
			this.skipToEndButton.Text = ">>";
			this.skipToEndButton.UseVisualStyleBackColor = true;
			// 
			// skipToBeginningButton
			// 
			this.skipToBeginningButton.Location = new System.Drawing.Point(23, 66);
			this.skipToBeginningButton.Name = "skipToBeginningButton";
			this.skipToBeginningButton.Size = new System.Drawing.Size(40, 40);
			this.skipToBeginningButton.TabIndex = 15;
			this.skipToBeginningButton.Text = "<<";
			this.skipToBeginningButton.UseVisualStyleBackColor = true;
			// 
			// speedBar
			// 
			this.speedBar.Location = new System.Drawing.Point(23, 125);
			this.speedBar.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
			this.speedBar.Maximum = 100;
			this.speedBar.Name = "speedBar";
			this.speedBar.Size = new System.Drawing.Size(253, 45);
			this.speedBar.TabIndex = 5;
			this.speedBar.TickFrequency = 10;
			this.speedBar.Value = 50;
			this.speedBar.Visible = false;
			// 
			// stepCounter
			// 
			this.stepCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.stepCounter.Location = new System.Drawing.Point(223, 19);
			this.stepCounter.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.stepCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.stepCounter.Name = "stepCounter";
			this.stepCounter.Size = new System.Drawing.Size(53, 23);
			this.stepCounter.TabIndex = 14;
			this.stepCounter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// fwdButton
			// 
			this.fwdButton.Location = new System.Drawing.Point(190, 66);
			this.fwdButton.Name = "fwdButton";
			this.fwdButton.Size = new System.Drawing.Size(40, 40);
			this.fwdButton.TabIndex = 2;
			this.fwdButton.Text = ">";
			this.fwdButton.UseVisualStyleBackColor = true;
			// 
			// restartButton
			// 
			this.restartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.restartButton.Location = new System.Drawing.Point(114, 9);
			this.restartButton.Name = "restartButton";
			this.restartButton.Size = new System.Drawing.Size(69, 40);
			this.restartButton.TabIndex = 7;
			this.restartButton.Text = "Restart";
			this.restartButton.UseVisualStyleBackColor = true;
			// 
			// playButton
			// 
			this.playButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.playButton.Location = new System.Drawing.Point(115, 66);
			this.playButton.Name = "playButton";
			this.playButton.Size = new System.Drawing.Size(69, 40);
			this.playButton.TabIndex = 1;
			this.playButton.Text = "Play";
			this.playButton.UseVisualStyleBackColor = true;
			// 
			// backButton
			// 
			this.backButton.Location = new System.Drawing.Point(69, 66);
			this.backButton.Name = "backButton";
			this.backButton.Size = new System.Drawing.Size(40, 40);
			this.backButton.TabIndex = 0;
			this.backButton.Text = "<";
			this.backButton.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(75)))));
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(855, 992);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			// 
			// RoundThresholdLabel
			// 
			this.RoundThresholdLabel.BackColor = System.Drawing.Color.Transparent;
			this.RoundThresholdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RoundThresholdLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.RoundThresholdLabel.Location = new System.Drawing.Point(338, 170);
			this.RoundThresholdLabel.Name = "RoundThresholdLabel";
			this.RoundThresholdLabel.Size = new System.Drawing.Size(176, 22);
			this.RoundThresholdLabel.TabIndex = 31;
			this.RoundThresholdLabel.Text = "Round down threshold (%)";
			this.RoundThresholdLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.DecimalPlaces = 1;
			this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDown1.Location = new System.Drawing.Point(532, 169);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(61, 23);
			this.numericUpDown1.TabIndex = 32;
			this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1904, 1041);
			this.Controls.Add(this.splitPanel);
			this.Name = "Form";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Rydberg Average Growth (Numerical Analysis)";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.splitPanel.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitPanel)).EndInit();
			this.splitPanel.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.probGroup.ResumeLayout(false);
			this.probGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.LatSizeValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gammaValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gammaBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ProbBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ProbValue)).EndInit();
			this.zoomGroup.ResumeLayout(false);
			this.zoomGroup.PerformLayout();
			this.playGroup.ResumeLayout(false);
			this.playGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stepCounter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitPanel;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Panel probGroup;
		private System.Windows.Forms.Label MaxTimeLabel;
		private System.Windows.Forms.NumericUpDown LatSizeValue;
		private System.Windows.Forms.Label initTitle;
		private System.Windows.Forms.Label gammaLabel;
		private System.Windows.Forms.NumericUpDown gammaValue;
		private System.Windows.Forms.TrackBar gammaBar;
		private System.Windows.Forms.Button GenerateButton;
		private System.Windows.Forms.TrackBar ProbBar;
		private System.Windows.Forms.NumericUpDown ProbValue;
		private System.Windows.Forms.Label ProbLabel;
		private System.Windows.Forms.Panel zoomGroup;
		private System.Windows.Forms.Label zoomTitle;
		private System.Windows.Forms.RadioButton zoomButton4;
		private System.Windows.Forms.RadioButton zoomButton3;
		private System.Windows.Forms.RadioButton zoomButton2;
		private System.Windows.Forms.RadioButton zoomButton1;
		private System.Windows.Forms.Panel playGroup;
		private System.Windows.Forms.Button skipToEndButton;
		private System.Windows.Forms.Button skipToBeginningButton;
		private System.Windows.Forms.TrackBar speedBar;
		private System.Windows.Forms.NumericUpDown stepCounter;
		private System.Windows.Forms.Button fwdButton;
		private System.Windows.Forms.Button restartButton;
		private System.Windows.Forms.Button playButton;
		private System.Windows.Forms.Button backButton;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label RoundThresholdLabel;
	}
}

