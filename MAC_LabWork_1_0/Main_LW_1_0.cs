using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FwG = MAC_DLL.Form_with_Graphics;

namespace MAC_LabWork_1_0
{
    class Main_LW_1_0
    {
        static void Main(string[] args)
        {
            Test_Sinus(100, -Math.PI, Math.PI, 800, 300);
        } 
        static void Test_Sinus(int n, double xo, double xn, int Nx, int Ny)
        {
            double h = (xn - xo) / n;
            (double x, double f)[] sinus = new (double, double)[n + 1];

            for (int i = 0; i<= n; i++)
            {
                sinus[i].x = xo + i * h;
                sinus[i].f = Math.Sin(sinus[i].x + 0.5);
            }
            FwG.SingleGraphics(sinus, "My Graphic of Sin(x)", Nx, Ny);
        }
    }
}
