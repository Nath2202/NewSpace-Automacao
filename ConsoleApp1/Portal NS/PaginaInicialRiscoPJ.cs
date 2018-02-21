using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using System.Threading;


namespace ConsoleApp1.Portal_NS
{
    class PaginaInicialRiscoPJ
    {

        private static string GeraCnpj()
        {
            #region GERADOR DE CNPJ
            string result = "";
            Int64[] numero = new Int64[13];
            Random rand = new Random();
            Int64 soma1, soma2, i,j, parte1, parte2, parte3, dig1, parte5, parte6, parte7, dig2;
            j = 0;

            for (i = 1; i <= 8; i++)
            {
                numero[i] = (rand.Next()) % 9;
            }
            numero[9] = 0;
            numero[10] = 0;
            numero[11] = 0;
            numero[12] = (rand.Next()) % 9;
            //*==========================================*
            //|       Primeiro digito veridicador        |
            //*==========================================*
            soma1 = ((numero[1] * 5) +
                  (numero[2] * 4) +
                  (numero[3] * 3) +
                  (numero[4] * 2) +
                  (numero[5] * 9) +
                  (numero[6] * 8) +
                  (numero[7] * 7) +
                  (numero[8] * 6) +
                  (numero[9] * 5) +
                  (numero[10] * 4) +
                  (numero[11] * 3) +
                  (numero[12] * 2));
            parte1 = (soma1 / 11);
            parte2 = (parte1 * 11);
            parte3 = (soma1 - parte2);
            dig1 = (11 - parte3);
            if (dig1 > 9) dig1 = 0;
            //*==========================================*
            //|        Segundo digito veridicador        |
            //*==========================================*
            soma2 = ((numero[1] * 6) +
                  (numero[2] * 5) +
                  (numero[3] * 4) +
                  (numero[4] * 3) +
                  (numero[5] * 2) +
                  (numero[6] * 9) +
                  (numero[7] * 8) +
                  (numero[8] * 7) +
                  (numero[9] * 6) +
                  (numero[10] * 5) +
                  (numero[11] * 4) +
                  (numero[12] * 3) +
                  (dig1 * 2));
            parte5 = (soma2 / 11);
            parte6 = (parte5 * 11);
            parte7 = (soma2 - parte6);
            dig2 = (11 - parte7);
            if (dig2 > 9) dig2 = 0;

            for (i = 1; i <= 12; i++)
            {
                result += Convert.ToString(numero[i]);
            }

            result += dig1 + "" + dig2;
            string[] cnpjALot = new string[100];
            cnpjALot[j] = result;
            j++;

            return result;
            #endregion
        }


        public void PreCadastro(string cnpj)
        {
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
          
            #region PÁGINA INICIAL

            driver.Navigate().GoToUrl("http://nsportal-hmlg-teste.newspace.com.br/Login.aspx");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtUsuario_text")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtUsuario_text")).Clear();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtUsuario_text")).SendKeys("comercial-nathalia");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtSenha_text")).SendKeys("R3dbl4ckk");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_cmdEntrar")).Click();
            Thread.Sleep(1000);
            #endregion

            #region TELA PRÉ-CADASTRO

            Actions action = new Actions(driver);
            wait.Until(d => d.FindElement(By.CssSelector(".rmText.rmExpandDown")).Displayed);
            action.MoveToElement(driver.FindElement(By.CssSelector(".rmText.rmExpandDown"))).Perform();
            wait.Until(d => d.FindElement(By.CssSelector(".rmItem.rmFirst.rmLast")).Displayed);
            driver.FindElement(By.CssSelector(".rmItem.rmFirst.rmLast")).Click();

            #endregion

            #region NOVO CADASTRO
            //driver.FindElement(By.CssSelector("#ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).Clear();
            //driver.FindElement(By.CssSelector("#ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).SendKeys("84835811000100");
            //61958996000137
            //53153573000111
            //55946114000110
            var data = Convert.ToString(DateTime.UtcNow.Date);
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_btnNovo")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroGrupo")).SendKeys("Grupo Teste");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroCodigoConvenio")).SendKeys("123");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroRazaoSocial")).SendKeys("Teste Automatizado");
            wait.Until(d => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroCNPJRazaoSocial")).Displayed);
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroCNPJRazaoSocial")).SendKeys(cnpj);
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroDataConstituicao")).SendKeys(data);
            IWebElement element7 = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroTipoRamoAtividade"));
            SelectElement selectElement7 = new SelectElement(element7);
            selectElement7.SelectByText("Não");

            IWebElement element8 = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroSetor"));
            SelectElement selectElement8 = new SelectElement(element8);
            selectElement8.SelectByText("Privado");

            IWebElement element9 = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroSegmento"));
            SelectElement selectElement9 = new SelectElement(element9);
            selectElement9.SelectByText("Corporate");

            //wait.Until(d => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroAnalistaPJ")).GetAttribute("value")==null);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroAnalistaPJ")).SendKeys("Risco PJ Nathalia - Ventron - nathalia.lourenco@ventron.com.br");
           // SelectElement selectElement10 = new SelectElement(element10);
           // selectElement10.SelectByText("Risco PJ Nathalia - Ventron - nathalia.lourenco@ventron.com.br");

           // driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroLeiExclusiva_0")).Click();
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
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroPrazoMaximo")).SendKeys("40");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl01_ctl00_PreCadastroMargem")).SendKeys("20");

            #endregion

            #region SALVANDO O FORMULÁRIO

            driver.FindElement(By.CssSelector(".new_button_origem.button_salvar_enviar_origem")).Click();

            wait.Until(d => d.FindElement(By.Id("confirmYes")).Displayed);
            driver.FindElement(By.Id("confirmYes")).Click();

            wait.Until(d => d.FindElement(By.Id("confirmPreencherFormulario811RespNao")).Displayed);
            driver.FindElement(By.Id("confirmPreencherFormulario811RespNao")).Click();
            wait.Until(d => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).Displayed);
            Thread.Sleep(1000);
            driver.Close();

            #endregion
            
    
        }
            

            public void FormularioComercial(string cnpj)
        {
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions actionTwo = new Actions(driver);
            Actions actionThree = new Actions(driver);
            Actions actionFour = new Actions(driver);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;


            #region    ACESSANDO USUÁRIO COMERCIAL

            driver.Url = "http://nsportal-hmlg-teste.newspace.com.br/Login.aspx";
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtUsuario_text")).Clear();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtUsuario_text")).SendKeys("comercial-nathalia");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtSenha_text")).SendKeys("R3dbl4ckk");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_cmdEntrar")).Click();

            #endregion

            #region ABRINDO A ABA DE ANÁLISE DE COMERCIAL

            wait.Until(d => d.FindElement(By.XPath("//a[@title= 'Análise']")).Displayed);
            actionTwo.MoveToElement(driver.FindElement(By.XPath("//a[@title= 'Análise']"))).Perform();
            wait.Until(d => d.FindElement(By.CssSelector(".rmText.rmExpandRight")).Displayed);
            actionThree.MoveToElement(driver.FindElement(By.CssSelector(".rmText.rmExpandRight"))).Perform();
            wait.Until(d => d.FindElement(By.XPath("//a[@title= 'Comercial - Em Análise']")).Displayed);
            actionFour.MoveToElement(driver.FindElement(By.XPath("//a[@title= 'Comercial - Em Análise']"))).Perform();
            driver.FindElement(By.XPath("//a[@title= 'Comercial - Em Análise']")).Click();


            #endregion

            #region PESQUISANDO O CNPJ 

            wait.Until(d => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).Displayed);
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).Clear();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).SendKeys(" " + cnpj);
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_cmdPesquisar")).Click();
            do
            {
                driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_cmdPesquisar")).Click();
            }
            while (wait.Until(d => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_cmdAbrir")).Enabled) == false);

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_cmdAbrir")).Click();



            #endregion

            #region PREENCHENDO O FORMULÁRIO COMERCIAL/DADOS CADASTRAIS

            wait.Until(d => d.FindElement(By.XPath("//li[@tab = 'III Comercial']")).Displayed);
            driver.FindElement(By.XPath("//li[@tab = 'III Comercial']")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_TemFilialCNPJConv_0")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_CepEmpregador")).SendKeys("18078638");
            driver.FindElement(By.Id("btnPesquisarCEP")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_NumeroEnderecoEmpregador")).SendKeys("921");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_ContatoRHNome")).SendKeys("Teste");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_EmailRH")).SendKeys("teste@teste");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_TelefoneRH")).SendKeys("11111111111");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_ContatoFinanNome")).SendKeys("Teste");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_EmailFinan")).SendKeys("teste@teste");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_TelefoneFinan")).SendKeys("11111111111");

            #endregion

            #region ATENDIMENTO

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_GerenteOriginal")).SendKeys("Teste");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_AtendimentoRede")).SendKeys("Teste");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_AtendimentoRegional")).SendKeys("Teste");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_AtendimentoComConsignado")).SendKeys("Teste");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_AtendimentoComConsigEmail")).SendKeys("teste@teste");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_AtendimentoComConsigTel")).SendKeys("11111111111");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_AtendimentoRegConsig")).SendKeys("Teste");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_AtendimentoRegConsigEmail")).SendKeys("teste@teste");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_AtendimentoRegConsigTel")).SendKeys("11111111111");


            #endregion

            #region AVERBAÇÃO E TROCA DE ARQUIVO

            driver.FindElement(By.CssSelector(".HeaderBlocoAverbacaoTrocaArquivo.grid-header")).Click();

            IWebElement element = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_TipoAverbacao"));
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByText("Santander Negócios");

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_PermiteMaisUmContrato_1")).Click();

            IWebElement element2 = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_CtrlCPFMatricula"));
            SelectElement selectElement2 = new SelectElement(element2);
            selectElement2.SelectByText("CPF");

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_FreqContratosAverb")).SendKeys("Semanalmente");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_NomeAverbador1")).SendKeys("Teste");

            IWebElement element3 = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_ResponsavelAverbador1"));
            SelectElement selectElement3 = new SelectElement(element3);
            selectElement3.SelectByText("Ambos");

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_CPFAverbador1")).SendKeys("45554321852");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_EmailAverbador1")).SendKeys("teste@teste");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_FoneAverbador1")).SendKeys("15988888888");

            #endregion

            #region TURN OVER

            jse.ExecuteScript("window.scrollBy(0,600)", "");
            driver.FindElement(By.XPath("//*[@id='formCadastro']/tbody/tr[15]/td/span")).Click();   
           
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_TurnOverDetFuncFaixaSalarial1")).SendKeys("25");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_TurnOverDetDesligadoFaixaSalarial1")).SendKeys("10");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_TurnOverDetFuncFaixaSalarial2")).SendKeys("50");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_TurnOverDetDesligadoFaixaSalarial2")).SendKeys("0");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_TurnOverDetFuncFaixaSalarial3")).SendKeys("25");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_TurnOverDetDesligadoFaixaSalarial3")).SendKeys("0");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_TurnOverDetFuncFaixaSalarial4")).SendKeys("0");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_TurnOverDetDesligadoFaixaSalarial4")).SendKeys("0");

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_TurnOverDetFuncFaixaTempoCasa1")).SendKeys("25");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_TurnOverDetDesligadoFaixaTempoCasa1")).SendKeys("10");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_TurnOverDetFuncFaixaTempoCasa2")).SendKeys("25");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_TurnOverDetDesligadoFaixaTempoCasa2")).SendKeys("0");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_TurnOverDetFuncFaixaTempoCasa3")).SendKeys("50");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_TurnOverDetDesligadoFaixaTempoCasa3")).SendKeys("0");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_TurnOverDetFuncFaixaTempoCasa4")).SendKeys("0");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_TurnOverDetDesligadoFaixaTempoCasa4")).SendKeys("0");

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_TemTurnOverDetTempoCasaInfo")).SendKeys("Não");

            #endregion

            #region CONCORRÊNCIA

            driver.FindElement(By.CssSelector(".HeaderBlocoConcorrencia.grid-header")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_SantanderConvExclusivo_0")).Click();

            #endregion

            #region APROVAÇÃO DE TAXAS

            driver.FindElement(By.CssSelector(".HeaderBlocoAprovacaoTaxas.grid-header")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_PermiteContratarSeguroPrestamista_1")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_TemLimiteTaxaDecreto_1")).Click();
            #endregion

            #region RÉGUA - DIAS DO MÊS

            driver.FindElement(By.CssSelector(".HeaderBlocoReguaDiasMes.grid-header")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_EnvioRelacaoDesconto")).SendKeys("01");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_DiaRepasseValoresDesc")).SendKeys("20");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_DiaFechamentoFolhaPagto")).SendKeys("30");

            #endregion

            #region CONDIÇÕES OPERACIONAIS

            driver.FindElement(By.CssSelector(".HeaderBlocoCondicoesOperacionais.grid-header")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_EfetuaDescParcProvFerias_1")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_HaDescParcial_1")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_InforMotvoNaoDesc_1")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_InformFuncFalecidos_1")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_RhExigeDocFisico_1")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_ConvObrCreOper_1")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_ConvenioCliqueUnico_1")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_EfetuaDescVerbasRecis_1")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_HaClausulaJurMulMor_1")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_ConcClausRepactRenegCont_1")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_EnviaAtestadoObito_1")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_ConvenioTLMK_1")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_InstitutoHaConvComBanco_1")).Click();
            IWebElement element4 = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_Seguro"));
            SelectElement selectElement4 = new SelectElement(element4);
            selectElement4.SelectByText("Não permitido a venda");
            IWebElement element5 = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_FormasPagtoRepasse"));
            SelectElement selectElement5 = new SelectElement(element5);
            selectElement5.SelectByText("Boleto");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_HaDebtCustoOper_1")).Click();
            #endregion

            #region MARGEM

            driver.FindElement(By.CssSelector(".HeaderBlocoMargens.grid-header")).Click();
            wait.Until(d => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_CalculoMargem")).Displayed);
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_CalculoMargem")).SendKeys("N/A");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_RubricasVerbasFixa")).SendKeys("N/A");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_BaseMargemIntranet_1")).Click();

            #endregion

            #region DEFESA COMERCIAL

            driver.FindElement(By.CssSelector(".HeaderBlocoDefesaComercial.grid-header")).Click();
            wait.Until(d => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_ParecerComercial")).Displayed);
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_ParecerComercial")).SendKeys("Ok");
            #endregion

            #region MINUTA

            driver.FindElement(By.CssSelector(".HeaderBlocoMinuta.grid-header")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_MinutaPadrao_0")).Click();
            IWebElement element6 = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl03_ctl00_MinutaCheckPrivadoComercial"));
            SelectElement selectElement6 = new SelectElement(element6);
            selectElement6.SelectByText("Nenhuma");
            driver.FindElement(By.CssSelector(".new_button_origem.button_salvar_enviar_origem")).Click();
            wait.Until(d => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).Displayed);
            driver.Close();
            #endregion
        }


        public void AnalistaRiscoPJ(string cnpj)
        {
            IWebDriver driver = new ChromeDriver();
            Actions actionOne = new Actions(driver);
            Actions actionTwo = new Actions(driver);
            Actions actionThree = new Actions(driver);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            driver.Url = "http://nsportal-hmlg-teste.newspace.com.br/Login.aspx";
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtUsuario_text")).SendKeys("riscopj-nathalia");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtSenha_text")).SendKeys("R3dbl4ckk");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_cmdEntrar")).Click();

            #region PÁGINA DE BUSCA
            wait.Until(d => d.FindElement(By.CssSelector(".rmText.rmExpandDown")).Displayed);
            actionOne.MoveToElement(driver.FindElement(By.CssSelector(".rmText.rmExpandDown"))).Perform();
            wait.Until(d => d.FindElement(By.XPath("//a[@title= 'Riscos PJ']")).Displayed);
            actionTwo.MoveToElement(driver.FindElement(By.XPath("//a[@title= 'Riscos PJ']"))).Perform();
            wait.Until(d => d.FindElement(By.XPath("//a[@title= 'Riscos PJ - Em Aprovação']")).Displayed);
            actionThree.MoveToElement(driver.FindElement(By.XPath("//a[@title= 'Riscos PJ - Em Aprovação']"))).Perform();
            driver.FindElement(By.XPath("//a[@title= 'Riscos PJ - Em Aprovação']")).Click();

            #endregion

            #region BUSCA DO CONVÊNIO
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).Clear();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).SendKeys(" " + cnpj);
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_cmdPesquisar")).Click();
            do
            {
                driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_cmdPesquisar")).Click();
            }
            while (wait.Until(d => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_cmdAbrir")).Enabled) == false);
            
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_cmdAbrir")).Click();
            #endregion

            #region ANÁLISE RISCO PJ

            wait.Until(d => d.FindElement(By.XPath("//li[@tab= 'II Pré Análise - Riscos PJ']")).Displayed);
            driver.FindElement(By.XPath("//li[@tab= 'II Pré Análise - Riscos PJ']")).Click();
            wait.Until(d => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl02_ctl00_RiscoAcaoPJ_0")).Displayed);
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl02_ctl00_RiscoAcaoPJ_0")).Click();
            driver.FindElement(By.CssSelector(".new_button_origem.button_salvar_enviar_origem")).Click();
            wait.Until(d => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).Displayed);
            driver.Close();

            #endregion
        }

        public void AnalisePrecos(string cnpj)
        {
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            Actions actions = new Actions(driver);
            Actions actionsTwo = new Actions(driver);
            Actions actionsThree = new Actions(driver);



            driver.Url = "http://nsportal-hmlg-teste.newspace.com.br/Login.aspx";
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtUsuario_text")).SendKeys("precos-nathalia");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtSenha_text")).SendKeys("R3dbl4ckk");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_cmdEntrar")).Click();

            #region ABRINDO TELA DE PESQUISA
            wait.Until(d => d.FindElement(By.CssSelector(".rmText.rmExpandDown")).Displayed);
            actions.MoveToElement(driver.FindElement(By.CssSelector(".rmText.rmExpandDown"))).Perform();
            wait.Until(d => d.FindElement(By.CssSelector(".rmText.rmExpandRight")).Displayed);
            actionsTwo.MoveToElement(driver.FindElement(By.CssSelector(".rmText.rmExpandRight"))).Perform();
            wait.Until(d => d.FindElement(By.XPath("//a[@title= 'Preços - Em Aprovação']")).Displayed);
            actionsThree.MoveToElement(driver.FindElement(By.XPath("//a[@title= 'Preços - Em Aprovação']"))).Perform();
            driver.FindElement(By.XPath("//a[@title= 'Preços - Em Aprovação']")).Click();
            #endregion

            #region PESQUISANDO O CONVÊNIO
            wait.Until(d => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).Displayed);
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).Clear();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).SendKeys(" " + cnpj);
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_cmdPesquisar")).Click();
            wait.Until(d => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_cmdAbrir")).Enabled);
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_cmdAbrir")).Click();

            #endregion

            #region ANÁLISE DE PREÇOS

            wait.Until(d => d.FindElement(By.XPath("//li[@tab= 'IV Dados Preço']")).Displayed);
            driver.FindElement(By.XPath("//li[@tab= 'IV Dados Preço']")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl04_ctl00_pendenciaPreco_0")).Click();
            driver.FindElement(By.XPath("//button[@action= 'preco-enviar']")).Click();
            wait.Until(d => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).Displayed);
            driver.Close();
            #endregion

        }

        public void AnaliseProduto(string cnpj)
        {
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            Actions actions = new Actions(driver);
            Actions actionsTwo = new Actions(driver);
            Actions actionsThree = new Actions(driver);

            driver.Url = "http://nsportal-hmlg-teste.newspace.com.br/Login.aspx";
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtUsuario_text")).SendKeys("produto-nathalia");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtSenha_text")).SendKeys("R3dbl4ckk");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_cmdEntrar")).Click();

            #region ABRINDO A TELA DE PESQUISA
            wait.Until(d => d.FindElement(By.CssSelector(".rmText.rmExpandDown")).Displayed);
            actions.MoveToElement(driver.FindElement(By.CssSelector(".rmText.rmExpandDown"))).Perform();
            wait.Until(d => d.FindElement(By.CssSelector(".rmText.rmExpandRight")).Displayed);
            actionsTwo.MoveToElement(driver.FindElement(By.CssSelector(".rmText.rmExpandRight"))).Perform();
            wait.Until(d => d.FindElement(By.XPath("//a[@title= 'Produtos - Em Aprovação']")).Displayed);
            actionsThree.MoveToElement(driver.FindElement(By.XPath("//a[@title= 'Produtos - Em Aprovação']"))).Perform();
            driver.FindElement(By.XPath("//a[@title= 'Produtos - Em Aprovação']")).Click();
            #endregion

            #region PESQUISANDO O CONVÊNIO
            wait.Until(d => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).Displayed);
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).Clear();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).SendKeys(" " + cnpj);
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_cmdPesquisar")).Click();
            wait.Until(d => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_cmdAbrir")).Enabled);
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_cmdAbrir")).Click();
            #endregion

            #region ANÁLISE DE PRODUTO
            wait.Until(d => d.FindElement(By.XPath("//li[@tab= 'V Dados Produto']")).Displayed);
            driver.FindElement(By.XPath("//li[@tab= 'V Dados Produto']")).Click();
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollBy(0,700)", "");
            driver.FindElement(By.CssSelector(".new_button_origem.button_salvar_enviar_origem")).Click();
            wait.Until(d => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).Displayed);
            driver.Close();

            #endregion
        }

        public void AnaliseCadastro(string cnpj)
        {

            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            Actions actions = new Actions(driver);
            Actions actionsTwo = new Actions(driver);
            Actions actionsThree = new Actions(driver);

            driver.Url = "http://nsportal-hmlg-teste.newspace.com.br/Login.aspx";
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtUsuario_text")).SendKeys("cadastro-nathalia");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtSenha_text")).SendKeys("R3dbl4ckk");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_cmdEntrar")).Click();

            #region ABRINDO A TELA DE PESQUISA
            wait.Until(d => d.FindElement(By.CssSelector(".rmText.rmExpandDown")).Displayed);
            actions.MoveToElement(driver.FindElement(By.CssSelector(".rmText.rmExpandDown"))).Perform();
            wait.Until(d => d.FindElement(By.CssSelector(".rmText.rmExpandRight")).Displayed);
            actionsTwo.MoveToElement(driver.FindElement(By.CssSelector(".rmText.rmExpandRight"))).Perform();
            wait.Until(d => d.FindElement(By.XPath("//a[@title= 'Cadastro - Em Aprovação']")).Displayed);
            actionsThree.MoveToElement(driver.FindElement(By.XPath("//a[@title= 'Cadastro - Em Aprovação']"))).Perform();
            driver.FindElement(By.XPath("//a[@title= 'Cadastro - Em Aprovação']")).Click();
            #endregion

            #region PESQUISANDO O CONVÊNIO
            wait.Until(d => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).Displayed);
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).Clear();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).SendKeys(" " + cnpj);
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_cmdPesquisar")).Click();
            wait.Until(d => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_cmdAbrir")).Enabled);
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_cmdAbrir")).Click();
            #endregion

            #region ANÁLISE DE CADASTRO
            wait.Until(d => d.FindElement(By.XPath("//li[@tab= 'VI Cadastro']")).Displayed);
            driver.FindElement(By.XPath("//li[@tab= 'VI Cadastro']")).Click();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl06_ctl00_CodigoConvenio")).SendKeys("123");
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollBy(0,550)", "");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rptContainer_ctl06_ctl00_pendenciaCadastro_0")).Click();
            driver.FindElement(By.CssSelector(".new_button_origem.button_salvar_enviar_origem")).Click();
            wait.Until(d => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_ucPesquisa_txtCNPJ_text")).Displayed);
            driver.Close();

            #endregion

        }

        [Test]
        public void FluxoOriginacao()
        {

            var cnpjValue = GeraCnpj();
            PreCadastro(cnpjValue);
            AnalistaRiscoPJ(cnpjValue);
            FormularioComercial(cnpjValue);
            AnalisePrecos(cnpjValue); 
            AnaliseProduto(cnpjValue);
            AnaliseCadastro(cnpjValue);
        }
      

    }//class


    }//namespace

