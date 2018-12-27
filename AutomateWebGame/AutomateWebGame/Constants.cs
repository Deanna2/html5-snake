using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomateWebGame
{
    public static class Constants
    {
        public enum Direction
        {
            Up, Down, Left, Right
        }

        public static Int32 GameWidth = 40;
        public static Int32 GameHeight = 30;
        public static Int32 SnakeInitialHead = 620; // 164, 124
        public static Int32 SnakeInitialLength = 6;

        // These variables relate to the javascript implementation of the game
        public static Int32 SnakeSize = 8;
        public static Int32 X_Offset = 4;
        public static Int32 Y_Offset = 4;
    }
}
