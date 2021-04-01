using IndividualProjectPartA_March2021_.Interfaces;
using IndividualProjectPartA_March2021_.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndividualProjectPartA
{
    public class Assignment :Controls, IID, IEducationalElements
    {
        private static int idSetter;
        private string title;
        private string description;
        private DateTime subDateTime;
        private float oralMark;
        private float totalMark;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public DateTime SubDateTime
        {
            get { return subDateTime; }
            set { subDateTime = value; }
        }
        public float OralMark
        {
            get { return oralMark; }
            set { oralMark = value; }
        }
        public float TotalMark
        {
            get { return totalMark; }
            set { totalMark = value; }
        }

        public static List<Assignment> Assignments = new List<Assignment>();

        public Assignment()
        {
            idSetter++;
            ID = "AS" + idSetter.ToString();
        }
        public Assignment(string fullConstructor)
        {
            Console.Clear();
            Console.WriteLine("-----New Assignment-----");
            idSetter++;
            ID = "AS" + idSetter.ToString();
            
            Console.Write("Title: ");
            Title = Console.ReadLine();
            
            Console.Write("Description: ");
            Description = Console.ReadLine();
            
            Console.Write("Submission Date: (dd/mm/yyyy)");
            SubDateTime = SetDate(DateTime.Parse(Console.ReadLine()));

            Console.WriteLine("Oral and Total marks to be implemented for each student if needed");
            Console.Write("Oral mark: ");
            Console.Write("Total mark: ");

            Assignments.Add(this);
            
        }
        public override bool SecondaryMenu()
        {
            Console.Clear();
            Console.WriteLine("-----Assignments-----");
            Console.WriteLine("1. Create new assignment.\n" +
                              "2. Display assignments.\n" +
                              "3. Display due assignments by date\n" +
                              "4. Previous menu\n");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Go to courses to add a new assignment in the Modify Section.");
                    Console.ReadKey();
                    return true;
                case "2":
                    GenericListDisplay(Assignments.Cast<Controls>().ToList());
                    Console.ReadKey();
                    return true;
                case "3":
                    DueAssignments();
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }

        private void DueAssignments()
        {
            Console.WriteLine("Input date (dd/mm/yyyy):");
            DateTime input = CheckDates(DateTime.Parse(Console.ReadLine()));
            List<Controls> DueAssignments = new List<Controls>();
            DateTime search = input;
            for (int i = 1; i <= 5; i++)
            {
                foreach (Assignment assignment in Assignments)
                {
                    if (assignment.SubDateTime == search)
                        DueAssignments.Add(assignment);
                }
                search = search.AddDays(1);
            }

            Console.WriteLine($"Due assignments for week {input.ToString("dd/MM/yyyy")} to {search.AddDays(4).ToString("dd/MM/yyyy")} are:");
            if (DueAssignments.Count!=0)
            {
                GenericListDisplay(DueAssignments);
            }
            else
                Console.WriteLine("----- No due assignments at this date. -----");
            Console.ReadKey();
        }

        public override void Register()
        {
            Console.WriteLine("Do you want to match the assignment to a Course? Y/N");
            string input = Console.ReadLine();
            if (input.ToLower().Equals("y"))
            {

                Console.WriteLine("Select a course:");
            }
        }


        public override string ToString()
        {
            return $"{ID}. {Title} \n" +
                   $"      {Description}\n" +
                   $"      Due Submission: {SubDateTime.ToString("dd/MM/yyyy")}";
        }
    }
}
