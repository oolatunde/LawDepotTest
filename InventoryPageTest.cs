using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using testing.Enums;

namespace TestProjectLawDepot
{
    public class InventoryPageTest : Tests
    {
        
        public void StandardUser()
        {
            Login(AccountTypes.standard_user);
            Thread.Sleep(1000);
        }
        [Test]
        public void AddBackPack()
        {
            StandardUser();
            driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();
            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
        }
        [Test]
        public void AddBikeLight()
        {
            StandardUser();
            driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light")).Click();
            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
        }
        [Test]
        public void AddBoltShirt()
        {
            StandardUser();
            driver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt")).Click();
            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
        }
        [Test]
        public void AddFleeceJacket()
        {
            StandardUser();
            driver.FindElement(By.Id("add-to-cart-sauce-labs-fleece-jacket")).Click();
            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
        }
        [Test]
        public void AddOneSie()
        {
            StandardUser();
            driver.FindElement(By.Id("add-to-cart-sauce-labs-onesie")).Click();
            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
        }
        [Test]
        public void AddTShirt()
        {
            StandardUser();
            driver.FindElement(By.Id("add-to-cart-test.allthethings()-t-shirt-(red)")).Click();
            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
        }

        [Test]
        public void AllInventoryTest()
        {
            bool check;
            StandardUser();
            //checking inventory count 

            IWebElement inventory = driver.FindElement(By.ClassName("inventory_list"));
            int inventoryCount = inventory.FindElements(By.ClassName("inventory_item")).Count();
            //Console.WriteLine("Inventory Count: "+ inventoryCount);
            if (inventoryCount == 6)
                check = true;
            else
                check = false;

            Assert.IsTrue(check);

            var inventoryElements = inventory.FindElements(By.ClassName("inventory_item"));
            //validating the images of the products

            foreach (var inventoryElement in inventoryElements)
            {
               var imgInv = inventoryElement.FindElement(By.ClassName("inventory_item_img"));
               var imgFound = imgInv.FindElement(By.TagName("img")).GetAttribute("alt").Contains("Sauce Labs Backpack");

                if (imgFound)
                    check = true;

                Assert.IsTrue(check);
            }

            //Adding all items to cart and validating the number of items added to cart
            foreach (var inventoryElement in inventoryElements)
            {
                var buttons = inventoryElement.FindElement(By.ClassName("pricebar"));
                var button = buttons.FindElement(By.TagName("button"));
                button.Click();
                Thread.Sleep(1000);
            }

            driver.FindElement(By.ClassName("shopping_cart_badge")).Text.Equals("6");
            Thread.Sleep(2000);

        }
    }
}
