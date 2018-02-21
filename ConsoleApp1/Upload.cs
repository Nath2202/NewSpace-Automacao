using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using AutoItX3Lib;
using System.Threading;
using System.Collections;
using OpenQA.Selenium.PhantomJS;

namespace ConsoleApp1
{
    class Upload
    {
        [Test]
        public void UploadImage()
        {
            IWebDriver driver = new ChromeDriver();
            IWebDriver data = new PhantomJSDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            

            driver.Url = "https://www.carteiradoestudante.com.br/";
            //Thread.Sleep(1000);
            driver.FindElement(By.XPath("//a[@href= 'https://www.carteiradoestudante.com.br/carteiras']")).Click();
            Thread.Sleep(1000);
            jse.ExecuteScript("window.scrollBy(0,250)", "");
            driver.FindElement(By.CssSelector(".btn.btn-black.btn-block")).Click();
            Thread.Sleep(1000);
            jse.ExecuteScript("window.scrollBy(0,250)", "");
            driver.FindElement(By.Id("Content_txtNome")).SendKeys("Leonardo Campestrini");
            driver.FindElement(By.Id("Content_txtRg")).SendKeys("553432370");
            driver.FindElement(By.Id("Content_txtCpf")).SendKeys("44585609806");
            driver.FindElement(By.Id("Content_dpdSexo")).SendKeys("Masculino");
            driver.FindElement(By.Id("Content_txtData")).Clear();
            driver.FindElement(By.Id("Content_txtData")).SendKeys("27021998");
            driver.FindElement(By.Id("Content_txtCelular")).SendKeys("15981591971");
            driver.FindElement(By.Id("Content_txtEmail")).SendKeys("leo.camph2202@hotmail.com");
            IWebElement element3 = driver.FindElement(By.Id("Content_dpdEscolaridade"));
            SelectElement selectElement3 = new SelectElement(element3);
            selectElement3.SelectByText("Ensino Superior");
            //driver.FindElement(By.Id("Content_dpdEscolaridade")).SendKeys("Ensino Superior");
            driver.FindElement(By.Id("Content_txtInstituicao")).SendKeys("Faculdade de Engenharia de Sorocaba");
            driver.FindElement(By.Id("Content_txtNomeCurso")).SendKeys("Engenharia Mecatrõnica");
            driver.FindElement(By.Id("Content_txtTurno")).SendKeys("Noturno");
            driver.FindElement(By.Id("Content_txtSerie")).SendKeys("3º ano");
            driver.FindElement(By.Id("Content_txtMatricula")).SendKeys("160922");
            driver.FindElement(By.Id("Content_chkRegulamento")).Click();
            driver.FindElement(By.Id("Content_lkbAvancar")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Content_rptFormaEnvio_lblFormaEnvio_2")).Click();
            jse.ExecuteScript("window.scrollBy(0,250)", "");
            IWebElement element =   driver.FindElement(By.Id("Content_ddlEstado"));
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByText("São Paulo");
            Thread.Sleep(1000);
            IWebElement element2 = driver.FindElement(By.Id("Content_ddlCidade"));
            SelectElement selectElement2 = new SelectElement(element2);
            //wait.Until(d => d.FindElement(By.Id("Content_ddlCidade")).Displayed);
            selectElement2.SelectByText("Sorocaba");
            //wait.Until(d => d.FindElement(By.l))
            driver.FindElement(By.Id("Content_rptLojas_rbtListaLoja_0")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Content_lkbAvancar")).Click();
            Thread.Sleep(1000);

            jse.ExecuteScript("window.scrollBy(0,750)", "");
            IWebElement file = driver.FindElement(By.Id("Content_spanUploadFoto"));
            file.SendKeys("C:\\Users\\nlourenco\\Desktop\\.png");
            ((PhantomJSDriver)driver).ExecutePhantomJS("var page = this; page.uploadFile('input[type=file]', '/path/to/file');");
            //driver.FindElement(By.Id("terms")).Click();

        }
    }
}
