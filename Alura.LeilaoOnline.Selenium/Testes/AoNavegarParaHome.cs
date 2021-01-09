using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Alura.LeilaoOnline.Selenium.Fixtures;

namespace Alura.LeilaoOnline.Selenium.Testes

{
    //chrome driver é o nome dado a colletion
    [Collection("Chrome Driver")]
    public class AoNavegarParaHome
    {
        private IWebDriver driver;

        /*Construtor da classe recebe como parametro a classe que está cuidando do setup e 
        teardown(que pode ser compartilhado com qualquer classe agora, desde que ela implemente 
        a interface IClassFixture<Passando tipo da classe que tem setup e teardown>)*/
        public AoNavegarParaHome(TestFixture testFixture)
        {
            driver = testFixture.Driver;
        }

        [Fact]
        public void DadoChromeAbertoDeveNavegarParaLeiloes()
        {
            //Arrange

            //Act
            driver.Navigate().GoToUrl("http://localhost:5000");
            //Assert
            Assert.Contains("Leilões", driver.Title);


        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            //Arrange

            //Act
            driver.Navigate().GoToUrl("http://localhost:5000");
            //Assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }


        [Fact]
        public void DadoChromeAbertoNaoDeveExibirErrosNaPagina()
        {
            //arrange

            //act
            driver.Navigate().GoToUrl("http://localhost:5000");
            //assert

            var form = driver.FindElement(By.TagName("form"));
            var spans = form.FindElements(By.TagName("span"));
            foreach (var span in spans)
            {
                Assert.True(string.IsNullOrEmpty(span.Text));
            }


        }

    }
}
