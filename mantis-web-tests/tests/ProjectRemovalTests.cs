using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
                app.Projects.CreateProject(new ProjectData("24022019"));
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
