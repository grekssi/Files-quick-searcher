using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Iterate(int[] numbers, int index, int maxnumber)
    {
        if (index == numbers.Length)
        {
            Console.WriteLine(string.Join(" ", numbers));
            return;
        }
        for (int i = 1; i <= maxnumber; i++)
        {
            numbers[index] = i;
            Iterate(numbers, index + 1, maxnumber);
        }
    }
    static void Main(string[] args)
    {
        var arr = new int[3];
        Iterate(arr, 0, 2);
    }
}