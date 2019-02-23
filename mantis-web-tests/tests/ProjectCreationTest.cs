using System;
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
            
            ProjectData project = new ProjectData("014");

            app.Projects.CreateProject(project);
        }
    }
}
