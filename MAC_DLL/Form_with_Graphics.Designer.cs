namespace MAC_DLL
{
    partial class Form_with_Graphics
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_with_Graphics));
            this.Chart_with_Graphics = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SaveGraph = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_with_Graphics)).BeginInit();
            this.SuspendLayout();
            // 
            // Chart_with_Graphics
            // 
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisX.LabelStyle.Format = "0.0";
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX2.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisY.LabelStyle.Format = "0.0";
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.Name = "ChartArea1";
            this.Chart_with_Graphics.ChartAreas.Add(chartArea1);
            this.Chart_with_Graphics.Location = new System.Drawing.Point(2, 2);
            this.Chart_with_Graphics.Name = "Chart_with_Graphics";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Name = "Series2";
            this.Chart_with_Graphics.Series.Add(series1);
            this.Chart_with_Graphics.Series.Add(series2);
            this.Chart_with_Graphics.Size = new System.Drawing.Size(640, 440);
            this.Chart_with_Graphics.TabIndex = 0;
            this.Chart_with_Graphics.Text = "chart1";
            title1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title1.Name = "Title1";
            title1.Text = "Графік функції, яку задано формулою";
            this.Chart_with_Graphics.Titles.Add(title1);
            // 
            // SaveGraph
            // 
            this.SaveGraph.Image = ((System.Drawing.Image)(resources.GetObject("SaveGraph.Image")));
            this.SaveGraph.Location = new System.Drawing.Point(582, 12);
            this.SaveGraph.Name = "SaveGraph";
            this.SaveGraph.Size = new System.Drawing.Size(28, 30);
            this.SaveGraph.TabIndex = 1;
            this.SaveGraph.UseVisualStyleBackColor = true;
            this.SaveGraph.Click += new System.EventHandler(this.SaveGraph_Click);
            // 
            // Form_with_Graphics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 429);
            this.Controls.Add(this.SaveGraph);
            this.Controls.Add(this.Chart_with_Graphics);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_with_Graphics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form_with_Graphics";
            this.Click += new System.EventHandler(this.SaveGraph_Click);
            ((System.ComponentModel.ISupportInitialize)(this.Chart_with_Graphics)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_with_Graphics;
        private System.Windows.Forms.Button SaveGraph;
    }
}