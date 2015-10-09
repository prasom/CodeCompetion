using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge1;

namespace SampleCodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            BattleshipBoard board = new BattleshipBoard();
            TigerWarShip tigerWarShip = new TigerWarShip();
            tigerWarShip.Play(board);
            Console.WriteLine(tigerWarShip.GetTeamName());
            Console.ReadLine();
        }
    }

    class TigerWarShip : IBattleshipAi
    {
        public void Play(IFireable fireable)
        {
            int hit = 0;
            for (int row = 1; row <= 10; row++)
            {
                for (int column = 1; column <= 10; column++)
                {
                    if (fireable.Fire(row, column) == (Result)ShotResult.HIT)
                    {
                        hit++;
                        Console.WriteLine("Hit on col {0} row {1} and now total {2}", row, column, hit);
                        if (hit == 17)
                            continue;

                    }
                }
            }
        }

        public string GetTeamName()
        {
            return "Liger";
        }
    }

    enum ShotResult
    {
        HIT,
        MISS,
        MISSION_COMPLETED
    }
}
