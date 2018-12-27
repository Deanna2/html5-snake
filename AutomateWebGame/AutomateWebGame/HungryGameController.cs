using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomateWebGame
{
    class HungryGameController : GameController
    {
        public HungryGameController(IWebDriver webDriver): base(webDriver){}

        protected override Move GetMove(GameState gameState, Snake snake)
        {
            var Xdistance = Utilities.CalculateXDistance(gameState.SnakeLocation, gameState.FoodLocation);
            if (Xdistance < 0)
            {
                if (snake.LastMove != Move.RIGHT)
                {
                    return Move.LEFT;
                }
            }
            if (Xdistance > 0)
            {
                if (snake.LastMove != Move.LEFT)
                {
                    return Move.RIGHT;
                }
            }
            var Ydistance = Utilities.CalculateYDistance(gameState.SnakeLocation, gameState.FoodLocation);
            if (Ydistance < 0 || snake.LastMove == Move.UP)
            {
                if (snake.LastMove != Move.DOWN)
                {
                    return Move.UP;
                }
            }
            return Move.DOWN;
        }
    }
}
