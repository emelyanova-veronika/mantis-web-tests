using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using mantis_web_tests.MantisWebTests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
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
            driver.FindElement(By.XPath("//input[@value='создать новый проект']")).Click();
            return this;
        }
        public ProjectHelper FillProjectForm(ProjectData project)
        {
            Type(By.Id("project-name"), project.Name);
            return this;
        }
        public ProjectHelper SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
            _cache = null;
            return this;
        }
        public ProjectHelper ReturnToControlProjects()
        {
            driver.FindElement(By.LinkText("Продолжить")).Click();
            return this;
        }
        public ProjectHelper SelectProject(int index)
        {
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Описание'])[1]/following::a[" + (index+1) + "]")).Click();
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
            _cache = null;
            return this;
        }

        public bool ExistProjectVerification()
        {
            var a = driver.FindElements(By.ClassName("form-container")).FirstOrDefault(x => x.Text.Contains("Проекты"));
            var b = a.FindElement(By.TagName("tbody")).FindElements(By.TagName("tr"));

            if (b.Count > 0)
            {
                return true;
            }
            return false;
        }

        private List<ProjectData> _cache;

        public List<ProjectData> GetProjectList()
        {
            if (_cache != null) return new List<ProjectData>(_cache);
            _cache = new List<ProjectData>();
            MantisConnectPortTypeClient cl = new MantisConnectPortTypeClient();
            var a = cl.mc_projects_get_user_accessible("administrator", "root");
            _cache.AddRange(a.Select(x => new ProjectData(x.name)));
            return new List<ProjectData>(_cache);
        }

        /*public List<ProjectData> GetProjectList()
        {
            if (cache == null)
            {
                cache = new List<ProjectData>();
                manager.Navigator.GoToControlInMainMenu();
                manager.Navigator.GoToControlProjects();

                ICollection<IWebElement> elements = driver.FindElement(By.TagName("tbody")).FindElements(By.TagName("tr"));
                foreach (IWebElement element in elements)
                {
                    var cells = element.FindElements(By.TagName("a"));
                    cache.Add(new ProjectData(cells[0].Text));

                }
            }
            return new List<ProjectData>(cache);
        }*/

        public int GetProjectCount()
        {
            return driver.FindElement(By.TagName("tbody")).FindElements(By.TagName("tr")).Count;
        }
    }
}
