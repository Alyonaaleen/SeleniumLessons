using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FirstTest
{
    [TestFixture]
    public class MyFirstTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver("C:\\Tools\\chromedriver.exe");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));
        }

        [Test]
        public void FirstTest()
        {
            driver.Navigate().GoToUrl("http://www.google.com/");
            driver.FindElement(By.Name("q")).SendKeys("webdriver");
            driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
            //driver.FindElement(By.Name("btnG")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleIs("webdriver - Поиск в Google"));
        }

        [TearDown]
        public void Stop ()
        {
           driver.Quit();
           driver = null;

        }
    }
}
