using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public class Employee
    {
        //public string name;
        public List<double> grades = new List<double>();
        public Employee(string name)
        {       
            this.Name = name;
        }
        public string Name{get; set;}
        public void AddGrade(double grade)
        {
            this.grades.Add(grade);
        }   

        public void AddGradeToStringIfDouble(string grade)
        {
            if(double.TryParse(grade, out double result) && result >=0 && result <=100)
            {
                this.grades.Add(result);
                Console.WriteLine($"Grade: {result} student {Name} got correct grade {result}.");
            }
            else
            {
                if(result <0 || result >100)
                {
                    Console.WriteLine($"Grade: {result} is over the limit. Try again."); 
                }
                else
                {
                    Console.WriteLine($"Grade: {result} is not correct. Try again.");
                }
               
            }
        }

public void AddNameCheckIsItDigit(string name)
        {
            var nameCheck = true;
           foreach (var n in name)
           {
            if(char.IsDigit(n))
            {
                nameCheck = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The following name: {name} has digit. The name: {name} doesn't meet conditions.");
                Console.WriteLine($"The result of operation equals: {nameCheck}");
                Console.ResetColor();
            break;
            }  
           }
             if(nameCheck)
             {
                this.Name = name;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"The following name: {name} meet the conditions. The name: {name} was added to the system.");
                Console.WriteLine($"The result of operation equals: {nameCheck}"); 
                Console.ResetColor();
            }
        }
        
    public Statistics GetStatistics()
    {
        var result = new Statistics();

        result.Average = 0.0;
        result.Difference = 0.0;
        result.High = double.MinValue;
        result.Low = double.MaxValue;
        foreach(var n in this.grades)
           {
            result.Low = Math.Min(result.Low, n);
            result.High = Math.Max(result.High, n);
            result.Average += n;    
           }
           result.Average /=grades.Count;
           result.Difference = (result.High - result.Low);
           return result;             
    }  
}
}