using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Threading;
using AutoItX3Lib;


namespace ConsoleApp1.Fluxo_RH_Portal_NS
{
  
    class FluxoRH
    {

        #region ARRAY DE ETIQUETAS
  
        string[] matricula = {        
"99984453720579",
"99984453720595",
"99984453720617",
"99984453720633",
"99984453720676",
"99984453720692",
"99984453720714",
"99984453720730",
"99984453720773",
"99984453720790",
"99984453720811",
"99984453720838",
"99984453720854",
"99984453720870",
"99984453720897",
"99984453720935",
"99984453720951",
"99984453720978",
"99984453721010",
"99984453721036",
"99984453721079",
"99984453721095",
"99984453721117",
"99984453721133",
"99984453721150",
"99984453721176",
"99984453721192",
"99984453721214",
"99984453721230",
"99984453721257",
"99984453721273",
"99984453721290",
"99984453721311",
"99984453721338",
"99984453721354",
"99984453721370",
"99984453721397",
"99984453721419",
"99984453721451",
"99984453721478",
"99984453721516",
"99984453721559",
"99984453721575",
"99984453721613",
"99984453721672",
"99984453721699",
"99984453721710",
"99984453721753",
"99984453721770",
"99984453721796",
"99984453721818",
"99984453721834",
"99984453721850",
"99984453721877",
"99984453721893",
"99984453721915",
"99984453721931",
"99984453721958",
"99984453721974",
"99984453721990",
"99984453722016",
"99984453722032",
"99984453722059",
"99984453722075",
"99984453722091",
"99984453722113",
"99984453722130",
"99984453722156",
"99984453722172",
"99984453722199",
"99984453722210",
"99984453722237",
"99984453722253",
"99984453722296",
"99984453722318",
"99984453722350",
"99984453722377",
"99984453722393",
"99984453722415",
"99984453722431",
"99984453722458",
"99984453722474",
"99984453722512",
"99984453722539",
"99984453722555",
"99984453722571",
"99984453722598",
"99984453722610",
"99984453722636",
"99984453722652",
"99984453722679",
"99984453722695",
"99984453722733",
"99984453722750",
"99984453722776",
"99984453722792",
"99984453722814",
"99984453722830",
"99984453722857",
"99984453722873",
"99984453722890",
"99984453722911",
"99984453722938",
"99984453722970",
"99984453722997",
"99984453723012",
"99984453723039",
"99984453723055",
"99984453723071",
"99984453723098",
"99984453723110",
"99984453723136",
"99984453723152",
"99984453723179",
"99984453723195",
"99984453723217",
"99984453723233",
"99984453723250",
"99984453723276",
"99984453723292",
"99984453723314",
"99984453723330",
"99984453723357",
"99984453723373",
"99984453723390",
"99984453723411",
"99984453723438",
"99984453723454",
"99984453723470",
"99984453723497",
"99984453723519",
"99984453723535",
"99984453723551",
"99984453723578",
"99984453723594",
"99984453723616",
"99984453723632",
"99984453723659",
"99984453723675",
"99984453723691",
"99984453723713",
"99984453723730",
"99984453723756",
"99984453723772",
"99984453723799",
"99984453723810",
"99984453723837",
"99984453723853",
"99984453723870",
"99984453723896",
"99984453723918",
"99984453723934",
"99984453723950",
"99984453723977",
"99984453723993",
"99984453724019",
"99984453724035",
"99984453724051",
"99984453724078",
"99984453724094",
"99984453724116",
"99984453724132",
"99984453724159",
"99984453724175",
"99984453724191",
"99984453724213",
"99984453724230",
"99984453724256",
"99984453724272",
"99984453724299",
"99984453724310",
"99984453724337",
"99984453724353",
"99984453724370",
"99984453724396",
"99984453724418",
"99984453724434",
"99984453724450",
"99984453724477",
"99984453724493",
"99984453724515",
"99984453724531",
"99984453724558",
"99984453724574",
"99984453724590",
"99984453724612",
"99984453724639",
"99984453724655",
"99984453724671",
"99984453724698",
"99984453724710",
"99984453724736",
"99984453724752",
"99984453724779",
"99984453724795",
"99984453724817",
"99984453724833",
"99984453724850",
"99984453724876",
"99984453724892",
"99984453724914",
"99984453724930",
"99984453724957",
"99984453724973",
"99984453724990",
"99984453725015",
"99984453725058",
"99984453725074",
"99984453725090",
"99984453725112",
"99984453725139",
"99984453725155",
"99984453725171",
"99984453725198",
"99984453725210",
"99984453725236",
"99984453725252",
"99984453725279",
"99984453725295",
"99984453725317",
"99984453725333",
"99984453725350",
"99984453725376",
"99984453725392",
"99984453725430",
"99984453725457",
"99984453725473",
"99984453725490",
"99984453725511",
"99984453725538",
"99984453725554",
"99984453725570",
"99984453725597",
"99984453725619",
"99984453725635",
"99984453725651",
"99984453725678",
"99984453725694",
"99984453725716",
"99984453725732",
"99984453725759",


};
        #endregion

        string numProtocolo;


        #region MÉTODOS DE ENVIO DE IMAGENS

        public void UploadCPF(IWebElement element)
        {
            AutoItX3 auto = new AutoItX3();
            element.Click();
            Thread.Sleep(1000);
            auto.WinActivate("Escolher arquivo a carregar");
            auto.Send(@"  C:\Users\nlourenco\Pictures\Fluxo RH\CPF.jpg");
            Thread.Sleep(1000);
            auto.Send("{ENTER}");
        }

        public void UploadRG(IWebElement element)
        {
            AutoItX3 autoTwo = new AutoItX3();
            element.Click();
            autoTwo.WinActivate("Escolher arquivo a carregar");
            autoTwo.Send(@"  C:\Users\nlourenco\Pictures\Fluxo RH\RG.jpg");
            Thread.Sleep(1000);
            autoTwo.Send("{ENTER}");
        }

        public void UploadTitulo(IWebElement element)
        {
            AutoItX3 autoThree = new AutoItX3();
            element.Click();
            Thread.Sleep(1000);
            autoThree.WinActivate("Escolher arquivo a carregar");
            autoThree.Send(@"  C:\Users\nlourenco\Pictures\Fluxo RH\Titulo de Eleitor.jpg");
            Thread.Sleep(1000);
            autoThree.Send("{ENTER}");
        }
        #endregion

        public void FluxoNSRH(string matricula)
        {
            /*Variavel de inicialização de opções do Internet Explorer*/
            InternetExplorerOptions options = new InternetExplorerOptions();

            /*permite que o driver do navegador ignore modais de diálogo que estão habilitadas, 
             porém não estão visíveis ao usuário*/
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            DesiredCapabilities ieCapabilities = options.ToCapabilities() as DesiredCapabilities;
            ieCapabilities.SetCapability("Ignore", InternetExplorerUnexpectedAlertBehavior.Ignore);

            /*Driver do navegador: é a base de qualquer teste automatizado.
             Ele é responsável por acessar URL´s, acessar elementos de tela e alterar o tamanho da página, por exemplo*/
            IWebDriver driver = new InternetExplorerDriver(options);

            /* Variável do tipo WebDriverWait: utilizada quando é preciso aguardar algum elemento em tela 
             estar visível ou habilitado para executar uma ação. Ela irá esperar até o tempo definido. */
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            /* Variável do tipo IJavaScriptExecutor: utilizada para acessar elementos de tela que
             utilizam de mecanismos do JavaScript*/
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;


            #region LOGIN
            driver.Url = "https://nsrh-teste.newspace.com.br/ "; 
            
            /*Maximizando a janela*/
            driver.Manage().Window.Maximize();

            /*Driver acessando um elemento textbox e enviando um dado */
            driver.FindElement(By.Id("MainContent_txtUsuario")).SendKeys("desenv");
            driver.FindElement(By.Id("MainContent_txtSenha")).SendKeys("123");
            wait.Until(d => d.FindElement(By.CssSelector(".btn.btn-default.btnLoginEntrar")).Enabled);
            driver.FindElement(By.CssSelector(".btn.btn-default.btnLoginEntrar")).Click();
            #endregion

            #region APLICAÇÃO
            /*Exemplo de uma espera explícita: aguardando o elemento estar visível para executar
              a próxima linha de comando*/
            wait.Until(d => d.FindElement(By.Id("MainContent_ddlCliente")).Displayed);

            /* Variável do tipo IWebElement: armazena elementos de tela.
             Seu uso mais comum é em situações em que temos uma combo box de dados, mas apenas um dado é relevante, como mostra as próximas linhas*/
            IWebElement element = driver.FindElement(By.Id("MainContent_ddlCliente"));

            /*Variável do tipo SelectElement: utiliza a variável do tipo IWebElement como referência para selecionar um dado específico da combo box */
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByText("Grupo Brasanitas");

            /*Espera implícita Thread: esse comando força o sistema a parar por um tempo determinado (milisegundos).
              Seu uso não é muito recomendado, mas há exceções.
              Ex.: quando não quer esperar um determinado elemento estar visível na tela*/
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(".btn.btn-default.btnLoginEntrar")).Click();
            #endregion

            #region UPLOAD
            wait.Until(d => d.FindElement(By.XPath("//a[text()='Upload']")).Displayed);
            driver.FindElement(By.XPath("//a[text()='Upload']")).Click();
            wait.Until(d => d.FindElement(By.XPath("//a[text()='Documento']")).Displayed);
            driver.FindElement(By.XPath("//a[text()='Documento']")).Click();
            #endregion

            #region PESQUISA UPLOAD

            driver.FindElement(By.Id("MainContent_ucPesquisaComum_txtEtiqueta")).SendKeys(matricula);
            driver.FindElement(By.Id("btnPesquisar")).Click();
            wait.Until(d => d.FindElement(By.Id("btnUpload")).Displayed);
            //jse.ExecuteScript("window.scrollBy(0,250)", "");
            driver.FindElement(By.Id("btnUpload")).Click();
            #endregion

            #region UPLOAD DE IMAGEM
            wait.Until(d => d.FindElement(By.XPath("//*[@id='ctl00_MainContent_ucArquivos_btnSelecionar']")).Displayed);
            IWebElement file = driver.FindElement(By.XPath("//*[@id='ctl00_MainContent_ucArquivos_btnSelecionar']"));
            UploadCPF(file);
            Thread.Sleep(1000);
            UploadRG(file);
            Thread.Sleep(1000);
            //UploadRG(file);
            //Thread.Sleep(1000);
            driver.FindElement(By.Id("ctl00_MainContent_ucArquivos_btnUpload")).Click();

            wait.Until(d => d.FindElement(By.Id("ctl00_MainContent_ucArquivos_btnFinalizar")).Enabled);
            driver.FindElement(By.Id("ctl00_MainContent_ucArquivos_btnFinalizar")).Click();
            #endregion

            #region TIPIFICAÇÃO
            wait.Until(d => d.FindElement(By.XPath("//a[text()='Análise']")).Displayed);
            driver.FindElement(By.XPath("//a[text()='Análise']")).Click();
            wait.Until(d => d.FindElement(By.XPath("//a[text()='Tipificação']")).Displayed);
            driver.FindElement(By.XPath("//a[text()='Tipificação']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("txtFiltro")).SendKeys("CPF");
            jse.ExecuteScript("window.scrollBy(0,250)", "");
            driver.FindElement(By.XPath("//button[text()='Salvar']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("txtFiltro")).SendKeys("RG");
            jse.ExecuteScript("window.scrollBy(0,250)", "");
            driver.FindElement(By.XPath("//button[text()='Salvar']")).Click();
            wait.Until(d => d.FindElement(By.CssSelector(".btn.btn-default.btnModalCancelar")).Displayed);
            driver.FindElement(By.CssSelector(".btn.btn-default.btnModalCancelar")).Click();
            #endregion

            #region FORMALIZAÇÃO
            driver.FindElement(By.XPath("//a[text()='Análise']")).Click();
            wait.Until(d => d.FindElement(By.XPath("//a[text()='Formalização']")).Displayed);
            driver.FindElement(By.XPath("//a[text()='Formalização']")).Click();
            wait.Until(d => d.FindElement(By.Id("MainContent_ucPesquisaComum_txtEtiqueta")).Displayed);
            driver.FindElement(By.Id("MainContent_ucPesquisaComum_txtEtiqueta")).SendKeys(matricula);
            Thread.Sleep(1000);
            driver.FindElement(By.Id("btnPesquisar")).Click();
            do
            {
                driver.FindElement(By.Id("btnPesquisar")).Click();
            } while (wait.Until(d => d.FindElement(By.Id("ctl00_MainContent_ucPesquisaComum_radCampos_ctl00__0")).Displayed) == false);

            driver.FindElement(By.Id("btnAnalisar")).Click();
            #endregion

            #region ANÁLISE FORMALIZAÇÃO
            wait.Until(d => d.FindElement(By.Id("chkVerTodos")).Enabled);
            driver.FindElement(By.Id("chkVerTodos")).Click();

            for (int i = 0; i <= 110; i++)
            {
                string id = "//div[@class='col-md-3']/select[@id='MainContent_rptCriterio_ddlCriterio_" + i + "']";
                SelectElement escolha = new SelectElement(driver.FindElement(By.XPath(id)));
                escolha.SelectByText("Sim");

            }

            driver.FindElement(By.Id("btnSalvar")).Click();
            #endregion

            #region AGUARDANDO FISICO

            wait.Until(d => d.FindElement(By.Id("MainContent_ucPesquisaComum_txtEtiqueta")).Displayed);
            driver.FindElement(By.XPath("//a[text()='Protocolo']")).Click();
            wait.Until(d => d.FindElement(By.XPath("//a[text()='Envio']")).Displayed);
            driver.FindElement(By.XPath("//a[text()='Envio']")).Click();
            wait.Until(d => d.FindElement(By.Id("txtEtiqueta")).Displayed);
            driver.FindElement(By.Id("txtEtiqueta")).SendKeys(matricula);
            driver.FindElement(By.Id("btnPesquisar")).Click();
            wait.Until(d => d.FindElement(By.Id("ctl00_MainContent_radPesquisa_ctl00__0")).Displayed);
            driver.FindElement(By.Id("ctl00_MainContent_radPesquisa_ctl00__0")).Click();
            driver.FindElement(By.Id("btnAdicionar")).Click();
            Thread.Sleep(1000);
            numProtocolo = driver.FindElement(By.Id("lblValorProtocolo")).Text;
            driver.FindElement(By.Id("btnFinalizar")).Click();
            wait.Until(d => d.FindElement(By.Id("numMalote")).Displayed);
            driver.FindElement(By.Id("numMalote")).SendKeys(numProtocolo);
            driver.FindElement(By.Id("numLacre")).SendKeys(numProtocolo);
            driver.FindElement(By.Id("btnGerarProt")).Click();
       
            #endregion

            #region CAIXA TEMPORÁRIA

            string caixa = "CX" + numProtocolo;
            wait.Until(d => d.FindElement(By.XPath("//button[text()= 'Imprimir Protocolo']")).Displayed);
            driver.FindElement(By.XPath("//a[text()= 'Expedição']")).Click();
            wait.Until(d => d.FindElement(By.XPath("//a[text()= 'Caixa Temporária']")).Displayed);
            driver.FindElement(By.XPath("//a[text()= 'Caixa Temporária']")).Click();
            wait.Until(d => d.FindElement(By.Id("txtCodigoCaixa")).Displayed);
            driver.FindElement(By.Id("txtCodigoCaixa")).SendKeys(caixa);
            driver.FindElement(By.Id("txtDescricaoCaixa")).SendKeys("Teste");
            driver.FindElement(By.Id("btnSalvar")).Click();
            #endregion

            #region RECEPÇÃO PROTOCOLO
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//a[text()='Recepção']")).Click();
            wait.Until(d => d.FindElement(By.XPath("//ul[@id = 'NavigationMenu:submenu:10']/li[@class= 'dynamic']/a[text()= 'Protocolo']")).Displayed);
            driver.FindElement(By.XPath("//ul[@id = 'NavigationMenu:submenu:10']/li[@class= 'dynamic']/a[text()= 'Protocolo']")).Click();
            wait.Until(d => d.FindElement(By.Id("btnContinuar")).Displayed);
            driver.FindElement(By.Id("txtProtocolo")).SendKeys(numProtocolo);
            driver.FindElement(By.Id("btnContinuar")).Click();
            wait.Until(d => d.FindElement(By.Id("txtCaixaTemp")).Displayed);
            driver.FindElement(By.Id("txtCaixaTemp")).SendKeys(caixa);
            driver.FindElement(By.Id("txtEtiqueta")).SendKeys(matricula);
            driver.FindElement(By.Id("btnPesquisar")).Click();
            driver.FindElement(By.Id("btnRecepcionar")).Click();
            driver.FindElement(By.Id("btnFechar")).Click();

            #endregion

            #region RECEPÇÃO MALOTE
            wait.Until(d => d.FindElement(By.Id("btnRecepcionar")).Displayed);
            driver.FindElement(By.XPath("//a[text()='Recepção']")).Click();
            wait.Until(d => d.FindElement(By.XPath("//ul[@id = 'NavigationMenu:submenu:10']/li[@class= 'dynamic']/a[text()= 'Malote']")).Displayed);
            driver.FindElement(By.XPath("//ul[@id = 'NavigationMenu:submenu:10']/li[@class= 'dynamic']/a[text()= 'Malote']")).Click();
            wait.Until(d => d.FindElement(By.Id("txtMalote")).Displayed);
            driver.FindElement(By.Id("txtMalote")).SendKeys(numProtocolo);
            driver.FindElement(By.Id("txtLacre")).SendKeys(numProtocolo);
            driver.FindElement(By.Id("btnOK")).Click();
            #endregion

            //driver.Close();

        }





        [Test]
        public void TesteAutomaizadoNSRH()
        {
            Random r = new Random();
            int pos = r.Next(matricula.Length);
                string mat = matricula[pos];
                FluxoNSRH(mat);
            Console.WriteLine(numProtocolo);
        }

			
    }
}
