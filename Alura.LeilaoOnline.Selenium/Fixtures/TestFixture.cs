using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Alura.LeilaoOnline.Selenium.Fixtures
{

    //Classe criada para cuidar do setup e teardown
    public class TestFixture : IDisposable
    {
        //propriedade criada para ser acessada por outras classes passando o driver...
        public IWebDriver Driver { get; private set; }


        //Setup
        public TestFixture()
        {
            //Cria uma instancia do navegador
            Driver = new ChromeDriver();
        }


        //TearDown

        public void Dispose()
        {
            //Mata os processos aberto do navegador
            Driver.Quit();
        }


    }
}
