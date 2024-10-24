﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FwG = MAC_DLL.Form_with_Graphics;
using MF = MathFunctions.CT_1_0;
using UTL = MAC_DLL.Utilities;
using System.IO;

namespace Main_CheckTask_1_0
{
    class Main_CT_1_0
    {
        static double xo = -4.50, xn = +0.60;
        static int n = 290, Nx = 700, Ny = 400;

        static void Main(string[] args)
        {
            string my_function = "fx_CT_1_0_v14";

            using (StreamWriter SW = UTL.ResultWriter(my_function, "Main_CT_1_0.cs"))
            {
                double h = (xn - xo) / n;
                (double x, double f)[] my_fx = new (double, double)[n + 1];

                for (int i = 0; i <= n; i++)
                {
                    my_fx[i].x = xo + i * h; my_fx[i].f = MF.fx_CT_1_0_v14(my_fx[i].x);
                }
                FwG.SingleGraphics(my_fx, "Graphic of my_fx(x)", Nx, Ny);
            }
        }
    }
}