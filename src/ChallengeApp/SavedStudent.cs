using System;
using System.IO;
using System.Collections.Generic;

namespace ChallengeApp
{
    public class SavedStudent : StudentBase
    {
         private const string fileName = "_grades.txt";
         private string fullfileName;
         public SavedStudent(string name) : base(name)
        {
            fullfileName = $"{name}{fileName}";
        }      
        public override void AddGrade(double grade)
        {
            if (grade > 0 && grade <= 6)
            {
                using (var writer = File.AppendText($"{fullfileName}"))
                using (var writer2 = File.AppendText("audit.txt"))             
                {
                    writer.WriteLine(grade);
                    writer2.WriteLine($"{Name} - {grade}     {DateTime.UtcNow}");
                    CheckEventGradeadded();
                if (grade < 3)
                {
                    CheckEventGradeaddedUnder3();
                }
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
            if (File.Exists($"{fullfileName}"))
            {

                using (var reader = File.OpenText($"{fullfileName}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = double.Parse(line);
                        result.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return result;
        }
     }
}


