using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;


namespace ConsoleApp1.Selenium_tests
{
    class Desafio2
    {
        [Test]
        public void Desafio()
        {
          
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://faleconosco.grupopaodeacucar.com.br/pdalojas/home/faleconosco";
            //preencher o campo CPF
            driver.FindElement(By.Id("CPF")).SendKeys("45554321852");
            //preencher o campo nome
            driver.FindElement(By.Id("Name")).SendKeys("Nathalia");
            //preencher o campo sobrenome
            driver.FindElement(By.Id("LastName")).SendKeys("Lourenço");
            //preencher o campo ddd
            driver.FindElement(By.Id("Telephone_DDD")).SendKeys("15");
            //preencher o campo telefone
            driver.FindElement(By.Id("Telephone_Phone")).SendKeys("32264178");
            //preencher o campo email
            driver.FindElement(By.Id("Email")).SendKeys("nah.f.lourenco@hotmail.com");

            //escolhendo a categoria da mensagem
            driver.FindElement(By.Id("Category")).SendKeys("Elogio");

            //escolhendo a loja 
            driver.FindElement(By.Id("Store")).SendKeys("SUPERMERCADO");

            //escolhendo o estado
            driver.FindElement(By.Id("State")).SendKeys("SP");

            //escolhendo a cidade
            driver.FindElement(By.Id("City")).SendKeys("Sorocaba");

            //escolhendo a loja
            driver.FindElement(By.Id("UnidadeLoja")).SendKeys("0014 - SOROCABA ALTO B VIST");

            //clicando no botão de enviar
            driver.FindElement(By.Name("Submit")).Click();

            driver.Quit();

           
        }
    }
}
