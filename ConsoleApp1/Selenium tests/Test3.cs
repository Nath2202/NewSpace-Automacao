using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;

namespace ConsoleApp1.Selenium_tests
{
    class Test3
    {
        
        [Test]
        public void Test()
        {
            
            IWebDriver driver2 = new ChromeDriver();

            driver2.Navigate().GoToUrl("http://demoqa.com");

            driver2.FindElement(By.Id("menu-item-155")).Click();
            driver2.Navigate().Back();
            driver2.Navigate().Forward();
            driver2.Navigate().Refresh();
            driver2.Close();
        }
    }
}
