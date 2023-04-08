using System;
using ChallengeApp;
using Xunit;

namespace Challenge.Tests
{
    public class TypeTests
    {

        public delegate string WriteMessage(string message);

        int counter = 0;

        [Fact]
        public void WriteMessageDelegateCanPointToMethod()
        {
            WriteMessage del = ReturnMessage;
            del += ReturnMessage;
            del += ReturnMessage2;

            var result = del("HELLO!");

            Assert.Equal(3, counter);

        }

        string ReturnMessage(string message)
        {
            counter++;
            return message;
        }

        string ReturnMessage2(string message)
        {
            counter++;
            return message.ToUpper();
        }

        [Fact]
        public void GetEmployeeReturnDifferentsObjects()
        {
            // arrange
            var emp1 = GetEmployee("Jacek");
            var emp2 = GetEmployee("Radek");
            // assert
            Assert.NotSame(emp1, emp2);
            Assert.False(Object.ReferenceEquals(emp1, emp2));
        }

        [Fact]
        public void GetStatisticsReturnsCorrectCalculations()
        {
            // arrange
            var emp3 = new StudentInMemory("Tomek");
            emp3.AddGrade(4);
            emp3.AddGrade(4);
            emp3.AddGrade(4);
            // act
            var result = emp3.GetStatistics();
            // assert 
            Assert.Equal(4, result.Average);
            Assert.Equal(4, result.Low);
            Assert.Equal(4, result.High);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            // arrange
            var emp4 = new StudentInMemory("Tomek");

            // act
            this.SetName(emp4, "NewName");

            // assert 
            Assert.Equal("NewName", emp4.Name);

        }
        private StudentInMemory GetEmployee(string name)
        {
            return new StudentInMemory(name);
        }

        private void SetName(StudentInMemory employee, string name)
        {
            employee.Name = name;

        }
    }
}