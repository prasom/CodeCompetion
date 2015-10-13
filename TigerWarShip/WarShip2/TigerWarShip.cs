using CodeChallenge1;

namespace WarShip2
{
    public class TigerWarShip : IBattleshipAi
    {
        public const int width = 10;
        public const int height = 10;
        private int hitPoint = 0;
        private string[,] shotHistory = new string[10, 10];
        public void Play(IFireable fireable)
        {
            Fire(fireable, 1, 3);
            Fire(fireable, 1, 5);
            Fire(fireable, 1, 7);
            Fire(fireable, 1, 9);
            Fire(fireable, 1, 11);
            Fire(fireable, 3, 13);
            Fire(fireable, 5, 15);
            Fire(fireable, 7, 17);
            Fire(fireable, 9, 19);
        }


        public void Fire(IFireable fireable, int col, int odd)
        {
            var _tempRow = (col - odd) * -1;
            if (col > 10 || _tempRow == 0 || _tempRow > 10 || _tempRow < 1 || shotHistory[col - 1, _tempRow - 1] != null)
                return;
            if (fireable.Fire(col, _tempRow) == Result.HIT)
            {
                AddHistory(col, _tempRow, "o");
                FireAround(fireable, col - 1, _tempRow);
                FireAround(fireable, col + 1, _tempRow);
                FireAround(fireable, col, _tempRow - 1);
                FireAround(fireable, col, _tempRow + 1);
            }
            else
            {
                AddHistory(col, _tempRow, "x");
            }
            Fire(fireable, col + 1, odd);
        }

        private void FireAround(IFireable fireable, int col, int row)
        {
            if (col > 10 || col < 1 || row > 10 || row < 1)
                return;
            if (IsAvaliableTarget(col - 1, row - 1))
            {
                if (fireable.Fire(col, row) == Result.HIT)
                    AddHistory(col, row, "o");
                else
                {
                    AddHistory(col, row, "x");
                }
            }
            else
            {
                AddHistory(col, row, "x");
            }
        }

        private void AddHistory(int col, int row, string val)
        {
            shotHistory[col - 1, row - 1] = val;
        }

        private bool IsAvaliableTarget(int col, int row)
        {
            var status = shotHistory[col, row] == null;
            return status;
        }

        //private void AddShotHistory(int col,int row,string val)
        //{
        //    shotHistory[col - 1, row - 1] = val;
        //}
        public string GetTeamName()
        {
            return "Tiger";
        }
    }
}