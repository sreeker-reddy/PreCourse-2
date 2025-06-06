
using System;
/*
Space complexity - O(n)
Time complexity - O(nlog n)

OUTPUT -
1 2 2 3 3 3 4 5 

Approach - Iteratively traverse the array by adding the indexes if there are elements to the left of the pivot to the stack and similarly the elemenets greater than pivot to the right of the stack.

*/

namespace Precourse2
{
    public class IterativeQuickSort
    {
        void swap(int[] arr, int i, int j)
        {
            //Try swapping without extra variable
            if (arr[i] != arr[j])
            {
                arr[i] = arr[i] + arr[j];
                arr[j] = arr[i] - arr[j];
                arr[i] = arr[i] - arr[j];
            }
        }

        /* This function is same in both iterative and 
           recursive*/
        int partition(int[] arr, int l, int h)
        {
            //Compare elements and swap.
            int pivot = arr[h];
            int temp = l;

            for(int i=l;i<h;i++)
            {
                if(arr[i]<=pivot)
                {
                    swap(arr, i, temp);
                    temp++;
                }
            }
            swap(arr, temp, h);

            return temp;
        }

        // Sorts arr[l..h] using iterative QuickSort 
        void QuickSort(int[] arr, int l, int h)
        {
            //Try using Stack Data Structure to remove recursion.
            int[] s = new int[h - l + 1];
            int top = -1;

            s[++top] = l;
            s[++top] = h;

            while(top>-1)
            {
                h = s[top--];
                l = s[top--];

                int part = partition(arr, l, h);

                if(part-1>l)
                {
                    s[++top] = l;
                    s[++top] = part - 1;   
                }
                if (part + 1 < h)
                {
                    s[++top] = part + 1;
                    s[++top] = h;
                }
            }
        }

        // A utility function to print contents of arr 
        void printArr(int[] arr, int n)
        {
            int i;
            for (i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
        }

        // Driver code to test above 
        public static void Main(String[] args)
        {
            IterativeQuickSort ob = new IterativeQuickSort();
            int[] arr = { 4, 3, 5, 2, 1, 3, 2, 3 };
            ob.QuickSort(arr, 0, arr.Length - 1);
            ob.printArr(arr, arr.Length);
        }
    }
}