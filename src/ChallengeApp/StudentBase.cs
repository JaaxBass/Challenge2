using System;

namespace ChallengeApp
{
    public abstract class StudentBase : NamedObject, IStudent
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);
        public abstract event GradeAddedDelegate GradeAdded;
        public abstract event GradeAddedDelegate GradeAdded2;
        public StudentBase(string name) : base(name)
        {
        }
        public abstract void AddGrade(double grade);

        public abstract void AddGradeString(string rate);
       
        public abstract Statistics GetStatistics();
        
    }
  
}

        
