namespace ChallengeApp
{
    public interface IStudent
    {
        void AddGrade(double grade);
        void AddGradeString(string rate);
        Statistics GetStatistics();
        string Name {get; }
        
    }
  
}

        
