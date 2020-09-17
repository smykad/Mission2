using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Flooring_Estimator
{
    // **************************************************************************************
    // Title:               The Flooring Estimator 2020 edition
    // Application Type:    Console
    // Description:         This application that will have a conversation with the user
    //                      about flooring a room.
    // Date Created:        9/17/2020
    // Date Revised:        9/17/2020
    // **************************************************************************************
    class Program
    {
        static void Main(string[] args)
        {
            //
            // constants
            //

            //
            // variables
            //

            string userName;
            string userResponse;
            string currentTimeofDay;

            double width, length;   // is it proper to place these here?
            double cost;            // can I convert it to (C) here? 


            //
            // determine if its morning, afternoon, evening or night time for user
            //

            DateTime currentTime = DateTime.Now;

            if (currentTime.Hour < 12 && currentTime.Hour >= 5)
            {
                currentTimeofDay = "morning";
            }
            else if (currentTime.Hour >= 12)
            {
                currentTimeofDay = "afternoon";
            }
            else if (currentTime.Hour >= 16)
            {
                currentTimeofDay = "evening";
            }
            else
            {
                currentTimeofDay = "god it's late";
            }

            //
            //          *********************
            //          *   Opening Screen  *
            //          *********************
            //
            // call in the functions to set background colors, foreground colors,
            // set cursor invisible and clear screen
            //
            OpenScreen();
            CursorClear();

            //
            // opening screen
            //

            Console.WriteLine();
            Console.WriteLine("     The Floor Estimator 2020 edition");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Press any key to continue");
            Console.ReadKey();

            //
            //          *************************
            //          *   initialize screen   *
            //          *************************
            //
            // use functions to set background colors, foreground colors,
            // set cursor invisible and clear screen
            //

            AppScreen();
            CursorClear();

            //
            // greet user
            //

            Console.WriteLine();
            Console.WriteLine("     Good " + currentTimeofDay + " floor enthusiast!");
            Console.WriteLine();
            Console.WriteLine("     This application will help you calculate the cost of flooring up to two rooms!");

            //
            // get users name and echo it back
            //

            Console.WriteLine();
            Console.Write("     What is your name?  ");
            userName = Console.ReadLine();

            CursorClear();
            Console.WriteLine();
            Console.Write("     Why hello there, {0}, would you like to put some new flooring in two rooms?", userName);
        }

        // method to set background and foreground colors for opening screen
        public static void OpenScreen()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        // method to set background and foreground colors for application screen
        public static void AppScreen()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }

        // method to set background and foreground colors for application closing screen
        public static void CloseScreen()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
        }

        // method to set cursor invisible and clear screen
        public static void CursorClear()
        {
            Console.CursorVisible = false;
            Console.Clear();
        }
        
    }
}
