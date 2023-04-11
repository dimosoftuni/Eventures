using Eventures.Tests.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Eventures.WebApp.UITests
{
    public class RegisterUser : BaseTests
    {
        private string userName = DateTime.Now.Ticks.ToString().Substring(12);
        private string userEmail = DateTime.Now.Ticks.ToString();
        private string userPassword = DateTime.Now.Ticks.ToString().Substring(12);

        public IWebElement inputUsername;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl(baseUrl + "/Identity/Account/Register");
            this.inputUsername = driver.FindElement(By.Id("Input_Username"));
        }

        [Test]
        public void Test_RegisterPageTitle()
        {
            driver.Url = baseUrl;
            var linkRegister = driver.FindElement(By.LinkText("Register"));
            linkRegister.Click();

            Assert.That(driver.Title, Is.EqualTo("Register - Eventures App"));
        }

        [Test]
        public void Test_RegisterValidUser()
        {
            inputUsername.SendKeys(userName);
            // Locate element by ID
            //var inputEmail = driver.FindElement(By.Id("Input_Email"));
            //inputEmail.SendKeys(userEmail + "@test.com");

            driver.FindElement(By.Id("Input_Email")).SendKeys(userEmail + "@test.com");


            var inputPassword = driver.FindElement(By.Id("Input_Password"));
            inputPassword.SendKeys(userPassword);

            var inputConfirmPassword = driver.FindElement(By.Id("Input_ConfirmPassword"));
            inputConfirmPassword.SendKeys(userPassword);

            var inputFirstName = driver.FindElement(By.Id("Input_FirstName"));
            inputFirstName.SendKeys("User1 First Name");

            var Input_LastName = driver.FindElement(By.Id("Input_LastName"));
            Input_LastName.SendKeys("User1 Last Name");

            var buttonRegister = driver.FindElement(By.XPath("//button[contains(.,'Register')]"));
            buttonRegister.Click();

            var labelName = driver.FindElement(By.XPath("(//a[@class='nav-link text-dark'])[1]"));

            Assert.That(labelName.Text, Is.EqualTo("Hello " + userName + "!"));
        }
    }
}