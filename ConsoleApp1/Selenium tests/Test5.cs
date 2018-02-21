using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;

namespace ConsoleApp1.Selenium_tests
{
    class Test5
    {
        [Test]
        public void Test()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://eliasnogueira.com/arquivos_blog/selenium/desafio/1desafio/";
            String num1 = driver.FindElement(By.Id("number1")).Text;
            String num2 = driver.FindElement(By.Id("number2")).Text;

            int resultado = Convert.ToInt32(num1) + Convert.ToInt32(num2);

            driver.FindElement(By.Name("soma")).SendKeys(resultado.ToString());
            driver.FindElement(By.Name("submit")).Click();

            Assert.AreEqual("CORRETO", driver.FindElement(By.Id("resultado")).Text);

            driver.Quit();


        }
    }
}
