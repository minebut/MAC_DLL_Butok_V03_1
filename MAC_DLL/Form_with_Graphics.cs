using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MAC_DLL
{
    public partial class Form_with_Graphics : Form
    {
        #region<--- члени --->

        public string filename;

        #endregion<--- члени --->

        #region<--- Конструктор  --->


        public Form_with_Graphics()
        {
            InitializeComponent();
        }

        private Form_with_Graphics((double x, double f)[] points, string title)
        {
            InitializeComponent();
            Chart_with_Graphics.Series[0].Points.Clear();
            Chart_with_Graphics.Series[1].Points.Clear();

            Chart_with_Graphics.Titles[0].Text = title;
            Chart_with_Graphics.ChartAreas[0].AxisX.Interval = 1.0;
            Chart_with_Graphics.ChartAreas[0].AxisY.Interval = 1.0;

            Series S1 = new Series();
            int n = points.Length - 1;
            double f_min = double.MaxValue, f_max = double.MinValue;

            foreach ((double x, double f) in points)
            {
                S1.Points.AddXY(x, f);
                f_min = Math.Min(f_min, f);
                f_max = Math.Max(f_max, f);
            }

            S1.ChartType = SeriesChartType.Spline;
            S1.MarkerStyle = MarkerStyle.None;
            S1.BorderWidth = 3;
            S1.Color = Color.DarkBlue;
            Chart_with_Graphics.Series[0] = S1;

            Chart_with_Graphics.ChartAreas[0].AxisX.Minimum = Math.Floor(points[0].x);
            Chart_with_Graphics.ChartAreas[0].AxisX.Maximum = Math.Ceiling(points[n].x);
            Chart_with_Graphics.ChartAreas[0].AxisY.Minimum = Math.Floor(f_min);
            Chart_with_Graphics.ChartAreas[0].AxisY.Maximum = Math.Ceiling(f_max);

            Chart_with_Graphics.Invalidate();
        }

        private Form_with_Graphics(MyTable MTD)
        {
            InitializeComponent();
            Chart_with_Graphics.Series[0].Points.Clear();
            Chart_with_Graphics.Series[1].Points.Clear();

            Chart_with_Graphics.Titles[0].Text = MTD.Title;
            Chart_with_Graphics.ChartAreas[0].AxisX.Interval = 1.0;
            Chart_with_Graphics.ChartAreas[0].AxisY.Interval = 1.0;

            Series S1 = new Series(); int n = MTD.Length - 1;
            for (int i = 0; i <= n; i++)
            {
                S1.Points.AddXY(MTD.X(i), MTD.F(i));
            }
            S1.ChartType = SeriesChartType.Point;
            S1.MarkerStyle = MarkerStyle.Circle;
            S1.BorderWidth = 3;
            S1.Color = Color.DarkBlue;

            Chart_with_Graphics.Series[0] = S1;
            Chart_with_Graphics.ChartAreas[0].AxisX.Minimum = Math.Floor(MTD.X(0));
            Chart_with_Graphics.ChartAreas[0].AxisX.Maximum = Math.Ceiling(MTD.X(n));
            Chart_with_Graphics.ChartAreas[0].AxisY.Minimum = Math.Floor(MTD.Minimum.F);
            Chart_with_Graphics.ChartAreas[0].AxisY.Maximum = Math.Ceiling(MTD.Maximum.F);

            Series S2 = new Series();
            S2.Points.AddXY(MTD.X(0), 0.0); S2.Points.AddXY(MTD.X(n), 0.0);
            S2.ChartType = SeriesChartType.Line;
            S2.MarkerStyle = MarkerStyle.None;
            S2.BorderWidth = 1; S2.Color = Color.Red;
            Chart_with_Graphics.Series[1] = S2;

            Chart_with_Graphics.Invalidate();
        }

        private Form_with_Graphics(MyTable f1, MyTable f2, string title)
        {
            InitializeComponent();
            Chart_with_Graphics.Series[0].Points.Clear(); // Очистка точек
            Chart_with_Graphics.Series[1].Points.Clear();

            Chart_with_Graphics.Titles[0].Text = title;
            Chart_with_Graphics.ChartAreas[0].AxisX.Interval = 1.0;
            Chart_with_Graphics.ChartAreas[0].AxisY.Interval = 1.0;

            Series S1 = new Series(); int n1 = f1.Length - 1;
            for (int i = 0; i <= n1; i++)
            {
                S1.Points.AddXY(f1.Nodes[i].X, f1.Nodes[i].F);
            }
            S1.ChartType = SeriesChartType.Point;
            S1.MarkerStyle = MarkerStyle.Circle;
            S1.MarkerSize = 5;
            S1.MarkerColor = Color.Red;
            S1.MarkerBorderColor = Color.DarkRed;
            Chart_with_Graphics.Series[0] = S1;

            Series S2 = new Series(); int n2 = f2.Length - 1;
            for (int i = 0; i <= n2; i++)
            {
                S2.Points.AddXY(f2.Nodes[i].X, f2.Nodes[i].F);
            }
            S2.ChartType = SeriesChartType.Point;
            S2.MarkerStyle = MarkerStyle.Circle;
            S2.Color = Color.Blue;
            S2.MarkerSize = 5;
            S2.MarkerBorderColor = Color.DarkBlue;
            Chart_with_Graphics.Series[1] = S2;

            double f_min = Math.Min(f1.Minimum.F, f2.Minimum.F);
            double f_max = Math.Max(f1.Maximum.F, f2.Maximum.F);
            double x_min = Math.Min(f1.Nodes[0].X, f2.Nodes[0].X);
            double x_max = Math.Max(f1.Nodes[n1].X, f2.Nodes[n2].X);

            Chart_with_Graphics.ChartAreas[0].AxisX.Minimum = Math.Floor(x_min);
            Chart_with_Graphics.ChartAreas[0].AxisX.Maximum = Math.Ceiling(x_max);
            Chart_with_Graphics.ChartAreas[0].AxisY.Minimum = Math.Floor(f_min);
            Chart_with_Graphics.ChartAreas[0].AxisY.Maximum = Math.Ceiling(f_max);

            if ((x_max - x_min) < 1.0)
                Chart_with_Graphics.ChartAreas[0].AxisX.Interval = 0.1;
            else
                Chart_with_Graphics.ChartAreas[0].AxisX.Interval = Math.Ceiling((x_max - x_min) / 10);

            if ((f_max - f_min) < 1.0)
                Chart_with_Graphics.ChartAreas[0].AxisY.Interval = 0.1;
            else
                Chart_with_Graphics.ChartAreas[0].AxisY.Interval = Math.Ceiling((f_max - f_min) / 10);

            Chart_with_Graphics.Invalidate();
        }

        #endregion<--- Конструктор--->

        #region <--- Методи --->
        public static void SingleGraphics((double, double)[] P, string Title, int Nx, int Ny)
        {
            Form_with_Graphics SingleG = new Form_with_Graphics(P, Title)
            {
                filename = Title,
                StartPosition = FormStartPosition.Manual,
                Location = new Point(Nx, Ny)
            };
            SingleG.ShowDialog();
        }
        public static void SingleGraphics(MyTable table, int Nx, int Ny)
        {
            if (table == null) return;
            Form_with_Graphics SingleG = new Form_with_Graphics(table);
            SingleG.filename = table.Title;
            SingleG.StartPosition = FormStartPosition.Manual;
            SingleG.Location = new Point(Nx, Ny);
            SingleG.ShowDialog();
        }

        public static void DoublyGraph(MyTable g1, MyTable g2, string title, int Nx, int Ny)
        {
            if ((g1 == null) || (g2 == null)) return;
            Form_with_Graphics fwd = new Form_with_Graphics(g1, g2, title);
            fwd.filename = title;
            fwd.StartPosition = FormStartPosition.Manual;
            fwd.Location = new Point(Nx, Ny); fwd.ShowDialog();
        }



        #endregion <--- Методи --->
        
        private void SaveGraph_Click(object sender, EventArgs e)
        {
            Chart_with_Graphics.SaveImage(filename + ".png", ChartImageFormat.Png);
            SaveGraph.Enabled = false;
            Dispose();
        }
    }
}
