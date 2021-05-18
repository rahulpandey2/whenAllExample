using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    class Program
    {
        static void Main(string[] args)
        {
            int number_of_testCases = Convert.ToInt32(Console.ReadLine());
            List<string> data = new List<string>();

            for (int i = 0; i < number_of_testCases; i++)
            {
                Console.ReadLine(); // number_of_elements

                data.Add(Console.ReadLine());
            }

            var output = Task.WhenAll(data.Select(async x => await MaxIndexDiff(x)));

            Console.WriteLine(string.Join("/n", output.Result));
            Console.ReadKey();
        }

        private static Task<int> MaxIndexDiff(string inputOfElements)
        {
            var elements = Array.ConvertAll(inputOfElements.Split(' '), int.Parse);
            int maxDiff = -1;
            int i, j;
            int n = elements.Length;

            for (i = 0; i < n; i++)
            {
                for (j = n - 1; j > i; --j)
                {
                    if (elements[j] > elements[i] && maxDiff < (j - i))
                        maxDiff = j - i;
                }
            }

            return Task.FromResult(maxDiff + 1);
        }
    }



}
