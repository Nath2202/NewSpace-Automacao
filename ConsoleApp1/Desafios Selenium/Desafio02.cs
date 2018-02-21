using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace ConsoleApp1.Desafios_Selenium
{
    class Desafio02
    {
        [Test]
        public void Desafio2()
        {
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            #region Coletando os elementos que serão arrastados
            driver.Manage().Window.Maximize();
            driver.Url= "http://eliasnogueira.com/arquivos_blog/selenium/desafio/3desafio/drag_and_drop/demo.php";
            IWebElement element1 = driver.FindElement(By.CssSelector("img[alt = 'iPod']"));
            IWebElement element2 = driver.FindElement(By.CssSelector("img[alt = 'iMac']"));
            IWebElement element3 = driver.FindElement(By.CssSelector("img[alt = 'iPhone']"));
            IWebElement element4 = driver.FindElement(By.CssSelector("img[alt = 'iPod Shuffle']"));
            IWebElement element5 = driver.FindElement(By.CssSelector("img[alt = 'iPod Nano']"));
            IWebElement element6 = driver.FindElement(By.CssSelector("img[alt = 'Apple TV']"));

            #endregion

            #region Coletando informação do receptor dos elementos
            IWebElement target = driver.FindElement(By.CssSelector(".content.drop-here.ui-droppable")); 
            #endregion
            Actions action = new Actions(driver);
            action.DragAndDrop(element1,target).Perform();
            wait.Until(d => d.FindElement(By.CssSelector("img[alt = 'loading..']")).Displayed != true);

            Actions action2 = new Actions(driver);
            action2.DragAndDrop(element2, target).Perform();
            wait.Until(d => d.FindElement(By.CssSelector("img[alt = 'loading..']")).Displayed != true);

            driver.Quit();
        }
    }
}
