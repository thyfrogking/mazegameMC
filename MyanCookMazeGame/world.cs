using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;


namespace MyanCookMazeGame
{
    internal class World
    {
        private string[,] Grid;
        private int Rows;
        private int Columns;

        public World(string[,] grid)
        {
            Grid = grid;
            Rows = grid.GetLength(0);
            Columns = grid.GetLength(1);
        }


        public void Draw()
        {
            // in the game y = the row and x= the collumn
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    string element = Grid[y, x];
                    Console.SetCursorPosition(x, y);
                    Write(element);
                }
            }

        }

        public string GetElementAt(int x, int y)
        {
            return Grid[y, x];
        }

        //says if player can walk on the space
        public bool Walkability(int x, int y)
        {
            //checking for bounds of x and y
            if (x < 0 || y < 0 || x >= Columns || y >= Rows)
            {
                return false;
            }

            return Grid[y, x] == " " || Grid[y, x] == "X";

        }


    }
}
