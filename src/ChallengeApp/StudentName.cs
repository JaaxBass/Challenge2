namespace ChallengeApp
{
    public class StudentName : object
    {
        public virtual string Name { get; set; }
        public StudentName(string name)
        {
            this.Name = name;
        }
    }
}


