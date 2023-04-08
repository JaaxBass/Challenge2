namespace ChallengeApp
{
    public interface IStudent
    {
        void AddGrade(double grade);
        void AddGrade(string grade);
        Statistics GetStatistics();
        string Name { get; }

    }

}


