using System;
using System.Collections.Generic;


namespace ChallengeApp
{
    public class StudentInMemory : StudentBase
    {
        private List<double> grades;

        public StudentInMemory(string name) : base(name)
        {
            grades = new List<double>();
        }
        public override void AddGrade(double grade)
        {
            if (grade > 0 && grade <= 6)
            {
                this.grades.Add(grade);
                CheckEventGradeadded();

                if (grade < 3)
                {
                    CheckEventGradeaddedUnder3();
                }
            }
            else
            {
                throw new ArgumentException($"Invalid argument: {nameof(grade)}. Only grades from 1 to 6 are allowed!");
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


