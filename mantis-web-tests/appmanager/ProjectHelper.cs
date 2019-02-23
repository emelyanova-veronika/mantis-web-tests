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
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager)
        {
           
        }

        public ProjectHelper Remove(int v)
        {
            manager.Navigator.GoToControlInMainMenu();
            manager.Navigator.GoToControlProjects();
            SelectProject(v);
            RemoveProject();
            SubmitRemoveProject();
            return this;
        }

        public ProjectHelper CreateProject(ProjectData project)
        {
            manager.Navigator.GoToControlInMainMenu();
            manager.Navigator.GoToControlProjects();
            InitProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
            ReturnToControlProjects();
            return this;
        }
        public ProjectHelper InitProjectCreation()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            return this;
        }
        public ProjectHelper FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Id("project-name")).Clear();
            driver.FindElement(By.Id("project-name")).SendKeys(project.Name);
            return this;
        }
        public ProjectHelper SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
            return this;
        }
        public ProjectHelper ReturnToControlProjects()
        {
            driver.FindElement(By.LinkText("Продолжить")).Click();
            return this;
        }
        public ProjectHelper SelectProject(int index)
        {
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Описание'])[1]/following::a[" + index + "]")).Click();
            //driver.FindElement(By.CssSelector("td > a")).Click();
            return this;
        }
        public ProjectHelper RemoveProject()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            return this;
        }
        public ProjectHelper SubmitRemoveProject()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            return this;
        }
    }
}
