using System;

namespace Kattis;

public class CandleBox // https://open.kattis.com/problems/candlebox
{
    public static void Execute()
    {
        var ageDifference = int.Parse(new string(Console.ReadLine()));
        var rBoxCandles = int.Parse(new string(Console.ReadLine()));
        var tBoxCandles = int.Parse(new string(Console.ReadLine()));

        var rSimCandles = 0;
        var tSimCandles = 0;
        var rSimAge = 4;
        var tSimAge = 3;
        var tDelay = ageDifference - 1;
            
        while (rSimCandles < rBoxCandles)
        {
            rSimCandles += rSimAge++;

            if (tDelay == 0)
                tSimCandles += tSimAge++;

            else
                tDelay--;

            if (tBoxCandles >= tSimCandles)
                continue;

            var rDifference = rBoxCandles - rSimCandles;
            var tDifference = tBoxCandles - tSimCandles;
                    
            if (rDifference + tDifference == 0)
                Console.WriteLine(rDifference);
        }
    }
}