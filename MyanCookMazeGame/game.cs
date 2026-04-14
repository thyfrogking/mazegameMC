using MyanCookMazeGame;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Console;

namespace MyanCookMazeGame
{
    internal class Game
    {
        private World MyWorld;
        private Player CurrentPlayer;
        int score = 0;
        int collected = 0;
        int totalcoins = 0;
       

        public void Start()
        {
            
            CursorVisible = false;

            string[,] grid = levelPusher.TextFileToArray("mazeLeveltxt");
            
           
            MyWorld = new World(grid);

            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    if (grid[y, x] == "c")
                        totalcoins++;
                }
            }


            CurrentPlayer = new Player(1, 1);
           
           
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
          
            SetCursorPosition(20, 20);

            WriteLine("your score is" + score);

        }


        private void HandlePlayerInput()
        {

            ConsoleKey key;
            do
            {
                ConsoleKeyInfo keyInfo = ReadKey(true);
                key = keyInfo.Key;


            } while (KeyAvailable);

            if (MyWorld.Walkability(CurrentPlayer.X, CurrentPlayer.Y))
            {

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
            if (MyWorld.Walkability(CurrentPlayer.X, CurrentPlayer.Y))
            { 
             string elementThere = MyWorld.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (elementThere == "c")
                {
                    score += 1;
                    collected++;
                    MyWorld.SetElementAt(CurrentPlayer.X, CurrentPlayer.Y, " ");
                    
                }
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
