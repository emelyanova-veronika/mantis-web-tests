using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace MantisWebTests
{
    public class LoginHelper : HelperBase
    {
       

        public LoginHelper(ApplicationManager manager):base(manager)
        {
        }
        public void Login(AccountData account)
        {
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys(account.Username);
            driver.FindElement(By.XPath("//input[@value='Войти']")).Click();
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Войти']")).Click();
        }
    }
}
