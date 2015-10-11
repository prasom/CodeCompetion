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
            board.CreateRandomBoard();
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
            int startRow = 0;
            int startColumn = 0;
            for (int row = 1; row <=10; row++)
            {
                if (fireable.Fire(row, row) == (Result)ShotResult.HIT)
                {
                    hit++;
                    Console.WriteLine("Hit on col {0} row {1} and now total {2}", row, row, hit);
                    if (hit == 17)
                        continue;
                    //Fire Up
                    var preTopRow = row - 1;
                    if (preTopRow > 1)
                    {
                        Console.WriteLine("?? {0}", row);
                        while (fireable.Fire(row, preTopRow--).Equals(ShotResult.MISS))
                        {
                           
                        }
                    }
                    //Fire Down
                    var preBottomRow = row + 1;
                    if (preBottomRow <= 10 & preBottomRow > row)
                    {
                        Console.WriteLine("?? {0}", row);
                        while (fireable.Fire(row, preBottomRow++).Equals(ShotResult.MISS))
                        {

                        }
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
