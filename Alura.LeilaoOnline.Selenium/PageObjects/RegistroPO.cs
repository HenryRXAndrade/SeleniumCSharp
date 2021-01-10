
using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class RegistroPO
    {
        private IWebDriver driver;

        private By inputNome;
        private By inputEmail;
        private By inputSenha;
        private By inputConfirmaSenha;
        private By BotaoConfirma;
        private By spanErroNome;
        private By spanErroEmail;
        private By spanErroSenha;
        private By spanErroConfirmaSenha;


        public RegistroPO(IWebDriver driver)
        {
            this.driver = driver;
            inputNome = By.Id("Nome");
            inputEmail = By.Id("Email");
            inputSenha = By.Id("Password");
            inputConfirmaSenha = By.Id("ConfirmPassword");
            BotaoConfirma = By.Id("btnRegistro");
            spanErroNome = By.CssSelector("span.msg-erro[data-valmsg-for=Nome]");
            spanErroEmail = By.CssSelector("span.msg-erro[data-valmsg-for=Email]");
            spanErroSenha = By.CssSelector("span.msg-erro[data-valmsg-for=Password]");
            spanErroConfirmaSenha = By.CssSelector("span.msg-erro[data-valmsg-for=ConfirmPassword]");

        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000");
        }

        public void SubmeteFormulario()
        {
            driver.FindElement(BotaoConfirma).Click();
        }

        public void PreencheFormulario(string nome, string email, string senha, string confirmaSenha)
        {
            driver.FindElement(inputNome).SendKeys(nome);
            driver.FindElement(inputEmail).SendKeys(email);
            driver.FindElement(inputSenha).SendKeys(senha);
            driver.FindElement(inputConfirmaSenha).SendKeys(confirmaSenha);
        }

        public string VerificaMensagemDeErroNome()
        {
            return driver.FindElement(spanErroNome).Text;
        }

        public string VerificaMensagemDeErroEmail()
        {
            return driver.FindElement(spanErroEmail).Text;
        }

        public string VerificaMensagemDeErroSenha()
        {
            return driver.FindElement(spanErroSenha).Text;
        }

        public string VerificaMensagemDeErroConfirmaSenha()
        {
            return driver.FindElement(spanErroConfirmaSenha).Text;
        }


    }
}
