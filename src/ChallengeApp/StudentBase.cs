using System;
using System.Collections.Generic;

namespace ChallengeApp
{
    public abstract class StudentBase : StudentName, IStudent
    {
        public delegate void  GradeAddedDelegate(object sender, EventArgs args);
        public delegate void  GradeAddedDelegateUnder3(object sender, EventArgs args);
        public event GradeAddedDelegate GradeAdded;
        public event GradeAddedDelegateUnder3 GradeAddedUnder3;
        public override string Name { get ; set ; }
        public StudentBase(string name) : base(name)
        {
        }
        public abstract void AddGrade(double grade);
        
        public void AddGrade(string grade)
        {
            double convertedGradeToDouble = char.GetNumericValue(grade[0]);
            if (grade.Length == 2)
            {
                switch (grade[1])
                {
                    case '+':
                        double addPlus = convertedGradeToDouble + 0.50;
                        if(addPlus >0 && addPlus <=6)
                        {
                            AddGrade(addPlus);
                        }
                        else
                        {
                            throw new ArgumentException($"Inserted grade {nameof(grade)} is out of range. Valid grade in range of (+/- 1 to 6)");
                        }
                        break;

                    case '-':
                        double addMinus = convertedGradeToDouble - 0.25;
                        if(addMinus >0 && addMinus <=6)
                        {
                            AddGrade(addMinus);
                        }
                        else
                        {
                            throw new ArgumentException($"Inserted grade {nameof(grade)} is out of range. Valid grade in range of (+/- 1 to 6)");
                        }
                        break;
                default:
                    throw new ArgumentException($"Inserted grade {nameof(grade)} is out of range. Valid grade in range of (+/- 1 to 6)");
                }
            }
            else
            {
                double gradeDouble = 0;
                var isParsed = double.TryParse(grade, out gradeDouble);
                if (isParsed && gradeDouble > 0 && gradeDouble <= 6)
                {
                    AddGrade(gradeDouble);
                }
                else
                {
                    throw new ArgumentException($"Invalid argument: {nameof(grade)}. Only grades from 1 to 6 are allowed!");
                }
            }
        }
        public abstract Statistics GetStatistics();
        protected void CheckEventGradeaddedUnder3()
        {
            if (GradeAddedUnder3 != null)
            {
                GradeAddedUnder3(this, new EventArgs());
            }
        }
        protected void CheckEventGradeadded()
        {
            if (GradeAdded != null)
            {
                GradeAdded(this, new EventArgs());
            }
        }

    }

}


