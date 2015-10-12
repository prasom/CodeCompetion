using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge1;

namespace TigerWarShip
{
    class Program
    {
        static void Main(string[] args)
        {
            BattleshipBoard board = new BattleshipBoard();
            TigerWarShip tigerWarShip = new TigerWarShip(1, 1);
            board.CreateRandomBoard();
            tigerWarShip.Play(board);
            Console.WriteLine(tigerWarShip.GetTeamName());
            Console.ReadLine();
        }
    }

    public class TigerWarShip : IBattleshipAi
    {
        private int _row;
        private int _col;

        public TigerWarShip(int row, int col)
        {
            _col = col;
            _row = row;
        }

        public void Play(IFireable fireable)
        {

            int hit = 0;

            for (int target = 1; target <= 10; target++)
            {
                if (fireable.Fire(target, target) == Result.HIT)
                {
                    hit++;
                    if (hit == 17)
                        continue;
                    while (fireable.Fire(target++, target) == Result.MISS)
                    {
                        
                    }
                   
                }
            }
        }

        public string GetTeamName()
        {
            return "TigerWarShip";
        }
    }
}
