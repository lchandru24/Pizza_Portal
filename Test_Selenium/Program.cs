using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace Test_Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = null;

            driver = new ChromeDriver(@"C:\DoverCorp");

            Thread.Sleep(2000);


            string url = "https://localhost:44370/Pizza";
            driver.Navigate().GoToUrl(url);

            IWebElement addToCart1 = driver.FindElement(By.Name("AddToCart"));
            addToCart1.Click();
            Thread.Sleep(2000);

            IWebElement addToCart2 = driver.FindElement(By.Name("AddToCart"));
            addToCart2.Click();
            Thread.Sleep(2000);

            IWebElement removeFromCart = driver.FindElement(By.Name("RemoveFromCart"));
            removeFromCart.Click();
            Thread.Sleep(2000);

            IWebElement addToCart3 = driver.FindElement(By.Name("AddToCart"));
            addToCart3.Click();
            Thread.Sleep(2000);

            IWebElement addMoreItems = driver.FindElement(By.Name("AddMoreItems"));
            addMoreItems.Click();
            Thread.Sleep(2000);

            IWebElement addToCart4 = driver.FindElement(By.Name("AddToCart"));
            addToCart4.Click();
            Thread.Sleep(2000);

            IWebElement addMoreItems2 = driver.FindElement(By.Name("AddMoreItems"));
            addMoreItems2.Click();
            Thread.Sleep(2000);


            IWebElement chicken_pizza = driver.FindElement(By.CssSelector("a[href*='/Orders/AddItemToShoppingCart/8' "));
            chicken_pizza.Click();
            Thread.Sleep(2000);

            IWebElement addMoreItems3 = driver.FindElement(By.Name("AddMoreItems"));
            addMoreItems3.Click();
            Thread.Sleep(2000);

            IWebElement farmhouse_pizza = driver.FindElement(By.CssSelector("a[href*='/Orders/AddItemToShoppingCart/9' "));
            farmhouse_pizza.Click();
            Thread.Sleep(2000);


            IWebElement completeOrder = driver.FindElement(By.Name("CompleteOrder"));
            completeOrder.Click();
            Thread.Sleep(5000);

            IWebElement Main_Page = driver.FindElement(By.Name("Main_Page"));
            Main_Page.Click();
            Thread.Sleep(5000);

            driver.Close();
        }
    }
}
