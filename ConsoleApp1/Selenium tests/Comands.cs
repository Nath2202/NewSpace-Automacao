using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace ConsoleApp1.Selenium_tests
{
    class Comands
    {
        [Test]
        public void Test()
        {
            IWebDriver d = new FirefoxDriver();

            //abrindo o google
            d.Url = "http://www.google.com";

            //pegando a url e passando para um  string
            String title = d.Title;

            //tamanho da url
            int length = d.Title.Length;

            //imprimindo o nome no console
            Console.WriteLine(title);

            //guardando page source em uma string
            String pageSourceTitle = d.PageSource;

            //fechando o navegador
            d.Quit();

           

        }
    }
}
