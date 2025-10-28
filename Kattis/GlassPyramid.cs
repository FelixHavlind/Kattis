using System;

namespace Kattis;

public class GlassPyramid
{
    private const int MaxDepth = 50;
    
    private class Glass(int depth, int index, Glass? subLeftGlass = null, Glass? subRightGlass = null)
    {
        private const double Capacity = 10.0;
        
        public int Depth { get; } = depth;
        public int Index { get; } = index;
        public double Inflow { get; set; }
        public bool Bottom => Depth == MaxDepth - 1;
        public Glass? SubLeftGlass { get; } = subLeftGlass;
        public Glass? SubRightGlass { get; } = subRightGlass;
        public bool Full => _volume == Capacity;
        
        private double _volume;

        public double IncreaseVolume(double amount)
        {
            _volume += amount;
            var overflow = 0.0;

            if (_volume >= Capacity)
            {
                overflow = _volume = Capacity;
            }
            
            return overflow;
        }
    }

    public static void Execute()
    {
        var targetDepth = int.Parse(new string(Console.ReadLine()));
        var targetIndex = int.Parse(new string(Console.ReadLine()));
        
        var glassQueue = new Queue<Glass>();
        var topGlass = _initiateGlassPyramid();
        var targetGlassFull = false;
        var counter = 0.0;
        
        while (!targetGlassFull)
        {
            topGlass.Inflow = 1.0;
            glassQueue.Enqueue(topGlass);
            
            while (0 < glassQueue.Count)
            {
                var glass = glassQueue.Dequeue();
                var overflow = glass.IncreaseVolume(glass.Inflow);
                glass.Inflow = 0.0;

                if (0 < overflow)
                {
                    if (glass.SubLeftGlass != null)
                    {
                        glass.SubLeftGlass.Inflow = overflow / 2;
                        
                        if (!glassQueue.Contains(glass.SubLeftGlass))
                            glassQueue.Enqueue(glass.SubLeftGlass);
                    }

                    if (glass.SubRightGlass != null)
                    {
                        glass.SubRightGlass.Inflow = overflow / 2;
                        glassQueue.Enqueue(glass.SubRightGlass);  
                    }
                }

                if (glass.Depth != targetDepth || glass.Index != targetIndex || !glass.Full)
                    continue;
                
                targetGlassFull = true;
                Console.WriteLine(++counter);
                break;
            }
            
            ++counter;
        }
    }

    private static Glass _initiateGlassPyramid()
    {
        var glassStack = new Stack<Glass>();

        for (var depth = MaxDepth - 1; 0 <= depth; depth--)
        {
            for (var index = 0; index < depth + 1; index++)
            {
                if (depth == MaxDepth - 1)
                    glassStack.Push(new Glass(depth, index));

                else
                {
                    glassStack.Push(new Glass(depth, index, glassStack.Pop(), index != depth ? 
                        glassStack.Peek() : 
                        glassStack.Pop()));
                }
            }
        }

        return glassStack.Pop();
    }
}