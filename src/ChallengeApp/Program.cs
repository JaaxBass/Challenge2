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

        //Console.WriteLine("Enter the time of first lap:");
        //double Lap1time = Convert.ToDouble(Console.ReadLine());
        //Console.WriteLine("Enter the time of second lap:");
        //double Lap2time = Convert.ToDouble(Console.ReadLine());
        //Console.WriteLine("Enter the time of third lap:");
        //double Lap3time = Convert.ToDouble(Console.ReadLine());
        //Console.WriteLine("Enter the time of fourth lap:");
        //double Lap4time = Convert.ToDouble(Console.ReadLine());
        //employee.AddGrade(Lap1time);  
        //employee.AddGrade(Lap2time);
        //employee.AddGrade(Lap3time);
        //employee.AddGrade(Lap4time);
        employee.AddGradeToStringIfDouble("21,37");
        employee.AddGradeToStringIfDouble("12");
        employee.AddGradeToStringIfDouble("-55");
        employee.AddGradeToStringIfDouble("21");
        employee.AddGradeToStringIfDouble("220");
        employee.AddNameCheckIsItDigit("Maciek");
        employee.AddNameCheckIsItDigit("W0jt6k");
        employee.AddNameCheckIsItDigit("Radek");
        employee.AddNameCheckIsItDigit("Pi0tr");

        var stat = employee.GetStatistics();

        Console.WriteLine($"The student {employee.Name} has completed the track with the following results:");
        Console.WriteLine($"Average track time: {stat.Average}s from {employee.grades.Count} Laps");
        Console.WriteLine($"The best track time: {stat.Low}s");
        Console.WriteLine($"The lowest track time: {stat.High}s");
        Console.WriteLine($"Time difference : {stat.Difference}s");
        }
    }
 
}