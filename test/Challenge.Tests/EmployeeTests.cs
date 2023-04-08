using System;
using ChallengeApp;
using Xunit;

namespace Challenge.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // arrange
            var student = new StudentInMemory("Jacek");
            student.AddGrade(2);
            student.AddGrade(3);
            student.AddGrade(4);

            // act
            var result = student.GetStatistics();

            // assert
            Assert.Equal(3, result.Average);
            Assert.Equal(4, result.High);
            Assert.Equal(2, result.Low);
        }
    }
}
