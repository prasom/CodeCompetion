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

            //for (int target = 1; target <= 10; target++)
            //{
            //    if (fireable.Fire(target, target) == Result.HIT)
            //    {
            //        hit++;
            //        if (hit == 17)
            //            continue;

            //    }
            //}
            string[,] tempShot = new string[10, 10];
            for (var column = 1; column <= 10; column++)
            {
                Fire(fireable, 1, column, hit, tempShot);
            }


        }

        private void Fire(IFireable fireable, int row, int column, int hit, string[,] tempShot)
        {

            if (hit == 17)
                return;

            if (row < 1 || row > 10 || column < 1 || column > 10)
                return;
            var initRow = row - 1;
            var initCol = column - 1;
            var current = tempShot[initRow, initCol];
            var top = initRow > 0 ? tempShot[initRow - 1, initCol] : "";
            var bottom = initRow < 9 ? tempShot[initRow + 1, initCol] : "";
            var left = initCol > 0 ? tempShot[initRow, initCol - 1] : "";
            var right = initCol < 9 ? tempShot[initRow, initCol + 1] : "";
            if (tempShot[initRow, initCol] == null)
            {
                if (fireable.Fire(column, row) == Result.HIT)
                {
                    hit++;
                    tempShot[initRow, initCol] = "hit";
                    Fire(fireable, row, column + 1, hit, tempShot);
                    Fire(fireable, row, column - 1, hit, tempShot);
                }
                else
                {
                    tempShot[initRow, initCol] = "miss";
                }
            }
            Fire(fireable, row + 1, column, hit, tempShot);
        }
        public string GetTeamName()
        {
            return "Tiger";
        }
    }
}
