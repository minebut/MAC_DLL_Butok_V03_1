using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FTN = MAC_DLL.MAC_Function_Table_Node;

namespace MAC_DLL
{
    public abstract class MyTable
    {
        #region <--- Основні Властивості MyTable --->

        // Масив вузлів (x,f) даної таблиці
        public FTN[] Nodes { get; protected set; } = null;

        // Повертає кількість вузлів в даній таблиці
        public int Length { get { return Nodes == null ? 0 : Nodes.Length; } }

        // Повертає посилання на вузол з найбільшим значенням функції
        public FTN Maximum { get; protected set; } = null;

        // Повертає посилання на вузол з найменшим значенням функції
        public FTN Minimum { get; protected set; } = null;

        // Повертає довжину області визначення для даної функції
        public double Region_x { get { return Nodes == null ? double.NaN : this[Length - 1].X - this[0].X; } }

        // Повертає довжину області значень для даної функції
        public double Region_f { get { return Nodes == null ? double.NaN : Maximum.F - Minimum.F; } }

        // Власивість, яка визначає похибку математичних операцій
        public double Epsilon { get; set; }

        // Власивість, яка визначає заголовок таблиці
        public string Title { get; protected set; } = null;

        #endregion

        #region <--- Додаткові Властивості MyTable --->
        public List<Root> Roots { get; internal set; }
        #endregion<--- Додаткові Властивості MyTable --->

        #region <--- Основні Методи MyTable --->

        // Індексатор 
        public FTN this[int index] { get { return (0 <= index) && (index < Length) ? Nodes[index] : null; } }

        // Повертає значення x для рядка таблиці з номером index
        public double X(int index) => (0 <= index) && (index < Length) ? this[index].X : double.NaN;

        // Повертає значення f для рядка таблиці з номером index
        public double F(int index) => (0 <= index) && (index < Length) ? this[index].F : double.NaN;

        // Повертає два масиви із значенням аргументу x і функції f
        public void ToArrays(out double[] x, out double[] f)
        {
            x = new double[Length]; f = new double[Length];
            for (int i = 0; i < Length; i++) { x[i] = this[i].X; f[i] = this[i].F; }
        }

        // Створює таблицю функції в текстовому форматі
        public virtual string Table_of_Function()
        {
            string txt = "\r\n Таблиця функції " + Title + " : \r\n";
            for (int i = 0; i < Length; i++) { txt += $"{i,4}" + Nodes[i].ToPrint() + "\r\n"; }
            txt += $"\r\n  x = [{Nodes[0].X,17:F12} :{Nodes[Length - 1].X,17:F12} ]";
            txt += $"   x_Reg = {Region_x,16:F12}\r\n";
            txt += $"\r\n Min  ({Minimum.X,18:F12},{Minimum.F,18:F12} )";
            txt += $"\r\n Max  ({Maximum.X,18:F12},{Maximum.F,18:F12} )";
            txt += $"  f_Reg = {Region_f,16:F12}\r\n";
            return txt + Table_of_Roots("");// return txt;
        }

        // Віртуальний метод, призначений длязбереження таблиці у
        // текстовому файлі path із додатковим коментарем comment
        public virtual void To_txt_File(string path, string comment)
        {
            if (path == "") path = "My_Table.txt";
            FileInfo file = new FileInfo(path); if (file.Exists) file.Delete();
            StreamWriter SW = new StreamWriter(file.OpenWrite());
            SW.Write(comment + "\r\n" + Table_of_Function()); SW.Close();
        }


        #endregion

        #region <--- Додаткові Методи MyTable --->
        public virtual void Roots_Correction(double eps) { }
        protected void Roots_Location()
        {
            int counter = 0;
            for (int i = 1; i < Length; i++)
                if (Nodes[i - 1].F * Nodes[i].F < 0)
                {
                    counter++;
                    if (counter == 1)
                    {
                        Roots = new List<Root>();
                    }
                    Roots.Add(new Root(Nodes[i - 1].X, Nodes[i].X));
                }
        }
        public string Table_of_Roots(string comment)
        {
            string table = comment + "\r\n";
            if (Roots != null)
            {
                table += "Таблиця нулів " + Title + " функції \r\n";
                for (int j = 0; j < Roots.Count; j++)
                    table += $"{j,3}" + Roots[j].ToPrint() + "\r\n";
            }
            else { table += "Таблиця нулів " + Title + " порожня!\r\n"; }
            return table;
        }
        // Додатковий віртуальний метод, призначений для операцій виводу 
        // в текстовій формі рвзноманітні інформації по даній таблиці 
        public virtual string ToPrint(string comment) { return comment; }
        #endregion 
    }
}
