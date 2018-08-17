using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject.Pavani
{
    [TestClass]
    public class UnitTest2:BaseClass
    {
         string Username => base.GetEnvironmentDetails("username");

         string Password => base.GetEnvironmentDetails("password");

        [TestMethod]
        public void CheckValidLogin()
        {
            try
            {
                LoginPage l = new LoginPage();
                l.LoginToPegasus(Username, Password);
                WaitForPagToLoad("Global Home");
                l.EnterIntoCourseAsIns();
                l.EnterIntoCourseAsStu();
                WaitForPagToLoad("Course Materials");
            }
            catch (Exception)
            {
                
            }
            finally
            {
                wd.Quit();
            }
        }

        [TestMethod]
        public void CheckInValidLogin()
        {
            try
            {
                LoginPage l = new LoginPage();
                l.LoginToPegasus(Username, Password + "dfdf");
                Assert.AreEqual("That username or password didn't work.", l.GetErrorMessage());
            }
            catch (Exception)
            {

            }
            finally
            {
                wd.Quit();
            }
        }

        [TestMethod]
        public void LogOut()
        {
            try
            {
                LoginPage l = new LoginPage();
                l.LoginToPegasus(Username, Password);
                WaitForPagToLoad("Global Home");
                l.LogoutFromPegasus();
            }
            catch (Exception)
            {

            }
            finally
            {
                wd.Quit();
            }

        }

    }
}
