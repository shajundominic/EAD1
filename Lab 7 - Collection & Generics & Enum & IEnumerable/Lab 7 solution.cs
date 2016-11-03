// sample solution to Lab 7
// author GC

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace College
{
    public enum Sex { Male, Female }

    // a student
    public class Student
    {
       public String Id {get; set; }                    // unique
       public String Name {get; set; }
       public Sex Gender {get; set;}

       // 1 constructor only
       public Student(String id, String name, Sex gender)
       {
           this.Id = id;
           this.Name = name;
           this.Gender = gender;
       }

       public override string ToString()
       {
           return "Id: " + Id + " Name: " + Name + " Gender: " + Gender;
       }
    }

    // a student class
    public class StudentClass : IEnumerable 
    {
        public String Crn { get; set; }                 // unique class reference number
        public String Lecturer { get; set; }

        // collection of students in the class
        private List<Student> students;                 // strongly typed

        // 1 constructor
        public StudentClass(String crn, String lecturer)
        {
            this.Crn = crn;
            this.Lecturer = lecturer;

            students = new List<Student>();
        }

        // add a student to the class, if not already in the class
        public void AddStudent(Student student)
        {
            if (students == null)                               // empty
            {
                students.Add(student);                          // first student
            }
            else
            {
                if ((students.Count(s => s.Id == student.Id)) == 1)                         // LINQ query, student id is unique
                {
                    throw new ArgumentException("Error student " + student.Name + " is already in the class");
                }
                else
                {
                    students.Add(student);
                }
            }
        }

        // indexer based on an int
        public Student this[int i]
        {
            get
            {
                // validate index values
                if ((i >= 0) & (i < students.Count))
                {
                    return students[i];
                }
                else
                {
                    throw new ArgumentException("Error: studuent index out of range");
                }
            }
        }

        // indexer based a String
        public Student this[String id]
        {
            get
            {
                // find matching student and return

                Student student = null;
                int count = students.Count(s => s.Id == id);                        // LINQ query
                if (count == 1)
                {
                    student = students.Where(s => s.Id == id).First();              // select the student
                    return student;
                }
                else
                {
                    throw new ArgumentException("no matching student found");
                }

                // alternative to LINQ: iterate using a loop to find matching student based on ID and return
            }
        }

        // iterate over student collection - foreach now possible on a StudentClass
        public IEnumerator GetEnumerator()
        {
            foreach (Student student in students)
            {
                yield return student;                   // iterator
            }
        }
    }


    // test class
    class Test
    {
        public static void Main()
        {
            try
            {
                // create 2 students
                Student s1 = new Student("X00000111", "Joe Soap", Sex.Male);
                Student s2 = new Student("X00000222", "Jane Doe", Sex.Female);
                
                // create a class
                StudentClass oosdev2 = new StudentClass("oosdev2", "Gary Clynch");

                // add the students
                oosdev2.AddStudent(s1);
                oosdev2.AddStudent(s2);
                //oosdev2.AddStudent(s2);                           // duplicate, throws an exception

                // print details of class and each stuednt
                Console.WriteLine("Class: CRN " + oosdev2.Crn + " Lecturer " + oosdev2.Lecturer);
                foreach (Student student in oosdev2)               // use iterator
                {
                    Console.WriteLine(student);
                }

                // try to find a player
                Student s = oosdev2["X00000111"];               // use overloaded indexer
                Console.WriteLine("Found " + s);
                s = oosdev2[1];                                 // use overloaded indexer
                Console.WriteLine("Found " + s);
            }
            catch (ArgumentException e1)
            {
                Console.WriteLine(e1.Message);
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2.Message);
            }
        }
    }
}