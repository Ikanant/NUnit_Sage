using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SageworksTasksManager.Controllers;

namespace ConsoleVerification.Tests
{
    class TaskTests
    {
        public static void Main(string[] args)
        {
            //BasicTest();

            //HardCodedScenarios();

            HardCodedScenariosWithAutoCheck();
        }

        public static void BasicTest()
        {
            while (true)
            {
                Console.WriteLine("Add a task: ");
                var input = Console.ReadLine();

                var task = new Task(input, DateTime.Today);

                Console.WriteLine("Description: " + task.Description);
                Console.WriteLine("Due Date: " + task.DueDate);
                Console.WriteLine();
            }
        }

        public static void HardCodedScenarios()
        {
            var input = "Finishe CRM-123";
            var task = new Task(input, DateTime.Today);
            Console.WriteLine("Description: " + task.Description);
            Console.WriteLine("Due Date: " + task.DueDate);
            Console.WriteLine();

            input = "Finishe ALLL-321";
            task = new Task(input, DateTime.Today);
            Console.WriteLine("Description: " + task.Description);
            Console.WriteLine("Due Date: " + task.DueDate);
            Console.WriteLine();

            Console.ReadLine();
        }

        public static void HardCodedScenariosWithAutoCheck()
        {
            var input = "Finishe CRM-123";
            var task = new Task(input, DateTime.Today);

            var descriptionShouldBe = input;
            DateTime? dueDateShouldBe = null;
            
            if (descriptionShouldBe == task.Description && dueDateShouldBe == task.DueDate)
            {
                Console.WriteLine("SUCCESS !");
            }
            else
            {
                Console.WriteLine("Description: " + task.Description);
                Console.WriteLine("Due Date: " + task.DueDate);
                Console.WriteLine("ERROR");
            }
            Console.WriteLine();



            input = "Finish CRM-123 December 14";
            task = new Task(input, DateTime.Today);

            descriptionShouldBe = input;
            dueDateShouldBe = DateTime.Today;

            if (descriptionShouldBe == task.Description && dueDateShouldBe == task.DueDate)
            {
                Console.WriteLine("SUCCESS !");
            }
            else
            {
                Console.WriteLine("Description was: " + task.Description);
                Console.WriteLine("Due Date was: " + task.DueDate);
                Console.WriteLine("ERROR");
            }
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
