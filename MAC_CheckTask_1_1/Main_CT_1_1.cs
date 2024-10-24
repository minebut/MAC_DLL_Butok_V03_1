using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLS = MAC_DLL.MAC_Series;
using UTL = MAC_DLL.Utilities;

namespace Main_CT_1_1
{

    class Program
    {
        //static int N = 10;
        //static double a = 0.5, b = -0.75, c = 1.12, d = 1.84, eps = 1.0E-9, dlt = 1.0E-8;
        //static int N = 1000;
        //static double a = 0.5, b = 1.50, c = 2.50, d = 3.50, eps = 1.0E-9, dlt = 1.0E-8;
        static int N = 2700;
        static double a = 2.51, b = 2.01, c = 4.46, d = 2.48, eps = 1.0E-9, dlt = 1.0E-8;

        static void Main(string[] args)
        {
            using (StreamWriter SW = UTL.ResultWriter("CT_1_1_v3_1", "Main_CT_1_1.cs"))
            {
                double SN = CLS.Sum_of_Numbers_Series(2, N, sk);
                SW.WriteLine($"     N={N,10}     SN={SN,15:F10}");

                int i_max = 0;
                double S1 = CLS.Sum_of_Number_Series_A(1, eps, si, ref i_max);
                SW.WriteLine($"i_max ={i_max,10}     S1={S1,15:F10}");

                int j_max = 0;
                double S2 = CLS.Sum_of_Number_Series_D(1, dlt, sj, ref j_max);
                SW.WriteLine($"j_max ={j_max,10}     S2={S2,15:F10}");
            }
        }

        public static double sk(int k)
        {

            double x1 = Math.Pow(k * k - 3.0, 0.5);
            double x2 = (k * k + 1.0) * (Math.Pow(k - 1.0, 2.0));
            return x1 / x2;

            //double x1 = Math.Pow(k * k - 3.0, 0.5);
            //double x2 = (k * k + 1.0) * (Math.Pow(k - 1.0, 2.0));
            //return x1 / x2;


            //double x1 = Math.Sqrt(Math.Sqrt(k + 1.0));
            //double x2 = (3.0 * Math.Pow(k, 2.0) - 1.0) * (Math.Sqrt(k) + 3.0);
            //return x1 / x2;
        }


        public static double si(int i)
        {

            double x1 = Math.Pow(i, -1.5) / (2.0 * i + 3.0 * b);
            double x2 = 1.0 / ((i + 7.0) * (i * i + a));
            return x1 + x2;
            //double x1 = (2.0 * i + 3.0 * b) + (i + 7.0) * (i * i + a);
            //double x2 = (Math.Pow(i, -1.5) + 1.0);
            //return x2 / x1;



            //double x1 = Math.Pow(5.0 * i + 2.0 * a, 2.0) * (b * i + 1.0);
            //double x2 = (Math.Sqrt(a + i)) + (Math.Sqrt(i - b));
            //return x2 / x1;
        }

        public static double sj(int j)
        {
            //double x1 = ((2.0 * j + 9.0 * c)*(c * j - d * Math.Pow(j, -2.0)));
            //double x2 = Math.Pow(-1.0, j);
            //if ((j % 2) == 0) return x2 / x1; else return x1 / x2;

            double x1 = (2.0 * j + 9.0 * c);
            double x2 = (c * j - d * Math.Pow(j, -2.0));
            return Math.Pow(-1.0, j - 1) / (x1 * x2);
            //double x1 = (Math.Pow(j * 1.0, 1.5) + c) * (2.0 * j - d + 1.0);
            //if ((j % 2) == 0) return 1.0 / x1; else return -1.0 / x1;
        }
    }
}
