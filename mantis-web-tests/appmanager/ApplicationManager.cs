﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt-1.3.17/login_page.php";

            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            projectHelper = new ProjectHelper(this);
        }
        ~ApplicationManager()
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

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.OpenHomePage();
                app.Value = newInstance;

            }
            return app.Value;
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
