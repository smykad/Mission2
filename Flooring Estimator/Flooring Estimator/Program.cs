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

            const double HARDWOOD_FLOOR = 7.80;
            const double VINYL_FLOOR = 2.00;
            const double STONE_TILE = 10.30;


            //
            // variables
            //

            string userName;
            string userResponse;
            string currentTimeOfDay;
            string floorType;
            
            int roomOne, roomTwo;
            int roomOneLength, roomTwoLength, roomOneWidth, roomTwoWidth;
            double costOne, costTwo;
            double floorCost;
            double roomOneDouble, roomTwoDouble;

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
            // call in method to determine greeting time of day
            //
            currentTimeOfDay = TimeOfDay();
            //
            // greet the user and ask for their name
            //
            Console.WriteLine();
            Console.Write("     Good " + currentTimeOfDay + ", what is your name?  ");
            userName = Console.ReadLine();
            //
            // clears the screen, sets cursor invisible
            //
            CursorClear();
            //
            // echos user name and asks for input
            //
            Console.WriteLine();
            Console.Write(" {0}, are you interested in flooring two rooms in your home or business?", userName);
            userResponse = Console.ReadLine().ToLower();
            if (userResponse == "yes" || userResponse == "y")
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
                Console.WriteLine();
                Console.WriteLine("         Floor Information");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(" I am here to assist you");
                Console.WriteLine();
                Console.WriteLine(" I will need some information about the rooms you would like to get flooring installed");
                //
                // get size of users rooms using area method
                //
                Console.WriteLine();
                Console.WriteLine(" Let's start with your first room");
                Console.WriteLine("What is the length of the room?");
                roomOneLength = IsValidInt();
                Console.WriteLine(" What is the width of the room?");
                roomOneWidth = IsValidInt();
                roomOne = roomOneLength * roomOneWidth;
                Console.WriteLine();
                Console.WriteLine(" And now for your second room");
                Console.WriteLine("What is the length of the room?");
                roomTwoLength = IsValidInt();
                Console.WriteLine(" What is the width of the room?");
                roomTwoWidth = IsValidInt();
                roomTwo = roomTwoLength * roomTwoWidth;
                

                // echo back suqare footage
                Console.WriteLine(" Room one is {0} sq ft and room two is {1} sq ft", roomOne, roomTwo);
                //
                // get what type of flooring user wants
                //
                Console.WriteLine();
                Console.ReadKey();
                do
                {
                    validResponse = true;
                    CursorClear();
                    Console.WriteLine();
                    Console.WriteLine("         Type of Flooring");
                    Console.WriteLine();

                    Console.WriteLine();
                    Console.WriteLine(" What type of flooring would you like to install so I can determine the cost to install flooring");
                    Console.WriteLine(" Hardwood    Vinyl   Stone");
                    Console.Write("Enter floor type:");
                    floorType = Console.ReadLine().ToLower();

                    if (floorType != "hardwood" && floorType != "vinyl" && floorType != "stone")
                    {
                        validResponse = false;

                        Console.WriteLine();
                        Console.WriteLine(" I'm sorry, I am not familiar with the floor type {0}, please reenter a valid floor type.");

                        Console.ReadKey();
                        Console.WriteLine(" Press any key to continue.");
                    }



                } while (!validResponse);

                switch (floorType)
                {
                    case "hardwood":
                        floorCost = HARDWOOD_FLOOR;
                        break;
                    case "vinyl":
                        floorCost = VINYL_FLOOR;
                        break;
                    case "stone":
                        floorCost = STONE_TILE;
                        break;
                    default:
                        floorCost = 0;
                        break;
                }
                if (floorCost != 0.0)
                {
                    roomOneDouble = Convert.ToDouble(roomOne);
                    costOne = roomOneDouble * floorCost;
                    roomTwoDouble = Convert.ToDouble(roomTwo);
                    costTwo = roomTwoDouble * floorCost;
                    Console.WriteLine("The cost of room one is {0} and the cost of room 2 is {1}", costOne, costTwo);
                }

            }
            else
            {
                currentTimeOfDay = TimeOfDay();
                Console.WriteLine("Sorry you are not interested in installing a new floor {0}, have a nice {1}", userName, currentTimeOfDay);
                Console.ReadKey();
            }

        }
        // method to validate if a users input is an integer
        public static int IsValidInt()
        {
            bool IsValidInt = false;
            int validInt = 0;
            while (!IsValidInt)
            {
                IsValidInt = int.TryParse(Console.ReadLine(), out validInt);
                if (!IsValidInt)
                {
                    Console.WriteLine("Sorry, that is not a valid number, please try again");
                    IsValidInt = false;
                }
            }
            return validInt;
        }

        //
        // method to determine if its morning, afternoon, evening or night time for user
        //
        public static string TimeOfDay()
        {
            DateTime currentTime = DateTime.Now;
            string currentTimeOfDay;

            if (currentTime.Hour < 12 && currentTime.Hour >= 5)
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
