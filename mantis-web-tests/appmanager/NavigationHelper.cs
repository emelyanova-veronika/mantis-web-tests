using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace MantisWebTests
{
    public class NavigationHelper : HelperBase
    {
        
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToControlInMainMenu()
        {
            driver.FindElement(By.LinkText("управление")).Click();
        }
        public void GoToControlProjects()
        {
            driver.FindElement(By.LinkText("Управление проектами")).Click();
        }
    }
}
