using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver wd;
        [TestMethod]
        public void TestMethod1()
        {
            wd = new ChromeDriver();

            wd.Manage().Window.Maximize();

            wd.Url = "";

            string currenttitle = wd.Title;

            wd.FindElement(By.Name("q")).SendKeys("");

            wd.Quit();

        }
    }
}
