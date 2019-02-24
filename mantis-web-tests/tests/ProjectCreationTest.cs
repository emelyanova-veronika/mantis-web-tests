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
        public static IEnumerable<ProjectData> RandomProjectDataProvider()
        {
            List<ProjectData> projects = new List<ProjectData>();
            for (int i = 0; i < 1; i++)
            {
                projects.Add(new ProjectData(GenerateRandomString(30)));

            }
            return projects;
        }

        

        [Test,TestCaseSource("RandomProjectDataProvider")]
        public void ProjectCreationTests(ProjectData project)
        {
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
