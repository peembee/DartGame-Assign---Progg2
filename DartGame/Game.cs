using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartGame
{
    internal class Game
    {
        private string playerName;
        private int numberOfPlayers;
        private int totalScore;
        private int round = 1;
        int dartCounter = 0;
        private int showPlayerNumber = 1;

        private new int[] dartpils = new int[3];
        private List<Player> playerList = new List<Player>();

        public Game()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("----");
            Console.WriteLine("Welcome to the Game of Darts");
            Console.WriteLine("----");
            Console.WriteLine("Rules:");
            Console.WriteLine("3 Darts. 1 - 20 Point. Max 60 Points / Round");
            Console.WriteLine("-");
            Console.WriteLine("Use a Random aim, press 0 when you are about to aim");            
            Console.WriteLine("-");
            Console.WriteLine("First up do 301points win the game!");
            Console.WriteLine("---------------------------------------");
        }
        public void PlayGame()
        {
            loadingscene(2);
            while (true)
            {
                try
                {
                    Console.WriteLine("----");
                    Console.Write("How many player would you like to add?: ");
                    numberOfPlayers = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    NotRecognizedInput();
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("To play with a bot, press enter or type BOT");
            Console.ResetColor();

            for (int i = 0; i < numberOfPlayers; i++)  // set name in class: Players, constructor
            {
                Console.WriteLine("____");
                Console.WriteLine("Player: " + showPlayerNumber);
                Console.Write("Enter your name please: ");
                playerName = Console.ReadLine();
                showPlayerNumber++;
                addPlayer(playerName);
            }

            while (totalScore < 301)
            {
                foreach (var player in playerList)
                {
                    playerName = player.showPlayer();
                    Console.WriteLine("Round # " + round);
                    dartCounter = 1;
                    if (playerName != "Secret Bot Player")
                    {
                        for (int i = 0; i < dartpils.Length; i++)
                        {                            
                            Console.WriteLine("Dart # " + dartCounter);
                            dartCounter++;
                            while (true)
                            {
                                try
                                {
                                    Console.Write("Tell me what number you aiming on: ");
                                    dartpils[i] = Convert.ToInt32(Console.ReadLine());
                                    if (dartpils[i] < 0 || dartpils[i] > 20)
                                    {
                                        NotRecognizedInput();
                                    }
                                    else 
                                    { 
                                        break;
                                    }
                                    
                                }
                                catch (Exception e)
                                {
                                    NotRecognizedInput();
                                }
                            }
                            
                            Console.WriteLine("--");
                            Console.WriteLine("Click to throw");
                            Console.ReadKey();

                            loadingscene(1);

                            dartpils[i] = aimDart(dartpils[i]);
                        }
                    }
                    else
                    {
                        botPlayer();
                    }
                    
                    player.AddTurn(dartpils[0], dartpils[1], dartpils[2]);
                    totalScore = player.PointHolder();
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Total Points: " + totalScore);
                    Console.WriteLine("------------------------------------");
                    Console.ReadKey();
                    if (totalScore >= 301)
                    {
                        break;
                    }
                }
                round++;
                Console.Clear();
            }
            Console.WriteLine("------------------------------------");
            Console.WriteLine("We have a winner: " + playerName + ". Score " + totalScore);
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Results, Press enter");
            Console.ReadKey();
            loadingscene(3);
            Console.Clear();

            foreach (var player in playerList)
            {
                player.PrintTurns();
            }
        }
        private void loadingscene(int loadingScenes)
        {
            if (loadingScenes == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                System.Threading.Thread.Sleep(100);
                Console.WriteLine(" --->");
                System.Threading.Thread.Sleep(100);
                Console.WriteLine("   --->");
                System.Threading.Thread.Sleep(100);
                Console.WriteLine("     --->");
                System.Threading.Thread.Sleep(100);
                Console.WriteLine("       --->");
                System.Threading.Thread.Sleep(200);
                Console.ResetColor();
            }
            else if (loadingScenes == 2)
            {
                System.Threading.Thread.Sleep(700);
                Console.WriteLine("Loading..");
                Console.ForegroundColor = ConsoleColor.Red;
                System.Threading.Thread.Sleep(700);
                Console.WriteLine("____      __________      _______     ");
                System.Threading.Thread.Sleep(300);
                Console.WriteLine("    ______          ______       _____");
                System.Threading.Thread.Sleep(100);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                System.Threading.Thread.Sleep(150);
                Console.WriteLine(" --->");
                System.Threading.Thread.Sleep(150);
                Console.WriteLine("   --->");
                System.Threading.Thread.Sleep(150);
                Console.WriteLine("     --->");
                System.Threading.Thread.Sleep(150);
                Console.WriteLine("       --->");
                System.Threading.Thread.Sleep(150);
                Console.WriteLine("       --->");
                System.Threading.Thread.Sleep(150);
                Console.WriteLine("     --->");
                System.Threading.Thread.Sleep(150);
                Console.WriteLine("   --->");
                System.Threading.Thread.Sleep(150);
                Console.WriteLine(" --->");
                Console.ResetColor();
            }
        }
        public void NotRecognizedInput()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Something went wrong /");
            Console.WriteLine("I only handle numbers: 0 - 20");
            Console.WriteLine("------------------------------------");
            Console.ResetColor();
        }
        private void addPlayer(string setupName)
        {
            if (string.IsNullOrWhiteSpace(setupName) || setupName.ToLower().Contains("bot"))
            {
                playerList.Add(new Player());
            }
            else
            {
                playerList.Add(new Player(setupName));
            }
        }
        private void botPlayer()
        {
            dartCounter = 1;
            Random random = new Random();
            System.Threading.Thread.Sleep(1000);
            for (int i = 0; i < dartpils.Length; i++)
            {
                Console.WriteLine("Dart # " + dartCounter);
                dartCounter++;
                dartpils[i] = random.Next(1, 21);
                Console.WriteLine("-");
                Console.WriteLine("Throwing..");
                loadingscene(1);
                dartpils[i] = aimDart(dartpils[i]);
                System.Threading.Thread.Sleep(500);
            }
        }
        private int aimDart(int dartPil)
        {
            Random random = new Random();
            int minPoint = dartPil;
            int maxPoint = dartPil;
            while (true)
            {
                if (dartPil == 0)
                {
                    dartPil = random.Next(0, 21);
                }
                else if (dartPil >= 0 && dartPil <= 5)
                {
                    minPoint = minPoint - 1;
                    maxPoint = maxPoint + 7;
                    dartPil = random.Next(minPoint, maxPoint);
                    break;
                }
                else if (dartPil >= 6 && dartPil <= 10)
                {
                    minPoint = minPoint - 3;
                    maxPoint = maxPoint + 7;
                    dartPil = random.Next(minPoint, maxPoint);
                    break;
                }
                else if (dartPil >= 11 && dartPil <= 16)
                {
                    minPoint = minPoint - 5;
                    maxPoint = maxPoint + 6;
                    dartPil = random.Next(minPoint, maxPoint);
                    break;
                }
                else if (dartPil >= 17 && dartPil <= 20)
                {
                    minPoint = minPoint - 18;
                    maxPoint = maxPoint + 4;
                    dartPil = random.Next(minPoint, maxPoint);

                    break;
                }
            }
            if (dartPil < 0)
            {
                dartPil = 0;
            }
            else if (dartPil > 20)
            {
                dartPil = 20;
            }
            Console.WriteLine("You hit:  " + dartPil);
            return dartPil;
        }
    }
}
