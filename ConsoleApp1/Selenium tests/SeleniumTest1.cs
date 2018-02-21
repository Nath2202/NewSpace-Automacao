using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;


namespace ConsoleApp1.Selenium_tests
{
    class SeleniumTest1
    {
        [Test]
        public void TestTaskIt()
        {
            #region Acessando o site pelo Google Chrome
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Url = "http://www.juliodelima.com.br/taskit/";
            #endregion

            #region clicar no botão sign in que possui o link "Sign in"
            driver.FindElement(By.LinkText("Sign in")).Click();
            #endregion

            #region selecionar o campo com o name "login" que pertence ao formulario  id "signinbox"
            IWebElement forms = driver.FindElement(By.Id("signinbox"));
            #endregion

            #region digitar no campo com o name "login" que pertence ao formulario  id "signinbox" o texto "julio0001"
            forms.FindElement(By.Name("login")).SendKeys("julio0001");
            #endregion

            #region digitar no campo com o name "password" que pertence ao formulario  id "signinbox" o texto "123456"
            forms.FindElement(By.Name("password")).SendKeys("123456");
            #endregion

            #region clicar no link com o texto "SIGN IN"
            driver.FindElement(By.LinkText("SIGN IN")).Click();
            #endregion


            




        }
    }
}
