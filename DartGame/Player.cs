using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartGame
{
    internal class Player
    {
        private int round = 1;
        private string playerName;
        Random random = new Random();        

        private List<Turns> turnsList = new List<Turns>();

        public Player(string playerName = "Secret Bot Player")
        {
            this.playerName = playerName;
        }
        public void AddTurn(int dartPilOne, int dartPilTwo, int dartPilThree)
        {
            turnsList.Add(new Turns(dartPilOne, dartPilTwo, dartPilThree));
        }
        public string showPlayer()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("________________________________");
            Console.WriteLine("Players turn: " + playerName);
            Console.WriteLine("Total Points. " + PointHolder());
            Console.ResetColor();
            return playerName;
        }
        public void PrintTurns()
        {
            System.Threading.Thread.Sleep(600);            
            foreach (var turns in turnsList)
            {
                Console.WriteLine("Round # " + round);
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Player: " + playerName);
                Console.ResetColor();
                turns.PrintRounds();
                Console.WriteLine("_");
                Console.WriteLine("Your best Throw: " + turns.HighestHit() + " Points");
                Console.WriteLine("_____________________________________________");                
                round++;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("____________________________________________________________");
            Console.WriteLine("____________________________________________________________");
            Console.ResetColor();
            Console.WriteLine("next players rounds/Exit, press enter!");
            Console.ReadKey();

        }
        public int PointHolder()
        {
            int pointHolder = 0;
            foreach (var turn in turnsList)
            {
                pointHolder = pointHolder + turn.GetScore();
            }
            return pointHolder;
        }
        public override string ToString()
        {
            return playerName;
        }

    }
}
