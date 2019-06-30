using System;

namespace مرتب_سازی_ادغامی
{
    class Program
    {

        static void MergeSort(int n , int[] s){

            int h = n/2;
            int m = n - h;
            int[] u = null;
            int[] v = null;
            if(n>1){

                u = CopyArray(0,h - 1,s);
                v = CopyArray(h,n - 1,s);
                
                MergeSort(h,u);
                MergeSort(m,v);
                Merge(h -1 ,m - 1,u,v,s);
                
            }
        }


        static void Merge(int h , int m , int[] u , int[] v , int[] s){
            int i=0,j=0,k=0;
            while ( i <= h && j <= m)
            {
                if(u[i] < v[j]){
                    s[k] = u[i];
                    i++;
                }
                else if(v[j] < u[i]){
                    s[k] = v[j];
                    j++;
                }
                k++;
            }

            if(i>h){
                while(j<=m){
                    s[k] = v[j];
                    j++; k++;
                }
            }
            else if(j>m){
                while (i<=h)
                {
                    s[k] = u[i];
                    i++; k++;
                }
            }
        }


        static int[]  CopyArray(int low , int high , int[] s){

            int[] temp = new int[high - low + 1];
            int i = low;
            int j = 0;
            while(i <= high){
                temp[j] = s[i];
                i++; j++;
            }
            return temp;
        }

        static void Display(int[] arr){
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0} ",arr[i]);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] arr={
                1,6,3,2,7,9,5
            };
            Display(arr);

            MergeSort(arr.Length,arr);

            Display(arr);
        }
    }
}
