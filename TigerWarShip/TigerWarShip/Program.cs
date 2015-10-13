﻿using System;
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
            TigerWarShip tigerWarShip = new TigerWarShip();
            board.CreateRandomBoard();
            tigerWarShip.Play(board);
            Console.WriteLine(tigerWarShip.GetTeamName());
            Console.ReadLine();
        }
    }

    
}
