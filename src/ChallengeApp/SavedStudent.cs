using System;
using System.IO;

namespace ChallengeApp
{
    public class SavedStudent : StudentBase
    {
        public override event GradeAddedDelegate GradeAdded;
        public override event GradeAddedDelegate GradeAddedUnder3;
        public SavedStudent(string name) : base(name)
        {
        }
        public override void AddGrade(double grade)
        {
            if (grade > 0 && grade <= 6)
            {
                using (var writer = File.AppendText($"{Name}.txt"))
                using (var writer2 = File.AppendText("audit.txt"))
                {
                    writer.WriteLine(grade);
                    writer2.WriteLine($"{Name} - {grade}     {DateTime.UtcNow}");

                    if (grade < 3)
                    {

                        GradeAddedUnder3(this, new EventArgs());
                    }
                }
                GradeAdded(this, new EventArgs());
            }
            else
            {
                throw new ArgumentException($"Invalid argument: {nameof(grade)}. Only grades from 1 to 6 are allowed!");
            }
        }
        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }

        public override void AddGrade(string grade)
        {
            throw new NotImplementedException();
        }
    }

}


