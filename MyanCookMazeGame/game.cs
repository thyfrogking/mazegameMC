using ExplorableWorld;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static System.Console;

namespace MyanCookMazeGame
{
    internal class Game
    {
        private World MyWorld;
        private Player CurrentPlayer;
        public void Start()
        {
            string[,] grid = {

                {"=", "=", "=", "=", "=", "=", "=" },
                {"=", " ", "=", " ", " ", " ", "X" },
                {" ", " ", "=", " ", "=", " ", "=" },
                {"=", " ", "=", " ", "=", " ", "=" },
                {"=", " ", " ", " ", "=", " ", "=" },
                {"=", "=", "=", "=", "=", "=", "=" },
            };
           
            MyWorld = new World(grid);

            CurrentPlayer = new Player(0, 2);

            RunGameLoop();

        }

        private void DisplayIntro()
        {
            WriteLine("Welcome to my maze");
            WriteLine("\n here is the instructions");
            WriteLine(" > use the arrow keys to move");
            Write(" > try to reach the goal, wh8ich is displayed as this ");
            ForegroundColor = ConsoleColor.Green;
            WriteLine("X");
            ResetColor();
            WriteLine(" > press any key to start");
            

            ReadKey(true);
        }

        private void DisplayOutro()
        {
            WriteLine("thanks for playing");
            WriteLine("press any key to exit");
            ReadKey(true);
        }
        private void DrawFrame()
        {
            Clear();
            MyWorld.Draw();
            CurrentPlayer.Draw();
            
        }

        private void HandlePlayerInput()
        {
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                    if (MyWorld.Walkability(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;
                    }
                    break;
                    case ConsoleKey.DownArrow:
                    if (MyWorld.Walkability(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Y += 1;
                    }
                    break;
                    case ConsoleKey.LeftArrow:
                    if (MyWorld.Walkability(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X -= 1;
                    }
                       break;
                    case ConsoleKey.RightArrow:
                    if (MyWorld.Walkability(CurrentPlayer.X + 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X += 1;
                    }
                       break;
                    default:
                    break;

                }




        }

        private void RunGameLoop()
        {
            DisplayIntro();
            while (true)
            {
                DrawFrame();

                HandlePlayerInput();

                string ElementAtPlayerPos = MyWorld.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (ElementAtPlayerPos == "X")
                {

                    break;
                }

                System.Threading.Thread.Sleep(100);

               
            }
            Clear();
            DisplayOutro();




        }

    }
}
