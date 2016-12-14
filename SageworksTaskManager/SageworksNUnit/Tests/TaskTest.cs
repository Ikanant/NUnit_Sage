using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SageworksTasksManager.Controllers;
using NUnit.Framework;

namespace SageworksNUnit.Tests
{
    /*
    packages\NUnit.Runners.2.6.4\tools\nunit-console.exe SageworksNUnit\bin\Debig\ConsoleVerification.exe
    */

    // Prior to NUnit 2.5 we also needed to include [TestFixture] on top of the needed class

    // Method format: METHOD_SCENARIO_EXPECTATION

    public class TaskTest : AssertionHelper
    {
        [Test]
        public void TestDescriptionAndNoDueDate()
        {
            var input = "Finishe CRM-123";
            var task = new Task(input, DateTime.Today);

            var descriptionShouldBe = input;
            DateTime? dueDateShouldBe = null;

            bool success = descriptionShouldBe == task.Description && dueDateShouldBe == task.DueDate;
            var failureMessage = "ERROR";

            Assert.That(success, failureMessage);

            // OR

            Assert.AreEqual(descriptionShouldBe, task.Description);
            Assert.AreEqual(dueDateShouldBe, task.DueDate);
        }

        [Test]
        public void SimplifyingTests()
        {
            var input = "Finishe CRM-123";
            var task = new Task(input, DateTime.Today);

            Expect(task.Description, Is.EqualTo(input));
            Assert.AreEqual(null, task.DueDate);
        }

        [Test]
        [TestCase("Pickup the groceries may 5 - as of 2015-05-31")]
        [TestCase("Pickup the groceries apr 5 - as of 2015-05-31")]
        public void MayDueDateDoesWrapYear(string input)
        {
            var today = new DateTime(2015, 5, 31);
            var task = new Task(input, today);

            Expect(task.DueDate.Value.Year, Is.EqualTo(2016));
        }

        [Test]
        [TestCase("Groceries jan 1", 1)]
        [TestCase("Groceries feb 2", 2)]
        [TestCase("Groceries mar 3", 3)]
        [TestCase("Groceries apr 4", 4)]
        [TestCase("Groceries may 5", 5)]
        [TestCase("Groceries jun 6", 6)]
        [TestCase("Groceries jul 7", 7)]
        [TestCase("Groceries aug 8", 8)]
        [TestCase("Groceries sep 9", 9)]
        [TestCase("Groceries oct 10", 10)]
        [TestCase("Groceries nov 11", 11)]
        [TestCase("Groceries dec 12", 12)]
        public void AprilDueDate(string input, int expectedMonth)
        {
            var today = new DateTime(2015, 5, 31);

            var task = new Task(input, today);

            Expect(task.DueDate, Is.Not.Null);
            Expect(task.DueDate.Value.Month, Is.EqualTo(expectedMonth));
        }
        
        [Test]
        public void TwoDigitDate_ParseBothDigits()
        {
            var input = "Groceries apr 12";

            var task = new Task(input, default(DateTime));

            Expect(task.DueDate.Value.Day, Is.EqualTo(12));
        }

        [Test]
        public void DayIsPastTheLastDayOfTheMonth_DoesNotParseDueDate()
        {
            var input = "Groceries apr 44";

            var task = new Task(input, default(DateTime));

            Expect(task.DueDate, Is.Null);
        }

        [Test]
        public void AddFeb29TaskInMarchOfYearBeforeLeapYear_ParsesDueDate()
        {
            var input = "Groceries feb 29";
            var today = new DateTime(2015, 3, 1);

            var task = new Task(input, today);

            Expect(task.DueDate.Value, Is.EqualTo(new DateTime(2016, 2, 29)));
        }
    }
}
