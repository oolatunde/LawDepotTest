using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestProjectLawDepot
{
    class CheckoutPageTest : CartPageTest
    {
        [Test]
        public void CheckoutInformation()
        {
            CheckoutProduct();

            var firstName = driver.FindElement(By.Id("first-name"));
            firstName.SendKeys("John");

            var lastName = driver.FindElement(By.Id("last-name"));
            lastName.SendKeys("Law Depot");

            var postalCode = driver.FindElement(By.Id("postal-code"));
            postalCode.SendKeys("XXX-XXX");

            driver.FindElement(By.Id("continue")).Click();

            var checkoutUrl = driver.Url;
            Assert.AreEqual(checkoutUrl, "https://www.saucedemo.com/checkout-step-two.html");

        }
    }
}
