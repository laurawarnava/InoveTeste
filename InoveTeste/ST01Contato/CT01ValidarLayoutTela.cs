using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using InoveTeste.PageObject;
using OpenQA.Selenium.Support.PageObjects;

namespace ST01Contato
{
    [TestFixture]
    public class CT01ValidarLayoutTela
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
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
        public void TheCT01ValidarLayoutTelaTest()
        {
            // Acessa o site
            driver.Navigate().GoToUrl(baseURL + "/contato");

            // Valida o layout da tela
            Thread.Sleep(20000);
            Assert.AreEqual("Envie uma mensagem", driver.FindElement(By.CssSelector("h1")).Text);
       
            //Page Object
            ContatoPageObject contato = new ContatoPageObject();
            PageFactory.InitElements(driver, contato);

            Assert.IsTrue(contato.name.Displayed);
            Assert.IsTrue(contato.email.Displayed);
            Assert.IsTrue(contato.subject.Displayed);
            Assert.IsTrue(contato.message.Displayed);
            Assert.IsTrue(contato.enviar.Displayed);
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
