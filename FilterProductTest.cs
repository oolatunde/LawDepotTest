using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing.Enums;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using NUnit.Framework;

namespace TestProjectLawDepot
{
    public class FilterProductTest : Tests
    {
        public void Filter()
        {
            Login(AccountTypes.standard_user);

            //Count the filter types available 
            SelectElement filter = new SelectElement(driver.FindElement(By.ClassName("product_sort_container")));
            IList<IWebElement> elementCount = filter.Options;
            Assert.AreEqual(elementCount.Count, 4);
            Console.Write(elementCount.Count);

            //Validate all the filter options
            int size = elementCount.Count;

            for(int i = 0; i < size; i++)
            {
                var filterOption = elementCount.ElementAt(i).Text;
                Console.WriteLine("Filter By: " + filterOption );
            }

            //Selecting a filter 
            filter.SelectByValue("az"); //Name (A to Z)
            filter.SelectByValue("za"); //Name (Z to A)
            filter.SelectByValue("lohi"); //Price (low to high)
            filter.SelectByValue("hilo"); //Price (high to low)
        }
    }
}
