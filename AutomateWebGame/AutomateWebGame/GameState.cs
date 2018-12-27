using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomateWebGame
{
    class GameState
    {
        public GameState(IWebDriver driver)
        {
            this.Score = Int32.Parse(driver.FindElement(By.Id("gameScore")).Text);
            this.SnakeLength = Int32.Parse(driver.FindElement(By.Id("snakeLength")).Text);
            this.Status = driver.FindElement(By.Id("status")).Text == "1" ? GameStatus.CONTINUE : GameStatus.GAMEOVER;
            this.SnakeLocation = Utilities.LocationTextToGameBoardIndex(driver.FindElement(By.Id("snakeLocation")).Text);
            this.FoodLocation = Utilities.LocationTextToGameBoardIndex(driver.FindElement(By.Id("foodLocation")).Text);
        }

        public enum GameStatus
        {
            CONTINUE,
            GAMEOVER
        };

        public int Score {get; }

        public int SnakeLength { get; }

        public GameStatus Status { get; }

        public int FoodLocation { get; }

        public int SnakeLocation { get; }

        public override string ToString()
        {
            var statusString = this.Status == GameStatus.CONTINUE ? "Continue" : "Game Over";
            return $"Status: {statusString}, Score: {this.Score}, Snake Length: {this.SnakeLength}, SnakeLocation: {this.SnakeLocation}, Food: {this.FoodLocation}";
        }
    }
}
