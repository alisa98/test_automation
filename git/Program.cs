using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public class Group
    {     
        public int Number { get; private set; }    
        public List<Student> students = new List<Student>();
        public Group(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("The group number must be greater than 0");
            }

            Number = number;
        }
    
        public Group(int number, params Student[] students) : this(number)
        {
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] != null)
                {
                    this.students.Add(students[i]);
                }
            }
        }

       
        public double AverageScore()
        {
            double avScore = 0;
            foreach (var student in students)
            {
                avScore += student.AverageScore();
            }
            return avScore / students.Count;
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }
    }
    public class Student
    {     
        public string FirstName { get; private set; }       
        public string LastName { get; private set; }      
        private List<int> notes = new List<int>();   
        public Student(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentNullException($"Invalid name {firstName}");
            }

            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentNullException($"Invalid name {lastName}");
            }

            FirstName = firstName;
            LastName = lastName;
        }      
        public Student(string firstName, string lastName, params int[] notes) : this(firstName, lastName)
        {
            for (int i = 0; i < notes.Length; i++)
            {
                if (notes[i] < 1 && notes[i] > 10)
                {
                    throw new ArgumentException($"Invalid note {notes[i]}");
                }

                this.notes.Add(notes[i]);
            }
        }    
        public double AverageScore()
            => notes.Average();

        public void AddNote(int note)
            => notes.Add(note);
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student Alisa = new Student("Alisa", "Utlik", 7, 8, 6, 7);
            Student Artem = new Student("Artem", "Zagorovsky", 7, 8, 9, 10);

	    Student Ivan = new Student("Ivan", "Star", 8, 6, 9);	


            Group group2 = new Group(2);
            group2.AddStudent(Alisa);
            group2.AddStudent(Artem);
            group2.AddStudent(Kirill);

            System.Console.WriteLine($"AverageScore of group 2: {group2.AverageScore()}");
            System.Console.WriteLine($"AverageScore of Akim 2: {Alisa.AverageScore()}");

            System.Console.ReadKey();
        }
    }
}
