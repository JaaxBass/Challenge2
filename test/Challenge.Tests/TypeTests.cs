using System;
using ChallengeApp;
using Xunit;

namespace Challenge.Tests
{
    public class TypeTests
    {
        [Fact]
        public void GetEmployeeReturnDifferentsObjects()
        {
            var emp1 = GetEmployee("Jacek");
            var emp2 = GetEmployee("Radek");

            //Assert.Equal("Jacek", emp1.Name);
            //Assert.Equal("Radek", emp2.Name);
            Assert.NotSame(emp1, emp2);
            Assert.False(Object.ReferenceEquals(emp1, emp2));
        }

        private Employee GetEmployee(string name)
        {
            return new Employee(name);
        }
    }
}