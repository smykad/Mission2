using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Media;

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
            string currentTimeOfDay;

            double width, length;   // is it proper to place these here?
            double cost;            // can I convert it to (C) here? 

            bool validResponse;

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
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "C:\\Users\\dougs\\Music\\Yoho\\crowsnest.wav";
            player.Play();

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
            currentTimeOfDay = timeOfDay();

            Console.WriteLine();
            Console.WriteLine("     Good " + currentTimeOfDay + " floor enthusiast!");
            Console.WriteLine();
            Console.WriteLine("     This application will help you calculate the cost of flooring up to two rooms!");

            //
            // get users name
            //

            Console.WriteLine();
            Console.Write("     What is your name?  ");
            userName = Console.ReadLine();

            // clears the screen, sets cursor invisible
            // echo users name back to them
            CursorClear();
            Console.WriteLine();
            Console.Write("     Why hello there, {0}, would you like to put some new flooring?", userName);
            userResponse = Console.ReadLine().ToLower();
            if (userResponse == "yes" || userResponse == "y")
            {   validResponse = true;
                while (validResponse is true)
                {
                    //
                    //          *************************
                    //          *   User Input Screen   *
                    //          *************************
                    //
                    // set cursor invisible and clear screen
                    CursorClear();

                    //
                    // display header
                    //
                }
            }
            else
            {

            }

        }

        //
        // method to determine if its morning, afternoon, evening or night time for user
        //
        public static string timeOfDay()
        {
            DateTime currentTime = DateTime.Now;
            string currentTimeOfDay;

            if (currentTime.Hour< 12 && currentTime.Hour >= 5)
            {
                currentTimeOfDay = "morning";
            }
            else if (currentTime.Hour >= 12)
            {
                currentTimeOfDay = "afternoon";
            }
            else if (currentTime.Hour >= 16)
            {
                currentTimeOfDay = "evening";
            }
            else
            {
                currentTimeOfDay = "night";
            }
            return currentTimeOfDay;
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
