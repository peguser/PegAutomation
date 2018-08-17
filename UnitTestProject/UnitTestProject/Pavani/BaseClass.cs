using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject.Pavani
{
    public class BaseClass
    {
       public static IWebDriver wd;

        protected void WaitForPagToLoad(string PageTitle)
        {
            WebDriverWait wait = new WebDriverWait(wd, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.TitleContains(PageTitle));
        }

        protected void TypeText(IWebElement Uname, string text)
        {
            Uname.Clear();
            Uname.SendKeys(text);
        }

        protected IWebElement FindById(string id)
        {
            WaitForElementToLoad(By.Id(id));
            return wd.FindElement(By.Id(id));
        }

        protected IWebElement FindByXpath(string xpath)
        {
            WaitForElementToLoad(By.XPath(xpath));
            return wd.FindElement(By.XPath(xpath));
        }
        protected IWebElement FindByPartialLinkText(string link)
        {
            WaitForElementToLoad(By.PartialLinkText(link));
            return wd.FindElement(By.PartialLinkText(link));
        }

        protected void WaitForElementToLoad(By by)
        {
            WebDriverWait wait = new WebDriverWait(wd, TimeSpan.FromSeconds(90));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(s=>
            {
                try
                {
                 return wd.FindElement(by).Displayed;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            );
        }

        protected void InitBrowser()
        {
            wd = new FirefoxDriver();

            wd.Manage().Window.Maximize();

            wd.Url = GetEnvironmentDetails("url");

            //wd.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        public string GetEnvironmentDetails(String Key)
        {
            string s = "";

            switch (ConfigurationManager.AppSettings["Env"])
            {
                case "PPE":
                    switch (Key)
                    {
                        case "username":
                            s = ConfigurationManager.AppSettings["ppeusername"];
                            break;
                        case "password":
                            s = ConfigurationManager.AppSettings["ppepassword"];
                            break;
                        case "url":
                            s = ConfigurationManager.AppSettings["ppeurl"];
                            break;
                    }
                    break;

                case "CGIE":
                    break;

                default:throw new ArgumentException();
                  
            }
            return s;

        }


    }
}
