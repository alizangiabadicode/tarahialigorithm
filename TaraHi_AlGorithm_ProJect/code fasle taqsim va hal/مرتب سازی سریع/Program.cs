using System;

namespace مرتب_سازی_سریع
{
    class Program
    {

        static int[] s = null;
        static Random rnd = new Random();
        static void QuickSort(int low, int high)
        {
            int pivotPoint =0;
            if (low < high)
            {
                pivotPoint = Partition(low,high);
                QuickSort(low, pivotPoint - 1);
                QuickSort(pivotPoint + 1, high);
            }
        }
        
        static int Partition(int low,int high){
            int pivotItem = s[low];
            int j = low;
            for (int i = low; i <= high; i++)
            {
                if(s[i] < pivotItem){
                    j++;
                    Exchange(i,j);
                }
            }
            Exchange(low,j);
            return j;
        }

        static void Exchange(int i, int j){
            int temp = s[j];
            s[j]=s[i];
            s[i]=temp;
        }

        static void Display(){
            for (int i = 0; i < s.Length; i++)
            {
                Console.Write("{0} ",s[i]);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            s = new int[]{
                2,7,5,1,4
            };
            Display();
            QuickSort(0,s.Length -1);
            Display();
        }
    }
}
