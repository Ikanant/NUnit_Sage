using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SageworksTasksManager.Controllers;

namespace SageworksNUnit.Tests
{
    class TaskLinkTest : AssertionHelper
    {
        [Test]
        public static void CreateTask_DescriptionWithALink_SetLink()
        {
            var input = "test test http://www.google.com";

            var task = new Task(input, DateTime.Today);

            Expect(task.Link, Is.EqualTo("http://www.google.com"));
        }
    }
}
