using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace MantisWebTests
{
    [TestFixture]
    public class ProjectCreationTest : AuthTestBase
    {
        [Test]
        public void ProjectCreationTests()
        {
            
            ProjectData project = new ProjectData("001");

            List<ProjectData> oldProjects = app.Projects.GetProjectList();

            app.Projects.CreateProject(project);

            Assert.AreEqual(oldProjects.Count+1, app.Projects.GetProjectCount());

            List<ProjectData> newProjects = app.Projects.GetProjectList();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);

        }
    }
}
