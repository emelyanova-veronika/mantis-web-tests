using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using mantis_web_tests.MantisWebTests;
using NUnit.Framework;

namespace MantisWebTests 
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void ProjectRemovalTest()
        {
            app.Navigator.GoToControlInMainMenu();
            app.Navigator.GoToControlProjects();
            if (!app.Projects.ExistProjectVerification())
            {
                MantisConnectPortTypeClient cl = new MantisConnectPortTypeClient();
                cl.mc_project_add("administrator", "root", new mantis_web_tests.MantisWebTests.ProjectData{name = "123"});
            }
            List<ProjectData> oldProjects = app.Projects.GetProjectList();

            app.Projects.Remove(0);
            Assert.AreEqual(oldProjects.Count - 1, app.Projects.GetProjectCount());
            List<ProjectData> newProjects = app.Projects.GetProjectList();
            oldProjects.RemoveAt(0);
            Assert.AreEqual(oldProjects,newProjects);
        }
    }
}
