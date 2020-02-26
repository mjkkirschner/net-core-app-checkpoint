using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#nullable enable

namespace CsharpNullReferenceTypesCheckpoint
{
    [TestClass]
    public class TestsBefore
    {
        [TestMethod]
        public void Test1()
        {
            var student = new Student()
            {
                FirstName = "John",
                LastName = "Smith",
                Email = "someEmail",
                Grade = 'A',
            };

            string result = ($"The student is called {student.FirstName}.");

            Assert.AreEqual("The student is called John.", result);
            Assert.AreEqual(student.LastName, "Smith");
            Assert.IsNotNull(student.Email);
            Assert.IsNotNull(student.Grade);

        }
    }

    public class Student
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public char? Grade { get; set; }
    }
}

#nullable disable