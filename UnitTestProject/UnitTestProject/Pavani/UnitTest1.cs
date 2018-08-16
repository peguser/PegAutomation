using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject.Pavani
{
    [TestClass]
    public class PS_UnitTest1
    {
        //private const string Url = "https//mylabs.px.ppe.pearsoncmg.com/Pegasus/frmlogin.aspx?s=3";
        IWebDriver wd;

        readonly string username = ConfigurationManager.AppSettings["username"];
        readonly string password = ConfigurationManager.AppSettings["password"];

        #region Login Page

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

        [TestInitialize]
        public void InitBroswer()
        {
            wd = new ChromeDriver();
            wd.Manage().Window.Maximize();
            wd.Navigate().GoToUrl("https://mylabs.px.ppe.pearsoncmg.com/Pegasus/frmlogin.aspx?s=3");

        }

        [TestMethod]
        [Priority(1)]
        

        public void Pgtitlechk()
        {
            string title = wd.Title;
            //string expectedtitle = "Pearson Sign In";
            Assert.AreEqual(Resource1.Pagetitle, title);
        }

        [TestMethod]
        [Priority(2)]

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
            pagetoload();
        }


         

        public void pagetoload()
        {
            WebDriverWait wait = new WebDriverWait(wd, System.TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.TitleContains("Global Home"));

        }
        [TestCleanup]

        public void QuitBrowser() => wd.Quit();
    }
}
