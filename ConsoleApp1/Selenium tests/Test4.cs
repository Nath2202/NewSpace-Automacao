using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
namespace ConsoleApp1.Selenium_tests
{
    class Test4
    {
        [Test]
        public void TestSite()
        {

            String text = "Seu cadastro foi realizado com sucesso. Em instantes você receberá um e-mail contendo um link para a confirmação de seu e-mail, somente após a confirmação você estará recebendo nossos informativos.";
            IWebDriver testDriver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(testDriver, TimeSpan.FromSeconds(20));
            //atribui a a url para a variavel e carrega no navegador especifico
            testDriver.Url = "https://www.legisweb.com.br/newsletter/cadastrar/";
            //procura pelo elemento da box nome pelo id e insere no nome no box
            testDriver.FindElement(By.Id("nome")).SendKeys("Nathalia Lourenço");
            //procura pelo elemento da box email pelo id e insere um email na box
            testDriver.FindElement(By.Id("email")).SendKeys("nah15f.lourenco@gmail.com");
            //idem
            testDriver.FindElement(By.Id("telefone")).SendKeys("15981591971");
            //idem
            testDriver.FindElement(By.Id("estado")).SendKeys("São Paulo");

            //espera o box de cidade carregar para preencher o box cidade
            wait.Until(d => d.FindElement(By.Id("boxcarregando")).Displayed != true);
            testDriver.FindElement(By.Id("cidade")).SendKeys("Sorocaba");
            //clica no botão relacionado ao id 
            testDriver.FindElement(By.Id("acao")).Click();
           
            //verificacao para aguardar a tela de msg "sucesso" 
           wait.Until(d => d.FindElement(By.CssSelector(".row.alerta.sucesso")));
           testDriver.FindElement(By.TagName("body")).Text.Contains(text);
            //se a tea de sucesso for exibida no display ele fecha a page, senão, exibe  a msg de erro
            if (testDriver.FindElement(By.CssSelector(".row.alerta.sucesso")).Text.Contains(text))
                testDriver.Quit();
            else
                Assert.Fail("O sistema não exibiu a mensagem");
           

        }
    }
}
