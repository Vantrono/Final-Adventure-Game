using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Final_Game
{
    class Game
    {
        //<summary>
        // Most of these are self explanatory.
        // So I will explain the ints and bools
        //</summary>

        //<summary> 
        // Parameters
        //</summary>
        //<param name="SearchRome"> Used to indicate how many times searched in Rome. This one specifically needs 3 searches to get the fragment piece. </param>
        //<param name="SearchJapan"> Used to indicate how many times searched in Japan. This one needs 2 searches to get the fragment piece and necklace. </param>
        //<param name="SearchCanada"> Used to indicate how many times searched in Canada. This one doesn't matter except for the first time you search here. </param>
        //<param name="Fragments"> Used to indicate how many fragments you have. You need 3 to win. </param>
        //<param name="_isNecklace"> Used to indicate if you have the necklace or not. It was easier to make it a boolean because there was only going to be one. </param>
        //<param name="_isSideQuest"> Used to indicate if you completed the sidequest by giving the necklace to the lady. </param>

        public static string Input = "";
        public static bool Run = true;
        public static int Choice = 0;
        public string CurrentLocation = "";
        int SearchRome = 0;
        int SearchJapan = 0;
        int SearchCanada = 0;
        int Fragments = 0;
        bool _isNecklace = false;
        bool _isSideQuest = false;
       

        public Game()
        {
            Title = "Final Game";
            WriteLine("Welcome to SUPER AMAZING KINDA BORING ADVENTURE!");
            WriteLine("What is your name?");
            string PlayerName = ReadLine();
            Clear();

            WriteLine($"Welcome to the game! {PlayerName} ");
            WriteLine("You are a time traveling adventurer that is in search of three fragment pieces to open the door to the ruins!");
            CurrentLocation = "the Ruins";

            while (Run == true)
            {
               
                Menu();

            }

             void Menu()
            {
                List<string> Inventory = new List<string>();
                //<summary> These are the two main choices that you make. Choice is used for the menu down below
                // TravelChoice is used for making the "CurrentLocation" variable to whichever you choose.
                //</summary>
                int Choice = 0;
                int TravelChoice = 0;

                
                // <remarks> MENU
                //</remarks>
                WriteLine("\n\n\n\n\n--------------------------------------------");
                WriteLine("Your current location is " + CurrentLocation);
                WriteLine("You have " + Fragments + " Ruin fragments");
                WriteLine(" 1) Travel   2) Search   3) Exit Game ");
                WriteLine("--------------------------------------------");

                Input = ReadLine();
                Choice = Convert.ToInt32(Input);
                // <summary>
                // TravelChoice is only if you enter in "1" as your inital "Choice".
                // </summary>
                if (Choice == 1)
                {
                    Clear();
                    WriteLine("Where do you want to time travel to?");
                    WriteLine("1) Japan     2) Rome    3) Canada     4) Ruins" );
               

                    Input = ReadLine();
                    TravelChoice = Convert.ToInt32(Input);
                    // <summary>
                    // Your travel choices change it to whichever you chose and then uses methods that are created down below for more choices.
                    // <summary>
                    if (TravelChoice == 1)
                    {
                        CurrentLocation = "in Japan";
                        Japan();
                        
                    }
                    else if (TravelChoice == 2)
                    {
                        CurrentLocation = "in Rome";
                        Rome();

                    }
                    else if (TravelChoice == 3)
                    {
                        CurrentLocation = "in Canada";
                        Canada();

                    }
                    else if (TravelChoice == 4)
                    {
                        CurrentLocation = "the Ruins";
                        Ruins();
                    }


                }
                // <summary>
                //  This part is when we use the "Search" Choice of our menu. 
                //  Basically if the "CurrentLocation" is in a specific spot lets say Japan then that means it would run the choices below.
                // </summary>
                else if (Choice == 2)
                {
                    if (CurrentLocation == "in Japan")
                    {
                        // <summary>
                        // Searching in Japan will add +1 to the int "SearchJapan" Once it reaches 1 or 2 you get items.
                        // First time you search in Japan you get a necklace. Second time is the Fragment piece. Afterwords it goes into a deadend.
                        // </summary>
                        SearchJapan++;
                        if (SearchJapan == 1)
                        {
                            Clear();
                            WriteLine("You find a necklace on the ground.");
                            WriteLine("Hmm looks valuable, finders keepers I guess!");
                            WriteLine("\nI wonder what else is around..");
                            _isNecklace = true;
                            

                        }
                        else if (SearchJapan == 2)
                        {
                            Clear();
                            WriteLine("Is that a fragment next to those flowers??");
                            WriteLine("This is way easier than expected!\n");
                            Fragments++;
                            WriteLine("Fragment piece acquired!");
                            
                        }
                        else if (SearchJapan > 2)
                        {
                            Clear();
                            WriteLine("Maybe after all this I go on vacation here.");
                        }


                    }
                    else if (CurrentLocation == "in Rome")
                    {
                        // <summary>
                        // Similar to the Japan one. Adds to the int "SearchRome" until it reaches 3 to get the fragment.
                        // </summary>
                        SearchRome++;
                        if (SearchRome == 3)
                        {
                            Clear();
                            WriteLine("Finally a fragment!\n");
                            Fragments++;
                            WriteLine("Fragment piece acquired!");
                        }

                        else if (SearchRome < 3)
                        {
                            Clear();
                            WriteLine("Nothing here.. Maybe I should keep searching around.");

                        }
                        else if (SearchRome > 3)
                        {
                            Clear();
                            WriteLine("I was hoping for a colosseum fight or something..");
                        }

                    }
                    // <summary>
                    // Canada is a little more complicated. 
                    // There are 5 different outcomes. The very first time you search in Canada, you get a different outcome depending if you have the necklace or not.
                    // It only does it once as the int "SearchCanada" is going to be equal to 1 onwards.
                    // After that point it depends on if you have the necklace or not. So if "_isNecklace" is true.
                    // After you give her the necklace "_isNecklace" is false and then "_isSideQuest" is true. This makes it so the next set of else if's turn on because "_isSideQuest" is true.
                    // </summary>
                    else if (CurrentLocation == "in Canada")
                    {
                        
                        if (SearchCanada == 0)
                        {
                            Clear();
                            WriteLine("An old lady approaches you.");
                            WriteLine("Old lady - Have you seen my necklace? I have been searching everywhere for it.");
                            if (_isNecklace == true)
                            {
                                WriteLine("\nMan I was looking forward to selling it.. I guess I should give it to her.");
                                SearchCanada++;
                            }
                            else
                            {
                                WriteLine("\nWhere would I even find one of those? We are in the middle of a forest..");
                                SearchCanada++;
                            }
                        }
                        else if(_isNecklace == true)
                        {
                            Clear();
                            WriteLine("You handed over the necklace..");
                            WriteLine("Old lady - Thank you " + PlayerName + "... Here have this fragment I found.");
                            WriteLine("\nHuh I don't remember telling me her name..");
                            WriteLine("You look around for her and she is no where to be found.");
                            Fragments++;
                            WriteLine("\n\nFragment piece acquired!");
                            _isNecklace = false;
                            _isSideQuest = true;
                        }
                        else if (_isSideQuest == true)
                        {
                            Clear();
                            WriteLine("I don't think theres anything else here.");
                        }
                        else if (_isNecklace == false)
                        {
                            Clear();
                            WriteLine("Maybe I should look elsewhere for a necklace..");

                        }
                        

                    }

                    // <summary>
                    // This is if you search in the Ruins. I made the fragments needing only 3 but if you acquire more; which is impossible but just in case it will still work.
                    // </summary>
                    else if (CurrentLocation == "the Ruins")
                    {
                        if (Fragments >= 3)
                        {
                            Clear();
                            EndSequence();
                        }

                        else if (Fragments < 3)
                        {
                            Clear();
                            WriteLine("I should look around for more fragments.");
                        }
                       
                    }

                }
                // Exit game
                else if (Choice == 3)
                {
                    WriteLine("\n Press any key to exit");
                    ReadKey(true);
                    Environment.Exit(0);
                }


            }

            // <summary>
            // More is to be added for these but for now they are barebones but using these methods now because I wanted to save room up earlier.
            // </summary>
         void Japan()
            {
                Clear();
                WriteLine("Ahhh a nice summer breeze hits your face.");
               
            }
        
        void Rome()
            {
                Clear();
                WriteLine("Man its hot here."); 
            }

        void Ruins()
            {
                Clear();
                WriteLine("Back to where we started.");

            }
        void Canada()
            {
                Clear();
                WriteLine("You land in a forest.. You hear someone nearby.");
            }
            
        void EndSequence()
            {
                WriteLine("Finally after hopefully 3-4 minutes you got all the pieces!");
                WriteLine("you put the fragments into the ruins door..");
                WriteLine("\nA bright flash blinds you briefly..");
                WriteLine("\nYou see something...");
                WriteLine("\n Press a key to continue");
                ReadKey(true);
                Clear();
                WriteLine("\nIt looks like an Adventure game program written in C# . . it's yours. ");
                WriteLine("\nYou look closer for the grade..  \n");
                WriteLine("\n Press a key to continue");
                ReadKey(true);
                Clear();
                WriteLine(@"                  
DDDDDDDDDDDDD
D::::::::::::DDD     
D:::::::::::::::DD   
DDD:::::DDDDD:::::D  
  D:::::D    D:::::D 
  D:::::D     D:::::D
  D:::::D     D:::::D
  D:::::D     D:::::D
  D:::::D     D:::::D
  D:::::D     D:::::D
  D:::::D     D:::::D
  D:::::D    D:::::D 
DDD:::::DDDDD:::::D  
D:::::::::::::::DD   
D::::::::::::DDD     
DDDDDDDDDDDDD        
                     
               ");
                WriteLine("WHAT? REALLY?? AFTER ALL THAT WORK??\n Maybe I shouldve done it in C+ . . . ");
                WriteLine("\n Press a key to continue");
                ReadKey(true);
                Clear();
                WriteLine("Thanks for playing!");
                WriteLine("I'm sorry I had to make a dumb joke for the ending.");
                WriteLine("Exit by hitting a key.");
                string key = ReadLine(); 
                if (key == "a")
                {
                    WriteLine("Ayeeeeee");
                    ReadKey(true);
                    Environment.Exit(0);
                }
                else
                {
                    Environment.Exit(0);
                }    
               
            }
        
        }

    }
}