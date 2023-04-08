using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public class StudentInMemory : StudentBase
    {
        public override event GradeAddedDelegate GradeAdded;
        public override event GradeAddedDelegate GradeAddedUnder3;
        private List<double> grades;

        public StudentInMemory(string name) : base(name)
        {
            grades = new List<double>();
        }
        public override void AddGrade(double grade)
        {
            this.grades.Add(grade);
        }
        public override void AddGrade(string rate)
        {
            var grade = rate switch
            {
                "1+" => 1.5,
                "2+" => 2.5,
                "3+" => 3.5,
                "4+" => 4.5,
                "5+" => 5.5,
                "1-" => 0.75,
                "2-" => 1.75,
                "3-" => 2.75,
                "4-" => 3.75,
                "5-" => 4.75,
                "1" or "2" or "3" or "4" or "5" => double.Parse(rate),
                _ => throw new ArgumentException($"Inserted grade is out of range. Valid grade in range of (+/- 1 to 5)")
            };
            this.grades.Add(grade);

            if (GradeAdded != null)
            {
                GradeAdded(this, new EventArgs());
            }
            if (grade < 3)
            {
                GradeAddedUnder3(this, new EventArgs());
            }

            Console.WriteLine($"Grade {grade} was added.");
        }
        public void AddGradeToStringIfDouble(string grade)
        {
            if (double.TryParse(grade, out double result) && result >= 0 && result <= 100)
            {
                this.grades.Add(result);

                Console.WriteLine($"Grade: {result} student {Name} got correct grade {result}.");
            }
            else
            {
                if (result < 0 || result > 100)
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
                if (char.IsDigit(n))
                {
                    nameCheck = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"The following name: {name} has digit. The name: {name} doesn't meet conditions.");
                    Console.WriteLine($"The result of operation equals: {nameCheck}");
                    Console.ResetColor();
                    break;
                }
            }
            if (nameCheck)
            {
                this.Name = name;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"The following name: {name} meet the conditions. The name: {name} was added to the system.");
                Console.WriteLine($"The result of operation equals: {nameCheck}");
                Console.ResetColor();
            }
        }  
        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            for (var index = 0; index < grades.Count; index += 1)
            {
                result.Add(grades[index]);
            }

            return result;
        }
    }

}


