using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace TestProjectLawDepot
{
    class CartPageTest : InventoryPageTest
    {
        [Test]
        public void RemoveAllCartProduct()
        {
            AllInventoryTest();
            driver.FindElement(By.ClassName("shopping_cart_link")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Thread.Sleep(2000);
            IWebElement cartList = driver.FindElement(By.ClassName("cart_list"));
            var cartItems = cartList.FindElements(By.ClassName("cart_item"));

            foreach (var cartItem in cartItems)
            {
                var buttons = cartItem.FindElement(By.ClassName("item_pricebar"));
                var button = buttons.FindElement(By.TagName("button"));
                button.Click();
                Thread.Sleep(1000);
            }
            try
            {
                driver.FindElement(By.ClassName("shopping_cart_badge"));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("All items removed"); 
            }
        }

        //To remove a particular product
        [Test]
        public void RemoveBackPack()
        {
            AddBackPack();
            driver.FindElement(By.Id("remove-sauce-labs-backpack")).Click();
        }
        [Test]
        public void RemoveBikeLight()
        {
            AddBikeLight();
            driver.FindElement(By.Id("remove-sauce-labs-bike-light")).Click();
        }
        [Test]
        public void RemoveBoltShirt()
        {
            AddBoltShirt();
            driver.FindElement(By.Id("remove-sauce-labs-bolt-t-shirt")).Click();
        }
        [Test]
        public void RemoveFleeceJacket()
        {
            AddFleeceJacket();
            driver.FindElement(By.Id("remove-sauce-labs-fleece-jacket")).Click();
        }
        [Test]
        public void RemoveOneSie()
        {
            AddOneSie();
            driver.FindElement(By.Id("remove-sauce-labs-onesie")).Click();
        }
        [Test]
        public void RemoveTShirt()
        {
            AddTShirt();
            driver.FindElement(By.Id("remove-test.allthethings()-t-shirt-(red)")).Click();
        }

        // Test for Continue Shopping Button

        public void ContinueShopping()
        {
            var continueBtn = driver.FindElement(By.CssSelector("#continue-shopping"));
            continueBtn.Text.Contains("Continue Shopping");
            continueBtn.Click();
        }

        //Test for Checkout and validating the URL
        [Test]
        public void CheckoutProduct()
        {
            AddTShirt();
           
            var checkoutBtn = driver.FindElement(By.CssSelector("#checkout"));
            checkoutBtn.Text.Contains("Checkout");
            checkoutBtn.Click();
            
            var currentUrl = driver.Url;
            Assert.AreEqual(currentUrl, "https://www.saucedemo.com/checkout-step-one.html");
        }
    }
}
