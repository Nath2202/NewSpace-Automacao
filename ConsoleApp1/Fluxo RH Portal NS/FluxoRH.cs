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
"99984253709237",
"99984453709575",
"99984453709737",
"99984453709818",
"99984453709893",
"99984453709958",
"99984453709990",
"99984453710018",
"99984453710093",
"99984453710158",
"99984453710174",
"99984453710190",
"99984453710239",
"99984453710352",
"99984453710379",
"99984453710433",
"99984453710492",
"99984453710514",
"99984453710530",
"99984453710557",
"99984453710590",
"99984453710611",
"99984453710654",
"99984453710735",
"99984453710816",
"99984453710832",
"99984453710859",
"99984453710875",
"99984453710891",
"99984453710913",
"99984453710930",
"99984453711030",
"99984453711057",
"99984453711154",
"99984453711170",
"99984453711251",
"99984453711294",
"99984453711332",
"99984453711359",
"99984453711391",
"99984453711430",
"99984453711472",
"99984453711537",
"99984453711570",
"99984453711677",
"99984453711715",
"99984453711774",
"99984453711790",
"99984453711812",
"99984453711839",
"99984453711855",
"99984453711871",
"99984453711898",
"99984453711910",
"99984453711936",
"99984453711952",
"99984453711979",
"99984453712010",
"99984453712037",
"99984453712053",
"99984453712070",
"99984453712096",
"99984453712118",
"99984453712134",
"99984453712150",
"99984453712177",
"99984453712193",
"99984453712215",
"99984453712231",
"99984453712258",
"99984453712274",
"99984453712290",
"99984453712312",
"99984453712339",
"99984453712371",
"99984453712398",
"99984453712410",
"99984453712436",
"99984453712452",
"99984453712479",
"99984453712495",
"99984453712517",
"99984453712533",
"99984453712550",
"99984453712576",
"99984453712592",
"99984453712614",
"99984453712630",
"99984453712657",
"99984453712673",
"99984453712690",
"99984453712711",
"99984453712738",
"99984453712754",
"99984453712770",
"99984453712797",
"99984453712835",
"99984453712851",
"99984453712878",
"99984453712894",
"99984453712916",
"99984453712932",
"99984453712959",
"99984453712975",
"99984453712991",
"99984453713017"


};
        #endregion

        string numProtocolo;
        int cont;


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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

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
            Thread.Sleep(2000);
            try
            {
                driver.FindElement(By.Id("btnUpload")).Click();
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Etiqueta não está na fila 'Aguardando Upload'.");
            }

            #endregion

            #region UPLOAD DE IMAGEM

            wait.Until(d => d.FindElement(By.XPath("//*[@id='ctl00_MainContent_ucArquivos_btnSelecionar']")).Displayed);
            IWebElement file = driver.FindElement(By.XPath("//*[@id='ctl00_MainContent_ucArquivos_btnSelecionar']"));

            //for (int i = 0; i <= 2; i++)
            //{
            //    UploadCPF(file);
            //    Thread.Sleep(1000);
            //    cont++;
            //}

            UploadCPF(file);
            Thread.Sleep(1000);

            driver.FindElement(By.Id("ctl00_MainContent_ucArquivos_btnUpload")).Click();
            Thread.Sleep(2000);
            try
            {
                wait.Until(d => d.FindElement(By.Id("ctl00_MainContent_ucArquivos_btnFinalizar")).Enabled);
                driver.FindElement(By.Id("ctl00_MainContent_ucArquivos_btnFinalizar")).Click();
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Problemas ao finalizar o Upload.");
            }


            #endregion

            #region TIPIFICAÇÃO
            wait.Until(d => d.FindElement(By.XPath("//a[text()='Análise']")).Displayed);
            driver.FindElement(By.XPath("//a[text()='Análise']")).Click();
            wait.Until(d => d.FindElement(By.XPath("//a[text()='Tipificação']")).Displayed);
            driver.FindElement(By.XPath("//a[text()='Tipificação']")).Click();
            Thread.Sleep(1000);
            //for (int i = 0; i <= cont; i++)
            //{
                driver.FindElement(By.Id("txtFiltro")).SendKeys("CPF");
                jse.ExecuteScript("window.scrollBy(0,250)", "");
                driver.FindElement(By.XPath("//button[text()='Salvar']")).Click();
                Thread.Sleep(1000);
            //}
            //driver.FindElement(By.Id("txtFiltro")).SendKeys("RG");
            //jse.ExecuteScript("window.scrollBy(0,250)", "");
            //driver.FindElement(By.XPath("//button[text()='Salvar']")).Click();

            try
            {
                wait.Until(d => d.FindElement(By.XPath("//div[text()= 'Não existem mais documentos a serem Tipificados.']")).Displayed);
                driver.FindElement(By.CssSelector(".btn.btn-default.btnModalCancelar")).Click();
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Não foram encontrados documentos para tipificação.");
            }

            #endregion

            #region FORMALIZAÇÃO
            driver.FindElement(By.XPath("//a[text()='Análise']")).Click();
            wait.Until(d => d.FindElement(By.XPath("//a[text()='Formalização']")).Displayed);
            driver.FindElement(By.XPath("//a[text()='Formalização']")).Click();
            wait.Until(d => d.FindElement(By.Id("MainContent_ucPesquisaComum_txtEtiqueta")).Displayed);
            driver.FindElement(By.Id("MainContent_ucPesquisaComum_txtEtiqueta")).SendKeys("99984453722610");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("btnPesquisar")).Click();

                try
            {
                wait.Until(d => d.FindElement(By.Id("ctl00_MainContent_ucPesquisaComum_radCampos_ctl00__0")).Displayed);
                driver.FindElement(By.Id("btnPesquisar")).Click();
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Etiqueta não foi encontrada. Verificar se o documento foi tipificado corretamente.");
            }
            driver.FindElement(By.Id("btnAnalisar")).Click();
            //do
            //{
            //    driver.FindElement(By.Id("btnPesquisar")).Click();
            //} while (wait.Until(d => d.FindElement(By.Id("ctl00_MainContent_ucPesquisaComum_radCampos_ctl00__0")).Displayed) == false);

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
        public void TesteAutomatizadoNSRH()
        {
            Random r = new Random();
            int pos = r.Next(matricula.Length);
                string mat = matricula[pos];
                FluxoNSRH(mat);
           
        }

			
    }
}
