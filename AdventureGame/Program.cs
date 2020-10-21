/*
 * Adventure game   
 * Jacob Henriksen. Date:29/01-2020
 *  
 * This work is a derivative of 
 * "C# Adventure Game" by http://programmingisfun.com, used under CC BY.
 * https://creativecommons.org/licenses/by/4.0/
 */

using System;

namespace Adventure
{
    public static class Game
    {
        //Character stuff
        static string CharacterName;
        static int Char_HP_Current = 30;
        static int Char_HP_Full = 100;
        static int Char_EXP_Current = 5;
        static double Char_EXP_Full = 100;
        static int Char_Level_Current = 1;
        
        static int Char_Move_Left_Right = 10;
        static int Char_Move_Up_Down = 10;
        static int Char_Attack = 10;

        //Do command og Rest
        static int Game_Running = 0;
        static int Resting_Time;

        //Command til at vælge menu og path:
        static string Current_Command;

        //Array til Inventory
        static String[,] Inventory = new string[9, 19];

        //Header mm. 
        static void SkrivHeader()
        {
            static void VandretLinje()
            {
                Console.WriteLine("________________________________________________________________________________________________________________________");
            }

            Console.SetCursorPosition(0, 0);
            VandretLinje();
            Console.SetCursorPosition(3, 1);
            Console.WriteLine("Name: {0}", CharacterName);
            Console.SetCursorPosition(35, 1);
            Console.WriteLine("HP: {0}/{1}", Char_HP_Current, Char_HP_Full);
            Console.SetCursorPosition(70, 1);
            Console.WriteLine("Level: {0}", Char_Level_Current);
            Console.SetCursorPosition(95, 1);
            Console.WriteLine("EXP: {0}/{1}", Char_EXP_Current, Char_EXP_Full);
            VandretLinje();
            //GameScreen:
            for (int a = 3; a <= 26; a++)
            {
                Console.SetCursorPosition(0, a);
                Console.Write("|");
                Console.SetCursorPosition(119, a);
                Console.Write("|");
            }
            Console.SetCursorPosition(0, 26);
            VandretLinje();

        }

        //Game strings
        public static void StartGame()
        {
            SkrivHeader();

            //Welcome text
            Console.SetCursorPosition(2, 4);
            Console.WriteLine("Stupid things happens when you need money..");
            Console.SetCursorPosition(2, 5);
            Console.WriteLine($"For one reason or another you have been hired by the mercenary band The Iron Daggers. A meeting is afoot as you step    into the room. Three men standig around a round table talking about something.");
            Console.ReadKey();

            Console.SetCursorPosition(2, 8);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("I tell you the best path is over the mountain");
            Console.ResetColor();
            Console.SetCursorPosition(2, 9);
            Console.WriteLine($"The young man stands in fine clothes, red and fine decorated, he speaks with a harsh tone. He leans over the table,     on the right side and looks firmely on a man opposite of him");
            Console.ReadKey();

            Console.SetCursorPosition(2, 12);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("No Rooster, the mines are the safest, long abandoned and quicker");
            Console.ResetColor();
            Console.SetCursorPosition(2, 13);
            Console.WriteLine($"The other man stands in dark ragged clothes, big scraps of leather is patched on. They then turn to the last man at     the table.");
            Console.ReadKey();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(2, 16);
            Console.WriteLine("Before we settle this, let's welcome our guest");
            Console.ResetColor();
            Console.SetCursorPosition(2, 17);
            Console.WriteLine($"The man stands a bit shorter than the two other men, with his arms crossed. He wears a grey vest with a hood, black     tunic and black trousers");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(2, 20);
            Console.WriteLine("I understand you are our hired help. What is your name?");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();

            NameCharacter();

        }

        public static void EndGame()
        {

            //end of game text
            Console.WriteLine("End of story text here.....");
            Console.WriteLine("Congratulations " + CharacterName + "!");


        }

        public static void Choice()
        {
            Console.Clear();
            SkrivHeader();

            Console.SetCursorPosition(2, 4);
            Console.WriteLine("A moment's pause as you walk over to the table. A map is on the table, it looks a bit worn and maybe outdated.");
            Console.ReadKey();
            Console.SetCursorPosition(2, 6);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"You’ve arrived at an interesting time {CharacterName}, Rooster and Roland here were just discussing what route is the best for    us to take, we need to go to Cromstone. What are your thoughts? You probably have more local knowledge than us.");
            Console.SetCursorPosition(2, 8);
            Console.WriteLine($"Before you answer {CharacterName}, We will let you look around");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();

            do
            {
                SkrivHeader();
                Console.SetCursorPosition(1, 25);
                Console.WriteLine("Available options: Location, Inventory, Sleep, Ready");
                Console.SetCursorPosition(1, 27);

                for (int a = 0; a < 19; a++)
                {
                    for (int b = 0; b < 9; b++)
                    {
                        Inventory[b, a] = "Empty";
                    }
                }
                Current_Command = Console.ReadLine().ToUpper();
                if (Current_Command == "INVENTORY" || Current_Command == "INV")
                {
                    Console.Clear();
                    //GUI & Stats:
                    SkrivHeader();

                    for (int a = 0; a < 19; a++)
                    {
                        for (int b = 0; b < 9; b++)
                        {
                            if (b <= 9)
                            {
                                Console.SetCursorPosition(b * 7 + 3, 5 + a);
                                Console.Write("{0}", Inventory[b, a]);
                            }
                            else { }
                        }
                    }
                    Console.SetCursorPosition(2, 25);
                    Console.WriteLine("< Back");
                    Console.SetCursorPosition(1, 29);
                }
                else { }
                if (Current_Command == "BACK" || Current_Command == "<")
                {
                    Console.Clear();
                }
                else { }
                if (Current_Command == "SLEEP" || Current_Command == "NAP" || Current_Command == "REST")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 - 3);
                        Console.WriteLine("How many hours are you resting?");
                        Console.SetCursorPosition(Console.WindowWidth / 2 + 3, Console.WindowHeight / 2);
                        Console.WriteLine("hours?");
                        Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                        if (int.TryParse(Console.ReadLine(), out int n))
                        {
                            Resting_Time = n;
                            break;
                        }
                    }

                    Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 2, Console.WindowHeight / 2 - 3);
                    Console.WriteLine("Resting");
                    Resting_Time = (Resting_Time * 1) * 1000;
                    System.Threading.Thread.Sleep(Resting_Time);
                    Console.Clear();
                    Console.WriteLine("Done Resting");
                    Console.SetCursorPosition(2, 25);
                    Console.WriteLine("< Back");
                    Console.SetCursorPosition(1, 29);
                    Char_HP_Current = Char_HP_Current + Resting_Time / 200;

                }
                else { }
                if (Current_Command == "LOCATION" || Current_Command == "DES" || Current_Command == "DESCRIPTION")
                {
                    Console.Clear();
                    Console.SetCursorPosition(2, 3);
                    Console.WriteLine($"You are in a big but simple room with 5 make shift beds, a table in the middle with a map. \n A candle light is the only lightsource");
                    Console.SetCursorPosition(1, 27);
                }
                else { }
                if (Current_Command == "READY" || Current_Command == "GO" || Current_Command == "DECIDE")
                {
                    Console.Clear();
                    Console.SetCursorPosition(2, 4);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine($"Are you ready {CharacterName}? What do you think, the mine or the mountain?");
                    Console.ResetColor();
                    Console.SetCursorPosition(2, 8);
                    Console.WriteLine($"*END FOR NOW*");
                }
                else { }

            } while (Game_Running == 0);

        }

        public static void NameCharacter()
        {
            
            if (Char_EXP_Current >= Char_EXP_Full)
            {
                Char_EXP_Current = Convert.ToInt32(Char_EXP_Current - Char_EXP_Full);
                Char_Level_Current++;
                Char_EXP_Full = Char_EXP_Full * 1.20;
            }
            //Count HP
            if (Char_HP_Current > Char_HP_Full)
            {
                Char_HP_Current = Char_HP_Full;
            }

            //GUI & Stats:
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            SkrivHeader();
                               
            //Dialog for scene
            Console.SetCursorPosition(2, 4);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("You reply.. ");
            Console.ResetColor();

            CharacterName = Console.ReadLine();
            if (CharacterName == "")
            {
                Console.SetCursorPosition(2, 6);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("The Silent type are you? I am sorry but we need a name.");
                Console.ResetColor();
                Console.ReadKey();
                NameCharacter();
            }
            else
            {
                Console.ResetColor();
                Console.SetCursorPosition(2, 4);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"Good to meet you {CharacterName}. I am Raven and this is Rooster and Rooland. \n\n");
                Console.ResetColor();
                Console.ReadKey();
                Choice();
            }
                                                        
        }

        public static void GameTitle()
        {
            string Title = @" The Dark Bird's Fall";
            Console.Title = Title;

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("________________________________________________________________________________________________________________________");
            Console.SetCursorPosition(0, 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Title);
            Console.ResetColor();

            Console.WriteLine("________________________________________________________________________________________________________________________");
            Console.SetCursorPosition(0, 2);

            Console.SetCursorPosition(0, 3);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" At the tip of the Dagger");
            Console.ResetColor();

            Console.SetCursorPosition(0, 26);
            Console.WriteLine("________________________________________________________________________________________________________________________");

            for (int a = 3; a <= 26; a++)
            {
                Console.SetCursorPosition(0, a);
                Console.Write("|");
                Console.SetCursorPosition(119, a);
                Console.Write("|");
            }
            Console.SetCursorPosition(0, 26);
            Console.WriteLine("________________________________________________________________________________________________________________________");

            Console.ResetColor();
            Console.WriteLine("\n Press enter to start");
            Console.ReadKey();
            Console.Clear();
            GUI();

        }

        //Interfaces og controls
        public static void GUI() 
        {

            if (Char_EXP_Current >= Char_EXP_Full)
            {
                Char_EXP_Current = Convert.ToInt32(Char_EXP_Current - Char_EXP_Full);
                Char_Level_Current++;
                Char_EXP_Full = Char_EXP_Full * 1.20;
            }
            //Count HP
            if (Char_HP_Current > Char_HP_Full)
            {
                Char_HP_Current = Char_HP_Full;
            }

            do
            {
                //GUI & Stats:
                SkrivHeader();

                //Welcome text
                Console.SetCursorPosition(1, 25);
                Console.WriteLine(" Welcome to the adventure, write 'Start' to begin.");
                Console.SetCursorPosition(0, 27);

                //Command Options Defualt: 

                for (int a = 0; a < 18; a++)
                {
                    for (int b = 0; b < 9; b++)
                    {
                        Inventory[b, a] = "abc";
                    }
                }
                Current_Command = Console.ReadLine().ToUpper();
                if (Current_Command == "INVENTORY" || Current_Command == "INV")
                {
                    Console.Clear();
                    //GUI & Stats:
                    SkrivHeader();

                    for (int a = 0; a < 19; a++)
                    {
                        for (int b = 0; b < 9; b++)
                        {
                            if (b <= 9)
                            {
                                Console.SetCursorPosition(b * 7 + 3, 5 + a);
                                Console.Write("{0}", Inventory[b, a]);
                            }
                            else { }
                        }
                    }
                    Console.SetCursorPosition(2, 25);
                    Console.WriteLine("< Back");
                    Console.SetCursorPosition(1, 29);
                }
                else { }
                if (Current_Command == "BACK" || Current_Command == "<")
                {
                    Console.Clear();
                }
                else { }
                if (Current_Command == "SLEEP" || Current_Command == "NAP" || Current_Command == "REST")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 - 3);
                        Console.WriteLine("How many hours are you resting?");
                        Console.SetCursorPosition(Console.WindowWidth / 2 + 3, Console.WindowHeight / 2);
                        Console.WriteLine("hours?");
                        Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                        if (int.TryParse(Console.ReadLine(), out int n))
                        {
                            Resting_Time = n;
                            break;
                        }
                    }

                    Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 2, Console.WindowHeight / 2 - 3);
                    Console.WriteLine("Resting");
                    Resting_Time = (Resting_Time * 1) * 1000;
                    System.Threading.Thread.Sleep(Resting_Time);
                    Console.Clear();
                    Console.WriteLine("Done Resting");
                    Console.SetCursorPosition(2, 25);
                    Console.WriteLine("< Back");
                    Console.SetCursorPosition(1, 29);
                    Char_HP_Current = Char_HP_Current + Resting_Time / 200;

                }
                else { }
                if (Current_Command == "START" || Current_Command == "BEGIN")
                {
                    Console.Clear();
                    StartGame();
                }
                else { }

            } while (Game_Running == 0);
                         
        }

        public static void Controls() 
        {
            //Player Controls
            ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow:
                    if (Char_Move_Left_Right < 118)
                    {
                        Char_Move_Left_Right++;
                        Console.SetCursorPosition(Char_Move_Left_Right, Char_Move_Up_Down);
                        Console.Write("X");
                        Console.SetCursorPosition(Char_Move_Left_Right - 1, Char_Move_Up_Down);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("X");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else { }
                    break;
                case ConsoleKey.LeftArrow:
                    if (Char_Move_Left_Right > 1)
                    {
                        Char_Move_Left_Right--;
                        Console.SetCursorPosition(Char_Move_Left_Right, Char_Move_Up_Down);
                        Console.Write("X");
                        Console.SetCursorPosition(Char_Move_Left_Right + 1, Char_Move_Up_Down);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("X");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else { }
                    break;
                case ConsoleKey.UpArrow:
                    if (Char_Move_Up_Down > 3)
                    {
                        Char_Move_Up_Down--;
                        Console.SetCursorPosition(Char_Move_Left_Right, Char_Move_Up_Down);
                        Console.Write("X");
                        Console.SetCursorPosition(Char_Move_Left_Right, Char_Move_Up_Down + 1);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("X");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else { }
                    break;
                case ConsoleKey.DownArrow:
                    if (Char_Move_Up_Down < 27)
                    {
                        Char_Move_Up_Down++;
                        Console.SetCursorPosition(Char_Move_Left_Right, Char_Move_Up_Down);
                        Console.Write("X");
                        Console.SetCursorPosition(Char_Move_Left_Right, Char_Move_Up_Down - 1);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("X");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else { }
                    break;
                case ConsoleKey.Spacebar:
                    Console.SetCursorPosition(Char_Move_Left_Right, Char_Move_Up_Down);
                    Console.Write("X");

                    System.Threading.Thread.Sleep(30);
                    Console.SetCursorPosition(Char_Move_Left_Right + 1, Char_Move_Up_Down);
                    Console.Write("-");
                    Console.SetCursorPosition(Char_Move_Left_Right + 1, Char_Move_Up_Down);
                    System.Threading.Thread.Sleep(50);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("-");
                    Console.ForegroundColor = ConsoleColor.White;

                    System.Threading.Thread.Sleep(30);
                    Console.SetCursorPosition(Char_Move_Left_Right, Char_Move_Up_Down - 1);
                    Console.Write("|");
                    Console.SetCursorPosition(Char_Move_Left_Right, Char_Move_Up_Down - 1);
                    System.Threading.Thread.Sleep(50);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("|");
                    Console.ForegroundColor = ConsoleColor.White;

                    System.Threading.Thread.Sleep(30);
                    Console.SetCursorPosition(Char_Move_Left_Right - 1, Char_Move_Up_Down);
                    Console.Write("-");
                    Console.SetCursorPosition(Char_Move_Left_Right - 1, Char_Move_Up_Down);
                    System.Threading.Thread.Sleep(50);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("-");
                    Console.ForegroundColor = ConsoleColor.White;

                    System.Threading.Thread.Sleep(30);
                    Console.SetCursorPosition(Char_Move_Left_Right, Char_Move_Up_Down + 1);
                    Console.Write("|");
                    Console.SetCursorPosition(Char_Move_Left_Right, Char_Move_Up_Down + 1);
                    System.Threading.Thread.Sleep(50);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("|");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }
    class Item
    {

    }
    class Program
    {
        static void Main()
        {
            Game.GameTitle();
            
           

        }
   
    }

}