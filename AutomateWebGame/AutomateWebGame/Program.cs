using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace AutomateWebGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Utilities.GetProjectDirectory());
            IWebDriver driver = new FirefoxDriver(@"C:\Users\Deanna\Documents\Deanna\Programming\C-sharp\WebDrivers");
            var fileString = $"file:///{Utilities.GetProjectDirectory()}/SnakeGame/index.html";
            driver.Url = fileString;
            var gameController = new SmartGameController(driver);
            gameController.PlayGame();
            driver.Quit();
        }
    }
}
