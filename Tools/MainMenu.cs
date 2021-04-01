using System;
using System.Collections.Generic;
using System.Text;

namespace IndividualProjectPartA
{
    public class MainMenu
    {
        public bool ShowMainMenu()
        {
            Controls controls;
            bool subMenu = true;
            
            Console.Clear();
            Console.WriteLine("-----Private School Secretary v1----\n");
            Console.WriteLine("Pick an option from the menu below\n");
            Console.WriteLine("1. Courses\n" +
                              "2. Trainers\n" +
                              "3. Students\n" +
                              "4. Assignments\n" +
                              "5. Exit\n");

            switch (Console.ReadLine())
            {
                case "1":
                    controls = new Course();
                    while (subMenu)
                    {
                        subMenu = controls.SecondaryMenu();
                    }
                    return true;
                case "2":
                    controls = new Trainer();
                    while (subMenu)
                    {
                        subMenu = controls.SecondaryMenu();
                    }
                    return true;
                case "3":
                    controls = new Student();
                    while (subMenu)
                    {
                        subMenu = controls.SecondaryMenu();
                    }
                    return true;
                case "4":
                    controls = new Assignment();
                    while (subMenu)
                    {
                        subMenu = controls.SecondaryMenu();
                    }
                    return true;
                case "5":
                    return false;
                default:
                    return true;
            }
        }
    }
}
