using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;



namespace ConsoleApp1.Desafios_Selenium
{
    class Desafio03
    {
        [Test]
        public void Desafio3()
        {
            IWebDriver driver = new FirefoxDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           
            driver.Url = "http://eliasnogueira.com/arquivos_blog/selenium/desafio/4desafio/";
            #region Parte 1 
            driver.FindElement(By.Id("cep")).SendKeys("01310200");
            driver.FindElement(By.Id("rua")).Click();

            Assert.AreEqual("Avenida: Paulista", driver.FindElement(By.Id("rua")).GetAttribute("value"));

            driver.FindElement(By.Id("numero")).SendKeys("1578");
            Assert.AreEqual("1578", driver.FindElement(By.Id("numero")).GetAttribute("value"));

            driver.FindElement(By.Id("complemento")).SendKeys("MASP");
            Assert.AreEqual("MASP", driver.FindElement(By.Id("complemento")).GetAttribute("value"));

            Assert.AreEqual("Bela Vista", driver.FindElement(By.Id("bairro")).GetAttribute("value"));

            Assert.AreEqual("São Paulo", driver.FindElement(By.Id("cidade")).GetAttribute("value"));

            Assert.AreEqual("SP", driver.FindElement(By.Id("estado")).GetAttribute("value"));

            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();
            #endregion

            #region Parte 2
            Assert.AreEqual("", driver.FindElement(By.Id("cep")).GetAttribute("value"));
            Assert.AreEqual("", driver.FindElement(By.Id("rua")).GetAttribute("value"));
            Assert.AreEqual("", driver.FindElement(By.Id("numero")).GetAttribute("value"));
            Assert.AreEqual("", driver.FindElement(By.Id("complemento")).GetAttribute("value"));
            Assert.AreEqual("", driver.FindElement(By.Id("bairro")).GetAttribute("value"));
            Assert.AreEqual("", driver.FindElement(By.Id("cidade")).GetAttribute("value"));
            Assert.AreEqual("", driver.FindElement(By.Id("estado")).GetAttribute("value"));

            driver.Quit();
            #endregion








        }
    }
}
