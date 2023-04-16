using static ChallengeApp.StudentBase;

namespace ChallengeApp
{
    public interface IStudent
    {
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
        event GradeAddedDelegateUnder3 GradeAddedUnder3;
        void AddGrade(double grade);
        void AddGrade(string grade);
        Statistics GetStatistics();        
    }

}


