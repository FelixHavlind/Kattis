using System;

namespace Kattis;

public static class FizzBuzz // https://open.kattis.com/problems/fizzbuzz
{
    public static void Execute()
    {
        var line = new string(Console.ReadLine()).Split(" ");
        var x = int.Parse(line[0]);
        var y = int.Parse(line[1]);
        var n = int.Parse(line[2]);

        if (1 <= x && x < y && y <= n && n <= 100)
        {
            for (var i = 1; i <= n; i++)
            {
                if (i % x == 0 && i % y == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
        
                else if (i % x == 0)
                {
                    Console.WriteLine("Fizz");
                }
        
                else if (i % y == 0)
                {
                    Console.WriteLine("Buzz");
                }

                else
                {
                    Console.WriteLine(i);
                }
            }
        }

        else
        {
            throw new ArgumentException();
        }
    }   
}