using System;

namespace ChallengeApp
{
    public abstract class StudentBase : StudentName, IStudent
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);
        public abstract event GradeAddedDelegate GradeAdded;
        public abstract event GradeAddedDelegate GradeAddedUnder3;
        public StudentBase(string name) : base(name)
        {
        }
        public abstract void AddGrade(double grade);

        public abstract void AddGrade(string grade);

        public abstract Statistics GetStatistics();

    }

}


