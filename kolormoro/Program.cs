using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace kolormoro
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://kolor.moro.es");

            IWebElement searchStartButton = driver.FindElement(By.Id("kolor-start"));
            searchStartButton.Click();

            IWebElement searchCountOfCircles = driver.FindElement(By.Id("kolor-options"));
            IWebElement searchColor = driver.FindElement(By.Id("kolor-kolor"));

            //.//*[@id='kolor-options']/li[1]/a
            for (int j = 0; j < 5000; j++)
            {
                
                string countStr = searchCountOfCircles.GetAttribute("class");
                int a = Int32.Parse(countStr.Remove(0, 6));
                               
                string color = searchColor.GetCssValue("background-color");
                
                for (int i = 1; i <= a; i++)
                {
                    IWebElement searchChoosableColor = driver.FindElement(By.XPath(".//*[@id='kolor-options']/li[" + i + "]/a"));
                    string choosableColor = searchChoosableColor.GetCssValue("background-color");
                    if (choosableColor == color)
                    {
                        searchChoosableColor.Click();
                        break;                       
                    }
                }
            }
            driver.Close();
        }
    }
}
