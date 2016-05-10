namespace QMStuff_v2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.stepCounter = new System.Windows.Forms.NumericUpDown();
			this.yProbValue = new System.Windows.Forms.NumericUpDown();
			this.xProbValue = new System.Windows.Forms.NumericUpDown();
			this.yProbLabel = new System.Windows.Forms.Label();
			this.xProbLabel = new System.Windows.Forms.Label();
			this.xProbBar = new System.Windows.Forms.TrackBar();
			this.restartButton = new System.Windows.Forms.Button();
			this.backButton = new System.Windows.Forms.Button();
			this.yProbBar = new System.Windows.Forms.TrackBar();
			this.playSpeedLabel = new System.Windows.Forms.Label();
			this.playButton = new System.Windows.Forms.Button();
			this.fwdButton = new System.Windows.Forms.Button();
			this.speedBar = new System.Windows.Forms.TrackBar();
			this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
			this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
			this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
			this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
			this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
			this.probGroup = new System.Windows.Forms.Panel();
			this.playGroup = new System.Windows.Forms.Panel();
			this.splitPanel = new System.Windows.Forms.SplitContainer();
			this.FlowLayout = new System.Windows.Forms.FlowLayoutPanel();
			((System.ComponentModel.ISupportInitialize)(this.stepCounter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.yProbValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xProbValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xProbBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.yProbBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
			this.probGroup.SuspendLayout();
			this.playGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitPanel)).BeginInit();
			this.splitPanel.Panel1.SuspendLayout();
			this.splitPanel.SuspendLayout();
			this.FlowLayout.SuspendLayout();
			this.SuspendLayout();
			// 
			// stepCounter
			// 
			this.stepCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.stepCounter.Location = new System.Drawing.Point(266, 27);
			this.stepCounter.Maximum = new decimal(new int[] {
            1000,
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
			// yProbValue
			// 
			this.yProbValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.yProbValue.Location = new System.Drawing.Point(19, 81);
			this.yProbValue.Name = "yProbValue";
			this.yProbValue.Size = new System.Drawing.Size(49, 23);
			this.yProbValue.TabIndex = 12;
			this.yProbValue.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.yProbValue.ValueChanged += new System.EventHandler(this.yProbValue_ValueChanged);
			// 
			// xProbValue
			// 
			this.xProbValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.xProbValue.Location = new System.Drawing.Point(19, 26);
			this.xProbValue.Name = "xProbValue";
			this.xProbValue.Size = new System.Drawing.Size(49, 23);
			this.xProbValue.TabIndex = 11;
			this.xProbValue.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.xProbValue.ValueChanged += new System.EventHandler(this.xProbValue_ValueChanged);
			// 
			// yProbLabel
			// 
			this.yProbLabel.AutoSize = true;
			this.yProbLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.yProbLabel.Location = new System.Drawing.Point(336, 83);
			this.yProbLabel.Name = "yProbLabel";
			this.yProbLabel.Size = new System.Drawing.Size(49, 17);
			this.yProbLabel.TabIndex = 10;
			this.yProbLabel.Text = "y Prob";
			// 
			// xProbLabel
			// 
			this.xProbLabel.AutoSize = true;
			this.xProbLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.xProbLabel.Location = new System.Drawing.Point(336, 27);
			this.xProbLabel.Name = "xProbLabel";
			this.xProbLabel.Size = new System.Drawing.Size(48, 17);
			this.xProbLabel.TabIndex = 9;
			this.xProbLabel.Text = "x Prob";
			// 
			// xProbBar
			// 
			this.xProbBar.Location = new System.Drawing.Point(80, 27);
			this.xProbBar.Maximum = 100;
			this.xProbBar.Name = "xProbBar";
			this.xProbBar.Size = new System.Drawing.Size(250, 45);
			this.xProbBar.TabIndex = 8;
			this.xProbBar.TickFrequency = 10;
			this.xProbBar.Value = 100;
			this.xProbBar.Scroll += new System.EventHandler(this.xProbBar_Scroll);
			// 
			// restartButton
			// 
			this.restartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.restartButton.Location = new System.Drawing.Point(257, 74);
			this.restartButton.Name = "restartButton";
			this.restartButton.Size = new System.Drawing.Size(69, 36);
			this.restartButton.TabIndex = 7;
			this.restartButton.Text = "Restart";
			this.restartButton.UseVisualStyleBackColor = true;
			this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
			// 
			// backButton
			// 
			this.backButton.Enabled = false;
			this.backButton.Location = new System.Drawing.Point(42, 17);
			this.backButton.Name = "backButton";
			this.backButton.Size = new System.Drawing.Size(40, 40);
			this.backButton.TabIndex = 0;
			this.backButton.Text = "<";
			this.backButton.UseVisualStyleBackColor = true;
			this.backButton.Click += new System.EventHandler(this.backButton_Click);
			// 
			// yProbBar
			// 
			this.yProbBar.Location = new System.Drawing.Point(80, 83);
			this.yProbBar.Maximum = 100;
			this.yProbBar.Name = "yProbBar";
			this.yProbBar.Size = new System.Drawing.Size(250, 45);
			this.yProbBar.TabIndex = 3;
			this.yProbBar.TickFrequency = 10;
			this.yProbBar.Value = 100;
			this.yProbBar.Scroll += new System.EventHandler(this.yProbBar_Scroll);
			// 
			// playSpeedLabel
			// 
			this.playSpeedLabel.AutoSize = true;
			this.playSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.playSpeedLabel.Location = new System.Drawing.Point(81, 107);
			this.playSpeedLabel.Name = "playSpeedLabel";
			this.playSpeedLabel.Size = new System.Drawing.Size(80, 17);
			this.playSpeedLabel.TabIndex = 6;
			this.playSpeedLabel.Text = "Play Speed";
			this.playSpeedLabel.Visible = false;
			// 
			// playButton
			// 
			this.playButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.playButton.Location = new System.Drawing.Point(89, 17);
			this.playButton.Name = "playButton";
			this.playButton.Size = new System.Drawing.Size(69, 40);
			this.playButton.TabIndex = 1;
			this.playButton.Text = "Play";
			this.playButton.UseVisualStyleBackColor = true;
			this.playButton.Click += new System.EventHandler(this.playButton_Click);
			// 
			// fwdButton
			// 
			this.fwdButton.Location = new System.Drawing.Point(164, 17);
			this.fwdButton.Name = "fwdButton";
			this.fwdButton.Size = new System.Drawing.Size(40, 40);
			this.fwdButton.TabIndex = 2;
			this.fwdButton.Text = ">";
			this.fwdButton.UseVisualStyleBackColor = true;
			this.fwdButton.Click += new System.EventHandler(this.fwdButton_Click);
			// 
			// speedBar
			// 
			this.speedBar.Location = new System.Drawing.Point(8, 80);
			this.speedBar.Maximum = 100;
			this.speedBar.Name = "speedBar";
			this.speedBar.Size = new System.Drawing.Size(231, 45);
			this.speedBar.TabIndex = 5;
			this.speedBar.TickFrequency = 10;
			this.speedBar.Value = 50;
			this.speedBar.Visible = false;
			this.speedBar.Scroll += new System.EventHandler(this.speedBar_Scroll);
			// 
			// BottomToolStripPanel
			// 
			this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
			this.BottomToolStripPanel.Name = "BottomToolStripPanel";
			this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
			// 
			// TopToolStripPanel
			// 
			this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
			this.TopToolStripPanel.Name = "TopToolStripPanel";
			this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
			// 
			// RightToolStripPanel
			// 
			this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
			this.RightToolStripPanel.Name = "RightToolStripPanel";
			this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
			// 
			// LeftToolStripPanel
			// 
			this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
			this.LeftToolStripPanel.Name = "LeftToolStripPanel";
			this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
			// 
			// ContentPanel
			// 
			this.ContentPanel.Size = new System.Drawing.Size(150, 150);
			// 
			// probGroup
			// 
			this.probGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.probGroup.Controls.Add(this.yProbLabel);
			this.probGroup.Controls.Add(this.yProbBar);
			this.probGroup.Controls.Add(this.yProbValue);
			this.probGroup.Controls.Add(this.xProbBar);
			this.probGroup.Controls.Add(this.xProbValue);
			this.probGroup.Controls.Add(this.xProbLabel);
			this.probGroup.Location = new System.Drawing.Point(20, 20);
			this.probGroup.Margin = new System.Windows.Forms.Padding(20);
			this.probGroup.Name = "probGroup";
			this.probGroup.Size = new System.Drawing.Size(399, 137);
			this.probGroup.TabIndex = 0;
			// 
			// playGroup
			// 
			this.playGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.playGroup.Controls.Add(this.playSpeedLabel);
			this.playGroup.Controls.Add(this.speedBar);
			this.playGroup.Controls.Add(this.stepCounter);
			this.playGroup.Controls.Add(this.fwdButton);
			this.playGroup.Controls.Add(this.restartButton);
			this.playGroup.Controls.Add(this.playButton);
			this.playGroup.Controls.Add(this.backButton);
			this.playGroup.Location = new System.Drawing.Point(459, 20);
			this.playGroup.Margin = new System.Windows.Forms.Padding(20);
			this.playGroup.Name = "playGroup";
			this.playGroup.Size = new System.Drawing.Size(339, 137);
			this.playGroup.TabIndex = 15;
			// 
			// splitPanel
			// 
			this.splitPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitPanel.Location = new System.Drawing.Point(0, 0);
			this.splitPanel.Name = "splitPanel";
			// 
			// splitPanel.Panel1
			// 
			this.splitPanel.Panel1.Controls.Add(this.FlowLayout);
			this.splitPanel.Size = new System.Drawing.Size(1424, 761);
			this.splitPanel.SplitterDistance = 840;
			this.splitPanel.TabIndex = 10;
			// 
			// FlowLayout
			// 
			this.FlowLayout.AutoScroll = true;
			this.FlowLayout.Controls.Add(this.probGroup);
			this.FlowLayout.Controls.Add(this.playGroup);
			this.FlowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FlowLayout.Location = new System.Drawing.Point(0, 0);
			this.FlowLayout.Name = "FlowLayout";
			this.FlowLayout.Size = new System.Drawing.Size(840, 761);
			this.FlowLayout.TabIndex = 16;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1424, 761);
			this.Controls.Add(this.splitPanel);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Square Lattice 2D v2";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)(this.stepCounter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.yProbValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xProbValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xProbBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.yProbBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
			this.probGroup.ResumeLayout(false);
			this.probGroup.PerformLayout();
			this.playGroup.ResumeLayout(false);
			this.playGroup.PerformLayout();
			this.splitPanel.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitPanel)).EndInit();
			this.splitPanel.ResumeLayout(false);
			this.FlowLayout.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TrackBar yProbBar;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button fwdButton;
        private System.Windows.Forms.TrackBar speedBar;
        private System.Windows.Forms.TrackBar xProbBar;
        private System.Windows.Forms.Label playSpeedLabel;
        private System.Windows.Forms.Label xProbLabel;
        private System.Windows.Forms.Label yProbLabel;
		private System.Windows.Forms.NumericUpDown yProbValue;
		private System.Windows.Forms.NumericUpDown xProbValue;
		private System.Windows.Forms.NumericUpDown stepCounter;
		private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
		private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
		private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
		private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
		private System.Windows.Forms.ToolStripContentPanel ContentPanel;
		private System.Windows.Forms.Panel playGroup;
		private System.Windows.Forms.Panel probGroup;
		private System.Windows.Forms.SplitContainer splitPanel;
		private System.Windows.Forms.FlowLayoutPanel FlowLayout;
	}
}

