using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;
using WebApplication1.Models;

namespace ClassLibrary1
{
    [TestFixture]
    public class Class1
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void Test_PizzaObj()
        { 
            //------------------------------------------------------------------------------------------------------------------------------------
            PizzaObj po = new PizzaObj();
            Pizza p = po.GetPizzaById(1001);
            var Actname = p.Name;
            var ExName = "Margeretta";
            Assert.AreEqual(Actname,ExName);
            p = po.GetPizzaById(1002);
            Actname = p.Name;
            ExName = "cheese and corn pizza";
            Assert.AreEqual(ExName, Actname);
           
        }
        [Test]
        public void checkNavigation()
        {
            IWebDriver driver = null;
            string url = "http://localhost:36069";
            driver = new ChromeDriver(@"C:\chromedriver_win32");
            driver.Navigate().GoToUrl(url);
            IWebElement pizza = driver.FindElement(By.Id("Pizza"));
            pizza.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            string preurl = driver.Url;
            string Acturl = "http://localhost:36069/Pizza";
            Assert.AreEqual(preurl, Acturl);
            IWebElement cart = driver.FindElement(By.Id("Cart"));
            cart.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            pizza = driver.FindElement(By.Id("Pizza"));
            pizza.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            IWebElement cartAdd = driver.FindElement(By.Id("CartAdd"));
            cartAdd.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            IWebElement checkout = driver.FindElement(By.Id("Checkout"));
            checkout.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            preurl = driver.Url;
            Acturl = "http://localhost:36069/Cart/Checkout";
            Assert.AreEqual(Acturl, preurl);
            IWebElement pay = driver.FindElement(By.Id("pay"));
            pay.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            preurl = driver.Url;
            Acturl = "http://localhost:36069/Cart/Payment";
            driver.Close();
        }

        
    }
}
