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
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected ProjectHelper projectHelper;

        public ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt-2.19.0/login_page.php";

            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            projectHelper = new ProjectHelper(this);
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public LoginHelper Auth
        {
            get { return loginHelper; }
        }

        public NavigationHelper Navigator
        {
            get { return navigator; }
        }

        public ProjectHelper Projects
        {
            get { return projectHelper; }
        }

        public IWebDriver Driver
        {
            get { return driver; }
        }
    }
}
