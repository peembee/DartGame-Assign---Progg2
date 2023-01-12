using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game playGame = new Game();            
            playGame.PlayGame();
            Console.WriteLine("Press any key to Exit");
            Console.ReadKey();
        }
    }
}
