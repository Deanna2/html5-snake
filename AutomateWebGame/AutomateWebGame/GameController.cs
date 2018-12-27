using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomateWebGame
{
    abstract class GameController
    {
        IWebDriver WebDriver { get; }

        public enum Move {
            UP,
            DOWN,
            LEFT,
            RIGHT
        }

        public GameController(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public void PlayGame()
        {
            Console.WriteLine("Start Game");
            StartGame();
            Console.WriteLine("Get Last Game State");
            var lastGameState = new GameState(WebDriver);
            var currentGameState = new GameState(WebDriver);
            var snake = new Snake();
            while (currentGameState.Status == GameState.GameStatus.CONTINUE)
            {
                Console.WriteLine("In Game Loop");
                // Poll for new game state
                Thread.Sleep(TimeSpan.FromMilliseconds(20));
                currentGameState = new GameState(WebDriver);

                // Make move if game state has changed
                if (lastGameState.SnakeLocation != currentGameState.SnakeLocation) {
                    // Update snake
                    if (lastGameState.SnakeLength != currentGameState.SnakeLength)
                    {
                        snake.Feed(currentGameState.SnakeLocation);
                    } else
                    {
                        snake.Move(currentGameState.SnakeLocation);
                    }

                    Console.WriteLine("Making next move");
                    var move = GetMove(currentGameState, snake);
                    MakeMove(move);
                    lastGameState = currentGameState;
                }
                Console.WriteLine($"Current game state {currentGameState.ToString()}");
            }
            Console.WriteLine("Game Over");
        }

        private void MakeMove(Move move)
        {
            var Action = new Actions(WebDriver);
            switch (move)
            {
                case Move.UP:
                    Action.SendKeys(Keys.ArrowUp).Perform();
                    break;
                case Move.DOWN:
                    Console.WriteLine("Making Move Down");
                    Action.SendKeys(Keys.ArrowDown).Perform();
                    break;
                case Move.LEFT:
                    Action.SendKeys(Keys.ArrowLeft).Perform();
                    break;
                case Move.RIGHT:
                    Action.SendKeys(Keys.ArrowRight).Perform();
                    break;
            }
        }

        protected abstract Move GetMove(GameState gameState, Snake snake);

        private Move MoveToFood(GameState gameState, Snake snake)
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
                } else
                {
                    // This else stops the snake from only going down when the food reappears directly above it.
                    return Move.LEFT;
                }
            }
            return Move.DOWN;
        }

        private void StartGame()
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(1000));
            var Action = new Actions(WebDriver);
            Action.SendKeys(Keys.Space).Perform();
            Thread.Sleep(TimeSpan.FromMilliseconds(50));
        }
    }
}
