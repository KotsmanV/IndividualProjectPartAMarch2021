using IndividualProjectPartA_March2021_.Interfaces;
using IndividualProjectPartA_March2021_.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndividualProjectPartA
{
    public class Trainer : Controls, IID, IPersons
    {
        private static int idSetter = 0;
        private string firstName;
        private string lastName;
        private string subject;

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
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public static List<Trainer> Trainers = new List<Trainer>();

        public Trainer()
        {
            idSetter++;
            ID = "TR" + idSetter.ToString();
        }
        public Trainer(string fullConstructor)
        {
            Console.Clear();
            Console.WriteLine("-----New Trainer-----");
            idSetter++;
            ID = "TR"+ idSetter.ToString();
            Console.Write("First name: ");
            
            FirstName = Console.ReadLine();
            Console.Write("Last name: ");
            LastName = Console.ReadLine();
            Console.Write("Subject: ");
            Subject = Console.ReadLine();

            Trainers.Add(this);

        }

        public override bool SecondaryMenu()
        {
            Console.Clear();
            Console.WriteLine("-----Trainers-----");
            Console.WriteLine("1. Register new Trainer\n" +
                              "2. Display Trainers\n" +
                              "3. Previous Menu\n");
            switch (Console.ReadLine())
            {
                case "1":
                    bool cntn;
                    do
                    {
                        Trainer trainer = new Trainer("myTrainer");
                        cntn = Continue();
                    } while (cntn);
                    return true;
                case "2":
                    if (Trainers.Count == 0)
                    {
                        Console.WriteLine("No entries yet");
                        Console.ReadKey();
                    }
                    else
                    {
                        GenericListDisplay(Trainers.Cast<Controls>().ToList());
                        Console.WriteLine("Do you want to register a trainer to a course? Y/N");
                        if (Console.ReadLine().ToUpper().Equals("Y"))
                        {
                            Register();
                        }
                    }

                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        } 

        public override void Register()
        {
            bool contnue;
            if(Trainers.Count==0||Course.Courses.Count==0)
            {
                Console.WriteLine("There are no trainers and/or courses available.");
            }
            else
            {
                do
                {
                    Trainer srchTrainer = Find();
                    Course temp;
                    GenericListDisplay(Course.Courses.Cast<Controls>().ToList());
                    temp = Course.Find();
                    temp.CurrentTrainers.Add(srchTrainer);
                    contnue = Continue();
                } while (contnue);

            }
            
        }
        private static Trainer Find()
        {
            Console.WriteLine("Select a trainer from the list by typing the ID");
            string trainerID = Console.ReadLine().ToUpper();
            return Trainers.Find(trainer => trainer.ID == trainerID);
        }
        public override string ToString()
        {
            return $"{ID}: {LastName}, {FirstName}, {Subject}";
        }
    }
}
