
using OpenQA.Selenium;
using Xunit;
using Alura.LeilaoOnline.Selenium.Fixtures;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;

        public AoEfetuarRegistro(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoInformacoesValidasDeveIrParaPaginaAgradecimento()
        {
            //Arrange - dado o chrome aberto, e dados de registros informados
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.FindElement(By.Id("Nome")).SendKeys("Henry Andrade");
            driver.FindElement(By.Id("Email")).SendKeys("Henry@Henry.com");
            driver.FindElement(By.Id("Password")).SendKeys("1234");
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys("1234");

            //Act - quando enviar o registro
            driver.FindElement(By.Id("btnRegistro")).Click();

            //Assert - entao devo ser redirecionado para pagina de agradecimento
            Assert.Contains("Obrigado por se registrar!", driver.PageSource);
        }

        //todos os inlinedata serao informados no teste, porém o resultado para cada linha tem que ser o mesmo...
        //que no caso é permanecer na mesma página.
        [Theory]
        [InlineData("", "", "", "")]
        [InlineData("Henry", "", "", "")]
        [InlineData("", "Henry", "", "")]
        [InlineData("", "", "123", "123")]
        [InlineData("1", "123", "12", "")]
        public void DadoFormularioComDadosInconsistenteDevePermanecerNaHome(string nome, string email, string senha,
            string confirmaSenha)
        {
            //Arrange - dado o chrome aberto, e dados de registros informados
            driver.Navigate().GoToUrl("http://localhost:5000");
            var inputNome = driver.FindElement(By.Id("Nome"));
            var inputEmail = driver.FindElement(By.Id("Email"));
            var inputSenha = driver.FindElement(By.Id("Password"));
            var inputConfirmaSenha = driver.FindElement(By.Id("ConfirmPassword"));

            inputNome.SendKeys(nome);
            inputEmail.SendKeys(email);
            inputSenha.SendKeys(senha);
            inputConfirmaSenha.SendKeys(confirmaSenha);

            //Act - quando enviar o registro
            driver.FindElement(By.Id("btnRegistro")).Click();

            //Assert - entao devo ser redirecionado para pagina de agradecimento
            Assert.Contains("section-registro", driver.PageSource);
        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {

            //Arrange
            driver.Navigate().GoToUrl("http://localhost:5000");
            var btn = driver.FindElement(By.Id("btnRegistro"));
            //Act
            btn.Click();
            //Assert
            IWebElement element = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Nome]"));
            Assert.True(element.Displayed);
        }


        [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {

            //Arrange
            driver.Navigate().GoToUrl("http://localhost:5000");
            var email = driver.FindElement(By.Id("Email"));
            var btn = driver.FindElement(By.Id("btnRegistro"));
            //Act
            email.SendKeys("Henry");
            btn.Click();
            //Assert
            IWebElement element = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Email]"));
            Assert.True(element.Displayed);
        }

        // falta corrigir o teste com equals... na aula resultado com vários elementos
    }
}
