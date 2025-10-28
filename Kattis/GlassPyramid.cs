using System;

namespace Kattis;

public class GlassPyramid
{
    private const int MaxDepth = 50;
    private static readonly Dictionary<int, Glass> GlassDictionary = new();
    
    private class Glass
    {
        private const decimal Capacity = 1.0m;
        public bool Full = false;
        public decimal Inflow { get; set; } = 0.0m;
        public decimal Volume { get; private set; } = 0.0m;

        public decimal Pour()
        {
            var overflow = 0.0m;
            
            Volume += Inflow;

            if (Volume < Capacity)
                return overflow;
            
            Full = true;
            overflow = Capacity - Volume;
            Volume = Capacity;

            return overflow;
        }
    }

    public static void Execute()
    {
        var targetDepth = int.Parse(new string(Console.ReadLine()));
        var targetIndex = int.Parse(new string(Console.ReadLine()));
        var counter = 0.0;

        for (var depth = 0; depth < MaxDepth; depth++)
        {
            for (var index = 0; index < depth + 1; index++)
            {
                GlassDictionary.Add(HashCode.Combine(depth, index), new Glass());
            }
        }
        
        var targetGlass = GlassDictionary.GetValueOrDefault(HashCode.Combine(targetDepth, targetIndex));
        var topGlass = GlassDictionary.GetValueOrDefault(HashCode.Combine(0, 0));

        if (targetGlass == null)
            throw new ArgumentException("Target glass at depth: " + targetDepth + ", and  target index: " + targetIndex + " was not found");
        
        if (topGlass == null)
            throw new InvalidOperationException("Top glass was not found");
        
        while (!targetGlass.Full)
        {
            topGlass.Inflow = 0.1m;
            
            for (var depth = 0; depth <= targetDepth; depth++)
            {
                for (var index = 0; index < depth + 1; index++)
                {
                    var glass = GlassDictionary.GetValueOrDefault(HashCode.Combine(depth, index));
                    
                    if (glass == null)
                        throw new ArgumentException("Glass at depth: " + depth + ", and index: " + index + " was not found");
                    
                    if (glass.Inflow == 0)
                        continue;

                    if (glass.Full)
                    {
                        HandleOverflow(depth, index, glass.Inflow);
                        glass.Inflow = 0.0m;
                        continue;
                    }

                    var overflow = glass.Pour();
                    glass.Inflow = 0.0m;

                    if (overflow == 0 || depth == MaxDepth - 1)
                        continue;
                    
                    HandleOverflow(depth, index, overflow);
                }
            }

            ++counter;
        }
        
        Console.WriteLine(counter);
        GlassDictionary.Clear();
    }

    private static void HandleOverflow(int depth, int index, decimal overflow)
    {
        var subLeftGlass = GlassDictionary.GetValueOrDefault(HashCode.Combine(depth + 1, index));
        var subRightGlass = GlassDictionary.GetValueOrDefault(HashCode.Combine(depth + 1, index + 1));

        if (subLeftGlass == null || subRightGlass == null)
            throw new ArgumentException("Glass at depth: " + (depth + 1) + ", and index: " + index + " or at " + (depth + 1) + ", and index: " + (index + 1) + " was not found");

        subLeftGlass.Inflow += overflow / 2;
        subRightGlass.Inflow += overflow / 2;
    }
}