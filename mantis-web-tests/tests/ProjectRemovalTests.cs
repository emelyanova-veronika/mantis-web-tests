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
            List<ProjectData> oldProjects = app.Projects.GetProjectList();

            app.Projects.Remove(0);

            List<ProjectData> newProjects = app.Projects.GetProjectList();
            oldProjects.RemoveAt(0);
            Assert.AreEqual(oldProjects,newProjects);
        }
    }
}
