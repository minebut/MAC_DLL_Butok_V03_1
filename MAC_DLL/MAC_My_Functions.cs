using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAC_DLL
{
    public class MAC_My_Functions
    {

        public static double my_f(double x, double a, double b, double eps)
        {
            if (x == 0) return 0.0;

            double b1 = Math.Cos(a * Math.Sqrt(x + Math.PI));
            double b2 = Math.Sin(b * Math.Pow(x, 1.5) + Math.PI);
            double bx = b1 + b2;

            double pk = 1.0, Ak = 1.0, summa = 0.0;

            for (int k = 1; Math.Abs(Ak) > eps; k++)
            {
                pk = -pk * (x / (2.0 * k - 1.0)) * (x / (2.0 * k));
                double f1 = Math.Cos(a * Math.Sqrt(x + Math.PI) / k);
                double f2 = Math.Sin((b * Math.Pow(x, 1.5) + Math.PI) / k);
                Ak = pk / k * (f1 + f2);
                summa += Ak;
            }

            return summa /2  ;
        }



        public static double fO(double x, double a, double b, double eps)
        {
            if (x == 0) return 0;
            double xz = 11.0 * x / 7.0, bx = b * x;
            double pk = 1.0, Ak = 1.0, summa = 0.0, Ao = (Math.Cos(bx) + Math.Sin(bx / a)) / a;

            for (int k = 1; Math.Abs(pk) > eps; k++)
            {
                pk = -pk * xz / (k + 1.0);
                Ak = pk * (Math.Cos(bx / (k + 1.0)) + Math.Sin(bx / (k + a))) / (2.0 * k + a);
                summa = summa + Ak;
            }
            return 0.25 * xz * (Ao + summa);
        }
        public static double MySin(double x, double eps)
        {
            if (x == 0) return 0.0;
            double sin = x, pk = x, x2 = 0.5 * x;
            for (int k = 2; Math.Abs(pk) > eps; k++)
            {
                pk = -pk * (x2 / (k - 1.0)) * (x2 / (k - 0.5)); sin += pk;

            }
            return sin;
        }
        public static double MyCos(double x, double eps)
        {
            if (x == 0) return 0.0;
            double cos = 1.0, pk = 1.0, x2 = 0.5 * x;
            for (int k = 1; Math.Abs(pk) > eps; k++)
            {
                pk = -pk * (x2 / (k - 0.5)) * (x2 / k); cos += pk;

            }
            return cos;
        }

        public static double MyExp(double x, double eps)
        {
            if (x == 0) return 1.0;
            double exp = 1.0, pk = 1.0;
            for (double k = 1.0; Math.Abs(pk) > eps; k = k + 1.0)
            {
                pk = pk * (x / k); exp += pk; Console.WriteLine($"{k,6}{pk,30:F22}");

            }
            return exp;
        }


        public static double MySinh(double x, double eps)
        {
            if (x == 0.0) return 0.0;
            double sinh = x, pk = x, x2 = 0.5 * x;
            for (double k = 2.0; Math.Abs(pk) > eps; k = k + 1)
            {
                pk = pk * (x2 / (k - 1.0)) * (x2 / (k - 0.5));
                sinh = sinh + pk;
            }
            return sinh;
        }

        public static double MyCosh(double x, double eps)
        {
            if (x == 0.0) return 1.0;
            double cosh = 1.0, pk = 1.0;
            double x2 = 0.5 * x;
            for (double k = 1.0; Math.Abs(pk) > eps; k = k + 1)
            {
                pk = pk * (x2 / (k - 0.5)) * (x2 / k);
                cosh = cosh + pk;

            }
            return cosh;
        }
    }
}


