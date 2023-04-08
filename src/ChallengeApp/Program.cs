using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Clear();
            WritelineColor(ConsoleColor.Blue, "-----------------------------------------------\n" +
                                              "| Welcome to the studen's Logbook application |\n" +
                                              "-----------------------------------------------");
            bool ExitProgram = false;

            while (!ExitProgram)
            {
                WritelineColor(ConsoleColor.Blue,
                    "1 - Add student's grades to the program memory and show statistics\n" +
                    "2 - Add student's grades to the .txt file and show statistics\n" +
                    "X - Exit Program\n");

                WritelineColor(ConsoleColor.Yellow, "What you want to do? \nPress key 1, 2 or X: ");
                var userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "1":
                        AddDataInMemory();
                        break;

                    case "2":
                        SavedAddData();
                        break;

                    case "X":
                        ExitProgram = true;
                        break;

                    default:
                        WritelineColor(ConsoleColor.Red, "Invalid operation. \n");
                        continue;
                }
            }
            WritelineColor(ConsoleColor.DarkMagenta, "\n\nThank you and have a nice dayx! Press any key to Exit.");
            Console.ReadKey();
        }

        private static void AddDataInMemory()
        {
            Console.WriteLine("Insert student name:");
            var inMemoryStudent = new StudentInMemory(Console.ReadLine());
            inMemoryStudent.GradeAdded += OnGradeAdded;
            inMemoryStudent.GradeAddedUnder3 += OnGradeAddedUnderThree;
            EnterGrade(inMemoryStudent);

            var stat = inMemoryStudent.GetStatistics();
            Console.WriteLine($"The student {inMemoryStudent.Name} has completed the task with the following grades:");
            Console.WriteLine($"Student {inMemoryStudent.Name} average grades are: {stat.Average}.");
            Console.WriteLine($"Student {inMemoryStudent.Name} lowest grade is: {stat.Low}.");
            Console.WriteLine($"Student {inMemoryStudent.Name} highest grade is: {stat.High}.");
        }

        private static void SavedAddData()
        {
            Console.WriteLine("Insert student name:");
            var studentSaved = new SavedStudent(Console.ReadLine());
            studentSaved.GradeAdded += OnGradeAdded;
            studentSaved.GradeAddedUnder3 += OnGradeAddedUnderThree;
            EnterGrade(studentSaved);

            var stat = studentSaved.GetStatistics();
            Console.WriteLine($"The student {studentSaved.Name} has completed the task with the following grades:");
            Console.WriteLine($"Student {studentSaved.Name} average grades are: {stat.Average}.");
            Console.WriteLine($"Student {studentSaved.Name} lowest grade is: {stat.Low}.");
            Console.WriteLine($"Student {studentSaved.Name} highest grade is: {stat.High}.");
        }
        private static void EnterGrade(IStudent student)
        {
            while (true)
            {
                Console.WriteLine($"Insert a grade for the student: {student.Name} , or press q to exit.");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    //double.Parse
                    var grade = double.Parse(input);
                    student.AddGrade(grade);
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
        private static void WritelineColor(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
