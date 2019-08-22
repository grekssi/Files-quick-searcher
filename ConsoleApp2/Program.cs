using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    private static Stack<int> first;
    private static Stack<int> second = new Stack<int>();
    private static Stack<int> third = new Stack<int>();
    private static int stepsTaken = 0;

    static void Main(string[] args)
    {
        int numberOfDisks = int.Parse(Console.ReadLine());
        first = new Stack<int>(Enumerable.Range(1, numberOfDisks).Reverse());
        PrintRods();
        MoveDisks(numberOfDisks, first, second, third);
    }

    private static void MoveDisks(int bottomDisk,
        Stack<int> first, 
        Stack<int> second,
        Stack<int> third)
    {
        if(bottomDisk == 1)
        {
            stepsTaken++;
            second.Push(first.Pop());
        }
        else
        {
            MoveDisks(bottomDisk - 1, first, third, second);
            second.Push(first.Pop());
            MoveDisks(bottomDisk - 1, third, second, first);
        }
    }

    private static void PrintRods()
    {
        Console.WriteLine($"Source: {String.Join(", ", first.Reverse())}");
        Console.WriteLine($"Destination: {String.Join(", ", second.Reverse())}");
        Console.WriteLine($"Spare: {String.Join(", ", third.Reverse())}");
        Console.WriteLine();
    }
}