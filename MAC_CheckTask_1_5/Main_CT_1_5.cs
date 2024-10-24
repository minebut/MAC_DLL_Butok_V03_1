using EToF = MAC_DLL.MyExtendedTableOfFunctions;
using UTL = MAC_DLL.Utilities;
using FTN = MAC_DLL.MAC_Function_Table_Node;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using FwG = MAC_DLL.Form_with_Graphics;
using MToF = MAC_DLL.MyTableOfFunction;
namespace MAC_CheckTask_1_5
{
    class Main_CT_1_5
    {
        static double a = 0.2, b = 1.0, s = Math.Sqrt(2);
        //static double a = -3.5, b = 0.5 , s = Math.Sqrt(2);
        //static double a = 0.1, b = -0.1, s = Math.Sqrt(10.0);
        static void Main(string[] args)
        {
           //MyVariant3_1test("CT_1_5_v03.1");
            MyVariant3_1("CT_1_5_v03.1");
        }


        static void MyVariant3_1(string file)
        {
            using (StreamWriter SW = UTL.ResultWriter(file, "Main_CT_1_5.cs"))
            {
                #region <--- Розв'язування завдання --->

                EToF ET_Fx = new EToF(-3.5, 0.5, 280, Fx, d1Fx, d2Fx, " - Newton -");
                ET_Fx.Roots_Correction(1.0E-12);

                SW.WriteLine(ET_Fx.Table_of_Roots("--- All Roots ---"));

                SW.WriteLine("\r\n Точки перетину траєкторій: \r\n");
                FTN xy;
                for (int i = 0; i < ET_Fx.Roots.Count; i++)
                {
                    xy = new FTN(ET_Fx.Roots[i].X, f1(ET_Fx.Roots[i].X));
                    SW.WriteLine($"{i,3}" + xy.ToPrint());
                }

                #endregion <--- Розв'язування завдання --->

                MToF y1 = new MToF(- 3.5, 0.5, 280, f1, "f1");
                MToF y2 = new MToF(-3.5, 0.5, 280, f2, "f2");
                FwG.DoublyGraph(y1, y2, "CT_1_5", 300, 500);
            }
        }



       

        public static double Fx(double x) { return f1(x) - f2(x); }
        public static double d1Fx(double x) { return d1f1(x) - d1f2(x); }
        public static double d2Fx(double x) { return d2f1(x) - d2f2(x); }


        public static double f1(double x) 
        {
            return 3.0 * s * Math.Sin(Math.PI * x + a); 
        }

        public static double d1f1(double x) 
        {
            return 3.0 * s * Math.PI * Math.Cos(Math.PI * x + a);
        }

        public static double d2f1(double x) 
        {;
            return -3.0 * s * Math.Pow(Math.PI, 2) * Math.Sin(Math.PI * x + a);
        }

        public static double f2(double x) 
        {

            return b * Math.Sqrt(Math.PI - 2.0 * x); 
        }

        static double d1f2(double x) 
        {

            return -b / (2.0 * Math.Sqrt(Math.PI - 2.0 * x));
        }

        static double d2f2(double x) 
        {

            return b / (4.0 * Math.Pow(Math.PI - 2.0 * x, 1.5));
        }
       
    }
}
