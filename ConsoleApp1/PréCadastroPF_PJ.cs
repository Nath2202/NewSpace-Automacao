using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace ConsoleApp1
{
    class PréCadastroPF_PJ
    {
        [Test]
        public void PreenchimentoPreCadastroPJ_PF()
        {
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions action = new Actions(driver);
            Actions action2 = new Actions(driver);
            Actions action3 = new Actions(driver);
            Actions action4 = new Actions(driver);
            
            
            driver.Url = "https://www.4devs.com.br/gerador_de_cnpj";
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("//input[@id = 'pontuacao_nao']")).Click();
            driver.FindElement(By.XPath("//input[@id = 'bt_gerar_cnpj']")).Click();
            Thread.Sleep(1000);
            wait.Until(d => d.FindElement(By.Id("texto_cnpj")).GetAttribute("value") != null);
            var cnpj1 = driver.FindElement(By.Id("texto_cnpj")).GetAttribute("value");
            //var cnpj2 = Convert.ToString(cnpj1);
            //Thread.Sleep(1000);
          
            driver.Navigate().GoToUrl("http://nsportal-hmlg-teste.newspace.com.br/Login.aspx");
            driver.Manage().Window.Maximize();

            //EFETUAR LOGIN COM USUÁRIO RESPONSÁVEL POR REALIZAR O PRÉ CADASTRO:  
            
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtUsuario_text")).SendKeys("comercial-nathalia");   
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtSenha_text")).SendKeys("R3dbl4ckk");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_cmdEntrar")).Click();
            //ESPERAR O MENU PRINCIPAL SER EXIBIDO PARA CLCIAR NO SUBITEM "EMPRESA": 
            
            wait.Until(d => d.FindElement(By.CssSelector(".rmText.rmExpandDown")).Displayed);
            action.MoveToElement(driver.FindElement(By.CssSelector(".rmText.rmExpandDown"))).Perform();
            wait.Until(d => d.FindElement(By.CssSelector(".rmItem.rmFirst.rmLast")).Displayed);
            driver.FindElement(By.CssSelector(".rmItem.rmFirst.rmLast")).Click();
            
            //AGUARDANDO O BOTÃO "NOVO" SER EXIBIDO NA TELA:  

            wait.Until(d => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_btnNovo")).Displayed);
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_btnNovo")).Click();
            //AGUARDANDO ABA "PRÉ-CADASTRO"  

            wait.Until(d => d.FindElement(By.CssSelector(".resp-tab-item.vert.resp-tab-active")).Displayed);
            //PREENCHIMENTO DOS CAMPOS DE CADASTRO (COM DADOS FIXOS):  

            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroGrupo")).SendKeys("Grupo Teste");
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroCodigoConvenio")).SendKeys("123");
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroRazaoSocial")).SendKeys("Teste Automatizado");
            
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroCNPJRazaoSocial")).SendKeys(cnpj1);
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroDataConstituicao")).SendKeys("02022002");
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroTipoRamoAtividade")).SendKeys("Cooperativas");
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroSetor")).SendKeys("Privado");
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroSegmento")).SendKeys("Corporate");
            wait.Until(d => d.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroAnalistaPJ")).GetAttribute("value") != null);
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroAnalistaPJ")).SendKeys("Risco PJ Nathalia - Ventron - nathalia.lourenco@ventron.com.br");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroFolhaPagamento_0")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroTipoFolhaPagamento_1")).Click();
            //ABA PIRÂMIDE SALARIAL:   

            driver.FindElement(By.CssSelector(".HeaderBlocoPiramideSalarial.grid-header")).Click();
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroSalMedio")).SendKeys("500000");
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroDiaPagto")).SendKeys("10");
            //ABA "REGIME DE TRABALHO"  

            driver.FindElement(By.CssSelector(".HeaderBlocoRegimeTrabalho.grid-header")).Click();
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroCLTPrivado")).SendKeys("100");
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroCLTPublic")).SendKeys("0");
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroEstabilidade")).SendKeys("0");
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroInativo")).SendKeys("0");
            //ABA "TURN OVER"  

            driver.FindElement(By.CssSelector(".HeaderBlocoTurnOver.grid-header")).Click();
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroQtdFunc")).SendKeys("100");
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroDemitidos")).SendKeys("2");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroPublicoEspecifico_1")).Click();
            //ABA "PARÂMETROS DE OPERAÇÃO PF E LIMITE OPERACIONAL"  

            driver.FindElement(By.CssSelector(".HeaderBlocoParametrosOperacaoPF.grid-header")).Click();
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroPrazoMaximo")).SendKeys("30");
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroMargem")).SendKeys("30");
            //CLICAR EM SALVAR E ENVIAR: 

            driver.FindElement(By.CssSelector(".new_button_origem.button_salvar_enviar_origem")).Click();
            wait.Until(d => d.FindElement(By.Id("confirmYes")).Displayed);
            driver.FindElement(By.Id("confirmYes")).Click();
            wait.Until(d => d.FindElement(By.Id("confirmPreencherFormulario811RespNao")).Displayed);
            driver.FindElement(By.Id("confirmPreencherFormulario811RespNao")).Click();
            
            //AGUARDAR VOLTAR PARA A TELA DE CONSULTA DE EMRPESAS: 

            wait.Until(d => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).Displayed);
            //PESQUISAR O CADASTRO PARA PREENCHIMENTO DO FORMULÁRIO COMERCIAL

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).Clear();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).SendKeys(" " + cnpj1);
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_cmdPesquisar")).Click();
            wait.Until(d => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_cmdAbrir")).Displayed);
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_cmdAbrir")).Click();
            wait.Until(d => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_btnVoltar")).Displayed);
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_btnVoltar")).Click();
            //73.435.703/0001-16
            
            //ESPERAR O MENU ANÁLISE SER EXIBIDO PARA CLCIAR NO SUBITEM "COMERCIAL" E EM SEGUIDA CLICAR NO ITEM "EM ANÁLISE"
           
            wait.Until(d => d.FindElement(By.XPath("//a[@title= 'Análise']")).Displayed);
            action2.MoveToElement(driver.FindElement(By.XPath("//a[@title= 'Análise']"))).Perform();
            wait.Until(d => d.FindElement(By.CssSelector(".rmText.rmExpandRight")).Displayed);
            action3.MoveToElement(driver.FindElement(By.CssSelector(".rmText.rmExpandRight"))).Perform();
            wait.Until(d => d.FindElement(By.XPath("//a[@title= 'Comercial - Em Análise']")).Displayed);
            action4.MoveToElement(driver.FindElement(By.XPath("//a[@title= 'Comercial - Em Análise']"))).Perform();
            driver.FindElement(By.XPath("//a[@title= 'Comercial - Em Análise']")).Click();


        }
    }
}
