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
            counter ++;
            return message;
        }

        string ReturnMessage2(string message)
        {
            counter ++;
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
            var emp3 = new Employee("Tomek"); 
            emp3.AddGrade(2.0);
            emp3.AddGrade(3.0);
            emp3.AddGrade(6.0);
            // act
            var result = emp3.GetStatistics();
            // assert 
            Assert.Equal(3.7, result.Average,1 );
            Assert.Equal(2.0, result.Low);
            Assert.Equal(6.0, result.High);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            // arrange
            var emp4 = new Employee("Tomek"); 
           
            // act
            this.SetName(emp4, "NewName");
            
            // assert 
            Assert.Equal("NewName", emp4.Name);
            
        }
        private Employee GetEmployee(string name)
        {
            return new Employee(name);
        }

        private void SetName(Employee employee, string name)
        {
            employee.Name = name;
     
       }
    }
}