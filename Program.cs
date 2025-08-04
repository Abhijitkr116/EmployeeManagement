using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saurav

{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] number = { 5, 4, 16, 8, 9 };
            for(int i = 0; i<number.Length; i++)
            {
                if (number[i] > i) { }
                Console.WriteLine(number[i]);
            }
            Console.ReadLine();
        }
    }
}