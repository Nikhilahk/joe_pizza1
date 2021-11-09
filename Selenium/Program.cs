using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = null;
            string url = "http://localhost:36069";
            driver = new ChromeDriver(@"C:\DoverCorp");
            driver.Navigate().GoToUrl(url);
            IWebElement home = driver.FindElement(By.Id("Home"));
            home.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            IWebElement pizza = driver.FindElement(By.Id("Pizza"));
            pizza.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            IWebElement cart = driver.FindElement(By.Id("Cart"));
            cart.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            home = driver.FindElement(By.Id("Home"));
            home.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            pizza = driver.FindElement(By.Id("Pizza"));
            pizza.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            IWebElement create = driver.FindElement(By.Id("Create"));
            create.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            IWebElement back = driver.FindElement(By.Id("Back"));
            back.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            IWebElement cartAdd= driver.FindElement(By.Id("CartAdd"));
            cartAdd.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            IWebElement checkout = driver.FindElement(By.Id("Checkout"));
            checkout.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            IWebElement pay = driver.FindElement(By.Id("Pay"));
            pay.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            pay = driver.FindElement(By.Id("Pay"));
            pay.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            driver.Close();







        }
    }
}
