using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;

namespace UnitTestProject.Pavani
{
    [TestClass]
    public class PS_UnitTest1 : BaseClass
    {
        //private const string Url = "https//mylabs.px.ppe.pearsoncmg.com/Pegasus/frmlogin.aspx?s=3";
        IWebDriver wd;

        readonly string username = ConfigurationManager.AppSettings["username"];
        readonly string password = ConfigurationManager.AppSettings["password"];

        #region Login Page

        IWebElement username3 => FindById("");

        /// <summary>
        /// this is username locator
        /// </summary>
        By UserName = By.Id("username");

        /// <summary>
        /// this is password locator
        /// </summary>
        By PassWord = By.Id("password");


        /// <summary>
        /// this is SignIn Button locator
        /// </summary>
        By Button = By.Id("mainButton");

        #endregion

        /// <summary>
        /// Method to Launch Browser
        /// </summary>
        public void InitBroswer()
        {
            wd = new ChromeDriver();
            wd.Manage().Window.Maximize();
            wd.Navigate().GoToUrl("https://mylabs.px.ppe.pearsoncmg.com/Pegasus/frmlogin.aspx?s=3");

        }

        /// <summary>
        /// Method to Launch Browser
        /// </summary>
        public void Pgtitlechk(string expectedtitle)
        {
            string title = wd.Title;
            //string expectedtitle = "Pearson Sign In";
            Assert.AreEqual(expectedtitle, title);
        }

        /// <summary>
        /// Method to Login to the app
        /// </summary>
        public void SignIn()
        {
            IWebElement Uname = wd.FindElement(UserName);

            Uname.Clear();
            Uname.SendKeys(username);

            IWebElement Password = wd.FindElement(PassWord);
            Password.Clear();
            Password.SendKeys(password);

            IWebElement button = wd.FindElement(Button);
            button.Click();
        }

        public void pagetoload(string pagetitle)
        {
            WebDriverWait wait = new WebDriverWait(wd, System.TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.TitleContains(pagetitle));

        }

        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                InitBroswer();

                Pgtitlechk("Pearson Sign In");

                SignIn();

                pagetoload("Global Home");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                wd.Quit();
            }
        }


    }
}
