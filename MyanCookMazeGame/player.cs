using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ExplorableWorld
{
    internal class Player
    {

        public int X { get; set; }
        public int Y { get; set; }
        private string PlayerMarker;
        private ConsoleColor PlayerColor;
        public Player(int initalX, int initalY)
        {
            X = initalX;
            Y = initalY;
            PlayerMarker = "0";
            PlayerColor = ConsoleColor.Green;
        }

        public void Draw()
        {
            ForegroundColor = PlayerColor;
            SetCursorPosition(X, Y);
            Write(PlayerMarker);
            ResetColor();
        }
    }
}