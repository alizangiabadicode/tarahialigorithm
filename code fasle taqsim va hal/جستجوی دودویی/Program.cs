using System;

namespace جستجوی_دودویی
{
    class Program
    {

        static int BinarySearch(int low, int high, int x, int[] s){
            if(low > high){
                return 0;
            }
            else{
                int mid = (low + high)/2;
                if(s[mid] == x)
                    return mid;
                
                else if(x < s[mid])
                    BinarySearch(low,mid - 1,x,s);
                
                else if(x > s[mid])
                    BinarySearch(mid + 1 ,high ,x ,s);
            }
            return -1;
        }


        static void Main(string[] args)
        {
            int[] array = {1,2,3,4,5,6,7};
            int index=BinarySearch(0,6,4,array);
            Console.WriteLine("{0} is {1}",4,index != -1 ? $"found at index {index}" : "not found!" );
        }
    }
}
