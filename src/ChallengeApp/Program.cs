using System;
using System.Collections.Generic;

namespace ChallengeApp
{
class Program
    {
        
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Insert student name:");
            var employee = new Employee(Console.ReadLine());
            employee.GradeAdded += OnGradeAdded;
            employee.GradeAdded2 += OnGradeAddedUnderThree;

            EnterGrade(employee);

            var stat = employee.GetStatistics();

            Console.WriteLine($"The student {employee.Name} has completed the task with the following grades:");
            Console.WriteLine($"Student {employee.Name} average grades are: {stat.Average}s from {employee.grades.Count} Grades.");
            Console.WriteLine($"Student {employee.Name} lowest grade is: {stat.Low}.");
            Console.WriteLine($"Student {employee.Name} highest grade is: {stat.High}.");
            Console.WriteLine($"Difference between highest and lowest grade is: {stat.Difference}.");

            //employee.AddGradeToStringIfDouble("0,0");
            //employee.AddGradeToStringIfDouble("12");
            //employee.AddGradeToStringIfDouble("-55");
            //employee.AddGradeToStringIfDouble("21");
            //employee.AddGradeToStringIfDouble("220");

            employee.AddNameCheckIsItDigit("Maciek");
            employee.AddNameCheckIsItDigit("W0jt6k");
            employee.AddNameCheckIsItDigit("Radek");
            employee.AddNameCheckIsItDigit("Pi0tr");
            employee.ForLoopTest();
        }

        private static void EnterGrade(Employee employee)
        {
            while (true)
            {
                Console.WriteLine($"Insert a grade for the student: {employee.Name} , or press q to exit.");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    employee.AddGradeString(input);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs args)
    {
        Console.WriteLine($"New grade in added");
    }

    static void OnGradeAddedUnderThree(object sender, EventArgs args)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Oh no! We should inform student's parents about this fact");
        Console.ResetColor();
    }
    }
 
}