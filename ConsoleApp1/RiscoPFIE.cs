using System;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace ConsoleApp1
{
    class RiscoPFIE
    {
        [Test]
        public void RiscoPFInternetExplorer()
        {
            IWebDriver driver = new InternetExplorerDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            driver.Url = "https://www.4devs.com.br/gerador_de_cnpj";
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("//input[@id = 'pontuacao_nao']")).Click();
            driver.FindElement(By.XPath("//input[@id = 'bt_gerar_cnpj']")).Click();
            wait.Until(d => d.FindElement(By.XPath("//input[@class = 'margem_menor text_grande']")).Displayed);
            var cnpj1 = driver.FindElement(By.XPath("//input[@class = 'margem_menor text_grande']")).GetAttribute("value");


            driver.Navigate().GoToUrl("http://nsportal-hmlg-teste.newspace.com.br/Login.aspx");
            //driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtUsuario_text")).SendKeys("comercial-nathalia");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtSenha_text")).SendKeys("R3dbl4ckk");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_cmdEntrar")).Click();

        }
    }
}
