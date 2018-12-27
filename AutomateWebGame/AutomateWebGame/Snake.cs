using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutomateWebGame.GameController;

namespace AutomateWebGame
{
    class Snake
    {
        public LinkedList<int> SnakeBody { get; set; }
        public Move LastMove { get; set; }

        public Snake()
        {
            SnakeBody = new LinkedList<int>();
            for (int i = Constants.SnakeInitialHead; i <= Constants.SnakeInitialHead + Constants.SnakeInitialLength; i++)
            {
                SnakeBody.AddLast(i);
            }
        }

        private Move CalculateLastMove(int newLocation)
        {
            var XDifference = Utilities.CalculateXDistance(SnakeBody.First(), newLocation);
            if (XDifference != 0)
            {
                if (XDifference < 0)
                {
                    return GameController.Move.LEFT;
                } else
                {
                    return GameController.Move.RIGHT;
                }
            }
            var YDifference = Utilities.CalculateYDistance(SnakeBody.First(), newLocation);
            if (YDifference != 0)
            {
                if (YDifference < 0)
                {
                    return GameController.Move.UP;
                } else
                {
                    return GameController.Move.DOWN;
                }
            }
            throw new Exception("Error calculating last move: new location is same as current location.");
        }

        public void Move(int location)
        {
            LastMove = CalculateLastMove(location);
            SnakeBody.AddFirst(location);
            SnakeBody.RemoveLast();
            
        }

        public void Feed(int location)
        {
            LastMove = CalculateLastMove(location);
            SnakeBody.AddFirst(location);
        }

        public bool IsCollision(int location)
        {
           return SnakeBody.Contains(location);
        }

        public int GetHead()
        {
            return SnakeBody.First();
        }
    }
}
