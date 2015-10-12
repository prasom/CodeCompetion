using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodFillAlgorithmSmaple
{
    class Program
    {
        private const int M = 10;
        private const int N = 10;
        public static int _count = 0;
        static void Main(string[] args)
        {
            int[,] screen = new int[M, N];
            screen = new int[,]
            {
                {1, 0, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 0, 1, 1, 1, 1, 0, 0, 0, 1},
                {1, 0, 1, 1, 1, 1, 1, 1, 0, 1},
                {1, 0, 1, 1, 1, 1, 1, 1, 0, 1},
                {1, 0, 0, 0, 1, 1, 1, 1, 0, 1},
                {1, 1, 1, 1, 1, 1, 1, 0, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 0, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 0, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 0, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
            };

            int x = 1, y = 8, newC = 3;
            FloodFill(screen, x, y, newC);

            Console.WriteLine("Updated screen after call to floodFill: \n");
            Console.WriteLine("FloodFill have been call {0} times", _count);
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(screen[i, j] + " ");
                Console.WriteLine("");
            }
            Console.ReadLine();
        }

        private static void FloodFill(int[,] screen, int x, int y, int newC)
        {
            int prevC = screen[x, y];
            Console.WriteLine("start at {0}", prevC);
            FloodFillUtil(screen, x, y, prevC, newC);
        }

        static void FloodFillUtil(int[,] screen, int x, int y, int prevC, int newC)
        {
            _count++;

            // Base cases
            if (x < 0 || x >= M || y < 0 || y >= N)
                return;
            if (screen[x, y] != prevC)
                return;

            // Replace the color at (x, y)
            screen[x, y] = newC;

            // Recur for north, east, south and west
            FloodFillUtil(screen, x + 1, y, prevC, newC);
            FloodFillUtil(screen, x - 1, y, prevC, newC);
            FloodFillUtil(screen, x, y + 1, prevC, newC);
            FloodFillUtil(screen, x, y - 1, prevC, newC);
        }
    }
}
