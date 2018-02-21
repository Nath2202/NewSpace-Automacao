
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;


namespace ConsoleApp1
{
    class Class1
    {
        IWebDriver driver;
        [SetUp]
        public void Initialize()
        {
            driver = new FirefoxDriver();
        }
        [Test]
        public void OpenApp()
        {
            driver.Url = "http://www.google.com.br";
        }
        [TearDown]
        public void CloseApp()
        {
            driver.Close();
        }
    }
}
