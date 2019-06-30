using System;

namespace مرتب_سازی_ادغامی_2
{
    class Program
    {

        static int[] s =null;
        static void MergeSort2(int low , int high){
            if(low < high){

                int mid = (low + high)/2;

                MergeSort2(low,mid);
                MergeSort2(mid + 1,high);

                Merge2(low,mid,high);
            }
        }

        static void Merge2(int low , int mid, int high){
            int i =low , j=mid+1 , k=0;
            int[] arr = new int[high - low + 1];
            while(i<=mid && j<=high){
                if(s[i]<s[j]){
                    arr[k]=s[i];
                    i++;
                }
                else if(s[j]<s[i]){
                    arr[k]=s[j];
                    j++;
                }
                k++;
            }
            if(i>mid){
                while (j<=high)
                {
                    arr[k]=s[j];
                    j++;
                    k++;
                }
            }
            else if(j>high){
                while (i<=mid){
                    arr[k]=s[i];
                    i++;
                    k++;
                }
            }
            int c=0;
            for (int o = low; o <= high; o++)
            {
                s[o] = arr[c++];
            }
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
            s=new int[]{
                1,4,2,6,5,7
            };
            Display(s);
            MergeSort2(0,s.Length-1);
            Display(s);
        }
    }
}
