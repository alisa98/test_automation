using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace task1
{
    class Program
    {

        static void Main(string[] args)
        {

            Student s1 = new Student("Утлик", "Алиса", 2, new int[] { 10, 8, 5 });
            Student s2 = new Student("Иванов", "Петр", 2, new int[] { 10, 7, 5 });
            Student s3 = new Student("Петров", "Иван", 9, new int[] { 6, 8, 5 });
            Student s4 = new Student("Соловьева", "Мария", 2, new int[] { 10, 4, 5 });
            Student[] students = new Student[] { s1, s2, s3, s4 };

            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine(students[i].GetSurname() + students[i].GetName() + " average mark:  " + students[i].AvgGroupMark());
            }
            Console.WriteLine("Average group mark: " + AvgGroupMark(students));
            Console.ReadKey();

        }

    }


    public class Student
    {

        public string surname;
        public string name;
        public int group;
        public int[] marks;



        public string GetName()
        {
            return name;
        }
        public void setName(String name)
        {
            this.name = name;
        }

        public string GetSurname()
        {
            return surname;
        }
        public void setSurname(String surname)
        {
            this.surname = surname;
        }


        public int GetGroup()
        {
            return group;
        }

        public void setGroup(int group)
        {
            this.group = group;
        }

        public int[] GetMarks()
        {
            return marks;
        }
        public void SetMarks(int[] marks)
        {
            this.marks = marks;
        }
        public Student(String surname, String name, int group, int[] marks)
        {

            this.name = name;
            this.surname = surname;
            this.group = group;
            this.marks = marks;

        }
        public string Info
        {
            get
            {
                string info = "surname: " + surname + " name: " + name + " group: " + group + "marks: ";
                return info;
            }
        }

        public float AvgMark()
        {
            float avgmark = 0;
            for (int i = 0; i < marks.Length; i++)
            {
                avgmark += marks[i];
            }
            avgmark = avgmark / marks.Length;
            return avgmark;
        }



        public float AvgGroupMark(Student[] s)
        {
            float avgmark = 0;
            for (int i = 0; i < s.Length; i++)
            {
                avgmark += s[i].AvgMark();
            }
            avgmark = avgmark / s.Length;
            return avgmark;
        }



    }


}
