

using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class LoginPO
    {

        private IWebDriver driver;

        private By inputLogin;
        private By inputSenha;
        private By spanErroLogin;
        private By spanErroSenha;
        private By botaoLogin;

        public LoginPO(IWebDriver driver)
        {
            this.driver = driver;
            inputLogin = By.Id("Login");
            inputSenha = By.Id("Password");
            spanErroLogin = By.Id("Login-error");
            spanErroSenha = By.Id("Password-error");
            botaoLogin = By.Id("btnLogin");

        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");
        }

        public void PreencheFormulario(string login, string senha)
        {
            driver.FindElement(inputLogin).SendKeys(login);
            driver.FindElement(inputSenha).SendKeys(senha);
        }

        public void SubmeteFormulario()
        {
            driver.FindElement(botaoLogin).Click();
            //driver.FindElement(botaoLogin).Submit();
        }

        public string VerificaMensagemErroLogin()
        {
            return driver.FindElement(spanErroLogin).Text;
        }

        public string VerificaMensagemErroSenha()
        {
            return driver.FindElement(spanErroSenha).Text;
        }
    }
}
