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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.stepCounter = new System.Windows.Forms.NumericUpDown();
			this.yProbValue = new System.Windows.Forms.NumericUpDown();
			this.xProbValue = new System.Windows.Forms.NumericUpDown();
			this.yProbLabel = new System.Windows.Forms.Label();
			this.xProbLabel = new System.Windows.Forms.Label();
			this.xProbBar = new System.Windows.Forms.TrackBar();
			this.restartButton = new System.Windows.Forms.Button();
			this.backButton = new System.Windows.Forms.Button();
			this.yProbBar = new System.Windows.Forms.TrackBar();
			this.playButton = new System.Windows.Forms.Button();
			this.fwdButton = new System.Windows.Forms.Button();
			this.speedBar = new System.Windows.Forms.TrackBar();
			this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
			this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
			this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
			this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
			this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
			this.probGroup = new System.Windows.Forms.Panel();
			this.GenerateFullButton = new System.Windows.Forms.Button();
			this.LatSizeLabel = new System.Windows.Forms.Label();
			this.LatSizeValue = new System.Windows.Forms.NumericUpDown();
			this.initTitle = new System.Windows.Forms.Label();
			this.HelpButton = new System.Windows.Forms.Button();
			this.gammaLabel = new System.Windows.Forms.Label();
			this.gammaValue = new System.Windows.Forms.NumericUpDown();
			this.gammaBar = new System.Windows.Forms.TrackBar();
			this.GenerateButton = new System.Windows.Forms.Button();
			this.playGroup = new System.Windows.Forms.Panel();
			this.skipToEndButton = new System.Windows.Forms.Button();
			this.skipToBeginningButton = new System.Windows.Forms.Button();
			this.splitPanel = new System.Windows.Forms.SplitContainer();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.ParamsTab = new System.Windows.Forms.TabPage();
			this.ParamsFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
			this.zoomGroup = new System.Windows.Forms.Panel();
			this.zoomTitle = new System.Windows.Forms.Label();
			this.zoomButton4 = new System.Windows.Forms.RadioButton();
			this.zoomButton3 = new System.Windows.Forms.RadioButton();
			this.zoomButton2 = new System.Windows.Forms.RadioButton();
			this.zoomButton1 = new System.Windows.Forms.RadioButton();
			this.ExportGroup = new System.Windows.Forms.Panel();
			this.ResChooser = new System.Windows.Forms.ComboBox();
			this.ResolutionLabel = new System.Windows.Forms.Label();
			this.FpsChooser = new System.Windows.Forms.ComboBox();
			this.FpsLabel = new System.Windows.Forms.Label();
			this.ExportLabel = new System.Windows.Forms.Label();
			this.ExportButton = new System.Windows.Forms.Button();
			this.AnalyticsTab = new System.Windows.Forms.TabPage();
			this.AnalyticsFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
			this.IndVarPanel = new System.Windows.Forms.Panel();
			this.AnalysisStartButton = new System.Windows.Forms.Button();
			this.TightnessChooser = new System.Windows.Forms.ComboBox();
			this.TimePeriodChooser = new System.Windows.Forms.ComboBox();
			this.SampPeriodLabel = new System.Windows.Forms.Label();
			this.IndVarChooser = new System.Windows.Forms.ComboBox();
			this.TightnessLabel = new System.Windows.Forms.Label();
			this.IndVarLabel = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.DepVarChooser = new System.Windows.Forms.ComboBox();
			this.DepVarLabel = new System.Windows.Forms.Label();
			this.MouseLabel = new System.Windows.Forms.Label();
			this.ShowPerimButton = new System.Windows.Forms.Button();
			this.Graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.PGAnalyticsTab = new System.Windows.Forms.TabPage();
			this.AnalyticsPGFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
			this.PGParamGroup = new System.Windows.Forms.Panel();
			this.PGRunNumberValue = new System.Windows.Forms.NumericUpDown();
			this.PGRunNumberLabel = new System.Windows.Forms.Label();
			this.PGLatticeSizeValue = new System.Windows.Forms.NumericUpDown();
			this.PGLatticeSizeLabel = new System.Windows.Forms.Label();
			this.PGSamplingValue = new System.Windows.Forms.NumericUpDown();
			this.PGGammaValue = new System.Windows.Forms.NumericUpDown();
			this.PGSetGammaLabel = new System.Windows.Forms.Label();
			this.PGSampleLabel = new System.Windows.Forms.Label();
			this.PGAnalysisButton = new System.Windows.Forms.Button();
			this.PGDomainResetButton = new System.Windows.Forms.Button();
			this.PGDataGroup = new System.Windows.Forms.Panel();
			this.PGTimeSlider = new System.Windows.Forms.TrackBar();
			this.PGTimeSliderLabel = new System.Windows.Forms.Label();
			this.PGSuccessValueLabel = new System.Windows.Forms.Label();
			this.PGRatioValueLabel = new System.Windows.Forms.Label();
			this.PGProbValueLabel = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.PGDataResetButton = new System.Windows.Forms.Button();
			this.CCAnalyticsTab = new System.Windows.Forms.TabPage();
			this.CCFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.SlidingDotGroup = new System.Windows.Forms.Panel();
			this.SDPShowRegionCheckbox = new System.Windows.Forms.CheckBox();
			this.SDPRegionHLabel = new System.Windows.Forms.Label();
			this.SDPRegionWLabel = new System.Windows.Forms.Label();
			this.SDPRegionYLabel = new System.Windows.Forms.Label();
			this.SDPRegionXLabel = new System.Windows.Forms.Label();
			this.SDPRegionHValue = new System.Windows.Forms.NumericUpDown();
			this.SDPRegionWValue = new System.Windows.Forms.NumericUpDown();
			this.SDPRegionYValue = new System.Windows.Forms.NumericUpDown();
			this.SDPRegionXValue = new System.Windows.Forms.NumericUpDown();
			this.SDPOffsetValue = new System.Windows.Forms.NumericUpDown();
			this.SDPOffsetLabel = new System.Windows.Forms.Label();
			this.SlidingDotStartButton = new System.Windows.Forms.Button();
			this.SlidingDotLabel = new System.Windows.Forms.Label();
			this.ConvolutionGroup = new System.Windows.Forms.Panel();
			this.ConvolveBrightnessLabel = new System.Windows.Forms.Label();
			this.ConvolveBrightnessBar = new System.Windows.Forms.TrackBar();
			this.ConvolveButton = new System.Windows.Forms.Button();
			this.ShowConvolveCheckbox = new System.Windows.Forms.CheckBox();
			this.StDevValue = new System.Windows.Forms.TrackBar();
			this.StDevLabel = new System.Windows.Forms.Label();
			this.ConvolutionLabel = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.SDPAutoRangeCheckbox = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SDPDomainStartLabel = new System.Windows.Forms.Label();
			this.SDPDomainStartCounter = new System.Windows.Forms.NumericUpDown();
			this.SDPDomainEndCounter = new System.Windows.Forms.NumericUpDown();
			this.SDPDomainEndLabel = new System.Windows.Forms.Label();
			this.CCGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.stepCounter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.yProbValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xProbValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xProbBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.yProbBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
			this.probGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LatSizeValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gammaValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gammaBar)).BeginInit();
			this.playGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitPanel)).BeginInit();
			this.splitPanel.Panel1.SuspendLayout();
			this.splitPanel.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.ParamsTab.SuspendLayout();
			this.ParamsFlowLayout.SuspendLayout();
			this.zoomGroup.SuspendLayout();
			this.ExportGroup.SuspendLayout();
			this.AnalyticsTab.SuspendLayout();
			this.AnalyticsFlowLayout.SuspendLayout();
			this.IndVarPanel.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Graph)).BeginInit();
			this.PGAnalyticsTab.SuspendLayout();
			this.AnalyticsPGFlowLayout.SuspendLayout();
			this.PGParamGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PGRunNumberValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PGLatticeSizeValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PGSamplingValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PGGammaValue)).BeginInit();
			this.PGDataGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PGTimeSlider)).BeginInit();
			this.panel2.SuspendLayout();
			this.CCAnalyticsTab.SuspendLayout();
			this.CCFlowLayoutPanel.SuspendLayout();
			this.SlidingDotGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SDPRegionHValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SDPRegionWValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SDPRegionYValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SDPRegionXValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SDPOffsetValue)).BeginInit();
			this.ConvolutionGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ConvolveBrightnessBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.StDevValue)).BeginInit();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SDPDomainStartCounter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SDPDomainEndCounter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CCGraph)).BeginInit();
			this.SuspendLayout();
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
			this.stepCounter.ValueChanged += new System.EventHandler(this.stepCounter_ValueChanged);
			// 
			// yProbValue
			// 
			this.yProbValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.yProbValue.Location = new System.Drawing.Point(53, 108);
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
			this.xProbValue.Location = new System.Drawing.Point(53, 57);
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
			this.yProbLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.yProbLabel.Location = new System.Drawing.Point(23, 108);
			this.yProbLabel.Name = "yProbLabel";
			this.yProbLabel.Size = new System.Drawing.Size(24, 17);
			this.yProbLabel.TabIndex = 10;
			this.yProbLabel.Text = "Py";
			// 
			// xProbLabel
			// 
			this.xProbLabel.AutoSize = true;
			this.xProbLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.xProbLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.xProbLabel.Location = new System.Drawing.Point(23, 57);
			this.xProbLabel.Name = "xProbLabel";
			this.xProbLabel.Size = new System.Drawing.Size(23, 17);
			this.xProbLabel.TabIndex = 9;
			this.xProbLabel.Text = "Px";
			// 
			// xProbBar
			// 
			this.xProbBar.Location = new System.Drawing.Point(108, 57);
			this.xProbBar.Maximum = 100;
			this.xProbBar.Name = "xProbBar";
			this.xProbBar.Size = new System.Drawing.Size(197, 45);
			this.xProbBar.TabIndex = 8;
			this.xProbBar.TickFrequency = 10;
			this.xProbBar.Value = 25;
			this.xProbBar.Scroll += new System.EventHandler(this.xProbBar_Scroll);
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
			this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
			// 
			// backButton
			// 
			this.backButton.Location = new System.Drawing.Point(69, 66);
			this.backButton.Name = "backButton";
			this.backButton.Size = new System.Drawing.Size(40, 40);
			this.backButton.TabIndex = 0;
			this.backButton.Text = "<";
			this.backButton.UseVisualStyleBackColor = true;
			this.backButton.Click += new System.EventHandler(this.backButton_Click);
			// 
			// yProbBar
			// 
			this.yProbBar.Location = new System.Drawing.Point(108, 108);
			this.yProbBar.Maximum = 100;
			this.yProbBar.Name = "yProbBar";
			this.yProbBar.Size = new System.Drawing.Size(197, 45);
			this.yProbBar.TabIndex = 3;
			this.yProbBar.TickFrequency = 10;
			this.yProbBar.Value = 25;
			this.yProbBar.Scroll += new System.EventHandler(this.yProbBar_Scroll);
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
			this.playButton.Click += new System.EventHandler(this.playButton_Click);
			// 
			// fwdButton
			// 
			this.fwdButton.Location = new System.Drawing.Point(190, 66);
			this.fwdButton.Name = "fwdButton";
			this.fwdButton.Size = new System.Drawing.Size(40, 40);
			this.fwdButton.TabIndex = 2;
			this.fwdButton.Text = ">";
			this.fwdButton.UseVisualStyleBackColor = true;
			this.fwdButton.Click += new System.EventHandler(this.fwdButton_Click);
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
			this.probGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
			this.probGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.probGroup.Controls.Add(this.GenerateFullButton);
			this.probGroup.Controls.Add(this.LatSizeLabel);
			this.probGroup.Controls.Add(this.LatSizeValue);
			this.probGroup.Controls.Add(this.initTitle);
			this.probGroup.Controls.Add(this.HelpButton);
			this.probGroup.Controls.Add(this.gammaLabel);
			this.probGroup.Controls.Add(this.gammaValue);
			this.probGroup.Controls.Add(this.gammaBar);
			this.probGroup.Controls.Add(this.GenerateButton);
			this.probGroup.Controls.Add(this.yProbLabel);
			this.probGroup.Controls.Add(this.yProbBar);
			this.probGroup.Controls.Add(this.yProbValue);
			this.probGroup.Controls.Add(this.xProbBar);
			this.probGroup.Controls.Add(this.xProbValue);
			this.probGroup.Controls.Add(this.xProbLabel);
			this.probGroup.Location = new System.Drawing.Point(30, 30);
			this.probGroup.Margin = new System.Windows.Forms.Padding(20);
			this.probGroup.Name = "probGroup";
			this.probGroup.Padding = new System.Windows.Forms.Padding(20);
			this.probGroup.Size = new System.Drawing.Size(643, 214);
			this.probGroup.TabIndex = 0;
			// 
			// GenerateFullButton
			// 
			this.GenerateFullButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.GenerateFullButton.Location = new System.Drawing.Point(487, 108);
			this.GenerateFullButton.Name = "GenerateFullButton";
			this.GenerateFullButton.Size = new System.Drawing.Size(131, 40);
			this.GenerateFullButton.TabIndex = 31;
			this.GenerateFullButton.Text = "Generate Full";
			this.GenerateFullButton.UseVisualStyleBackColor = true;
			this.GenerateFullButton.Click += new System.EventHandler(this.GenerateFullButton_Click);
			// 
			// LatSizeLabel
			// 
			this.LatSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LatSizeLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.LatSizeLabel.Location = new System.Drawing.Point(342, 57);
			this.LatSizeLabel.Name = "LatSizeLabel";
			this.LatSizeLabel.Size = new System.Drawing.Size(54, 40);
			this.LatSizeLabel.TabIndex = 30;
			this.LatSizeLabel.Text = "Lattice Size";
			this.LatSizeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// LatSizeValue
			// 
			this.LatSizeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.LatSizeValue.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.LatSizeValue.Location = new System.Drawing.Point(404, 66);
			this.LatSizeValue.Maximum = new decimal(new int[] {
            700,
            0,
            0,
            0});
			this.LatSizeValue.Minimum = new decimal(new int[] {
            100,
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
			// HelpButton
			// 
			this.HelpButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.HelpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.HelpButton.Location = new System.Drawing.Point(345, 108);
			this.HelpButton.Name = "HelpButton";
			this.HelpButton.Size = new System.Drawing.Size(108, 40);
			this.HelpButton.TabIndex = 17;
			this.HelpButton.Text = "Help";
			this.HelpButton.UseVisualStyleBackColor = true;
			this.HelpButton.Click += new System.EventHandler(this.helpButton_Click);
			// 
			// gammaLabel
			// 
			this.gammaLabel.AutoSize = true;
			this.gammaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gammaLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.gammaLabel.Location = new System.Drawing.Point(23, 159);
			this.gammaLabel.Name = "gammaLabel";
			this.gammaLabel.Size = new System.Drawing.Size(16, 17);
			this.gammaLabel.TabIndex = 16;
			this.gammaLabel.Text = "Γ";
			// 
			// gammaValue
			// 
			this.gammaValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.gammaValue.Location = new System.Drawing.Point(53, 159);
			this.gammaValue.Name = "gammaValue";
			this.gammaValue.Size = new System.Drawing.Size(49, 23);
			this.gammaValue.TabIndex = 15;
			this.gammaValue.ValueChanged += new System.EventHandler(this.gammaValue_ValueChanged);
			// 
			// gammaBar
			// 
			this.gammaBar.Location = new System.Drawing.Point(108, 159);
			this.gammaBar.Maximum = 100;
			this.gammaBar.Name = "gammaBar";
			this.gammaBar.Size = new System.Drawing.Size(197, 45);
			this.gammaBar.TabIndex = 14;
			this.gammaBar.TickFrequency = 10;
			this.gammaBar.Value = 50;
			this.gammaBar.Scroll += new System.EventHandler(this.gammaBar_Scroll);
			// 
			// GenerateButton
			// 
			this.GenerateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.GenerateButton.Location = new System.Drawing.Point(487, 57);
			this.GenerateButton.Name = "GenerateButton";
			this.GenerateButton.Size = new System.Drawing.Size(131, 40);
			this.GenerateButton.TabIndex = 13;
			this.GenerateButton.Text = "Generate";
			this.GenerateButton.UseVisualStyleBackColor = true;
			this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
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
			this.playGroup.TabIndex = 15;
			// 
			// skipToEndButton
			// 
			this.skipToEndButton.Location = new System.Drawing.Point(236, 66);
			this.skipToEndButton.Name = "skipToEndButton";
			this.skipToEndButton.Size = new System.Drawing.Size(40, 40);
			this.skipToEndButton.TabIndex = 16;
			this.skipToEndButton.Text = ">>";
			this.skipToEndButton.UseVisualStyleBackColor = true;
			this.skipToEndButton.Click += new System.EventHandler(this.skipToEndButton_Click);
			// 
			// skipToBeginningButton
			// 
			this.skipToBeginningButton.Location = new System.Drawing.Point(23, 66);
			this.skipToBeginningButton.Name = "skipToBeginningButton";
			this.skipToBeginningButton.Size = new System.Drawing.Size(40, 40);
			this.skipToBeginningButton.TabIndex = 15;
			this.skipToBeginningButton.Text = "<<";
			this.skipToBeginningButton.UseVisualStyleBackColor = true;
			this.skipToBeginningButton.Click += new System.EventHandler(this.skipToBeginningButton_Click);
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
			this.splitPanel.Panel1.BackColor = System.Drawing.Color.Black;
			this.splitPanel.Panel1.Controls.Add(this.tabControl1);
			this.splitPanel.Panel1.Padding = new System.Windows.Forms.Padding(10, 10, 0, 10);
			this.splitPanel.Size = new System.Drawing.Size(1904, 1041);
			this.splitPanel.SplitterDistance = 873;
			this.splitPanel.SplitterWidth = 8;
			this.splitPanel.TabIndex = 10;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.ParamsTab);
			this.tabControl1.Controls.Add(this.AnalyticsTab);
			this.tabControl1.Controls.Add(this.PGAnalyticsTab);
			this.tabControl1.Controls.Add(this.CCAnalyticsTab);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.tabControl1.Location = new System.Drawing.Point(10, 10);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(863, 1021);
			this.tabControl1.TabIndex = 17;
			// 
			// ParamsTab
			// 
			this.ParamsTab.BackColor = System.Drawing.SystemColors.Control;
			this.ParamsTab.Controls.Add(this.ParamsFlowLayout);
			this.ParamsTab.Location = new System.Drawing.Point(4, 25);
			this.ParamsTab.Name = "ParamsTab";
			this.ParamsTab.Padding = new System.Windows.Forms.Padding(3);
			this.ParamsTab.Size = new System.Drawing.Size(855, 992);
			this.ParamsTab.TabIndex = 1;
			this.ParamsTab.Text = "Parameters";
			// 
			// ParamsFlowLayout
			// 
			this.ParamsFlowLayout.AutoScroll = true;
			this.ParamsFlowLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(75)))));
			this.ParamsFlowLayout.Controls.Add(this.probGroup);
			this.ParamsFlowLayout.Controls.Add(this.zoomGroup);
			this.ParamsFlowLayout.Controls.Add(this.playGroup);
			this.ParamsFlowLayout.Controls.Add(this.ExportGroup);
			this.ParamsFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ParamsFlowLayout.Location = new System.Drawing.Point(3, 3);
			this.ParamsFlowLayout.Name = "ParamsFlowLayout";
			this.ParamsFlowLayout.Padding = new System.Windows.Forms.Padding(10);
			this.ParamsFlowLayout.Size = new System.Drawing.Size(849, 986);
			this.ParamsFlowLayout.TabIndex = 16;
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
			this.zoomGroup.TabIndex = 16;
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
			this.zoomButton4.CheckedChanged += new System.EventHandler(this.zoomButton4_CheckedChanged);
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
			this.zoomButton3.CheckedChanged += new System.EventHandler(this.zoomButton3_CheckedChanged);
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
			this.zoomButton2.CheckedChanged += new System.EventHandler(this.zoomButton2_CheckedChanged);
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
			this.zoomButton1.CheckedChanged += new System.EventHandler(this.zoomButton1_CheckedChanged);
			// 
			// ExportGroup
			// 
			this.ExportGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
			this.ExportGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ExportGroup.Controls.Add(this.ResChooser);
			this.ExportGroup.Controls.Add(this.ResolutionLabel);
			this.ExportGroup.Controls.Add(this.FpsChooser);
			this.ExportGroup.Controls.Add(this.FpsLabel);
			this.ExportGroup.Controls.Add(this.ExportLabel);
			this.ExportGroup.Controls.Add(this.ExportButton);
			this.ExportGroup.Location = new System.Drawing.Point(30, 511);
			this.ExportGroup.Margin = new System.Windows.Forms.Padding(20);
			this.ExportGroup.Name = "ExportGroup";
			this.ExportGroup.Padding = new System.Windows.Forms.Padding(20);
			this.ExportGroup.Size = new System.Drawing.Size(243, 214);
			this.ExportGroup.TabIndex = 31;
			// 
			// ResChooser
			// 
			this.ResChooser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ResChooser.FormattingEnabled = true;
			this.ResChooser.Items.AddRange(new object[] {
            "800 x 800",
            "600 x 600",
            "400 x 400"});
			this.ResChooser.Location = new System.Drawing.Point(114, 104);
			this.ResChooser.Name = "ResChooser";
			this.ResChooser.Size = new System.Drawing.Size(101, 24);
			this.ResChooser.TabIndex = 33;
			// 
			// ResolutionLabel
			// 
			this.ResolutionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ResolutionLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.ResolutionLabel.Location = new System.Drawing.Point(21, 105);
			this.ResolutionLabel.Name = "ResolutionLabel";
			this.ResolutionLabel.Size = new System.Drawing.Size(81, 21);
			this.ResolutionLabel.TabIndex = 32;
			this.ResolutionLabel.Text = "Resolution";
			// 
			// FpsChooser
			// 
			this.FpsChooser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.FpsChooser.FormattingEnabled = true;
			this.FpsChooser.Items.AddRange(new object[] {
            "24 Hz (fastest video)",
            "10 Hz",
            "5 Hz",
            "2 Hz (slowest video)"});
			this.FpsChooser.Location = new System.Drawing.Point(69, 61);
			this.FpsChooser.Name = "FpsChooser";
			this.FpsChooser.Size = new System.Drawing.Size(146, 24);
			this.FpsChooser.TabIndex = 31;
			// 
			// FpsLabel
			// 
			this.FpsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FpsLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.FpsLabel.Location = new System.Drawing.Point(21, 61);
			this.FpsLabel.Name = "FpsLabel";
			this.FpsLabel.Size = new System.Drawing.Size(54, 21);
			this.FpsLabel.TabIndex = 30;
			this.FpsLabel.Text = "FPS";
			// 
			// ExportLabel
			// 
			this.ExportLabel.AutoSize = true;
			this.ExportLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.ExportLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.ExportLabel.Location = new System.Drawing.Point(73, 20);
			this.ExportLabel.Name = "ExportLabel";
			this.ExportLabel.Size = new System.Drawing.Size(88, 17);
			this.ExportLabel.TabIndex = 28;
			this.ExportLabel.Text = "Export Video";
			this.ExportLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// ExportButton
			// 
			this.ExportButton.Enabled = false;
			this.ExportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.ExportButton.Location = new System.Drawing.Point(53, 150);
			this.ExportButton.Name = "ExportButton";
			this.ExportButton.Size = new System.Drawing.Size(131, 40);
			this.ExportButton.TabIndex = 13;
			this.ExportButton.Text = "Export";
			this.ExportButton.UseVisualStyleBackColor = true;
			this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
			// 
			// AnalyticsTab
			// 
			this.AnalyticsTab.AutoScroll = true;
			this.AnalyticsTab.Controls.Add(this.AnalyticsFlowLayout);
			this.AnalyticsTab.Controls.Add(this.Graph);
			this.AnalyticsTab.Location = new System.Drawing.Point(4, 25);
			this.AnalyticsTab.Name = "AnalyticsTab";
			this.AnalyticsTab.Padding = new System.Windows.Forms.Padding(3);
			this.AnalyticsTab.Size = new System.Drawing.Size(855, 992);
			this.AnalyticsTab.TabIndex = 0;
			this.AnalyticsTab.Text = "Analytics";
			// 
			// AnalyticsFlowLayout
			// 
			this.AnalyticsFlowLayout.AutoScroll = true;
			this.AnalyticsFlowLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(75)))));
			this.AnalyticsFlowLayout.Controls.Add(this.IndVarPanel);
			this.AnalyticsFlowLayout.Controls.Add(this.panel1);
			this.AnalyticsFlowLayout.Controls.Add(this.ShowPerimButton);
			this.AnalyticsFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AnalyticsFlowLayout.Location = new System.Drawing.Point(3, 3);
			this.AnalyticsFlowLayout.Name = "AnalyticsFlowLayout";
			this.AnalyticsFlowLayout.Padding = new System.Windows.Forms.Padding(10);
			this.AnalyticsFlowLayout.Size = new System.Drawing.Size(849, 537);
			this.AnalyticsFlowLayout.TabIndex = 43;
			// 
			// IndVarPanel
			// 
			this.IndVarPanel.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
			this.IndVarPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.IndVarPanel.Controls.Add(this.AnalysisStartButton);
			this.IndVarPanel.Controls.Add(this.TightnessChooser);
			this.IndVarPanel.Controls.Add(this.TimePeriodChooser);
			this.IndVarPanel.Controls.Add(this.SampPeriodLabel);
			this.IndVarPanel.Controls.Add(this.IndVarChooser);
			this.IndVarPanel.Controls.Add(this.TightnessLabel);
			this.IndVarPanel.Controls.Add(this.IndVarLabel);
			this.IndVarPanel.Location = new System.Drawing.Point(30, 30);
			this.IndVarPanel.Margin = new System.Windows.Forms.Padding(20);
			this.IndVarPanel.Name = "IndVarPanel";
			this.IndVarPanel.Padding = new System.Windows.Forms.Padding(20);
			this.IndVarPanel.Size = new System.Drawing.Size(289, 255);
			this.IndVarPanel.TabIndex = 42;
			// 
			// AnalysisStartButton
			// 
			this.AnalysisStartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.AnalysisStartButton.Location = new System.Drawing.Point(78, 190);
			this.AnalysisStartButton.Name = "AnalysisStartButton";
			this.AnalysisStartButton.Size = new System.Drawing.Size(131, 40);
			this.AnalysisStartButton.TabIndex = 34;
			this.AnalysisStartButton.Text = "Start Analysis";
			this.AnalysisStartButton.UseVisualStyleBackColor = true;
			this.AnalysisStartButton.Click += new System.EventHandler(this.AnalysisStartButton_Click);
			// 
			// TightnessChooser
			// 
			this.TightnessChooser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TightnessChooser.FormattingEnabled = true;
			this.TightnessChooser.Items.AddRange(new object[] {
            "1 (tightest)",
            "2",
            "3",
            "4",
            "5",
            "6",
            "8",
            "10",
            "20",
            "50 (loosest)"});
			this.TightnessChooser.Location = new System.Drawing.Point(181, 122);
			this.TightnessChooser.Name = "TightnessChooser";
			this.TightnessChooser.Size = new System.Drawing.Size(78, 24);
			this.TightnessChooser.TabIndex = 34;
			this.TightnessChooser.Visible = false;
			// 
			// TimePeriodChooser
			// 
			this.TimePeriodChooser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TimePeriodChooser.FormattingEnabled = true;
			this.TimePeriodChooser.Items.AddRange(new object[] {
            "10",
            "20",
            "50",
            "100"});
			this.TimePeriodChooser.Location = new System.Drawing.Point(23, 122);
			this.TimePeriodChooser.Name = "TimePeriodChooser";
			this.TimePeriodChooser.Size = new System.Drawing.Size(112, 24);
			this.TimePeriodChooser.TabIndex = 33;
			this.TimePeriodChooser.Visible = false;
			// 
			// SampPeriodLabel
			// 
			this.SampPeriodLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SampPeriodLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.SampPeriodLabel.Location = new System.Drawing.Point(20, 98);
			this.SampPeriodLabel.Name = "SampPeriodLabel";
			this.SampPeriodLabel.Size = new System.Drawing.Size(115, 21);
			this.SampPeriodLabel.TabIndex = 32;
			this.SampPeriodLabel.Text = "Sampling Period";
			this.SampPeriodLabel.Visible = false;
			// 
			// IndVarChooser
			// 
			this.IndVarChooser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.IndVarChooser.FormattingEnabled = true;
			this.IndVarChooser.Items.AddRange(new object[] {
            "Tightness",
            "Time",
            "P and Γ"});
			this.IndVarChooser.Location = new System.Drawing.Point(23, 43);
			this.IndVarChooser.Name = "IndVarChooser";
			this.IndVarChooser.Size = new System.Drawing.Size(236, 24);
			this.IndVarChooser.TabIndex = 31;
			this.IndVarChooser.SelectedIndexChanged += new System.EventHandler(this.IndVarChooser_SelectedIndexChanged);
			// 
			// TightnessLabel
			// 
			this.TightnessLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TightnessLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.TightnessLabel.Location = new System.Drawing.Point(178, 98);
			this.TightnessLabel.Name = "TightnessLabel";
			this.TightnessLabel.Size = new System.Drawing.Size(80, 21);
			this.TightnessLabel.TabIndex = 30;
			this.TightnessLabel.Text = "Tightness";
			this.TightnessLabel.Visible = false;
			// 
			// IndVarLabel
			// 
			this.IndVarLabel.AutoSize = true;
			this.IndVarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.IndVarLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.IndVarLabel.Location = new System.Drawing.Point(20, 18);
			this.IndVarLabel.Name = "IndVarLabel";
			this.IndVarLabel.Size = new System.Drawing.Size(143, 17);
			this.IndVarLabel.TabIndex = 28;
			this.IndVarLabel.Text = "Independent Variable";
			// 
			// panel1
			// 
			this.panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.DepVarChooser);
			this.panel1.Controls.Add(this.DepVarLabel);
			this.panel1.Controls.Add(this.MouseLabel);
			this.panel1.Location = new System.Drawing.Point(359, 30);
			this.panel1.Margin = new System.Windows.Forms.Padding(20);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(20);
			this.panel1.Size = new System.Drawing.Size(289, 255);
			this.panel1.TabIndex = 43;
			// 
			// DepVarChooser
			// 
			this.DepVarChooser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DepVarChooser.FormattingEnabled = true;
			this.DepVarChooser.Items.AddRange(new object[] {
            "Perimeter",
            "Area",
            "Density",
            "Mean Radius",
            "Success Rate"});
			this.DepVarChooser.Location = new System.Drawing.Point(26, 85);
			this.DepVarChooser.Name = "DepVarChooser";
			this.DepVarChooser.Size = new System.Drawing.Size(236, 24);
			this.DepVarChooser.TabIndex = 36;
			this.DepVarChooser.SelectedIndexChanged += new System.EventHandler(this.DepVarChooser_SelectedIndexChanged);
			// 
			// DepVarLabel
			// 
			this.DepVarLabel.AutoSize = true;
			this.DepVarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.DepVarLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.DepVarLabel.Location = new System.Drawing.Point(23, 60);
			this.DepVarLabel.Name = "DepVarLabel";
			this.DepVarLabel.Size = new System.Drawing.Size(134, 17);
			this.DepVarLabel.TabIndex = 35;
			this.DepVarLabel.Text = "Dependent Variable";
			// 
			// MouseLabel
			// 
			this.MouseLabel.AutoSize = true;
			this.MouseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.MouseLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.MouseLabel.Location = new System.Drawing.Point(23, 28);
			this.MouseLabel.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
			this.MouseLabel.Name = "MouseLabel";
			this.MouseLabel.Size = new System.Drawing.Size(42, 17);
			this.MouseLabel.TabIndex = 38;
			this.MouseLabel.Text = "(0, 0)";
			// 
			// ShowPerimButton
			// 
			this.ShowPerimButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.ShowPerimButton.Location = new System.Drawing.Point(671, 13);
			this.ShowPerimButton.Name = "ShowPerimButton";
			this.ShowPerimButton.Size = new System.Drawing.Size(131, 40);
			this.ShowPerimButton.TabIndex = 35;
			this.ShowPerimButton.Text = "Show Perimeter";
			this.ShowPerimButton.UseVisualStyleBackColor = true;
			this.ShowPerimButton.Click += new System.EventHandler(this.ShowPerimButton_Click);
			// 
			// Graph
			// 
			this.Graph.BorderlineColor = System.Drawing.Color.Black;
			this.Graph.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			this.Graph.BorderlineWidth = 5;
			chartArea1.Area3DStyle.Inclination = 0;
			chartArea1.Area3DStyle.IsRightAngleAxes = false;
			chartArea1.Area3DStyle.Rotation = 45;
			chartArea1.AxisX.IsMarginVisible = false;
			chartArea1.AxisX.MajorGrid.Enabled = false;
			chartArea1.AxisX.Minimum = 0D;
			chartArea1.AxisX.Title = "X";
			chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			chartArea1.AxisY.MajorGrid.Enabled = false;
			chartArea1.AxisY.Title = "Y";
			chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			chartArea1.Name = "ChartArea1";
			this.Graph.ChartAreas.Add(chartArea1);
			this.Graph.Dock = System.Windows.Forms.DockStyle.Bottom;
			legend1.Enabled = false;
			legend1.Name = "Legend1";
			this.Graph.Legends.Add(legend1);
			this.Graph.Location = new System.Drawing.Point(3, 540);
			this.Graph.Name = "Graph";
			series1.BorderWidth = 5;
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series1.Legend = "Legend1";
			series1.MarkerColor = System.Drawing.Color.Black;
			series1.MarkerSize = 8;
			series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
			series1.Name = "Series1";
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
			series2.Legend = "Legend1";
			series2.MarkerSize = 12;
			series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
			series2.Name = "Series2";
			this.Graph.Series.Add(series1);
			this.Graph.Series.Add(series2);
			this.Graph.Size = new System.Drawing.Size(849, 449);
			this.Graph.TabIndex = 42;
			this.Graph.Text = "chart1";
			// 
			// PGAnalyticsTab
			// 
			this.PGAnalyticsTab.BackColor = System.Drawing.SystemColors.Control;
			this.PGAnalyticsTab.Controls.Add(this.AnalyticsPGFlowLayout);
			this.PGAnalyticsTab.Location = new System.Drawing.Point(4, 25);
			this.PGAnalyticsTab.Name = "PGAnalyticsTab";
			this.PGAnalyticsTab.Size = new System.Drawing.Size(855, 992);
			this.PGAnalyticsTab.TabIndex = 2;
			this.PGAnalyticsTab.Text = "Prob/Gamma Analysis";
			// 
			// AnalyticsPGFlowLayout
			// 
			this.AnalyticsPGFlowLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(75)))));
			this.AnalyticsPGFlowLayout.Controls.Add(this.PGParamGroup);
			this.AnalyticsPGFlowLayout.Controls.Add(this.PGDataGroup);
			this.AnalyticsPGFlowLayout.Controls.Add(this.panel2);
			this.AnalyticsPGFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AnalyticsPGFlowLayout.Location = new System.Drawing.Point(0, 0);
			this.AnalyticsPGFlowLayout.Name = "AnalyticsPGFlowLayout";
			this.AnalyticsPGFlowLayout.Padding = new System.Windows.Forms.Padding(10);
			this.AnalyticsPGFlowLayout.Size = new System.Drawing.Size(855, 992);
			this.AnalyticsPGFlowLayout.TabIndex = 0;
			// 
			// PGParamGroup
			// 
			this.PGParamGroup.Controls.Add(this.PGRunNumberValue);
			this.PGParamGroup.Controls.Add(this.PGRunNumberLabel);
			this.PGParamGroup.Controls.Add(this.PGLatticeSizeValue);
			this.PGParamGroup.Controls.Add(this.PGLatticeSizeLabel);
			this.PGParamGroup.Controls.Add(this.PGSamplingValue);
			this.PGParamGroup.Controls.Add(this.PGGammaValue);
			this.PGParamGroup.Controls.Add(this.PGSetGammaLabel);
			this.PGParamGroup.Controls.Add(this.PGSampleLabel);
			this.PGParamGroup.Controls.Add(this.PGAnalysisButton);
			this.PGParamGroup.Controls.Add(this.PGDomainResetButton);
			this.PGParamGroup.Location = new System.Drawing.Point(30, 30);
			this.PGParamGroup.Margin = new System.Windows.Forms.Padding(20);
			this.PGParamGroup.Name = "PGParamGroup";
			this.PGParamGroup.Padding = new System.Windows.Forms.Padding(10);
			this.PGParamGroup.Size = new System.Drawing.Size(298, 231);
			this.PGParamGroup.TabIndex = 0;
			// 
			// PGRunNumberValue
			// 
			this.PGRunNumberValue.Location = new System.Drawing.Point(232, 117);
			this.PGRunNumberValue.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.PGRunNumberValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.PGRunNumberValue.Name = "PGRunNumberValue";
			this.PGRunNumberValue.Size = new System.Drawing.Size(53, 23);
			this.PGRunNumberValue.TabIndex = 9;
			this.PGRunNumberValue.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// PGRunNumberLabel
			// 
			this.PGRunNumberLabel.AutoSize = true;
			this.PGRunNumberLabel.ForeColor = System.Drawing.Color.White;
			this.PGRunNumberLabel.Location = new System.Drawing.Point(18, 117);
			this.PGRunNumberLabel.Margin = new System.Windows.Forms.Padding(8);
			this.PGRunNumberLabel.Name = "PGRunNumberLabel";
			this.PGRunNumberLabel.Size = new System.Drawing.Size(187, 17);
			this.PGRunNumberLabel.TabIndex = 8;
			this.PGRunNumberLabel.Text = "Number of Runs per Sample";
			// 
			// PGLatticeSizeValue
			// 
			this.PGLatticeSizeValue.Location = new System.Drawing.Point(232, 51);
			this.PGLatticeSizeValue.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.PGLatticeSizeValue.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.PGLatticeSizeValue.Name = "PGLatticeSizeValue";
			this.PGLatticeSizeValue.Size = new System.Drawing.Size(53, 23);
			this.PGLatticeSizeValue.TabIndex = 7;
			this.PGLatticeSizeValue.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			// 
			// PGLatticeSizeLabel
			// 
			this.PGLatticeSizeLabel.AutoSize = true;
			this.PGLatticeSizeLabel.ForeColor = System.Drawing.Color.White;
			this.PGLatticeSizeLabel.Location = new System.Drawing.Point(18, 51);
			this.PGLatticeSizeLabel.Margin = new System.Windows.Forms.Padding(8);
			this.PGLatticeSizeLabel.Name = "PGLatticeSizeLabel";
			this.PGLatticeSizeLabel.Size = new System.Drawing.Size(81, 17);
			this.PGLatticeSizeLabel.TabIndex = 6;
			this.PGLatticeSizeLabel.Text = "Lattice Size";
			// 
			// PGSamplingValue
			// 
			this.PGSamplingValue.Location = new System.Drawing.Point(232, 82);
			this.PGSamplingValue.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
			this.PGSamplingValue.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.PGSamplingValue.Name = "PGSamplingValue";
			this.PGSamplingValue.Size = new System.Drawing.Size(53, 23);
			this.PGSamplingValue.TabIndex = 5;
			this.PGSamplingValue.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// PGGammaValue
			// 
			this.PGGammaValue.Location = new System.Drawing.Point(232, 16);
			this.PGGammaValue.Name = "PGGammaValue";
			this.PGGammaValue.Size = new System.Drawing.Size(53, 23);
			this.PGGammaValue.TabIndex = 4;
			this.PGGammaValue.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			// 
			// PGSetGammaLabel
			// 
			this.PGSetGammaLabel.AutoSize = true;
			this.PGSetGammaLabel.ForeColor = System.Drawing.Color.White;
			this.PGSetGammaLabel.Location = new System.Drawing.Point(18, 18);
			this.PGSetGammaLabel.Margin = new System.Windows.Forms.Padding(8);
			this.PGSetGammaLabel.Name = "PGSetGammaLabel";
			this.PGSetGammaLabel.Size = new System.Drawing.Size(95, 17);
			this.PGSetGammaLabel.TabIndex = 3;
			this.PGSetGammaLabel.Text = "Gamma value";
			// 
			// PGSampleLabel
			// 
			this.PGSampleLabel.AutoSize = true;
			this.PGSampleLabel.ForeColor = System.Drawing.Color.White;
			this.PGSampleLabel.Location = new System.Drawing.Point(18, 84);
			this.PGSampleLabel.Margin = new System.Windows.Forms.Padding(8);
			this.PGSampleLabel.Name = "PGSampleLabel";
			this.PGSampleLabel.Size = new System.Drawing.Size(132, 17);
			this.PGSampleLabel.TabIndex = 2;
			this.PGSampleLabel.Text = "Number of Samples";
			// 
			// PGAnalysisButton
			// 
			this.PGAnalysisButton.Location = new System.Drawing.Point(164, 178);
			this.PGAnalysisButton.Name = "PGAnalysisButton";
			this.PGAnalysisButton.Size = new System.Drawing.Size(121, 40);
			this.PGAnalysisButton.TabIndex = 1;
			this.PGAnalysisButton.Text = "Graph";
			this.PGAnalysisButton.UseVisualStyleBackColor = true;
			this.PGAnalysisButton.Click += new System.EventHandler(this.PGAnalysisButton_Click);
			// 
			// PGDomainResetButton
			// 
			this.PGDomainResetButton.Location = new System.Drawing.Point(13, 178);
			this.PGDomainResetButton.Name = "PGDomainResetButton";
			this.PGDomainResetButton.Size = new System.Drawing.Size(121, 40);
			this.PGDomainResetButton.TabIndex = 0;
			this.PGDomainResetButton.Text = "Reset Domain";
			this.PGDomainResetButton.UseVisualStyleBackColor = true;
			this.PGDomainResetButton.Click += new System.EventHandler(this.PGDomainResetButton_Click);
			// 
			// PGDataGroup
			// 
			this.PGDataGroup.Controls.Add(this.PGTimeSlider);
			this.PGDataGroup.Controls.Add(this.PGTimeSliderLabel);
			this.PGDataGroup.Controls.Add(this.PGSuccessValueLabel);
			this.PGDataGroup.Controls.Add(this.PGRatioValueLabel);
			this.PGDataGroup.Controls.Add(this.PGProbValueLabel);
			this.PGDataGroup.Location = new System.Drawing.Point(368, 30);
			this.PGDataGroup.Margin = new System.Windows.Forms.Padding(20);
			this.PGDataGroup.Name = "PGDataGroup";
			this.PGDataGroup.Padding = new System.Windows.Forms.Padding(10);
			this.PGDataGroup.Size = new System.Drawing.Size(298, 231);
			this.PGDataGroup.TabIndex = 3;
			// 
			// PGTimeSlider
			// 
			this.PGTimeSlider.Location = new System.Drawing.Point(13, 173);
			this.PGTimeSlider.Maximum = 20;
			this.PGTimeSlider.Name = "PGTimeSlider";
			this.PGTimeSlider.Size = new System.Drawing.Size(272, 45);
			this.PGTimeSlider.TabIndex = 6;
			this.PGTimeSlider.TickFrequency = 5;
			this.PGTimeSlider.Value = 20;
			this.PGTimeSlider.Scroll += new System.EventHandler(this.PGTimeSlider_Scroll);
			// 
			// PGTimeSliderLabel
			// 
			this.PGTimeSliderLabel.AutoSize = true;
			this.PGTimeSliderLabel.ForeColor = System.Drawing.Color.White;
			this.PGTimeSliderLabel.Location = new System.Drawing.Point(110, 145);
			this.PGTimeSliderLabel.Margin = new System.Windows.Forms.Padding(8);
			this.PGTimeSliderLabel.Name = "PGTimeSliderLabel";
			this.PGTimeSliderLabel.Size = new System.Drawing.Size(79, 17);
			this.PGTimeSliderLabel.TabIndex = 5;
			this.PGTimeSliderLabel.Text = "Time Slider";
			// 
			// PGSuccessValueLabel
			// 
			this.PGSuccessValueLabel.AutoSize = true;
			this.PGSuccessValueLabel.ForeColor = System.Drawing.Color.White;
			this.PGSuccessValueLabel.Location = new System.Drawing.Point(18, 51);
			this.PGSuccessValueLabel.Margin = new System.Windows.Forms.Padding(8);
			this.PGSuccessValueLabel.Name = "PGSuccessValueLabel";
			this.PGSuccessValueLabel.Size = new System.Drawing.Size(85, 17);
			this.PGSuccessValueLabel.TabIndex = 4;
			this.PGSuccessValueLabel.Text = "% Growth = ";
			// 
			// PGRatioValueLabel
			// 
			this.PGRatioValueLabel.AutoSize = true;
			this.PGRatioValueLabel.ForeColor = System.Drawing.Color.White;
			this.PGRatioValueLabel.Location = new System.Drawing.Point(18, 84);
			this.PGRatioValueLabel.Margin = new System.Windows.Forms.Padding(8);
			this.PGRatioValueLabel.Name = "PGRatioValueLabel";
			this.PGRatioValueLabel.Size = new System.Drawing.Size(45, 17);
			this.PGRatioValueLabel.TabIndex = 3;
			this.PGRatioValueLabel.Text = "P/Γ = ";
			// 
			// PGProbValueLabel
			// 
			this.PGProbValueLabel.AutoSize = true;
			this.PGProbValueLabel.ForeColor = System.Drawing.Color.White;
			this.PGProbValueLabel.Location = new System.Drawing.Point(18, 18);
			this.PGProbValueLabel.Margin = new System.Windows.Forms.Padding(8);
			this.PGProbValueLabel.Name = "PGProbValueLabel";
			this.PGProbValueLabel.Size = new System.Drawing.Size(33, 17);
			this.PGProbValueLabel.TabIndex = 2;
			this.PGProbValueLabel.Text = "P = ";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.PGDataResetButton);
			this.panel2.Location = new System.Drawing.Point(30, 301);
			this.panel2.Margin = new System.Windows.Forms.Padding(20);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(10);
			this.panel2.Size = new System.Drawing.Size(298, 71);
			this.panel2.TabIndex = 10;
			// 
			// PGDataResetButton
			// 
			this.PGDataResetButton.Location = new System.Drawing.Point(13, 13);
			this.PGDataResetButton.Name = "PGDataResetButton";
			this.PGDataResetButton.Size = new System.Drawing.Size(272, 45);
			this.PGDataResetButton.TabIndex = 0;
			this.PGDataResetButton.Text = "Reset Data";
			this.PGDataResetButton.UseVisualStyleBackColor = true;
			this.PGDataResetButton.Click += new System.EventHandler(this.PGDataResetButton_Click);
			// 
			// CCAnalyticsTab
			// 
			this.CCAnalyticsTab.Controls.Add(this.CCFlowLayoutPanel);
			this.CCAnalyticsTab.Controls.Add(this.CCGraph);
			this.CCAnalyticsTab.Location = new System.Drawing.Point(4, 25);
			this.CCAnalyticsTab.Name = "CCAnalyticsTab";
			this.CCAnalyticsTab.Size = new System.Drawing.Size(855, 992);
			this.CCAnalyticsTab.TabIndex = 3;
			this.CCAnalyticsTab.Text = "Cross Correlation";
			this.CCAnalyticsTab.UseVisualStyleBackColor = true;
			// 
			// CCFlowLayoutPanel
			// 
			this.CCFlowLayoutPanel.AutoScroll = true;
			this.CCFlowLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(75)))));
			this.CCFlowLayoutPanel.Controls.Add(this.SlidingDotGroup);
			this.CCFlowLayoutPanel.Controls.Add(this.ConvolutionGroup);
			this.CCFlowLayoutPanel.Controls.Add(this.panel3);
			this.CCFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CCFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.CCFlowLayoutPanel.Name = "CCFlowLayoutPanel";
			this.CCFlowLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
			this.CCFlowLayoutPanel.Size = new System.Drawing.Size(855, 543);
			this.CCFlowLayoutPanel.TabIndex = 44;
			// 
			// SlidingDotGroup
			// 
			this.SlidingDotGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
			this.SlidingDotGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.SlidingDotGroup.Controls.Add(this.SDPShowRegionCheckbox);
			this.SlidingDotGroup.Controls.Add(this.SDPRegionHLabel);
			this.SlidingDotGroup.Controls.Add(this.SDPRegionWLabel);
			this.SlidingDotGroup.Controls.Add(this.SDPRegionYLabel);
			this.SlidingDotGroup.Controls.Add(this.SDPRegionXLabel);
			this.SlidingDotGroup.Controls.Add(this.SDPRegionHValue);
			this.SlidingDotGroup.Controls.Add(this.SDPRegionWValue);
			this.SlidingDotGroup.Controls.Add(this.SDPRegionYValue);
			this.SlidingDotGroup.Controls.Add(this.SDPRegionXValue);
			this.SlidingDotGroup.Controls.Add(this.SDPOffsetValue);
			this.SlidingDotGroup.Controls.Add(this.SDPOffsetLabel);
			this.SlidingDotGroup.Controls.Add(this.SlidingDotStartButton);
			this.SlidingDotGroup.Controls.Add(this.SlidingDotLabel);
			this.SlidingDotGroup.Location = new System.Drawing.Point(30, 30);
			this.SlidingDotGroup.Margin = new System.Windows.Forms.Padding(20);
			this.SlidingDotGroup.Name = "SlidingDotGroup";
			this.SlidingDotGroup.Padding = new System.Windows.Forms.Padding(20);
			this.SlidingDotGroup.Size = new System.Drawing.Size(336, 255);
			this.SlidingDotGroup.TabIndex = 42;
			// 
			// SDPShowRegionCheckbox
			// 
			this.SDPShowRegionCheckbox.AutoSize = true;
			this.SDPShowRegionCheckbox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.SDPShowRegionCheckbox.Location = new System.Drawing.Point(185, 123);
			this.SDPShowRegionCheckbox.Name = "SDPShowRegionCheckbox";
			this.SDPShowRegionCheckbox.Size = new System.Drawing.Size(105, 21);
			this.SDPShowRegionCheckbox.TabIndex = 52;
			this.SDPShowRegionCheckbox.Text = "Show region";
			this.SDPShowRegionCheckbox.UseVisualStyleBackColor = true;
			this.SDPShowRegionCheckbox.CheckedChanged += new System.EventHandler(this.SDPShowRegionCheckbox_CheckedChanged);
			// 
			// SDPRegionHLabel
			// 
			this.SDPRegionHLabel.AutoSize = true;
			this.SDPRegionHLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.SDPRegionHLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.SDPRegionHLabel.Location = new System.Drawing.Point(182, 94);
			this.SDPRegionHLabel.Name = "SDPRegionHLabel";
			this.SDPRegionHLabel.Size = new System.Drawing.Size(16, 17);
			this.SDPRegionHLabel.TabIndex = 51;
			this.SDPRegionHLabel.Text = "h";
			this.SDPRegionHLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// SDPRegionWLabel
			// 
			this.SDPRegionWLabel.AutoSize = true;
			this.SDPRegionWLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.SDPRegionWLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.SDPRegionWLabel.Location = new System.Drawing.Point(182, 65);
			this.SDPRegionWLabel.Name = "SDPRegionWLabel";
			this.SDPRegionWLabel.Size = new System.Drawing.Size(17, 17);
			this.SDPRegionWLabel.TabIndex = 50;
			this.SDPRegionWLabel.Text = "w";
			this.SDPRegionWLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// SDPRegionYLabel
			// 
			this.SDPRegionYLabel.AutoSize = true;
			this.SDPRegionYLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.SDPRegionYLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.SDPRegionYLabel.Location = new System.Drawing.Point(53, 94);
			this.SDPRegionYLabel.Name = "SDPRegionYLabel";
			this.SDPRegionYLabel.Size = new System.Drawing.Size(15, 17);
			this.SDPRegionYLabel.TabIndex = 49;
			this.SDPRegionYLabel.Text = "y";
			this.SDPRegionYLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// SDPRegionXLabel
			// 
			this.SDPRegionXLabel.AutoSize = true;
			this.SDPRegionXLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.SDPRegionXLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.SDPRegionXLabel.Location = new System.Drawing.Point(53, 65);
			this.SDPRegionXLabel.Name = "SDPRegionXLabel";
			this.SDPRegionXLabel.Size = new System.Drawing.Size(14, 17);
			this.SDPRegionXLabel.TabIndex = 48;
			this.SDPRegionXLabel.Text = "x";
			this.SDPRegionXLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// SDPRegionHValue
			// 
			this.SDPRegionHValue.Location = new System.Drawing.Point(225, 92);
			this.SDPRegionHValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.SDPRegionHValue.Name = "SDPRegionHValue";
			this.SDPRegionHValue.Size = new System.Drawing.Size(65, 23);
			this.SDPRegionHValue.TabIndex = 47;
			this.SDPRegionHValue.ValueChanged += new System.EventHandler(this.SDPRegionHValue_ValueChanged);
			// 
			// SDPRegionWValue
			// 
			this.SDPRegionWValue.Location = new System.Drawing.Point(225, 63);
			this.SDPRegionWValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.SDPRegionWValue.Name = "SDPRegionWValue";
			this.SDPRegionWValue.Size = new System.Drawing.Size(65, 23);
			this.SDPRegionWValue.TabIndex = 46;
			this.SDPRegionWValue.ValueChanged += new System.EventHandler(this.SDPRegionWValue_ValueChanged);
			// 
			// SDPRegionYValue
			// 
			this.SDPRegionYValue.Location = new System.Drawing.Point(88, 92);
			this.SDPRegionYValue.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
			this.SDPRegionYValue.Minimum = new decimal(new int[] {
            400,
            0,
            0,
            -2147483648});
			this.SDPRegionYValue.Name = "SDPRegionYValue";
			this.SDPRegionYValue.Size = new System.Drawing.Size(65, 23);
			this.SDPRegionYValue.TabIndex = 45;
			this.SDPRegionYValue.ValueChanged += new System.EventHandler(this.SDPRegionYValue_ValueChanged);
			// 
			// SDPRegionXValue
			// 
			this.SDPRegionXValue.Location = new System.Drawing.Point(88, 63);
			this.SDPRegionXValue.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
			this.SDPRegionXValue.Minimum = new decimal(new int[] {
            400,
            0,
            0,
            -2147483648});
			this.SDPRegionXValue.Name = "SDPRegionXValue";
			this.SDPRegionXValue.Size = new System.Drawing.Size(65, 23);
			this.SDPRegionXValue.TabIndex = 44;
			this.SDPRegionXValue.ValueChanged += new System.EventHandler(this.SDPRegionXValue_ValueChanged);
			// 
			// SDPOffsetValue
			// 
			this.SDPOffsetValue.Location = new System.Drawing.Point(88, 121);
			this.SDPOffsetValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.SDPOffsetValue.Name = "SDPOffsetValue";
			this.SDPOffsetValue.Size = new System.Drawing.Size(65, 23);
			this.SDPOffsetValue.TabIndex = 43;
			this.SDPOffsetValue.ValueChanged += new System.EventHandler(this.SDPOffsetValue_ValueChanged);
			// 
			// SDPOffsetLabel
			// 
			this.SDPOffsetLabel.AutoSize = true;
			this.SDPOffsetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.SDPOffsetLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.SDPOffsetLabel.Location = new System.Drawing.Point(36, 123);
			this.SDPOffsetLabel.Name = "SDPOffsetLabel";
			this.SDPOffsetLabel.Size = new System.Drawing.Size(46, 17);
			this.SDPOffsetLabel.TabIndex = 42;
			this.SDPOffsetLabel.Text = "Offset";
			this.SDPOffsetLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// SlidingDotStartButton
			// 
			this.SlidingDotStartButton.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.SlidingDotStartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.SlidingDotStartButton.Location = new System.Drawing.Point(20, 193);
			this.SlidingDotStartButton.Name = "SlidingDotStartButton";
			this.SlidingDotStartButton.Size = new System.Drawing.Size(294, 40);
			this.SlidingDotStartButton.TabIndex = 34;
			this.SlidingDotStartButton.Text = "Start";
			this.SlidingDotStartButton.UseVisualStyleBackColor = true;
			this.SlidingDotStartButton.Click += new System.EventHandler(this.SlidingDotStartButton_Click);
			// 
			// SlidingDotLabel
			// 
			this.SlidingDotLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.SlidingDotLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.SlidingDotLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.SlidingDotLabel.Location = new System.Drawing.Point(20, 20);
			this.SlidingDotLabel.Name = "SlidingDotLabel";
			this.SlidingDotLabel.Size = new System.Drawing.Size(294, 17);
			this.SlidingDotLabel.TabIndex = 28;
			this.SlidingDotLabel.Text = "Sliding Dot Product";
			this.SlidingDotLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// ConvolutionGroup
			// 
			this.ConvolutionGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
			this.ConvolutionGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ConvolutionGroup.Controls.Add(this.ConvolveBrightnessLabel);
			this.ConvolutionGroup.Controls.Add(this.ConvolveBrightnessBar);
			this.ConvolutionGroup.Controls.Add(this.ConvolveButton);
			this.ConvolutionGroup.Controls.Add(this.ShowConvolveCheckbox);
			this.ConvolutionGroup.Controls.Add(this.StDevValue);
			this.ConvolutionGroup.Controls.Add(this.StDevLabel);
			this.ConvolutionGroup.Controls.Add(this.ConvolutionLabel);
			this.ConvolutionGroup.Location = new System.Drawing.Point(406, 30);
			this.ConvolutionGroup.Margin = new System.Windows.Forms.Padding(20);
			this.ConvolutionGroup.Name = "ConvolutionGroup";
			this.ConvolutionGroup.Padding = new System.Windows.Forms.Padding(20);
			this.ConvolutionGroup.Size = new System.Drawing.Size(336, 255);
			this.ConvolutionGroup.TabIndex = 43;
			// 
			// ConvolveBrightnessLabel
			// 
			this.ConvolveBrightnessLabel.AutoSize = true;
			this.ConvolveBrightnessLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.ConvolveBrightnessLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.ConvolveBrightnessLabel.Location = new System.Drawing.Point(42, 148);
			this.ConvolveBrightnessLabel.Name = "ConvolveBrightnessLabel";
			this.ConvolveBrightnessLabel.Size = new System.Drawing.Size(75, 17);
			this.ConvolveBrightnessLabel.TabIndex = 41;
			this.ConvolveBrightnessLabel.Text = "Brightness";
			this.ConvolveBrightnessLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// ConvolveBrightnessBar
			// 
			this.ConvolveBrightnessBar.Location = new System.Drawing.Point(114, 148);
			this.ConvolveBrightnessBar.Maximum = 50;
			this.ConvolveBrightnessBar.Minimum = 10;
			this.ConvolveBrightnessBar.Name = "ConvolveBrightnessBar";
			this.ConvolveBrightnessBar.Size = new System.Drawing.Size(197, 45);
			this.ConvolveBrightnessBar.TabIndex = 40;
			this.ConvolveBrightnessBar.TickStyle = System.Windows.Forms.TickStyle.None;
			this.ConvolveBrightnessBar.Value = 10;
			this.ConvolveBrightnessBar.Scroll += new System.EventHandler(this.ConvolveBrightnessBar_Scroll);
			// 
			// ConvolveButton
			// 
			this.ConvolveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.ConvolveButton.Location = new System.Drawing.Point(102, 91);
			this.ConvolveButton.Name = "ConvolveButton";
			this.ConvolveButton.Size = new System.Drawing.Size(131, 40);
			this.ConvolveButton.TabIndex = 37;
			this.ConvolveButton.Text = "Convolve";
			this.ConvolveButton.UseVisualStyleBackColor = true;
			this.ConvolveButton.Click += new System.EventHandler(this.ConvolveButton_Click);
			// 
			// ShowConvolveCheckbox
			// 
			this.ShowConvolveCheckbox.AutoSize = true;
			this.ShowConvolveCheckbox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.ShowConvolveCheckbox.Location = new System.Drawing.Point(45, 199);
			this.ShowConvolveCheckbox.Name = "ShowConvolveCheckbox";
			this.ShowConvolveCheckbox.Size = new System.Drawing.Size(177, 21);
			this.ShowConvolveCheckbox.TabIndex = 39;
			this.ShowConvolveCheckbox.Text = "Show Convolved Lattice";
			this.ShowConvolveCheckbox.UseVisualStyleBackColor = true;
			this.ShowConvolveCheckbox.CheckedChanged += new System.EventHandler(this.ShowConvolveCheckbox_CheckedChanged);
			// 
			// StDevValue
			// 
			this.StDevValue.Location = new System.Drawing.Point(114, 54);
			this.StDevValue.Maximum = 100;
			this.StDevValue.Name = "StDevValue";
			this.StDevValue.Size = new System.Drawing.Size(197, 45);
			this.StDevValue.TabIndex = 38;
			this.StDevValue.TickStyle = System.Windows.Forms.TickStyle.None;
			this.StDevValue.Value = 20;
			this.StDevValue.Scroll += new System.EventHandler(this.StDevValue_Scroll);
			// 
			// StDevLabel
			// 
			this.StDevLabel.AutoSize = true;
			this.StDevLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.StDevLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.StDevLabel.Location = new System.Drawing.Point(42, 54);
			this.StDevLabel.Name = "StDevLabel";
			this.StDevLabel.Size = new System.Drawing.Size(40, 17);
			this.StDevLabel.TabIndex = 37;
			this.StDevLabel.Text = "σ = 1";
			this.StDevLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// ConvolutionLabel
			// 
			this.ConvolutionLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.ConvolutionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.ConvolutionLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.ConvolutionLabel.Location = new System.Drawing.Point(20, 20);
			this.ConvolutionLabel.Name = "ConvolutionLabel";
			this.ConvolutionLabel.Size = new System.Drawing.Size(294, 17);
			this.ConvolutionLabel.TabIndex = 37;
			this.ConvolutionLabel.Text = "Gaussian Convolution";
			this.ConvolutionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel3
			// 
			this.panel3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.SDPAutoRangeCheckbox);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Controls.Add(this.SDPDomainStartLabel);
			this.panel3.Controls.Add(this.SDPDomainStartCounter);
			this.panel3.Controls.Add(this.SDPDomainEndCounter);
			this.panel3.Controls.Add(this.SDPDomainEndLabel);
			this.panel3.Location = new System.Drawing.Point(30, 325);
			this.panel3.Margin = new System.Windows.Forms.Padding(20);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(20);
			this.panel3.Size = new System.Drawing.Size(312, 195);
			this.panel3.TabIndex = 43;
			// 
			// SDPAutoRangeCheckbox
			// 
			this.SDPAutoRangeCheckbox.AutoSize = true;
			this.SDPAutoRangeCheckbox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.SDPAutoRangeCheckbox.Location = new System.Drawing.Point(56, 146);
			this.SDPAutoRangeCheckbox.Name = "SDPAutoRangeCheckbox";
			this.SDPAutoRangeCheckbox.Size = new System.Drawing.Size(140, 21);
			this.SDPAutoRangeCheckbox.TabIndex = 42;
			this.SDPAutoRangeCheckbox.Text = "Auto-adjust range";
			this.SDPAutoRangeCheckbox.UseVisualStyleBackColor = true;
			this.SDPAutoRangeCheckbox.CheckedChanged += new System.EventHandler(this.SDPAutoRangeCheckbox_CheckedChanged);
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Top;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.label3.Location = new System.Drawing.Point(20, 20);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(270, 17);
			this.label3.TabIndex = 28;
			this.label3.Text = "Graph properties";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// SDPDomainStartLabel
			// 
			this.SDPDomainStartLabel.AutoSize = true;
			this.SDPDomainStartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.SDPDomainStartLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.SDPDomainStartLabel.Location = new System.Drawing.Point(53, 66);
			this.SDPDomainStartLabel.Name = "SDPDomainStartLabel";
			this.SDPDomainStartLabel.Size = new System.Drawing.Size(82, 17);
			this.SDPDomainStartLabel.TabIndex = 38;
			this.SDPDomainStartLabel.Text = "Domain Min";
			this.SDPDomainStartLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// SDPDomainStartCounter
			// 
			this.SDPDomainStartCounter.Location = new System.Drawing.Point(185, 64);
			this.SDPDomainStartCounter.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.SDPDomainStartCounter.Name = "SDPDomainStartCounter";
			this.SDPDomainStartCounter.Size = new System.Drawing.Size(65, 23);
			this.SDPDomainStartCounter.TabIndex = 37;
			this.SDPDomainStartCounter.ValueChanged += new System.EventHandler(this.SDPDomainStartCounter_ValueChanged);
			// 
			// SDPDomainEndCounter
			// 
			this.SDPDomainEndCounter.Location = new System.Drawing.Point(185, 101);
			this.SDPDomainEndCounter.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.SDPDomainEndCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.SDPDomainEndCounter.Name = "SDPDomainEndCounter";
			this.SDPDomainEndCounter.Size = new System.Drawing.Size(65, 23);
			this.SDPDomainEndCounter.TabIndex = 35;
			this.SDPDomainEndCounter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.SDPDomainEndCounter.ValueChanged += new System.EventHandler(this.SDPDomainEndCounter_ValueChanged);
			// 
			// SDPDomainEndLabel
			// 
			this.SDPDomainEndLabel.AutoSize = true;
			this.SDPDomainEndLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.SDPDomainEndLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.SDPDomainEndLabel.Location = new System.Drawing.Point(53, 103);
			this.SDPDomainEndLabel.Name = "SDPDomainEndLabel";
			this.SDPDomainEndLabel.Size = new System.Drawing.Size(85, 17);
			this.SDPDomainEndLabel.TabIndex = 36;
			this.SDPDomainEndLabel.Text = "Domain Max";
			this.SDPDomainEndLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// CCGraph
			// 
			this.CCGraph.BorderlineColor = System.Drawing.Color.Black;
			this.CCGraph.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			this.CCGraph.BorderlineWidth = 5;
			chartArea2.Area3DStyle.Inclination = 0;
			chartArea2.Area3DStyle.IsRightAngleAxes = false;
			chartArea2.Area3DStyle.Rotation = 45;
			chartArea2.AxisX.IsMarginVisible = false;
			chartArea2.AxisX.MajorGrid.Enabled = false;
			chartArea2.AxisX.Title = "X";
			chartArea2.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			chartArea2.AxisY.MajorGrid.Enabled = false;
			chartArea2.AxisY.Title = "Y";
			chartArea2.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			chartArea2.Name = "ChartArea1";
			this.CCGraph.ChartAreas.Add(chartArea2);
			this.CCGraph.Dock = System.Windows.Forms.DockStyle.Bottom;
			legend2.Enabled = false;
			legend2.Name = "Legend1";
			this.CCGraph.Legends.Add(legend2);
			this.CCGraph.Location = new System.Drawing.Point(0, 543);
			this.CCGraph.Name = "CCGraph";
			series3.BorderWidth = 3;
			series3.ChartArea = "ChartArea1";
			series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series3.Legend = "Legend1";
			series3.MarkerColor = System.Drawing.Color.Black;
			series3.MarkerSize = 0;
			series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
			series3.Name = "Series1";
			series4.BorderWidth = 3;
			series4.ChartArea = "ChartArea1";
			series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series4.Legend = "Legend1";
			series4.MarkerSize = 0;
			series4.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
			series4.Name = "Series2";
			this.CCGraph.Series.Add(series3);
			this.CCGraph.Series.Add(series4);
			this.CCGraph.Size = new System.Drawing.Size(855, 449);
			this.CCGraph.TabIndex = 43;
			this.CCGraph.Text = "chart1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1904, 1041);
			this.Controls.Add(this.splitPanel);
			this.KeyPreview = true;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Square Lattice 2D v2";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
			((System.ComponentModel.ISupportInitialize)(this.stepCounter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.yProbValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xProbValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xProbBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.yProbBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
			this.probGroup.ResumeLayout(false);
			this.probGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.LatSizeValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gammaValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gammaBar)).EndInit();
			this.playGroup.ResumeLayout(false);
			this.playGroup.PerformLayout();
			this.splitPanel.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitPanel)).EndInit();
			this.splitPanel.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.ParamsTab.ResumeLayout(false);
			this.ParamsFlowLayout.ResumeLayout(false);
			this.zoomGroup.ResumeLayout(false);
			this.zoomGroup.PerformLayout();
			this.ExportGroup.ResumeLayout(false);
			this.ExportGroup.PerformLayout();
			this.AnalyticsTab.ResumeLayout(false);
			this.AnalyticsFlowLayout.ResumeLayout(false);
			this.IndVarPanel.ResumeLayout(false);
			this.IndVarPanel.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.Graph)).EndInit();
			this.PGAnalyticsTab.ResumeLayout(false);
			this.AnalyticsPGFlowLayout.ResumeLayout(false);
			this.PGParamGroup.ResumeLayout(false);
			this.PGParamGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PGRunNumberValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PGLatticeSizeValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PGSamplingValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PGGammaValue)).EndInit();
			this.PGDataGroup.ResumeLayout(false);
			this.PGDataGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PGTimeSlider)).EndInit();
			this.panel2.ResumeLayout(false);
			this.CCAnalyticsTab.ResumeLayout(false);
			this.CCFlowLayoutPanel.ResumeLayout(false);
			this.SlidingDotGroup.ResumeLayout(false);
			this.SlidingDotGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SDPRegionHValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SDPRegionWValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SDPRegionYValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SDPRegionXValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SDPOffsetValue)).EndInit();
			this.ConvolutionGroup.ResumeLayout(false);
			this.ConvolutionGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ConvolveBrightnessBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.StDevValue)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SDPDomainStartCounter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SDPDomainEndCounter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CCGraph)).EndInit();
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
		private System.Windows.Forms.FlowLayoutPanel ParamsFlowLayout;
		private System.Windows.Forms.Panel zoomGroup;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage ParamsTab;
		private System.Windows.Forms.Button GenerateButton;
		private System.Windows.Forms.Button skipToEndButton;
		private System.Windows.Forms.Button skipToBeginningButton;
		private System.Windows.Forms.RadioButton zoomButton4;
		private System.Windows.Forms.RadioButton zoomButton3;
		private System.Windows.Forms.RadioButton zoomButton2;
		private System.Windows.Forms.RadioButton zoomButton1;
		private System.Windows.Forms.Label zoomTitle;
		private System.Windows.Forms.Label gammaLabel;
		private System.Windows.Forms.NumericUpDown gammaValue;
		private System.Windows.Forms.TrackBar gammaBar;
        private System.Windows.Forms.Button HelpButton;
        private System.Windows.Forms.Label initTitle;
		private System.Windows.Forms.Label LatSizeLabel;
		private System.Windows.Forms.NumericUpDown LatSizeValue;
		private System.Windows.Forms.Panel ExportGroup;
		private System.Windows.Forms.ComboBox FpsChooser;
		private System.Windows.Forms.Label FpsLabel;
		private System.Windows.Forms.Label ExportLabel;
		private System.Windows.Forms.Button ExportButton;
		private System.Windows.Forms.ComboBox ResChooser;
		private System.Windows.Forms.Label ResolutionLabel;
		private System.Windows.Forms.TabPage AnalyticsTab;
		private System.Windows.Forms.DataVisualization.Charting.Chart Graph;
		private System.Windows.Forms.Label MouseLabel;
		private System.Windows.Forms.Button AnalysisStartButton;
		private System.Windows.Forms.FlowLayoutPanel AnalyticsFlowLayout;
		private System.Windows.Forms.Panel IndVarPanel;
		private System.Windows.Forms.ComboBox TimePeriodChooser;
		private System.Windows.Forms.Label SampPeriodLabel;
		private System.Windows.Forms.ComboBox IndVarChooser;
		private System.Windows.Forms.Label TightnessLabel;
		private System.Windows.Forms.Label IndVarLabel;
		private System.Windows.Forms.ComboBox TightnessChooser;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ComboBox DepVarChooser;
		private System.Windows.Forms.Label DepVarLabel;
		private System.Windows.Forms.TabPage PGAnalyticsTab;
		private System.Windows.Forms.FlowLayoutPanel AnalyticsPGFlowLayout;
		private System.Windows.Forms.Panel PGParamGroup;
		private System.Windows.Forms.Label PGSampleLabel;
		private System.Windows.Forms.Button PGAnalysisButton;
		private System.Windows.Forms.Button PGDomainResetButton;
		private System.Windows.Forms.Panel PGDataGroup;
		private System.Windows.Forms.Label PGProbValueLabel;
		private System.Windows.Forms.Label PGSetGammaLabel;
		private System.Windows.Forms.Label PGSuccessValueLabel;
		private System.Windows.Forms.Label PGRatioValueLabel;
		private System.Windows.Forms.NumericUpDown PGLatticeSizeValue;
		private System.Windows.Forms.Label PGLatticeSizeLabel;
		private System.Windows.Forms.NumericUpDown PGSamplingValue;
		private System.Windows.Forms.NumericUpDown PGGammaValue;
		private System.Windows.Forms.TrackBar PGTimeSlider;
		private System.Windows.Forms.Label PGTimeSliderLabel;
		private System.Windows.Forms.NumericUpDown PGRunNumberValue;
		private System.Windows.Forms.Label PGRunNumberLabel;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button PGDataResetButton;
		private System.Windows.Forms.Button GenerateFullButton;
		private System.Windows.Forms.TabPage CCAnalyticsTab;
		private System.Windows.Forms.FlowLayoutPanel CCFlowLayoutPanel;
		private System.Windows.Forms.Panel SlidingDotGroup;
		private System.Windows.Forms.Button SlidingDotStartButton;
		private System.Windows.Forms.Label SlidingDotLabel;
		private System.Windows.Forms.Panel ConvolutionGroup;
		private System.Windows.Forms.DataVisualization.Charting.Chart CCGraph;
		private System.Windows.Forms.Label SDPDomainEndLabel;
		private System.Windows.Forms.NumericUpDown SDPDomainEndCounter;
		private System.Windows.Forms.TrackBar StDevValue;
		private System.Windows.Forms.Label StDevLabel;
		private System.Windows.Forms.Label ConvolutionLabel;
		private System.Windows.Forms.Button ConvolveButton;
		private System.Windows.Forms.CheckBox ShowConvolveCheckbox;
		private System.Windows.Forms.Label ConvolveBrightnessLabel;
		private System.Windows.Forms.TrackBar ConvolveBrightnessBar;
		private System.Windows.Forms.Label SDPDomainStartLabel;
		private System.Windows.Forms.NumericUpDown SDPDomainStartCounter;
		private System.Windows.Forms.CheckBox SDPAutoRangeCheckbox;
		private System.Windows.Forms.NumericUpDown SDPOffsetValue;
		private System.Windows.Forms.Label SDPOffsetLabel;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label SDPRegionHLabel;
		private System.Windows.Forms.Label SDPRegionWLabel;
		private System.Windows.Forms.Label SDPRegionYLabel;
		private System.Windows.Forms.Label SDPRegionXLabel;
		private System.Windows.Forms.NumericUpDown SDPRegionHValue;
		private System.Windows.Forms.NumericUpDown SDPRegionWValue;
		private System.Windows.Forms.NumericUpDown SDPRegionYValue;
		private System.Windows.Forms.NumericUpDown SDPRegionXValue;
		private System.Windows.Forms.CheckBox SDPShowRegionCheckbox;
		private System.Windows.Forms.Button ShowPerimButton;
	}
}

