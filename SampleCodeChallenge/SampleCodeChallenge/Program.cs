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
        string[,] shotHistory = new string[10, 10];
        public void Play(IFireable fireable)
        {
            int hit = 0;

            //for (int target = 1; target <= 10; target++)
            //{
            //    if (fireable.Fire(target, target) == Result.HIT)
            //    {
            //        hit++;
            //        if (hit == 17)
            //            continue;

            //    }
            //}
            
            for (var column = 1; column <= 10; column++)
            {
                FireDown(fireable, 1, column, hit);
            }


        }

        private void FireDown(IFireable fireable, int row, int column, int hit)
        {

            if (hit == 17)
                return;

            if (row < 1 || row > 10 || column < 1 || column > 10)
                return;
            var initRow = row - 1;
            var initCol = column - 1;
            var current = shotHistory[initRow, initCol];
            var top = initRow > 0 ? shotHistory[initRow - 1, initCol] : "";
            var bottom = initRow < 9 ? shotHistory[initRow + 1, initCol] : "";
            var left = initCol > 0 ? shotHistory[initRow, initCol - 1] : "";
            var right = initCol < 9 ? shotHistory[initRow, initCol + 1] : "";
            if (shotHistory[initRow, initCol] == null)
            {
                if (right != "miss")
                {
                    if (fireable.Fire(column, row) == Result.HIT)
                    {
                        hit++;
                        shotHistory[initRow, initCol] = "hit";
                        FindAnyShip(fireable, row, column, hit, shotHistory);
                        //Fire(fireable, row, column - 1, hit, tempShot);
                    }
                    else
                    {
                        shotHistory[initRow, initCol] = "miss";
                    }
                }
                else
                {
                    shotHistory[initRow, initCol] = "miss";
                }
            }
            FireDown(fireable, row + 1, column, hit);
        }

        private void FindAnyShip(IFireable fireable, int row, int col, int hitPoint, string[,] historyStrings)
        {
            if (hitPoint == 17)
                return;

            if (row < 1 || row > 10 || col < 1 || col > 10)
                return;
            var initRow = row - 1;
            var initCol = col - 1;
            var current = historyStrings[initRow, initCol];
            var top = initRow > 0 ? historyStrings[initRow - 1, initCol] : "";
            var bottom = initRow < 9 ? historyStrings[initRow + 1, initCol] : "";
            var left = initCol > 0 ? historyStrings[initRow, initCol - 1] : "";
            var right = initCol < 9 ? historyStrings[initRow, initCol + 1] : "";
            if (historyStrings[initRow, initCol] == null)
            {
                if (right != "miss")
                {
                    if (fireable.Fire(col, row) == Result.HIT)
                    {
                        hitPoint++;
                        historyStrings[initRow, initCol] = "hit";
                        FindAnyShip(fireable, row, col + 1, hitPoint, historyStrings);
                        FindAnyShip(fireable, row, col - 1, hitPoint, historyStrings);
                    }
                    else
                    {
                        historyStrings[initRow, initCol] = "miss";
                    }
                }
                else
                {
                    historyStrings[initRow, initCol] = "miss";
                }
            }
        }
        public string GetTeamName()
        {
            return "Tiger";
        }
    }
}
