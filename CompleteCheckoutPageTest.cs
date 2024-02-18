using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectLawDepot
{
    class CompleteCheckoutPageTest:CheckoutPageTest
    {
        [Test]
        public void CheckoutSummaryInformation()
        {
            CheckoutInformation();

            //verify item(s) in summary page
            IWebElement cartList = driver.FindElement(By.ClassName("cart_list"));
            cartList.FindElements(By.ClassName("cart_item"));

            //verify summary info
            var summary = driver.FindElement(By.ClassName("summary_info"));
            summary.FindElements(By.Id("summary_info_label"));

            //Click on Finish
            driver.FindElement(By.Id("finish")).Click();

            var checkoutCompleteUrl = driver.Url;
            Assert.AreEqual(checkoutCompleteUrl, "https://www.saucedemo.com/checkout-complete.html");

            //Complete Checkout
            driver.FindElement(By.ClassName("title")).Text.Contains("Checkout: Complete!");
            driver.FindElement(By.ClassName("complete-header")).Text.Contains("Thank you for your order!");
        }

    }
}
