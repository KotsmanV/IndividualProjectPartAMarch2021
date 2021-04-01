using IndividualProjectPartA_March2021_.Interfaces;
using IndividualProjectPartA_March2021_.Tools;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace IndividualProjectPartA
{
    public class Course : Controls, IID, IEducationalElements
    {
        private static int idSetter = 0;
        private string title;
        private string stream;
        private string type;
        private DateTime start_date;
        private DateTime end_date;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Stream
        {
            get { return stream; }
            set { stream = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public DateTime StartDate
        {
            get { return start_date; }
            set { start_date = value; }
        }
        public DateTime EndDate
        {
            get { return end_date; }
            set { end_date = value; }
        }

        //public static object cultureInfo = new CultureInfo("el-GR");

        public static List<Course> Courses = new List<Course>();
        public List<Student> Participants = new List<Student>();
        public List<Trainer> CurrentTrainers = new List<Trainer>();
        public List<Assignment> CurrentAssignments = new List<Assignment>();

        public Course()
        {
            idSetter++;
            ID = "CR" + idSetter.ToString();
        }
        public Course(bool synthConstructor)
        {
            Console.Clear();
            Console.WriteLine("-----New Course-----");
            idSetter++;
            ID = "CR" + idSetter.ToString();
            Console.Write("Title: ");
            Title = Console.ReadLine();
            Console.Write("Stream: ");
            Stream = Console.ReadLine();
            Console.Write("Type: ");
            Type = Console.ReadLine();
        }
        public Course(string fullConstructor)
        {
            Console.Clear();
            Console.WriteLine("-----New Course-----");
            
            idSetter++;
            ID = "CR" + idSetter.ToString();
            
            Console.Write("Title: ");
            Title = Console.ReadLine();
            
            Console.Write("Stream: A) Humanities or B) Natural Sciences? ");
                if (Console.ReadLine().ToUpper().Equals("A"))
                    Stream = "Humanities";
                else if (Console.ReadLine().ToUpper().Equals("B"))
                    Stream = "Natural Sciences";
            
            Console.Write("Type: A) Yearly B) Semester A C) Semester B? ");
                if (Console.ReadLine().ToUpper().Equals("A"))
                    Type = "Yearly";
                else if (Console.ReadLine().ToUpper().Equals("B"))
                    Type = "Semester A";
                else if (Console.ReadLine().ToUpper().Equals("B"))
                    Type = "Semester B";
            
            Console.Write("Start Date: (dd/mm/yyyy)");
            StartDate = SetDate(DateTime.Parse(Console.ReadLine()));

            Console.Write("End Date: (dd/mm/yyyy)");
            EndDate = SetDate(DateTime.Parse(Console.ReadLine()));

            Courses.Add(this);
        }
        public override bool SecondaryMenu()
        {
            Console.Clear();
            Console.WriteLine("-----Courses-----");
            Console.WriteLine("1. Add new course.\n" +
                              "2. Display Courses.\n" +
                              "3. Previous Menu\n");
            switch (Console.ReadLine())
            {
                case "1":
                    bool cntn;
                    do
                    {
                        Course course = new Course("myCourse");
                        cntn = Continue();
                    } while (cntn);
                    return true;
                case "2":                    
                    if (Courses.Count == 0)
                    {
                        Console.WriteLine("No entries yet");
                        Console.ReadKey();
                    }
                    else
                    {
                        GenericListDisplay(Courses.Cast<Controls>().ToList());
                        ViewSubMenu();
                    }
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }

        private static bool ViewSubMenu()
        {
            Course search;
            Console.WriteLine("\nChoose an option for a course:\n" +
                                                  "1. Display Trainers\n" +
                                                  "2. Display Students\n" +
                                                  "3. Display Assignments\n" +
                                                  "4. New Assignment\n" +
                                                  "5. Previous menu\n");
            string input = Console.ReadLine();
            

                
            
            switch (input)
            {

                case "1":
                    search = Find();
                    Console.WriteLine($"-----{search.Title}: Trainers-----");
                    if (search.CurrentTrainers.Count != 0)
                    {
                        foreach (Trainer trainer in search.CurrentTrainers)
                        {
                            Console.WriteLine(trainer);
                        }
                    }
                    else
                        Console.WriteLine("No trainers assigned.");

                    Console.WriteLine("Press a key to continue...");
                    Console.ReadKey();
                    return true;

                case "2":
                    search = Find();
                    Console.WriteLine($"-----{search.Title}: Students-----");
                    if (search.Participants.Count != 0)
                    {
                        foreach (Student student in search.Participants)
                        {
                            Console.WriteLine(student);
                        }
                    }
                    else
                        Console.WriteLine("No students registered.");

                    Console.WriteLine("Press a key to continue...");
                    Console.ReadKey();
                    return true;

                case "3":
                    search = Find();
                    Console.WriteLine($"-----{search.Title}: Assignments-----");
                    if (search.CurrentAssignments.Count != 0)
                    {
                        foreach (Assignment assignment in search.CurrentAssignments)
                        {
                            Console.WriteLine(assignment);
                        }
                    }
                    else
                        Console.WriteLine("No current assignments.");

                    Console.WriteLine("Press a key to continue...");
                    Console.ReadKey();
                    return true;
                case "4":
                    search = Find();
                    search.CurrentAssignments.Add(search.CreateAssignment());
                    return true;
                case "5":
                    return false;
                default:
                    return true;
            }
        }
        

        //private bool Modify(Course course)
        //{
        //    Console.WriteLine($"-----{course.Title}-----");
        //    Console.WriteLine("Pick an option\n");
        //    Console.WriteLine("1. Add Trainer\n" +
        //                      "2. Register student\n" +
        //                      "3. Create Assignment\n" +
        //                      //"\nModify Course properties" +
        //                      //"4. Change Title\n" +
        //                      //"5. Change Stream\n" +
        //                      //"6. Change Type\n" +
        //                      //"7. Change Start Date\n" +
        //                      //"8. Change End Date\n" +
        //                      "7. Previous Menu\n");

        //    switch (Console.ReadLine())
        //    {
        //        case "1":
        //            GenericListDisplay(Trainer.Trainers.Cast<Controls>().ToList());

        //            return true;
        //        case "2":
        //            return true;
        //        case "3":
        //            course.CurrentAssignments.Add(course.CreateAssignment());
        //            return true;
        //        case "4":
        //            return true;
        //        case "5":
        //            return true;
        //        case "6":                                        
        //            return true;
        //        case "7":
        //            return false;
        //        default:
        //            return true;
        //    }
        //}

        public Assignment CreateAssignment()
        {
            Assignment assignment = new Assignment("myAssignment");
            foreach (Student student in Participants)
            {
                student.IndividualAssignments.Add(assignment);
                CurrentAssignments.Add(assignment);
            }
            return assignment;
        }
        public static Course Find()
        {
            //Exception unhandled if object does not exist

            Console.Write("\nSelect a course from the list by typing the ID:");
            string courseID = Console.ReadLine();
            return Courses.Find(course => course.ID == courseID.ToUpper());
        }

        public override void Register()
        {
            //Method not needed.
        }

                public override string ToString()
        {
            return $"{ID}:  {Title}\n " +
                   $"         Stream   :     {Stream}    Type: {Type}\n" +
                   $"         Start Date: {StartDate.ToString("dd/MM/yyyy")}\n" +
                   $"         End Date  : {EndDate.ToString("dd/MM/yyyy")}\n";
        }




    }
}
