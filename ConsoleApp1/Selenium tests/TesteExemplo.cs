using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;


namespace Learning
{
    public class UnitTest1
    {
        public IWebElement findByXpath(IWebDriver driver, string path)
        {
            return (driver.FindElement(By.XPath(path)));
        }
        public IWebElement findById(IWebDriver driver, string id)
        {
            return (driver.FindElement(By.Id(id)));
        }
        public IWebElement findByName(IWebDriver driver, string name)
        {
            return (driver.FindElement(By.Name(name)));
        }
        public IWebElement findByCssSelector(IWebDriver driver, string cssselector)
        {
            return (driver.FindElement(By.CssSelector(cssselector)));
        }
        public IWebElement findByClassName(IWebDriver driver, string classname)
        {
            return (driver.FindElement(By.ClassName(classname)));
        }


        [Test]
        public void Lesson1()
        {
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            for (int i = 0; i >= 10; i++)
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://www.4devs.com.br/gerador_de_pessoas");

                wait.Until(d => d.FindElement(By.Id("pontuacao_nao")).Displayed);
                driver.FindElement(By.Id("pontuacao_nao")).Click();
                driver.FindElement(By.Id("bt_gerar_pessoa")).Click();

                wait.Until(d => d.FindElement(By.Id("area_resposta")).Displayed);


                System.Threading.Thread.Sleep(2000);
                var nome = driver.FindElement(By.Id("nome")).GetAttribute("value");
                var data = "15/12/2017";
                var nacionalidade = "brasileiro";
                var dataNasc = driver.FindElement(By.Id("data_nasc")).GetAttribute("value");
                var estadoCivil = "solteiro";
                var rg = driver.FindElement(By.Id("rg")).GetAttribute("value");
                var rgem1 = "ssp-sp1";
                var rua = driver.FindElement(By.Id("endereco")).GetAttribute("value");
                var num = driver.FindElement(By.Id("numero")).GetAttribute("value");
                var bairro = driver.FindElement(By.Id("bairro")).GetAttribute("value");
                var cidade = driver.FindElement(By.Id("cidade")).GetAttribute("value");
                var estado = driver.FindElement(By.Id("estado")).GetAttribute("value");
                var cep = driver.FindElement(By.Id("cep")).GetAttribute("value");


                driver.Navigate().GoToUrl("https://www.4devs.com.br/gerador_de_pis_pasep");
                wait.Until(d => d.FindElement(By.Id("bt_gerar")).Displayed);
                driver.FindElement(By.Id("pontuacao_nao")).Click();
                driver.FindElement(By.Id("bt_gerar")).Click();

                System.Threading.Thread.Sleep(2000);
                wait.Until(d => d.FindElement(By.Id("texto_pis")).Displayed);
                var inss = driver.FindElement(By.Id("texto_pis")).GetAttribute("value");


                driver.Navigate().GoToUrl("http://www.previdencia.gov.br/forms/formularios/form022.html");

                wait.Until(d => d.FindElement(By.XPath("//*[@id='formularios-previdencia']/table[4]/tbody/tr/td[1]/input")).Displayed);
                findByXpath(driver, "//*[@id='formularios-previdencia']/table[4]/tbody/tr/td[1]/input").Click();
                findByXpath(driver, "//*[@id='formularios-previdencia']/table[4]/tbody/tr/td[1]/input").SendKeys(nome);
                findByXpath(driver, "//*[@id='formularios-previdencia']/table[4]/tbody/tr/td[2]/input").SendKeys(inss);
                findByXpath(driver, "//*[@id='formularios-previdencia']/table[4]/tbody/tr/td[3]/input").SendKeys(data);
                findByXpath(driver, "//*[@id='formularios-previdencia']/table[5]/tbody/tr/td[1]/input").SendKeys(nacionalidade);
                findByXpath(driver, "//*[@id='formularios-previdencia']/table[5]/tbody/tr/td[2]/input").SendKeys(dataNasc);
                findByXpath(driver, "//*[@id='formularios-previdencia']/table[5]/tbody/tr/td[3]/input").SendKeys(estadoCivil);
                findByXpath(driver, "//*[@id='formularios-previdencia']/table[6]/tbody/tr/td[1]/input").SendKeys(rg);
                findByXpath(driver, "//*[@id='formularios-previdencia']/table[6]/tbody/tr/td[2]/input").SendKeys(rgem1);
                findByXpath(driver, "//*[@id='formularios-previdencia']/table[7]/tbody/tr/td[1]/input").SendKeys(rua);
                findByXpath(driver, "//*[@id='formularios-previdencia']/table[7]/tbody/tr/td[2]/input").SendKeys(num);
                findByXpath(driver, "//*[@id='formularios-previdencia']/table[8]/tbody/tr/td[2]/input").SendKeys(bairro);
                findByXpath(driver, "//*[@id='formularios-previdencia']/table[9]/tbody/tr/td[1]/input").SendKeys(cidade);
                findByXpath(driver, "//*[@id='formularios-previdencia']/table[9]/tbody/tr/td[2]/input").SendKeys(estado);
                findByXpath(driver, "//*[@id='formularios-previdencia']/table[9]/tbody/tr/td[3]/input").SendKeys(cep);

                findByXpath(driver, "//*[@id='formularios-previdencia']/table[11]/tbody/tr/td/textarea").SendKeys("Teste automatizado, treinando selenium");
                driver.Close();
            }

        }
        [Test]
        public void connectExcel()
        {

        }
    }
}
