using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge1;

namespace TigerWarShip
{
    public class TigerWarShip : IBattleshipAi
    {
        int hit = 0;
        string[,] shotHistory = new string[10, 10];
        public void Play(IFireable fireable)
        {


            for (int i = 1; i < 11; i++)
            {
                Fire(fireable, i, i);
            }

            int startRow = 1;
            for (int i = 10; i >= 0; i--)
            {

                Fire(fireable, startRow, i);
                startRow++;
            }

            for (int i = 1; i < 11; i++)
            {
                Fire(fireable, 6, i);
            }

            for (int i = 1; i < 11; i++)
            {
                Fire(fireable, i, 6);
            }

        }

        public void Fire(IFireable fireable, int row, int col)
        {
            if (hit == 17 || row < 1 || row > 10 || col < 1 || col > 10)
                return;
            var curpoint = shotHistory[row-1, col-1];
            if(curpoint != null)
                return;
            if (fireable.Fire(col, row) == Result.HIT)
            {
                shotHistory[row - 1, col - 1] = "y";
                hit++;
                Fire(fireable, row + 1, col);
                Fire(fireable, row - 1, col);
                Fire(fireable, row, col + 1);
                Fire(fireable, row, col - 1);
            }
            else
            {
                shotHistory[row - 1, col - 1] = "x";
                return;
            }

        }

        private bool CanShot(int row, int col)
        {

            var canShot = false || 10 - col <= 1 & shotHistory[row - 1, col - 1] == "y";
            return canShot;

        }
        public string GetTeamName()
        {
            return "TigerWarShip";
        }
    }
}
