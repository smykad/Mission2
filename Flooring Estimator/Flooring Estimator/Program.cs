﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Threading;

namespace Flooring_Estimator
{
    // **************************************************************************************
    // Title:               The Flooring Estimator 2020 edition
    // Application Type:    Console
    // Description:         This application that will have a conversation with the user
    //                      about flooring a room.
    // Date Created:        9/17/2020
    // Date Revised:        9/20/2020
    // **************************************************************************************
    class Program
    {
        static void Main(string[] args)
        {
            //
            // calling in the sound player to play music in the application
            //
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
            CursorClear();

            //
            // opening screen
            // use a for loop to change colors of the font
            // set the size of the window
            // set where the ASCII art will appear
            // sleep for 3 seconds
            //
            for (int i = 0; i < 17; i++)
            {
                Console.SetWindowSize(120, 28);
                Console.SetCursorPosition(0, 2);
                ConsoleColor[] colour = {ConsoleColor.Red,
                           ConsoleColor.White,
                           ConsoleColor.Yellow,
                           ConsoleColor.Magenta,
                           ConsoleColor.Blue,
                           ConsoleColor.DarkYellow,
                           ConsoleColor.Cyan,
                           ConsoleColor.Red,
                           ConsoleColor.DarkCyan,
                           ConsoleColor.DarkGreen,
                           ConsoleColor.DarkMagenta,
                           ConsoleColor.DarkRed,
                           ConsoleColor.DarkYellow,
                           ConsoleColor.Cyan,
                           ConsoleColor.Yellow,
                           ConsoleColor.White,
                           ConsoleColor.Green
                           };
                Console.ForegroundColor = colour[i];
                Console.Write(@"                                                                                                                                                              
                                                          _  .-')               .-') _             
                                                         ( \( -O )             ( OO ) )            
               ,------.,--.      .-'),-----.  .-'),-----. ,------.  ,-.-') ,--./ ,--,'  ,----.     
            ('-| _.---'|  |.-') ( OO'  .-.  '( OO'  .-.  '|   /`. ' |  |OO)|   \ |  |\ '  .-./-')  
            (OO|(_\    |  | OO )/   |  | |  |/   |  | |  ||  /  | | |  |  \|    \|  | )|  |_( O- ) 
            /  |  '--. |  |`-' |\_) |  |\|  |\_) |  |\|  ||  |_.' | |  |(_/|  .     |/ |  | .--, \ 
            \_)|  .--'(|  '---.'  \ |  | |  |  \ |  | |  ||  .  '.',|  |_.'|  |\    | (|  | '. (_/ 
              \|  |_)  |      |    `'  '-'  '   `'  '-'  '|  |\  \(_|  |   |  | \   |  |  '--'  |  
               `--'    `------'      `-----'      `-----' `--' '--' `--'   `--'  `--'   `------' 

               ('-.    .-')    .-') _          _   .-')      ('-.     .-') _                _  .-')   
             _(  OO)  ( OO ). (  OO) )        ( '.( OO )_   ( OO ).-.(  OO) )              ( \( -O )  
            (,------.(_)---\_)/     '._ ,-.-') ,--.   ,--.) / . --. //     '._  .-'),-----. ,------.  
             |  .---'/    _ | |'--...__)|  |OO)|   `.'   |  | \-.  \ |'--...__)( OO'  .-.  '|   /`. ' 
             |  |    \  :` `. '--.  .--'|  |  \|         |.-'-'  |  |'--.  .--'/   |  | |  ||  /  | | 
            (|  '--.  '..`''.)   |  |   |  |(_/|  |'.'|  | \| |_.'  |   |  |   \_) |  |\|  ||  |_.' | 
             |  .--' .-._)   \   |  |  ,|  |_.'|  |   |  |  |  .-.  |   |  |     \ |  | |  ||  .  '.' 
             |  `---.\       /   |  | (_|  |   |  |   |  |  |  | |  |   |  |      `'  '-'  '|  |\  \  
             `------' `-----'    `--'   `--'   `--'   `--'  `--' `--'   `--'        `-----' `--' '--'
            
");
                Thread.Sleep(300);
            }
            Console.WriteLine("                                         Press any key to continue.");
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
            Console.Write("                 Good " + currentTimeOfDay + ", what is your name?  ");
            userName = Console.ReadLine();
            //
            // echos user name and ask if they want to use the application
            //
            Console.WriteLine();
            Console.Write("                 {0}, are you interested in flooring two rooms in your home or business?  ", userName);
            userResponse = Console.ReadLine().ToLower();
            //
            // determines if user wants to use the application
            //
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
                Console.WriteLine("__________________________________________________________________________________________________");
                Console.WriteLine();
                Console.WriteLine("         I am here to assist you");
                Console.WriteLine();
                Console.WriteLine("         I will need some information about the rooms you would like to get flooring installed");
                //
                // get size of users rooms using area method
                //
                Console.WriteLine();
                Console.WriteLine("         I will need the dimensions first room");
                Console.Write("         Enter the length of the room:  ");
                rmOneL = IsValidInt();
                Console.Write("         Enter the width of the room:  ");
                rmOneW = IsValidInt();

                Console.WriteLine();
                Console.WriteLine("         Now I need the dimensions for your second room");
                Console.Write("         Enter the length of the room:  ");
                rmTwoL = IsValidInt();
                Console.Write("         Enter the width of the room:  ");
                rmTwoW = IsValidInt();

                Console.WriteLine();
                Console.ReadKey();
                //
                // clear console, set cursor invisible
                //
                CursorClear();
                //
                //          **********************
                //          *   input screen     *
                //          **********************
                //
                Console.WriteLine();
                Console.WriteLine("         Type of Flooring");
                Console.WriteLine("__________________________________________________________________________________________________");
                Console.WriteLine();
                //
                // here I ask the user what type of floor they want and set the cost per square foot by using the floor cost method I created
                //
                Console.WriteLine("         What type of flooring would you like to install so I can determine the cost to install flooring");
                Console.WriteLine("         Hardwood    Vinyl   Stone");
                Console.Write("         Enter floor type for room one: ");
                rmOneCost = FloorCost();
                Console.Write("         Enter floor type for room two: ");
                rmTwoCost = FloorCost();
                //
                // in these two blocks I set a variable to the users flooring types for the rooms using an if/else if/else block
                // this way I can display it at the end of the appication in a table
                //
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

                //
                // in this block I determine the area of the rooms and the cost of the rooms
                // 
                rmOne = rmOneL * rmOneW;
                rmTwo = rmTwoL * rmTwoW;
                costOne = rmOneCost * rmOne;
                costTwo = rmTwoCost * rmTwo;
                //
                // clear console, cursor invisible
                //
                CursorClear();
                //
                // display header
                //
                Console.WriteLine();
                Console.WriteLine("         Flooring Cost Table");
                Console.WriteLine("__________________________________________________________________________________________________");
                Console.WriteLine();
                //
                // display table of information for user
                //
                Console.WriteLine(String.Format("{0, 20}  {1, 20}  {2, 20}  {3, 20}", "Room", "Area", "Floor Type", "Cost"  ));
                Console.WriteLine(String.Format("{0, 20}  {1, 20}  {2, 20}  {3, 20}" , rmO, rmOne, floorTypeOne, costOne.ToString("C2")));
                Console.WriteLine(String.Format("{0, 20}  {1, 20}  {2, 20}  {3, 20}" , rmT, rmTwo, floorTypeTwo, costTwo.ToString("C2")));

                Console.WriteLine();
                Console.ReadKey();


            }
            //
            // if user did not want to use program then it will read this message to them and end the application
            //
            else
            {
                currentTimeOfDay = TimeOfDay();
                Console.WriteLine("         Sorry you are not interested in installing a new floor {0}, have a nice {1}", userName, currentTimeOfDay);
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
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
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
