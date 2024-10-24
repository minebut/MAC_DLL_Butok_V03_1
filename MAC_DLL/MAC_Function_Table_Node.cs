using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAC_DLL
{
    public class MAC_Function_Table_Node
    {
        public double X { get; internal set; } = double.NaN;
        public double F { get; internal set; } = double.NaN;
        public MAC_Function_Table_Node(double x, double f) { X = x; F = f; }
         
        public string ToPrint () => $"({X,16:F10},{F,16:F10})";
    }
}
