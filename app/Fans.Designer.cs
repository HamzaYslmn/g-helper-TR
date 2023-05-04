﻿using CustomControls;
using System.Windows.Forms.DataVisualization.Charting;

namespace GHelper
{
    partial class Fans
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
            ChartArea chartArea4 = new ChartArea();
            Title title4 = new Title();
            ChartArea chartArea5 = new ChartArea();
            Title title5 = new Title();
            ChartArea chartArea6 = new ChartArea();
            Title title6 = new Title();
            panelFans = new Panel();
            labelFansResult = new Label();
            labelTip = new Label();
            labelBoost = new Label();
            comboBoost = new RComboBox();
            picturePerf = new PictureBox();
            tableFanCharts = new TableLayoutPanel();
            chartGPU = new Chart();
            chartCPU = new Chart();
            chartMid = new Chart();
            labelFans = new Label();
            checkApplyFans = new RCheckBox();
            buttonReset = new RButton();
            panelPower = new Panel();
            pictureBox1 = new PictureBox();
            labelPowerLimits = new Label();
            checkApplyPower = new RCheckBox();
            panelCPU = new Panel();
            labelCPU = new Label();
            label2 = new Label();
            trackCPU = new TrackBar();
            panelTotal = new Panel();
            labelTotal = new Label();
            labelPlatform = new Label();
            trackTotal = new TrackBar();
            pictureFine = new PictureBox();
            labelInfo = new Label();
            panelGPU = new Panel();
            buttonResetGPU = new RButton();
            labelGPUMemory = new Label();
            trackGPUMemory = new TrackBar();
            labelGPUMemoryTitle = new Label();
            pictureBox2 = new PictureBox();
            labelGPUCore = new Label();
            labelGPU = new Label();
            trackGPUCore = new TrackBar();
            labelGPUCoreTitle = new Label();
            panelFans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picturePerf).BeginInit();
            tableFanCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartGPU).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartCPU).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartMid).BeginInit();
            panelPower.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelCPU.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackCPU).BeginInit();
            panelTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackTotal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureFine).BeginInit();
            panelGPU.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackGPUMemory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackGPUCore).BeginInit();
            SuspendLayout();
            // 
            // panelFans
            // 
            panelFans.Controls.Add(labelFansResult);
            panelFans.Controls.Add(labelTip);
            panelFans.Controls.Add(labelBoost);
            panelFans.Controls.Add(comboBoost);
            panelFans.Controls.Add(picturePerf);
            panelFans.Controls.Add(tableFanCharts);
            panelFans.Controls.Add(labelFans);
            panelFans.Controls.Add(checkApplyFans);
            panelFans.Controls.Add(buttonReset);
            panelFans.Dock = DockStyle.Left;
            panelFans.Location = new Point(364, 0);
            panelFans.Margin = new Padding(0);
            panelFans.Name = "panelFans";
            panelFans.Padding = new Padding(10);
            panelFans.Size = new Size(824, 1189);
            panelFans.TabIndex = 12;
            // 
            // labelFansResult
            // 
            labelFansResult.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelFansResult.ForeColor = Color.Red;
            labelFansResult.Location = new Point(30, 1073);
            labelFansResult.Name = "labelFansResult";
            labelFansResult.Size = new Size(760, 32);
            labelFansResult.TabIndex = 41;
            labelFansResult.TextAlign = ContentAlignment.TopRight;
            labelFansResult.Visible = false;
            // 
            // labelTip
            // 
            labelTip.AutoSize = true;
            labelTip.BackColor = SystemColors.ControlLightLight;
            labelTip.Location = new Point(155, 9);
            labelTip.Name = "labelTip";
            labelTip.Padding = new Padding(5);
            labelTip.Size = new Size(107, 42);
            labelTip.TabIndex = 40;
            labelTip.Text = "500,300";
            // 
            // labelBoost
            // 
            labelBoost.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelBoost.AutoSize = true;
            labelBoost.Location = new Point(375, 17);
            labelBoost.Name = "labelBoost";
            labelBoost.Size = new Size(125, 32);
            labelBoost.TabIndex = 39;
            labelBoost.Text = "CPU Boost";
            labelBoost.TextAlign = ContentAlignment.MiddleRight;
            // 
            // comboBoost
            // 
            comboBoost.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoost.BorderColor = Color.White;
            comboBoost.ButtonColor = Color.FromArgb(255, 255, 255);
            comboBoost.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoost.FormattingEnabled = true;
            comboBoost.Items.AddRange(new object[] { "Disabled", "Enabled", "Aggressive", "Efficient Enabled", "Efficient Aggressive" });
            comboBoost.Location = new Point(526, 15);
            comboBoost.Name = "comboBoost";
            comboBoost.Size = new Size(266, 40);
            comboBoost.TabIndex = 38;
            // 
            // picturePerf
            // 
            picturePerf.BackgroundImage = Properties.Resources.icons8_fan_head_96;
            picturePerf.BackgroundImageLayout = ImageLayout.Zoom;
            picturePerf.InitialImage = null;
            picturePerf.Location = new Point(30, 18);
            picturePerf.Margin = new Padding(4, 2, 4, 2);
            picturePerf.Name = "picturePerf";
            picturePerf.Size = new Size(36, 38);
            picturePerf.TabIndex = 37;
            picturePerf.TabStop = false;
            // 
            // tableFanCharts
            // 
            tableFanCharts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableFanCharts.ColumnCount = 1;
            tableFanCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableFanCharts.Controls.Add(chartGPU, 0, 1);
            tableFanCharts.Controls.Add(chartCPU, 0, 0);
            tableFanCharts.Controls.Add(chartMid, 0, 2);
            tableFanCharts.Location = new Point(28, 64);
            tableFanCharts.Margin = new Padding(4);
            tableFanCharts.Name = "tableFanCharts";
            tableFanCharts.RowCount = 2;
            tableFanCharts.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            tableFanCharts.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            tableFanCharts.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            tableFanCharts.Size = new Size(764, 1022);
            tableFanCharts.TabIndex = 36;
            // 
            // chartGPU
            // 
            chartArea4.Name = "ChartArea1";
            chartGPU.ChartAreas.Add(chartArea4);
            chartGPU.Dock = DockStyle.Fill;
            chartGPU.Location = new Point(2, 350);
            chartGPU.Margin = new Padding(2, 10, 2, 10);
            chartGPU.Name = "chartGPU";
            chartGPU.Size = new Size(760, 320);
            chartGPU.TabIndex = 17;
            chartGPU.Text = "chartGPU";
            title4.Name = "Title1";
            chartGPU.Titles.Add(title4);
            // 
            // chartCPU
            // 
            chartArea5.Name = "ChartArea1";
            chartCPU.ChartAreas.Add(chartArea5);
            chartCPU.Dock = DockStyle.Fill;
            chartCPU.Location = new Point(2, 10);
            chartCPU.Margin = new Padding(2, 10, 2, 10);
            chartCPU.Name = "chartCPU";
            chartCPU.Size = new Size(760, 320);
            chartCPU.TabIndex = 14;
            chartCPU.Text = "chartCPU";
            title5.Name = "Title1";
            chartCPU.Titles.Add(title5);
            // 
            // chartMid
            // 
            chartArea6.Name = "ChartArea3";
            chartMid.ChartAreas.Add(chartArea6);
            chartMid.Dock = DockStyle.Fill;
            chartMid.Location = new Point(2, 690);
            chartMid.Margin = new Padding(2, 10, 2, 10);
            chartMid.Name = "chartMid";
            chartMid.Size = new Size(760, 322);
            chartMid.TabIndex = 14;
            chartMid.Text = "chartMid";
            title6.Name = "Title3";
            chartMid.Titles.Add(title6);
            chartMid.Visible = false;
            // 
            // labelFans
            // 
            labelFans.AutoSize = true;
            labelFans.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelFans.Location = new Point(66, 20);
            labelFans.Margin = new Padding(4, 0, 4, 0);
            labelFans.Name = "labelFans";
            labelFans.Size = new Size(138, 32);
            labelFans.TabIndex = 28;
            labelFans.Text = "Fan Curves";
            // 
            // checkApplyFans
            // 
            checkApplyFans.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            checkApplyFans.AutoSize = true;
            checkApplyFans.BackColor = SystemColors.ControlLight;
            checkApplyFans.Location = new Point(449, 1118);
            checkApplyFans.Margin = new Padding(4, 2, 4, 2);
            checkApplyFans.Name = "checkApplyFans";
            checkApplyFans.Padding = new Padding(15, 5, 15, 5);
            checkApplyFans.Size = new Size(339, 46);
            checkApplyFans.TabIndex = 17;
            checkApplyFans.Text = Properties.Strings.ApplyFanCurve;
            checkApplyFans.UseVisualStyleBackColor = false;
            // 
            // buttonReset
            // 
            buttonReset.Activated = false;
            buttonReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonReset.BackColor = SystemColors.ControlLight;
            buttonReset.BorderColor = Color.Transparent;
            buttonReset.BorderRadius = 2;
            buttonReset.FlatStyle = FlatStyle.Flat;
            buttonReset.Location = new Point(30, 1112);
            buttonReset.Margin = new Padding(4, 2, 4, 2);
            buttonReset.Name = "buttonReset";
            buttonReset.Secondary = true;
            buttonReset.Size = new Size(232, 54);
            buttonReset.TabIndex = 15;
            buttonReset.Text = Properties.Strings.FactoryDefaults;
            buttonReset.UseVisualStyleBackColor = false;
            // 
            // panelPower
            // 
            panelPower.Controls.Add(pictureBox1);
            panelPower.Controls.Add(labelPowerLimits);
            panelPower.Controls.Add(checkApplyPower);
            panelPower.Controls.Add(panelCPU);
            panelPower.Controls.Add(panelTotal);
            panelPower.Controls.Add(pictureFine);
            panelPower.Controls.Add(labelInfo);
            panelPower.Dock = DockStyle.Left;
            panelPower.Location = new Point(0, 0);
            panelPower.Margin = new Padding(10);
            panelPower.Name = "panelPower";
            panelPower.Padding = new Padding(10);
            panelPower.Size = new Size(364, 1189);
            panelPower.TabIndex = 13;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.icons8_processor_96;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(20, 18);
            pictureBox1.Margin = new Padding(4, 2, 4, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(36, 38);
            pictureBox1.TabIndex = 38;
            pictureBox1.TabStop = false;
            // 
            // labelPowerLimits
            // 
            labelPowerLimits.AutoSize = true;
            labelPowerLimits.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelPowerLimits.Location = new Point(54, 20);
            labelPowerLimits.Margin = new Padding(4, 0, 4, 0);
            labelPowerLimits.Name = "labelPowerLimits";
            labelPowerLimits.Size = new Size(229, 32);
            labelPowerLimits.TabIndex = 26;
            labelPowerLimits.Text = "Power Limits (PPT)";
            // 
            // checkApplyPower
            // 
            checkApplyPower.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkApplyPower.AutoSize = true;
            checkApplyPower.BackColor = SystemColors.ControlLight;
            checkApplyPower.Location = new Point(20, 1118);
            checkApplyPower.Margin = new Padding(4, 2, 4, 2);
            checkApplyPower.Name = "checkApplyPower";
            checkApplyPower.Padding = new Padding(15, 5, 15, 5);
            checkApplyPower.Size = new Size(277, 46);
            checkApplyPower.TabIndex = 25;
            checkApplyPower.Text = Properties.Strings.ApplyPowerLimits;
            checkApplyPower.UseVisualStyleBackColor = false;
            // 
            // panelCPU
            // 
            panelCPU.Controls.Add(labelCPU);
            panelCPU.Controls.Add(label2);
            panelCPU.Controls.Add(trackCPU);
            panelCPU.Location = new Point(184, 72);
            panelCPU.Margin = new Padding(4);
            panelCPU.Name = "panelCPU";
            panelCPU.Size = new Size(160, 510);
            panelCPU.TabIndex = 23;
            // 
            // labelCPU
            // 
            labelCPU.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelCPU.Location = new Point(13, 40);
            labelCPU.Margin = new Padding(4, 0, 4, 0);
            labelCPU.Name = "labelCPU";
            labelCPU.Size = new Size(120, 32);
            labelCPU.TabIndex = 13;
            labelCPU.Text = "CPU";
            labelCPU.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 8);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(58, 32);
            label2.TabIndex = 12;
            label2.Text = "CPU";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // trackCPU
            // 
            trackCPU.Location = new Point(48, 88);
            trackCPU.Margin = new Padding(4, 2, 4, 2);
            trackCPU.Maximum = 85;
            trackCPU.Minimum = 5;
            trackCPU.Name = "trackCPU";
            trackCPU.Orientation = Orientation.Vertical;
            trackCPU.Size = new Size(90, 416);
            trackCPU.TabIndex = 11;
            trackCPU.TickFrequency = 5;
            trackCPU.Value = 80;
            // 
            // panelTotal
            // 
            panelTotal.Controls.Add(labelTotal);
            panelTotal.Controls.Add(labelPlatform);
            panelTotal.Controls.Add(trackTotal);
            panelTotal.Location = new Point(16, 72);
            panelTotal.Margin = new Padding(4);
            panelTotal.Name = "panelTotal";
            panelTotal.Size = new Size(160, 512);
            panelTotal.TabIndex = 22;
            // 
            // labelTotal
            // 
            labelTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelTotal.Location = new Point(16, 40);
            labelTotal.Margin = new Padding(4, 0, 4, 0);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(122, 32);
            labelTotal.TabIndex = 12;
            labelTotal.Text = "Platform";
            labelTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelPlatform
            // 
            labelPlatform.AutoSize = true;
            labelPlatform.Location = new Point(26, 8);
            labelPlatform.Margin = new Padding(4, 0, 4, 0);
            labelPlatform.Name = "labelPlatform";
            labelPlatform.Size = new Size(104, 32);
            labelPlatform.TabIndex = 11;
            labelPlatform.Text = "Platform";
            labelPlatform.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // trackTotal
            // 
            trackTotal.Location = new Point(44, 88);
            trackTotal.Margin = new Padding(4, 2, 4, 2);
            trackTotal.Maximum = 180;
            trackTotal.Minimum = 10;
            trackTotal.Name = "trackTotal";
            trackTotal.Orientation = Orientation.Vertical;
            trackTotal.Size = new Size(90, 416);
            trackTotal.TabIndex = 10;
            trackTotal.TickFrequency = 5;
            trackTotal.TickStyle = TickStyle.TopLeft;
            trackTotal.Value = 125;
            // 
            // pictureFine
            // 
            pictureFine.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureFine.BackgroundImageLayout = ImageLayout.Zoom;
            pictureFine.Image = Properties.Resources.everything_is_fine_itsfine;
            pictureFine.Location = new Point(20, 682);
            pictureFine.Margin = new Padding(4, 2, 4, 2);
            pictureFine.Name = "pictureFine";
            pictureFine.Size = new Size(324, 268);
            pictureFine.SizeMode = PictureBoxSizeMode.Zoom;
            pictureFine.TabIndex = 20;
            pictureFine.TabStop = false;
            pictureFine.Visible = false;
            // 
            // labelInfo
            // 
            labelInfo.Location = new Point(24, 618);
            labelInfo.Margin = new Padding(4, 0, 4, 0);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(320, 330);
            labelInfo.TabIndex = 19;
            labelInfo.Text = "label";
            // 
            // panelGPU
            // 
            panelGPU.Controls.Add(buttonResetGPU);
            panelGPU.Controls.Add(labelGPUMemory);
            panelGPU.Controls.Add(trackGPUMemory);
            panelGPU.Controls.Add(labelGPUMemoryTitle);
            panelGPU.Controls.Add(pictureBox2);
            panelGPU.Controls.Add(labelGPUCore);
            panelGPU.Controls.Add(labelGPU);
            panelGPU.Controls.Add(trackGPUCore);
            panelGPU.Controls.Add(labelGPUCoreTitle);
            panelGPU.Dock = DockStyle.Left;
            panelGPU.Location = new Point(1188, 0);
            panelGPU.Name = "panelGPU";
            panelGPU.Size = new Size(347, 1189);
            panelGPU.TabIndex = 14;
            // 
            // buttonResetGPU
            // 
            buttonResetGPU.Activated = false;
            buttonResetGPU.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonResetGPU.BackColor = SystemColors.ControlLight;
            buttonResetGPU.BorderColor = Color.Transparent;
            buttonResetGPU.BorderRadius = 2;
            buttonResetGPU.FlatStyle = FlatStyle.Flat;
            buttonResetGPU.Location = new Point(48, 1110);
            buttonResetGPU.Margin = new Padding(4, 2, 4, 2);
            buttonResetGPU.Name = "buttonResetGPU";
            buttonResetGPU.Secondary = true;
            buttonResetGPU.Size = new Size(232, 54);
            buttonResetGPU.TabIndex = 43;
            buttonResetGPU.Text = "Reset Clocks";
            buttonResetGPU.UseVisualStyleBackColor = false;
            // 
            // labelGPUMemory
            // 
            labelGPUMemory.AutoSize = true;
            labelGPUMemory.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelGPUMemory.Location = new Point(184, 112);
            labelGPUMemory.Name = "labelGPUMemory";
            labelGPUMemory.Size = new Size(130, 32);
            labelGPUMemory.TabIndex = 42;
            labelGPUMemory.Text = "2000 MHz";
            labelGPUMemory.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // trackGPUMemory
            // 
            trackGPUMemory.LargeChange = 100;
            trackGPUMemory.Location = new Point(216, 160);
            trackGPUMemory.Margin = new Padding(4, 2, 4, 2);
            trackGPUMemory.Maximum = 300;
            trackGPUMemory.Name = "trackGPUMemory";
            trackGPUMemory.Orientation = Orientation.Vertical;
            trackGPUMemory.Size = new Size(90, 454);
            trackGPUMemory.SmallChange = 10;
            trackGPUMemory.TabIndex = 41;
            trackGPUMemory.TickFrequency = 50;
            // 
            // labelGPUMemoryTitle
            // 
            labelGPUMemoryTitle.AutoSize = true;
            labelGPUMemoryTitle.Location = new Point(167, 72);
            labelGPUMemoryTitle.Name = "labelGPUMemoryTitle";
            labelGPUMemoryTitle.Size = new Size(169, 32);
            labelGPUMemoryTitle.TabIndex = 40;
            labelGPUMemoryTitle.Text = "Memory Clock";
            labelGPUMemoryTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.icons8_video_card_48;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.ErrorImage = null;
            pictureBox2.InitialImage = null;
            pictureBox2.Location = new Point(25, 17);
            pictureBox2.Margin = new Padding(4, 2, 4, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(36, 38);
            pictureBox2.TabIndex = 39;
            pictureBox2.TabStop = false;
            // 
            // labelGPUCore
            // 
            labelGPUCore.AutoSize = true;
            labelGPUCore.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelGPUCore.Location = new Point(20, 112);
            labelGPUCore.Name = "labelGPUCore";
            labelGPUCore.Size = new Size(130, 32);
            labelGPUCore.TabIndex = 28;
            labelGPUCore.Text = "1500 MHz";
            labelGPUCore.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelGPU
            // 
            labelGPU.AutoSize = true;
            labelGPU.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelGPU.Location = new Point(60, 19);
            labelGPU.Margin = new Padding(4, 0, 4, 0);
            labelGPU.Name = "labelGPU";
            labelGPU.Size = new Size(162, 32);
            labelGPU.TabIndex = 27;
            labelGPU.Text = "GPU Settings";
            // 
            // trackGPUCore
            // 
            trackGPUCore.LargeChange = 100;
            trackGPUCore.Location = new Point(48, 160);
            trackGPUCore.Margin = new Padding(4, 2, 4, 2);
            trackGPUCore.Maximum = 300;
            trackGPUCore.Name = "trackGPUCore";
            trackGPUCore.Orientation = Orientation.Vertical;
            trackGPUCore.RightToLeft = RightToLeft.No;
            trackGPUCore.Size = new Size(90, 454);
            trackGPUCore.SmallChange = 10;
            trackGPUCore.TabIndex = 17;
            trackGPUCore.TickFrequency = 50;
            trackGPUCore.TickStyle = TickStyle.TopLeft;
            // 
            // labelGPUCoreTitle
            // 
            labelGPUCoreTitle.AutoSize = true;
            labelGPUCoreTitle.Location = new Point(22, 72);
            labelGPUCoreTitle.Name = "labelGPUCoreTitle";
            labelGPUCoreTitle.Size = new Size(129, 32);
            labelGPUCoreTitle.TabIndex = 16;
            labelGPUCoreTitle.Text = "Core Clock";
            labelGPUCoreTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Fans
            // 
            AutoScaleDimensions = new SizeF(192F, 192F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1542, 1189);
            Controls.Add(panelGPU);
            Controls.Add(panelFans);
            Controls.Add(panelPower);
            Margin = new Padding(4, 2, 4, 2);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            MinimumSize = new Size(26, 1260);
            Name = "Fans";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fans and Power";
            panelFans.ResumeLayout(false);
            panelFans.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picturePerf).EndInit();
            tableFanCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartGPU).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartCPU).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartMid).EndInit();
            panelPower.ResumeLayout(false);
            panelPower.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelCPU.ResumeLayout(false);
            panelCPU.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackCPU).EndInit();
            panelTotal.ResumeLayout(false);
            panelTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackTotal).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureFine).EndInit();
            panelGPU.ResumeLayout(false);
            panelGPU.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackGPUMemory).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackGPUCore).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelFans;
        private RCheckBox checkApplyFans;
        private RButton buttonReset;
        private Panel panelPower;
        private RCheckBox checkApplyPower;
        private Panel panelCPU;
        private Label labelCPU;
        private Label label2;
        private TrackBar trackCPU;
        private Panel panelTotal;
        private Label labelTotal;
        private Label labelPlatform;
        private TrackBar trackTotal;
        private PictureBox pictureFine;
        private Label labelInfo;
        private Label labelPowerLimits;
        private TableLayoutPanel tableFanCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGPU;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCPU;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMid;
        private Label labelFans;
        private PictureBox picturePerf;
        private PictureBox pictureBox1;
        private RComboBox comboBoost;
        private Label labelBoost;
        private Label labelTip;
        private Label labelFansResult;
        private Panel panelGPU;
        private Label labelGPUCore;
        private Label labelGPU;
        private TrackBar trackGPUCore;
        private Label labelGPUCoreTitle;
        private PictureBox pictureBox2;
        private Label labelGPUMemory;
        private TrackBar trackGPUMemory;
        private Label labelGPUMemoryTitle;
        private RButton buttonResetGPU;
    }
}