using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public class Employee
    {
        public string name;
        public List<double> grades = new List<double>();
        public Employee(string name)
        {       
            this.name = name;
        }
        public void AddGrade(double grade)
        {
            this.grades.Add(grade);
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