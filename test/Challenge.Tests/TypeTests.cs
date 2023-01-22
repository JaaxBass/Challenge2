using System;
using ChallengeApp;
using Xunit;

namespace Challenge.Tests
{
    public class TypeTests
    {
        private string surname;

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
            var emp3 = new Employee("Tomek", "Marcinkowski"); 
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
            var emp4 = new Employee("Tomek", "Marcinkowski"); 
           
            // act
            this.SetName(emp4, "NewName", "NewSurname");
            // assert 
            Assert.Equal("NewName", emp4.Name);
        }
        private Employee GetEmployee(string name)
        {
            return new Employee(name, surname);
        }

        private void SetName(Employee employee, string name, string surname)
        {
            employee.Name = name;
            employee.Surname = surname;
        }
    }
}