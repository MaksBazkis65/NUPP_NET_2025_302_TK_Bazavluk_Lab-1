using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentList = new List<Student>
            {
                new Student(1, "John", 20),
                new Student(2, "Alice", 22),
                new Student(3, "Bob", 21)
            };

            var studentService = new StudentService();

            Console.WriteLine("Students before sorting:");
            foreach (var s in studentList)
            {
                Console.WriteLine(s);
            }

            var sortedStudents = studentService.SortStudentsByAge(studentList);

            Console.WriteLine("\nStudents after sorting by age:");
            foreach (var s in sortedStudents)
            {
                Console.WriteLine(s);
            }
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Student(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Age: {Age}";
        }
    }

    public class StudentService
    {
        public List<Student> SortStudentsByAge(List<Student> students)
        {
            return students.OrderBy(s => s.Age).ToList();
        }
    }
}