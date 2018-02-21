
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace ConsoleApp1.Selenium_tests
{
    class TesteUnitario
    {
        [Test]
        public void TestExemplo()
        {
            IWebDriver driver = new FirefoxDriver();
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));
            IWebElement element = driver.FindElement(By.Id("Página Inicial"));
            
            driver.Navigate().GoToUrl("http://blackboard.facens.br");
            driver.FindElement(By.Id("MainContent_txtUser")).SendKeys("150218");
            driver.FindElement(By.Id("MainContent_txtPassword")).SendKeys("45554321852");
            driver.FindElement(By.Id("MainContent_btnEntra")).Click();
            
        }
    }
}
