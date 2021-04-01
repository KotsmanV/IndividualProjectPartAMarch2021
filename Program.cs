using System;
using System.Collections.Generic;
using System.Linq;

namespace IndividualProjectPartA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n-----!!!!!WARNING!!!!!-----\n\n");
            Console.WriteLine("The program does not handle exceptions, \nsearch and date inputs should be exact, \notherwise program will fail.");
            Console.ReadLine();
            Console.Clear();
            
            SyntheticData sampleData = new SyntheticData();
            MainMenu myMenu = new MainMenu();
            bool showmenu = true;
            while (showmenu)
            {
                showmenu = myMenu.ShowMainMenu();
            }



        }
    }
}
