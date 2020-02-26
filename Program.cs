﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsharpAsyncStreamsCheckpoint
{
    [TestClass]
    public class TestsBefore
    {

        [TestMethod]
        public async Task Test1()
        {
            /*
            string result = "";
            await foreach (var student in GetStudentsAsync())
            {
                result = result + ($"{student.FirstName} {student.LastName} - ");
                Console.WriteLine(result);
            }
            Console.WriteLine("asdsadasdsad");
            Assert.AreEqual("John Doe - Jane Doe - John Smith - ", result);
            */
              dostuff1();
             await dostuff2();
        }

        static async IAsyncEnumerable<Student> GetStudentsAsync()
        {
            await Task.Delay(2000);
            var students = new List<Student>()
            {
                new Student() {FirstName = "John", LastName = "Doe", Email = "john.doe@gmail.com", Grade = 'A'},
                new Student() {FirstName = "Jane", LastName = "Doe", Email="jane.doe@galvanize.com", Grade = 'B'},
                new Student() {FirstName = "John", LastName = "Smith", Email = "john.smith@galvanize.com", Grade = 'C'}
            };

            foreach (var item in students)
            {
                yield return item;
            }
        }

        static async Task dostuff1()
        {
            string result = "";
            await foreach (var student in GetStudentsAsync())
            {
                result = result + ($"{student.FirstName} {student.LastName} - from dostuff 1");
                Console.WriteLine(result);
                 Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
            }
        }
        static async Task dostuff2()
        {
             string result = "";
            await foreach (var student in GetStudentsAsync())
            {
                result = result + ($"{student.FirstName} {student.LastName} - from dostuff 2 ");
                Console.WriteLine(result);
                  Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
            }
        }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public char Grade { get; set; }
    }
}