using System;
using ChallengeApp;
using Xunit;

namespace Challenge.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            // arrange
            var driver = new Employee("Jacek");
            driver.AddGrade(10.0);
            driver.AddGrade(20.0);
            driver.AddGrade(10.0);
            
            // act
            var result = driver.GetStatistics();

            // assert
            Assert.Equal(13.3, result.Average, 1);
            Assert.Equal(20.0, result.High);
            Assert.Equal(10.0, result.Low);
        }
    }
}