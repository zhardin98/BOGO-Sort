using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace BOGO_Sort
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("Please enter numbers seperated by spaces: ");
            string input = Console.ReadLine().Trim();
            string[] numbers = input.Split(' ');
            int num = 0;
            int[] arr = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                bool ret = int.TryParse(numbers[i].Trim(), out num);
                if (!ret)
                {
                    Console.WriteLine("[ERROR] Can not parse: " + numbers[i] + " Skipping...");
                    continue;
                }
                arr[i] = num;
            }
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Sort(ref arr);
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed.ToString());
        }

        private static void Sort(ref int[] arr)
        {
            while (!sorted(arr))
            {
                Random rdm = new Random();
                for (int i = 0; i < arr.Length; i++)
                {
                    {
                        
                        for(int u = 0; u < arr.Length; u++)
                        {
                            Swap(ref arr, u, rdm.Next(0, arr.Length - 1));
                        }
                    }
                }
                for (int v = 0; v < arr.Length; v++)
                {
                    Console.Write("[" + arr[v] + "] ");
                }
                Console.WriteLine();
            }
        }

        private static void Swap(ref int[] arr, int u, int v)
        {
            int temp = arr[u];
            arr[u] = arr[v];
            arr[v] = temp;
        }
        public static bool sorted(int[] arr)
        {
            bool ret = true;
            for(int i = 0; i < arr.Length -1; i++)
            {
                if(arr[i] > arr[i+1])
                {
                    ret = false;
                    break;
                }
            }
            return ret;
        }
    }
}
