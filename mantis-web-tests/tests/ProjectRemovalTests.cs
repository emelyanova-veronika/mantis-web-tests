﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace MantisWebTests 
{
    [TestFixture]
    public class ProjectRemovalTests : TestBase
    {
        

        [Test]
        public void ProjectRemovalTest()
        {
            app.Projects.Remove(1);
            
        }
    }
}