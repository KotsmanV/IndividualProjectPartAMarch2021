using IndividualProjectPartA;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndividualProjectPartA_March2021_
{
    public class Controls
    {

        public static IList<Course> Courses = new List<Course>();
        public static IList<Trainer> Trainers = new List<Trainer>();
        public static IList<Student> Students = new List<Student>();
        public static IList<Assignment> Assignments = new List<Assignment>();

        public static List<object> Lists = new List<object> { Courses, Trainers, Students, Assignments };



        public bool ViewMenu()
        {
            Console.Clear();
            Console.WriteLine("-----View Data-----");
            Console.WriteLine("1.Courses\n" +
                              "2.Trainers\n" +
                              "3.Students\n" +
                              "4.Assignments\n" +
                              "5.Previous Menu\n");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("-----Courses-----");
                    DisplayList((IList<object>)Courses);
                    Console.ReadKey();
                    return true;
                case "2":
                    Console.Clear();
                    Console.WriteLine("-----Trainers-----");
                    return true;
                case "3":
                    Console.Clear();
                    Console.WriteLine("-----Students-----");
                    return true;
                case "4":
                    Console.Clear();
                    Console.WriteLine("-----Assignments-----");
                    return true;
                case "5":
                    return false;
                default:
                    return true;
            }
        }

        public void DisplayList(IList<object> list)
        {
            foreach (var item in list)
            {
                if (list.Count == 0)
                    Console.WriteLine("No entries yet.");
                else
                {
                    int counter = 0;
                    Console.WriteLine($"{++counter}. {item.ToString()}");
                }
            }
        }

    }
}
