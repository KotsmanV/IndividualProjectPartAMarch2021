using IndividualProjectPartA;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndividualProjectPartA
{
    public class SyntheticData
    {
        private Random random = new Random();
        //DateTimes
        private DateTime startDateSemesterA = Controls.SetDate(new DateTime(2020, 9, 1));
        private DateTime startDateSemesterB = Controls.SetDate(new DateTime(2021, 3, 1));
        private DateTime endDateSemesterA = Controls.SetDate(new DateTime(2021, 2, 28));
        private DateTime endDateFull = Controls.SetDate(new DateTime(2021, 8, 31));

        //Courses
        private string[] Titles = { "Maths", "Physics", "Language", "History" };

        //Assignments
        private string[] AssignTitles = {"Assignment I", "Assignment II", "Final" };
        private string description = "Generic Assignment Description";

        //Persons
        private string[] firstNames = { "Maria", "Mohammed", "Wei", "Yan", "John",
                                        "Helen", "Christina", "David","Ahmed","Astridr",
                                        "Anna", "Luis","Fatima","Olga", "Richard",
                                        "Victor", "Sandra", "Ming", "Marina","Carmen",
                                        "Clarissa", "Melpomene","James","Camina","Amos",
                                        "Klaes", "Julie","Jules-Pierre","Fred","Arjun",
                                        "Elvi","Shed","Cotyar","Filip","Josephus",
                                        "Frodo","Sam","Merry","Pippin","Gandalf",
                                        "Aragorn","Legolas","Gimli","Boromir","Morgoth",
                                        "Melkor","Sauron","Ellaria","Gloin","Glorfindel",
                                        "Eowyn","Arwen","Balin","Celebrimbor","Denethor",
                                        "Elendil","Elrond","Galadriel","Hurin","Turin",
                                        "Nienor","Luthien","Saruman"};
        private string[] lastNames = {"Wang","Nagata","Holden","Burton","Kamal",
                                     "Dawes","Anderson","Avasarala","Inaros", "Mao",
                                     "Johnson","Miller","Wei","Volovodof","Shaddid",
                                     "Drummer","Ashford","Cortazar","Errinwright","Murtry",
                                     "Pereira","Ren","Skywalker","Lannister","Stark",
                                     "Baratheon","Martell","Targaryen","Arryn","Tyrell",
                                     "Tully","Greyjoy","Allgood","Allyrion","Amber",
                                     "Bolton","Blount","Bar Emmon","Celtigar","Velaryon",
                                     "Sunglass","Brune","Blackfyre","Slynt","Mormont","Cerwyn"
                                     };
        private DateTime SetBirthday()
        {

            int year = random.Next(1960, 2004);
            int month = random.Next(1, 13);
            int day = random.Next(1, 28);
            DateTime birthday = new DateTime(year, month, day);
            return birthday;
        }

        private void CreateStudents()
        {
            for (int i = 0; i < 100; i++)
            {
                Student student = new Student
                {
                    FirstName = firstNames[random.Next(0, firstNames.Length)],
                    LastName = lastNames[random.Next(0, lastNames.Length)],
                    DateOfBirth = SetBirthday(),
                    TuitionFees = 2500
                };
                int a= random.Next(0, Course.Courses.Count);
                int b = random.Next(0, Course.Courses.Count);

                Course courseA = Course.Courses[a];
                Course courseB = Course.Courses[b];
                courseA.Participants.Add(student);
                student.Courses.Add(courseA);
                int rnd = random.Next(0, 11);
                if (rnd>=6)
                {
                    courseB.Participants.Add(student);
                    student.Courses.Add(courseB);
                }
                Student.Students.Add(student);
            }
        }
        private void CreateTrainers()
        {
            for (int i = 0; i < 16; i++)
            {
                Trainer trainer = new Trainer
                {
                    FirstName = firstNames[random.Next(0, firstNames.Length)],
                    LastName = lastNames[random.Next(0, lastNames.Length)],
                };
                Trainer.Trainers.Add(trainer);
                if (i<4)
                {
                    Course.Courses[0].CurrentTrainers.Add(trainer);
                    Course.Courses[1].CurrentTrainers.Add(trainer);
                    Course.Courses[2].CurrentTrainers.Add(trainer);
                    trainer.Subject = "Maths";
                }
                else if (i>=4&&i<8)
                {
                    Course.Courses[3].CurrentTrainers.Add(trainer);
                    Course.Courses[4].CurrentTrainers.Add(trainer);
                    Course.Courses[5].CurrentTrainers.Add(trainer);
                    trainer.Subject = "Physics";
                }
                else if (i >= 8 && i < 12)
                {
                    Course.Courses[6].CurrentTrainers.Add(trainer);
                    Course.Courses[7].CurrentTrainers.Add(trainer);
                    Course.Courses[8].CurrentTrainers.Add(trainer);
                    trainer.Subject = "Language";
                }
                else
                {
                    Course.Courses[9].CurrentTrainers.Add(trainer);
                    Course.Courses[10].CurrentTrainers.Add(trainer);
                    Course.Courses[11].CurrentTrainers.Add(trainer);
                    trainer.Subject = "History";
                }
            }
        }
        private void CreateCourses()
        {
            for (int i = 0; i < Titles.Length; i++)
            {
                Course course1 = new Course
                {
                    Title = Titles[i],
                    Type = "Yearly",
                    StartDate = startDateSemesterA,
                    EndDate = endDateFull
                };
                Course course2 = new Course
                {
                    Title = Titles[i],
                    Type = "SemesterA",
                    StartDate = startDateSemesterA,
                    EndDate = endDateSemesterA
                };
                Course course3 = new Course
                {
                    Title = Titles[i],
                    Type = "SemesterB",
                    StartDate = startDateSemesterB,
                    EndDate = endDateFull
                };
                if (i==(0|1))
                {
                    course1.Stream = "Natural Sciences";
                    course2.Stream = "Natural Sciences";
                    course3.Stream = "Natural Sciences";
                }
                else
                {
                    course1.Stream = "Humanities";
                    course2.Stream = "Humanities";
                    course3.Stream = "Humanities";
                }
                Course.Courses.Add(course1);
                Course.Courses.Add(course2);
                Course.Courses.Add(course3);
            }
        }
        private void CreateAssignments()
        {
            for (int i = 0; i < Course.Courses.Count; i++)
            {
                for (int j = 0; j < AssignTitles.Length; j++)
                {
                    Assignment assignment = new Assignment
                    {
                        Title = AssignTitles[j],
                        Description = description
                    };
                    Assignment.Assignments.Add(assignment);
                    Course.Courses[i].CurrentAssignments.Add(assignment);
                    assignment.Title = $"{Course.Courses[i].Title}: {assignment.Title}";
                    foreach (Student student in Course.Courses[i].Participants)
                    {
                        student.IndividualAssignments.Add(assignment);
                    }
                    
                    if (j == 0)
                        assignment.SubDateTime = Course.Courses[i].StartDate.AddMonths(2);
                    else if (j == 1)
                        assignment.SubDateTime = Course.Courses[i].StartDate.AddMonths(4);
                    else
                        assignment.SubDateTime = Course.Courses[i].EndDate;
                }
            }
        }
        
        public SyntheticData()
        {
            CreateCourses();
            CreateTrainers();
            CreateStudents();
            CreateAssignments();
        }

    }
}
