using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace InoveTeste.PageObject
{
    class ContatoPageObject
    {
        [FindsBy(How = How.Name, Using = "your-name")]
        public IWebElement name { get; set; }

        [FindsBy(How = How.Name, Using = "your-email")]
        public IWebElement email { get; set; }

        [FindsBy(How = How.Name, Using = "your-subject")]
        public IWebElement subject { get; set; }

        [FindsBy(How = How.Name, Using = "your-message")]
        public IWebElement message { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.wpcf7-form-control.wpcf7-submit")]
        public IWebElement enviar { get; set; }

        public void ButtonEnviarClick()
        {
            enviar.Click();
        }
    }
}
