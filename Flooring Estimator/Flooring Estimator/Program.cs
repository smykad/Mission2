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
    // Date Revised:        9/19/2020
    // **************************************************************************************
    class Program
    {
        static void Main(string[] args)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\crowsnest.wav";
            player.PlayLooping();
            //
            // variables
            //

            string userName;
            string userResponse;
            string currentTimeOfDay;
            string floorTypeOne, floorTypeTwo;
            string rmO = "Room One";
            string rmT = "Room Two";

            int rmOne, rmTwo;
            int rmOneL, rmTwoL, rmOneW, rmTwoW;
            double costOne, costTwo;
            double rmOneCost, rmTwoCost;

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
                rmOneL = IsValidInt();
                Console.WriteLine(" What is the width of the room?");
                rmOneW = IsValidInt();

                Console.WriteLine();
                Console.WriteLine(" And now for your second room");
                Console.WriteLine("What is the length of the room?");
                rmTwoL = IsValidInt();
                Console.WriteLine(" What is the width of the room?");
                rmTwoW = IsValidInt();
                //
                // get what type of flooring user wants
                //
                Console.WriteLine();
                Console.ReadKey();

                CursorClear();
                Console.WriteLine();
                Console.WriteLine("         Type of Flooring");
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine(" What type of flooring would you like to install so I can determine the cost to install flooring");
                Console.WriteLine(" Hardwood    Vinyl   Stone");
                Console.Write("Enter floor type for room one: ");
                rmOneCost = FloorCost();
                Console.Write("Enter floor type for room two: ");
                rmTwoCost = FloorCost();

                if (rmOneCost == 10.30)
                {
                    floorTypeOne = "Stone Tile";
                }
                else if (rmOneCost == 2.00)
                {
                    floorTypeOne = "Vinyl";
                }
                else
                {
                    floorTypeOne = "Hardwood";
                }

                if (rmTwoCost == 10.30)
                {
                    floorTypeTwo = "Stone Tile";
                }
                else if (rmTwoCost == 2.00)
                {
                    floorTypeTwo = "Vinyl";
                }
                else
                {
                    floorTypeTwo = "Hardwood";
                }

                // do math stuff here
                rmOne = rmOneL * rmOneW;
                rmTwo = rmTwoL * rmTwoW;
                costOne = rmOneCost * rmOne;
                costTwo = rmTwoCost * rmTwo;

                CursorClear();

                Console.WriteLine();
                Console.WriteLine("                 Flooring Cost Table");
                Console.WriteLine();

                Console.WriteLine(String.Format("{0, 20} - {1, 20} - {2, 20} - {3, 20}", "Room", "Area", "Floor Type", "Cost"  ));
                Console.WriteLine(String.Format("{0, 20} - {1, 20} - {2, 20} - {3, 20}" , rmO, rmOne, floorTypeOne, costOne.ToString("C2")));
                Console.WriteLine(String.Format("{0, 20} - {1, 20} - {2, 20} - {3, 20}" , rmT, rmTwo, floorTypeTwo, costTwo.ToString("C2")));



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


        public static double FloorCost()
        {
            string floorType;
            bool validResponse;
            double floorCost;

            const double HARDWOOD_FLOOR = 7.80;
            const double VINYL_FLOOR = 2.00;
            const double STONE_TILE = 10.30;
            do
            {
                validResponse = true;
                floorType = Console.ReadLine().ToLower();
                if (floorType != "hardwood" && floorType != "vinyl" && floorType != "stone")
                {
                    validResponse = false;

                    Console.WriteLine();
                    Console.WriteLine(" I'm sorry, I am not familiar with the floor type {0}, please reenter a valid floor type.", floorType);
                    Console.Write(" Please enter a valid floor type: ");
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
            return floorCost;
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
