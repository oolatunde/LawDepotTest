using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using testing.Enums;

namespace TestProjectLawDepot
{
    public class Tests
    {
        public static IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            driver = new ChromeDriver("C:\\Users\\jxolatun\\LawDepot\\TestProject1");
           
            driver.Url = "https://www.saucedemo.com/";
        }

        public void Login(AccountTypes user)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement userName = driver.FindElement(By.Id("user-name"));
            userName.SendKeys(user.ToString());
            IWebElement passWord = driver.FindElement(By.Id("password"));
            passWord.SendKeys(Password.secret_sauce.ToString());
            Thread.Sleep(1000);
            driver.FindElement(By.Id("login-button")).Click();
            Thread.Sleep(3000);
        }
      

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Webdriver exit");
            driver.Quit();
        }
    }
}