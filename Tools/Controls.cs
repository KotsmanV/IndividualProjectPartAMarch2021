using IndividualProjectPartA_March2021_.Interfaces;
using IndividualProjectPartA_March2021_.Tools;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace IndividualProjectPartA
{
    public abstract class Controls : IID
    {
        //public List<Controls> baseList = Course.Courses.Cast<Controls>().ToList();
        public static object cultureInfo = new CultureInfo("el-GR");

        public string ID { get; set; }

        //public abstract void DisplayList();
        public abstract void Register();
        public static bool Continue()
        {
            Console.WriteLine("Do you want to continue; Y/N");
            string input = Console.ReadLine();
            if (input.ToLower().Equals("y"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public abstract bool SecondaryMenu();


        public static void GenericListDisplay(List<Controls>controls)
        {
                int counter = 0;
                foreach (var item in controls)
                {
                        counter++;
                        Console.WriteLine($"{counter}. {item}");
                }

        }
        public static DateTime SetDate(DateTime dt)
        {
            if (dt.DayOfWeek == DayOfWeek.Saturday)
                return dt.AddDays(2);
            else if (dt.DayOfWeek == DayOfWeek.Sunday)
                return dt.AddDays(1);
            else
                return dt;                
        }

        public static DateTime CheckDates(DateTime dt)
        {
            SetDate(dt);
            if (dt.DayOfWeek != DayOfWeek.Monday)
            {
                int currentDate = (int)dt.DayOfWeek-1;
                return dt.AddDays(-currentDate);
            }
            else
                return dt;
        }
    }
}
