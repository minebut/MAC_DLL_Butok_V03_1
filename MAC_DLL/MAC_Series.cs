using System;
using System.IO;
namespace MAC_DLL
{
    public class MAC_Series
    {
        public static double Sum_of_Numbers_Series
            (int Initial_Index, int Last_Index, Func<int, double> Members)
        {
            double global_sum = 0.0;
            for (int k = Initial_Index; k <= Last_Index; k++) global_sum += Members(k);
            return global_sum;
        }
    

        public static double Sum_of_Number_Series_A
            (int Initial_Index, double Eps, Func<int, double> Members, ref int Final_Index)
        {
            double ak, sum_1, sum_0 = 0.0; int k = Initial_Index;
            bool flag;
            do
            {
                ak = Members(k); sum_0 += ak;
                flag = Math.Abs(ak) >= Eps; k++;
            }while (flag);

            int N = k - Initial_Index;
            do 
            {
                sum_1 = Sum_of_Numbers_Series(k, k + N, Members);
                sum_0 += sum_1;
                flag = (Math.Abs(sum_1) >= Eps); if (flag) k += N + 1;
            } while (flag);
            Final_Index = k + N; return sum_0;
        }

        public static double Sum_of_Number_Series_D
            (int Initial_Index, double Delta, Func<int, double> Members, ref int Final_Index)
        {
            double mem_k, partial_sum, global_sum = 0.0;
            int k = Initial_Index;
            bool flag;
            do
            {
                mem_k = Members(k); global_sum += mem_k;
                flag = (Math.Abs(mem_k / global_sum) >= Delta); k++;
            }while(flag);

            int N = k - Initial_Index;
            do
            {
                partial_sum = Sum_of_Numbers_Series(k, k + N, Members);
                global_sum += partial_sum;
                flag = (Math.Abs(partial_sum / global_sum) >= Delta); 
                if (flag) k += N + 1;
            }while(flag);
            Final_Index = k + N; return global_sum;
        }
    }
}
