using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Pavani
{
    public class LoginPage:BaseClass
    {
        IWebElement username_textbox => FindById("username");
        
        IWebElement password_textbox => FindById("password");

        IWebElement SignInButton => FindById("mainButton");

        IWebElement CourseName => FindByPartialLinkText("MySpanishLab Course - Audit Cherry");

        IWebElement ClickButton => FindById("");

        IWebElement ErrorMessage => FindByXpath("//p[@class='panel-title pe-form--error ng-binding']");

        IWebElement DropDown => FindByXpath("//button[@class='dropdown-toggle navbartxt txthlname helloobjectlist profileDropDownBtn']");

        IWebElement SignOut => FindByXpath("//a[@title='Sign out']");

        IWebElement Cdropdown => FindByXpath("//span[text()='Course Materials']/following::span[@class='fa fa-chevron-down glyficFont'][1]");

        IWebElement AddFromLibrary => FindByXpath("//span[text()='Course Materials']/following::span[@class='fa fa-chevron-down glyficFont'][1]/following::a[@class='subMenuText'][1]");

        IWebElement StudentLink => FindByXpath("//span[text()='Go to Student View']");

        IWebElement ScourseMaterials => FindByXpath("//span[text()='Course Materials']");

        IWebElement SviewAllCourseMaterials => FindByXpath("//a[normalize-space(.)='View All Course Materials']");

        public void LoginToPegasus(string Uname, string pwd)
        {
            InitBrowser();

            WaitForPagToLoad("Pearson Sign In");

            TypeText(username_textbox, Uname);

            TypeText(password_textbox, pwd);

            SignInButton.Click();

            
        }

        public void LogoutFromPegasus()
        {
            DropDown.Click();

            SignOut.Click();

            WaitForPagToLoad("Pearson Sign In");
        }
        public string GetErrorMessage()
        {
            return ErrorMessage.Text;
        }

        public void EnterIntoCourseAsIns()
        {

            CourseName.Click();

            WaitForPagToLoad("Today's View");

            Cdropdown.Click();

            AddFromLibrary.Click();

            WaitForPagToLoad("Course Materials");


        }

        public void EnterIntoCourseAsStu()
        {
            WaitForPagToLoad("Course Materials");

            StudentLink.Click();

            var ac = new Actions(wd);

            ac.MoveToElement(ScourseMaterials).Build().Perform();

            SviewAllCourseMaterials.Click();


        }
    }
}
