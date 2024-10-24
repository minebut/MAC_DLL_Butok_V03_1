using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MyToF = MAC_DLL.MyTableOfFunction;
using UTL = MAC_DLL.Utilities;
using Eq = MAC_DLL.MAC_Equations;

namespace MAC_LabWork_1_5
{
     class Main_LW_1_5
    {
        static double Sq10 = Math.Sqrt(10.0), eps = 1.0E-12;
        static void Main(string[] args)
        {
            using (StreamWriter SW = UTL.ResultWriter("LW_1_5_v03_01.txt"))
            {
                MyToF T_Fx = new MyToF(-1.5, -0.5, 330, Fx3_1, "Fx");
                T_Fx.Roots_Correction(eps);
                SW.WriteLine(T_Fx.Table_of_Roots("- Dichotomy -"));

                double xr = double.NaN;
                SW.WriteLine("\r\n Таблиця Нулів, яку обчислено за схемою (1.5.1):");
                for (int j = 0; j < T_Fx.Roots.Count; j++)
                {
                    xr = Eq.Tangent(Fx3_1, D1F3_1, D2F3_1, T_Fx.Roots[j].XL, T_Fx.Roots[j].XR, eps, out int K);
                    SW.WriteLine($"{j,3}{xr,17:F10}{Math.Abs(Fx3_1(xr)),10:E1}{K,3}");
                }
                SW.WriteLine("\r\n Таблиця нулів, яку обчислено за схемою (1.5.2):");
                for (int j = 0; j < T_Fx.Roots.Count; j++)
                {
                    xr = Eq.Tangent(Fx3_1, T_Fx.Roots[j].XL, T_Fx.Roots[j].XR, eps, out int K);
                    SW.WriteLine($"{j,3}{xr,17:F10}{Math.Abs(Fx3_1(xr)),10:E1}{K,3}");
                }
                SW.WriteLine($"Перша похідна = {D1F3_1(xr)}");
                SW.WriteLine($"Друга похідна = {D2F3_1(xr)}");
            }
        }

        public static double Fx3_1(double x)
        {
            return Math.Log(Math.Exp(1.0) * (x + Math.PI)) + 4.0 * Math.Sin(2.0 * x + 1);
        }

        public static double D1F3_1(double x)
        {
            return (1.0 / (x + Math.PI)) + 8.0 * Math.Cos(2.0 * x + 1);
        }
        public static double D2F3_1(double x)
        {
            return (-1.0 / ((x + Math.PI) * (x + Math.PI))) -16.0 * Math.Sin(2.0 * x + 1);
        }
            
            
            
            
            
            #region LW_1_5
        //    using (StreamWriter SW = UTL.ResultWriter("LW_1_5.txt"))
        //    {
        //        MyToF T_Fx = new MyToF(1.0, 10.0, 500, Fx, "Fx");
        //        T_Fx.Roots_Correction(eps);
        //        SW.WriteLine(T_Fx.Table_of_Roots("- Dichotomy -"));

        //        double xr = double.NaN;
        //        SW.WriteLine("\r\n Таблиця Нулів, яку обчислено за схемою (1.5.1):");
        //        for (int j = 0; j < T_Fx.Roots.Count; j++)
        //        {
        //            xr = Eq.Tangent(Fx, D1F, D2F, T_Fx.Roots[j].XL, T_Fx.Roots[j].XR, eps, out int K);
        //            SW.WriteLine($"{j,3}{xr,17:F12}{Math.Abs(Fx(xr)), 10:E1}{K,3}");
        //        }
        //        SW.WriteLine("\r\n Таблиця нулів, яку обчислено за схемою (1.5.2):");
        //        for (int j = 0; j < T_Fx.Roots.Count; j++)
        //        {
        //            xr = Eq.Tangent(Fx, T_Fx.Roots[j].XL, T_Fx.Roots[j].XR, eps, out int K);
        //            SW.WriteLine($"{j,3}{xr,17:F12}{Math.Abs(Fx(xr)),10:E1}{K,3}");
        //        }
        //    }
        //}
        
        //public static double Fx(double x)
        //{
        //    return Math.Tanh(x) - 2.0 * Math.Cos(Sq10 * x);
        //}

        //public static double D1F(double x)
        //{
        //    return 1.0 / Math.Cosh(x) / Math.Cosh(x) + 2.0 * Sq10 * Math.Sin(Sq10 * x);
        //}
        //public static double D2F(double x)
        //{
        //    return 2.0 * (10.0 * Math.Cos(Sq10 * x) - Math.Tanh(x) / Math.Cosh(x) / Math.Cosh(x));
        //}
        #endregion

    }
}
