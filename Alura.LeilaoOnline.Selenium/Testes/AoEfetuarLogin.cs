using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Alura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using Alura.LeilaoOnline.Selenium.PageObjects;


namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogin
    {
        private IWebDriver driver;

        public AoEfetuarLogin(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoCrecenciaisValidasDeveIrParaDashBoard()
        {
            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("fulano@example.org", "123");
            //act
            loginPO.SubmeteFormulario();
            //assert
            Assert.Contains("Dashboard", driver.Title);
        }

        [Fact]
        public void DadoCredenciaisInvalidasDevePermanecerNaPaginaDeLogin()
        {
            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("yoda", "");
            //act
            loginPO.SubmeteFormulario();
            //assert
            Assert.Contains("Login", driver.PageSource);
        }
    }
}
