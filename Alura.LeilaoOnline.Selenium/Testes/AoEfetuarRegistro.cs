
using OpenQA.Selenium;
using Xunit;
using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;

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
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();
            registroPO.PreencheFormulario(
                "Henry andrade",
                "henry@henry.com",
                "1234",
                "1234");

            //Act - quando enviar o registro
            registroPO.SubmeteFormulario();

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
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();
            registroPO.PreencheFormulario(nome, email, senha, confirmaSenha);

            //Act - quando enviar o registro
            registroPO.SubmeteFormulario();

            //Assert - entao devo ser redirecionado para pagina de agradecimento
            Assert.Contains("section-registro", driver.PageSource);
        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {

            //Arrange
            var regitroPO = new RegistroPO(driver);
            regitroPO.Visitar();

            //Act
            regitroPO.SubmeteFormulario();

            //Assert
            Assert.Equal("The Nome field is required.", regitroPO.VerificaMensagemDeErroNome());
        }


        [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {

            //Arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();
            //Act
            registroPO.PreencheFormulario("", "Henry", "", "");
            registroPO.SubmeteFormulario();

            //Assert
            Assert.Equal("Please enter a valid email address.", registroPO.VerificaMensagemDeErroEmail());
        }


        [Fact]
        public void DadoEmailEmBrancoDeveMostrarMensagemDeErro()
        {
            //arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            //act
            registroPO.SubmeteFormulario();

            //assert
            Assert.Equal("The Endereço de Email field is required.", registroPO.VerificaMensagemDeErroEmail());
        }

        [Fact]
        public void DadoSenhaEmBrancoDeveExibirMensagemDeErro()
        {
            //arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            //act
            registroPO.SubmeteFormulario();

            //assert
            Assert.Equal("The Senha field is required.", registroPO.VerificaMensagemDeErroSenha());
        }

        [Fact]
        public void DadoConfirmacaoDeSenhaEmBrancoDeveExibirMensagemDeErro()
        {
            //arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();
            //act
            registroPO.SubmeteFormulario();
            //assert
            Assert.Equal("The Confirmação de Senha field is required.", registroPO.VerificaMensagemDeErroConfirmaSenha());

        }

        [Fact]
        public void DadoConfirmacaoSenhaDiferenteDeveExibirMensagemDeErro()
        {
            //arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();
            //act
            registroPO.PreencheFormulario("", "", "1", "2");
            registroPO.SubmeteFormulario();
            //assert
            Assert.Equal("'Confirmação de Senha' and 'Senha' do not match.", registroPO.VerificaMensagemDeErroConfirmaSenha());

        }

    }
}
