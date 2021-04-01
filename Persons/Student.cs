using IndividualProjectPartA_March2021_.Interfaces;
using IndividualProjectPartA_March2021_.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndividualProjectPartA
{
    public class Student : Controls, IID, IPersons
    {
        private static int idSetter = 0;
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private double tuitionFees;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }
        public double TuitionFees
        {
            get { return tuitionFees; }
            set { tuitionFees = value; }
        }

        public static List<Student> Students = new List<Student>();
        public List<Assignment> IndividualAssignments = new List<Assignment>();
        public List<Course> Courses = new List<Course>();

        public Student()
        {
            idSetter++;
            ID = "ST" + idSetter.ToString();
        }
        public Student(string fullConstructor)
        {
            Console.Clear();
            Console.WriteLine("-----New Student-----");
            idSetter++;
            ID = "ST" + idSetter.ToString();
            Console.Write("First name: ");
            FirstName = Console.ReadLine();
            Console.Write("Last name: ");
            LastName = Console.ReadLine();
            Console.Write("Date of birth (dd/mm/yyyy): ");
            DateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.Write("Tuition fees: ");
            TuitionFees = double.Parse(Console.ReadLine());
            Students.Add(this);
        }

        public override bool SecondaryMenu()
        {
            Console.Clear();
            Console.WriteLine("-----Students-----");
            Console.WriteLine("1. Register new student\n" +
                              "2. Display Students\n" +
                              "3. Previous Menu\n");
            switch (Console.ReadLine())
            {
                case "1":
                    bool cntn;
                    do
                    {
                        Student student = new Student("myStudent");
                        cntn = Continue();
                    } while (cntn);
                    return true;
                case "2":
                    if (Students.Count == 0)
                    {
                        Console.WriteLine("No entries yet");
                        Console.ReadKey();
                    }
                    else
                    {
                        GenericListDisplay(Students.Cast<Controls>().ToList());
                        ViewSubMenu();
                    }
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }

        public bool ViewSubMenu()
        {

            Console.WriteLine("\nChoose an option:\n" +
                              "1. Assignments per student\n" +
                              "2. Register to course\n" +
                              "3. Students in multiple courses\n" +
                              "4. Previous menu\n");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    DisplayAssignmentsPerStudent();
                    return true;
                case "2":
                    Register();
                    return true;
                case "3":
                    GenericListDisplay(StudentsMultipleCourses());
                    Console.ReadKey();
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }

        private static void DisplayAssignmentsPerStudent()
        {
            Student search = Find();
            Console.WriteLine($"-----{search.LastName}, {search.FirstName}: Assignments-----");
            if (search.IndividualAssignments.Count != 0)
            {
                foreach (Assignment assignment in search.IndividualAssignments)
                {
                    Console.WriteLine(assignment);
                }
            }
            else
                Console.WriteLine("No current assignments.");

            Console.WriteLine("Press a key to continue...");
            Console.ReadKey();
        }

        //public static Student FindStudent()
        //{
        //    //view student list

        //    foreach (Student student in Students)
        //    {
        //        if (studentID.Equals(student.ID))
        //        {
        //            return student;
        //        }
        //    }
        //}
        public override void Register()
        {
            bool contnue;
            if (Students.Count == 0 || Course.Courses.Count == 0)
            {
                Console.WriteLine("There are no trainers and/or courses available.");
            }
            else
            {
                do
                {
                    Console.Clear();
                    GenericListDisplay(Students.Cast<Controls>().ToList());
                    Student selection = Find();
                    GenericListDisplay(Course.Courses.Cast<Controls>().ToList());
                    Course selection2 = Course.Find();
                    selection2.Participants.Add(selection);
                    selection.Courses.Add(selection2);
                    contnue = Continue();
                } while (contnue);
            }

        }

        public List<Controls> StudentsMultipleCourses()
        {
            List<Controls> StudentsMultipleCourses = new List<Controls>();
            foreach (Student student in Students)
            {
                if (student.Courses.Count > 1)
                    StudentsMultipleCourses.Add(student);
            }
            return StudentsMultipleCourses;
        }


        private static Student Find()
        {
            Console.WriteLine("Select a student from the list by typing the ID");
            string studentID = Console.ReadLine();
            return Students.Find(student => student.ID == studentID.ToUpper());            
        }
        public override string ToString()
        {
            return $"{ID}:     {LastName}, {FirstName}, {DateOfBirth.ToString("dd/MM/yyyy")}, Tuition Fees: €{TuitionFees}";
        }

    }
}
