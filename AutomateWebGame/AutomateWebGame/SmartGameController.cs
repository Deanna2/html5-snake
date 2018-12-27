using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomateWebGame
{
    class SmartGameController : GameController
    {
        public SmartGameController(IWebDriver webDriver) : base(webDriver) { }

        protected override Move GetMove(GameState gameState, Snake snake)
        {
            var moves = GetOrderedMoves(gameState, snake);
            if (IsSafeMove(moves[0], gameState, snake))
            {
                return moves[0];
            }
            if (IsSafeMove(moves[1], gameState, snake))
            {
                return moves[1];
            }
            return moves[2];
        }

        // Returns an array of length 3
        private Move[] GetOrderedMoves(GameState gameState, Snake snake)
        {
            LinkedList<Move> moveList = new LinkedList<Move>();
            var XDistance = Utilities.CalculateXDistance(gameState.SnakeLocation, gameState.FoodLocation);
            var YDistance = Utilities.CalculateYDistance(gameState.SnakeLocation, gameState.FoodLocation);

            if (snake.LastMove != Move.RIGHT)
            {
                moveList.AddFirst(Move.LEFT);
            }

            if (snake.LastMove != Move.LEFT)
            {
                if (XDistance > 0)
                {
                    moveList.AddFirst(Move.RIGHT);
                } else
                {
                    moveList.AddLast(Move.RIGHT);
                }
            }

            if (snake.LastMove != Move.DOWN)
            {
                if (YDistance < 0)
                {
                    moveList.AddFirst(Move.UP);
                } else
                {
                    moveList.AddLast(Move.UP);
                }
            }

            if (snake.LastMove != Move.UP)
            {
                if (YDistance > 0)
                {
                    moveList.AddFirst(Move.DOWN);
                } else
                {
                    moveList.AddLast(Move.DOWN);
                }
            }
            return moveList.ToArray<Move>();
        }

        private Boolean IsSafeMove(Move move, GameState gameState, Snake snake)
        {
            return true;
        }
    }
}
