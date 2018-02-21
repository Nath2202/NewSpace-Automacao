using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace ConsoleApp1.Portal_NS
{
    class PaginaInicialRiscoPF
    {
      

        [Test]

        public void RiscoPF()
        {
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(2000);

            #region PRÉ-CADASTRO

            driver.Url = "https://www.4devs.com.br/gerador_de_cnpj";
            driver.FindElement(By.XPath("//input[@id = 'pontuacao_nao']")).Click();
            driver.FindElement(By.XPath("//input[@id = 'bt_gerar_cnpj']")).Click();
            wait.Until(d => d.FindElement(By.XPath("//input[@class = 'margem_menor text_grande']")).GetAttribute("value")!= null);
            var cnpj = driver.FindElement(By.XPath("//input[@class = 'margem_menor text_grande']")).GetAttribute("value");

            #endregion

            Thread.Sleep(2000);
            driver.Url = "http://nsportal-hmlg-teste.newspace.com.br/Login.aspx";
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtUsuario_text")).SendKeys("comercial-nathalia");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtSenha_text")).SendKeys("R3dbl4ckk");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_cmdEntrar")).Click();
            //dado1.Close();


            #region TELA PRÉ-CADASTRO
          
            Actions action = new Actions(driver);
            wait.Until(d => d.FindElement(By.CssSelector(".rmText.rmExpandDown")).Displayed);
            action.MoveToElement(driver.FindElement(By.CssSelector(".rmText.rmExpandDown"))).Perform();
            wait.Until(d => d.FindElement(By.CssSelector(".rmItem.rmFirst.rmLast")).Displayed);
            driver.FindElement(By.CssSelector(".rmItem.rmFirst.rmLast")).Click();

            #endregion


            #region NOVO CADASTRO
         
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_btnNovo")).Click();
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroGrupo")).SendKeys("Grupo Teste");
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroCodigoConvenio")).SendKeys("123");
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroRazaoSocial")).SendKeys("Teste Automatizado");
            wait.Until(d => d.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroCNPJRazaoSocial")).Displayed);
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroCNPJRazaoSocial")).SendKeys(cnpj);
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroDataConstituicao")).SendKeys("02022002");
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroTipoRamoAtividade")).SendKeys("Não");
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroSetor")).SendKeys("Público");
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroSegmento")).SendKeys("Corporate");
            wait.Until(d => d.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroAnalistaPJ")).GetAttribute("value") != null);
            driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$rptContainer$ctl01$ctl00$PreCadastroAnalistaPJ")).SendKeys("Risco PJ Nathalia - Ventron - nathalia.lourenco@ventron.com.br");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroLeiExclusiva_1")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroFolhaPagamento_0")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroTipoFolhaPagamento_1")).Click();

            #endregion


            #region PIRÂMIDE SALARIAL

            driver.FindElement(By.CssSelector(".HeaderBlocoPiramideSalarial.grid-header")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroSalMedio")).SendKeys("500000");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroDiaPagto")).SendKeys("10");

            #endregion


            #region REGIME DE TRABALHO
            driver.FindElement(By.CssSelector(".HeaderBlocoRegimeTrabalho.grid-header")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroCLTPrivado")).SendKeys("100");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroCLTPublic")).SendKeys("0");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroEstabilidade")).SendKeys("0");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroInativo")).SendKeys("0");


            #endregion


            #region TURN OVER

            driver.FindElement(By.CssSelector(".HeaderBlocoTurnOver.grid-header")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroQtdFunc")).SendKeys("100");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroDemitidos")).SendKeys("10");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroPublicoEspecifico_1")).Click();



            #endregion


            #region PARÂMETROS DE OPERAÇÃO PF E LIMITE OPERACIONAL

            driver.FindElement(By.CssSelector(".HeaderBlocoParametrosOperacaoPF.grid-header")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroPrazoMaximo")).SendKeys("80");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroMargem")).SendKeys("20");

            #endregion


            #region SALVANDO O FORMULÁRIO

            driver.FindElement(By.CssSelector(".new_button_origem.button_salvar_enviar_origem")).Click();

            wait.Until(d => d.FindElement(By.Id("confirmYes")).Displayed);
            driver.FindElement(By.Id("confirmYes")).Click();

            wait.Until(d => d.FindElement(By.Id("confirmPreencherFormulario811RespNao")).Displayed);
            driver.FindElement(By.Id("confirmPreencherFormulario811RespNao")).Click();

            #endregion


        }

    }
 }
