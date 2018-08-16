using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Configuration;

namespace AmazonDemo
{
    [TestClass]
    public class AmazonSearch
    {
        [TestMethod]
        public void Search()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.co.in");
            Assert.AreEqual("Google", driver.Title);
            IWebElement wd = driver.FindElement(By.CssSelector("input[id = 'lst-ib']"));
            wd.SendKeys("amazon offers");
            Thread.Sleep(1500);
            var xyz = driver.FindElements(By.XPath("//li[@role='presentation']//b"));
            foreach (var item in xyz)
            {
                Console.WriteLine(item.Text);
            }


            driver.Quit();




        }
        [TestMethod]
        public void LetsKode()
        {
            try
            {



                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://letskodeit.teachable.com/p/practice");
                driver.Manage().Window.Maximize();
                driver.Quit();
            }
            catch (Exception)
            {

                throw;
            }

        }
        [TestMethod]
        public void PegLogin()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(GetConfigValue("PPE"));
            driver.Manage().Window.Maximize();

            string status = driver.Title;
            Console.WriteLine(status);
            IWebElement un = driver.FindElement(By.Id("username"));
            un.SendKeys(GetConfigValue("UN"));
            IWebElement pw = driver.FindElement(By.Id("password"));
            pw.SendKeys(GetConfigValue("PW"));
            IWebElement sm = driver.FindElement(By.Id("mainButton"));
            sm.Click();


            while (driver.Title != "Global Home")
            {
                Thread.Sleep(2000);
            }
            driver.FindElement(By.XPath("//a/span[text()='Sequential Assignment Module-Demo']/following::button[2]")).Click();
            if (driver.Title == "Program Administration")
            {
                driver.FindElement(By.Id("btnBack")).Click();
            }




        }

        public string GetConfigValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        [TestMethod]
        public void configDemo()
        {
            Console.WriteLine(GetConfigValue("name"));
        }
    }
}
