using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace ConsoleApp1.Desafios_Selenium
{
    class Desafio01
    {
        [Test]
        public void Desafio1()
        {
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));
            driver.Url = "http://eliasnogueira.com/arquivos_blog/selenium/desafio/2desafio/";
            #region Preenchimento do campo NOME
            wait.Until(d => d.FindElement(By.Id("name_rg_display_section"))).Click();//espera até o campo ser clicado para liberar a ação de preenchimento
            driver.FindElement(By.Id("nome_pessoa")).Click();//clica no campo para digitação
            driver.FindElement(By.Id("nome_pessoa")).Clear();//limpa o campo para receber o novo nome
            driver.FindElement(By.Id("nome_pessoa")).SendKeys("Nathalia");//recebe o nome
            //busca no forms onde se localiza o botão
            driver.FindElement(By.CssSelector("#name_hv_editing_section > input[value = 'Salvar']")).Click();
            #endregion

            #region Preenchimento do campo EMAIL
            wait.Until(d => d.FindElement(By.Id("email_rg_display_section"))).Click();
            driver.FindElement(By.Id("email_value")).Click();
            driver.FindElement(By.Id("email_value")).Clear();
            driver.FindElement(By.Id("email_value")).SendKeys("nah.f.lourenco@hotmail.com");
            driver.FindElement(By.CssSelector("#email_hv_editing_section > input[value = 'Salvar']")).Click();
            #endregion

            #region Preenchimento do campo TELEFONE
            wait.Until(d => d.FindElement(By.Id("phone_rg_display_section"))).Click();
            driver.FindElement(By.Id("phone_value")).Click();
            driver.FindElement(By.Id("phone_value")).Clear();
            driver.FindElement(By.Id("phone_value")).SendKeys("15 981591971");
            driver.FindElement(By.CssSelector("#phone_hv_editing_section > input[value = 'Salvar']")).Click();
            #endregion

            driver.Close();
        }
    }
}