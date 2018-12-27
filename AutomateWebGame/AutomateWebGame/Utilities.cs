using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AutomateWebGame
{
    class Utilities
    {
        public static string GetProjectDirectory()
        {
            var directory = Directory.GetCurrentDirectory();
            for (int i = 0; i < 4; i++)
            {
                directory = Directory.GetParent(directory).ToString();
            }
            return directory.Replace('\\', '/');
        }

        public static int CalculateGameBoardArrayIndex(int x, int y)
        {
            var scaledOffsetX = (x - Constants.X_Offset) / Constants.SnakeSize;
            var scaledOffsetY = (y - Constants.Y_Offset) / Constants.SnakeSize;
            return (scaledOffsetY * Constants.GameWidth) + scaledOffsetX;
        }

        // Returns negative if food is to the left, positive if food is to the right.
        public static int CalculateXDistance(int snake, int food)
        {
            var snakeX = snake % Constants.GameWidth;
            var foodX = food % Constants.GameWidth;
            return foodX - snakeX;
        }

        // Returns negative if food above, positive if food below.
        public static int CalculateYDistance(int snake, int food)
        {
            var snakeX = snake / Constants.GameWidth;
            var foodX = food / Constants.GameWidth;
            return foodX - snakeX;
        }

        public static int LocationTextToGameBoardIndex(string location)
        {
            var locationCoordinates = location.Split(' ');
            var x = Int32.Parse(locationCoordinates[0]);
            var y = Int32.Parse(locationCoordinates[1]);
            return CalculateGameBoardArrayIndex(x, y);
        }
    }
}
