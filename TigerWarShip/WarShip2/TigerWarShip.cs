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
            CutTopLeftAndBottomRight(fireable);
            CutBottomLeftAndTopRight(fireable);
        }

        private void CutTopLeftAndBottomRight(IFireable fireable)
        {
            Fire(fireable, 2, 1);
            Fire(fireable, 1, 2);
            Fire(fireable, 9, 10);
            Fire(fireable, 10, 9);
        }
        private void CutBottomLeftAndTopRight(IFireable fireable)
        {
            Fire(fireable, 9, 1);
            Fire(fireable, 10, 2);
            Fire(fireable, 1, 9);
            Fire(fireable, 2, 10);
        }
        public void RightDiagonalFire(IFireable fireable)
        {
            for (int target = 1; target <= 10; target++)
            {
                Fire(fireable, target, target);
            }
        }
        public void LeftDiagonalFire(IFireable fireable)
        {
            int row = 1;
            for (int target = 10; target >= 1; target--)
            {
                Fire(fireable, target, row);
                row++;
            }
        }

        public void VerticalFire(IFireable fireable)
        {
            int col = 5;
            int row = 1;
            for (int target = row; target <= 10; target++)
            {
                Fire(fireable, col, target);
            }
        }
        public void HorizontalFire(IFireable fireable)
        {
            int col = 1;
            int row = 5;
            for (int target = col; target <= 10; target++)
            {
                Fire(fireable, target, row);
            }
        }
        public void Fire(IFireable fireable, int col, int row)
        {
            if (hitPoint == 17 || row < 1 || row > 10 || col < 1 || col > 10 || shotHistory[row - 1, col - 1] != null)
                return;
            shotHistory[row - 1, col - 1] = "o";
            if (fireable.Fire(col, row) == Result.HIT)
            {
                hitPoint++;
                Fire(fireable, col + 1, row);
                if (col > 1) { Fire(fireable, col - 1, row); }
                Fire(fireable, col, row + 1);
                if (row > 1) { Fire(fireable, col, row - 1); }

            }
        }

        public string GetTeamName()
        {
            return "Tiger";
        }
    }
}