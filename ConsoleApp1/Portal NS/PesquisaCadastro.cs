using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;



namespace ConsoleApp1.Portal_NS
{
    class PesquisaCadastro
    {
       // String cnpj = " 61958996000137";
        [Test]

        public void Pesquisa()
        {
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Actions action1 = new Actions(driver);
            ConsoleApp1.Portal_NS.PaginaInicialRiscoPJ exemplo = new ConsoleApp1.Portal_NS.PaginaInicialRiscoPJ();
            //var ex = " " + exemplo.CNPJ();


            driver.Url = "http://nsportal-hmlg-teste.newspace.com.br/Login.aspx";
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtUsuario_text")).SendKeys("comercial-nathalia");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtSenha_text")).SendKeys("R3dbl4ckk");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_cmdEntrar")).Click();

            wait.Until(d => d.FindElement(By.CssSelector(".rmText.rmExpandDown")).Displayed);
            action1.MoveToElement(driver.FindElement(By.CssSelector(".rmText.rmExpandDown"))).Perform();
            wait.Until(d => d.FindElement(By.CssSelector(".rmItem.rmFirst.rmLast")).Displayed);
            driver.FindElement(By.CssSelector(".rmItem.rmFirst.rmLast")).Click();



            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).Clear();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).SendKeys("");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_cmdPesquisar")).Click();

            wait.Until(d => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_cmdAbrir")).Displayed);
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_cmdAbrir")).Click();

            
             wait.Until(d => d.FindElement(By.XPath("//li[@tab = 'II Pré Análise - Riscos PJ']")).Displayed);
             driver.FindElement(By.XPath("//li[@tab = 'II Pré Análise - Riscos PJ']")).Click();
             
           
        }
      
    }

}
