using System;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using InoveTeste;
using System.Configuration;

namespace ST01Contato
{
    [TestFixture]
    public class CT03EnviarMensagem
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private IJavaScriptExecutor js;

        [SetUp]
        public void SetupTest()
        {
            driver = Comandos.GetBrowserLocal(driver, ConfigurationManager.AppSettings["browser"]);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            baseURL = "https://livros.inoveteste.com.br/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheCT03EnviarMensagemTest()
        {
            // Acessa o site
            driver.Navigate().GoToUrl(baseURL + "/contato");

            // Preenche todos os campos do formulário
            driver.FindElement(By.Name("your-name")).Clear();
            driver.FindElement(By.Name("your-name")).SendKeys(ConfigurationManager.AppSettings["nome"]);
            driver.FindElement(By.Name("your-email")).Clear();
            driver.FindElement(By.Name("your-email")).SendKeys(ConfigurationManager.AppSettings["email"]);
            driver.FindElement(By.Name("your-subject")).Clear();
            driver.FindElement(By.Name("your-subject")).SendKeys(ConfigurationManager.AppSettings["assunto"]);
            driver.FindElement(By.Name("your-message")).Clear();
            driver.FindElement(By.Name("your-message")).SendKeys(ConfigurationManager.AppSettings["mensagem"]);
            
            // Clica no botão Enviar após preencher todos os campos obrigatórios
            Comandos.ExecuteJS(driver, "document.querySelector('input.wpcf7-form-control.wpcf7-submit').click();");

            // Valida a mensagem de sucesso do envio da mensagem.
            Thread.Sleep(10000);
            Assert.AreEqual("Agradecemos a sua mensagem. Responderemos em breve.", driver.FindElement(By.XPath("//div[@id='wpcf7-f372-p24-o1']/form/div[2]")).Text);
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
