using System.Net.Security;
using System.Threading;

namespace fancy_text
{
    class Program
    {
        static int menuWidth = 80;
        static bool OneColor = false;
        static ConsoleColor[] multiColors = { ConsoleColor.Red };
        static bool LeftToRight = true;

        static void Main(string[] args)
        {
            Console.Title = "FTG - by newoutsider <3";
            //PlayIntro();
            DisplayMenu();
        }

        static void PlayIntro()
        {
            Console.Clear();
            int letterDelay = 10;
            int textDelay = 250;
            string introTitle = "Fancy Text Generator";
            string introAuthor = "Made by newoutsider <3";
            int introWidth = 50;
            string[] introDescription =
                               {"!------------------------------------------------!",
                                "!                     Note                       !",
                                "!------------------------------------------------!",
                                "! This program was made for a producer Ludvík.   !",
                                "! Feel free to check out his music on his        !",
                                "! soundcloud ( @plastic_heart03 ).               !",
                                "!                                                !",
                                "! To move between options use arrows and for     !",
                                "! selection press enter.                         !",
                                "! To continue press any key.                     !",
                                "!                                                !",
                                "!                                    Made by <3. !",
                                "!------------------------------------------------!"};

            //title
            Console.SetCursorPosition(GetCenterPos(introTitle), 0);
            for (int i = 0; i < introTitle.Length; i++)
            {
                Console.Write(introTitle[i]);
                Thread.Sleep(letterDelay);
            }
            Thread.Sleep(textDelay);

            //made by me ofc
            Console.SetCursorPosition(GetCenterPos(introAuthor), 1);
            for (int i = 0; i < introAuthor.Length; i++)
            {
                Console.Write(introAuthor[i]);
                Thread.Sleep(letterDelay);
            }
            Thread.Sleep(textDelay);

            //description
            int cursorTop = 3;
            foreach(string line in introDescription)
            {
                Console.SetCursorPosition(GetCenterPos(introDescription[0]), cursorTop);
                for (int i = 0; i < line.Length; i++)
                {
                    Console.Write(line[i]);
                    Thread.Sleep(letterDelay);
                }
                cursorTop++;
            }

            Console.ReadKey();
        }
        //menus
        static void DisplayMenu()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            int optionSelector = 0;
            string introTitle = "Fancy Text Generator";
            string introAuthor = "Made by newoutsider <3";

            string[] Options =
            {
                    "Change Color scheme",
                    "Change Direction",
                    "Change Delays",
                    "Change Background",
                    "Exit"
            };

            CenterText(introTitle);
            CenterText(introAuthor);

            while (true)
            {
                Console.SetCursorPosition(0, 3);
                CreateCenterLine(menuWidth);
                CreateCenterText(menuWidth, "Main Menu");
                CreateCenterLine(menuWidth);
                CreateSpace(menuWidth);
                for (int i = 0; i < Options.Length; i++)
                {
                    if (i == Options.Length - 1)
                    {
                        CreateSpace(menuWidth);
                    }
                    if (i == optionSelector)
                    {
                        CreateCenterFarLeftText(menuWidth, "[*]  " + Options[i], 8);
                    }
                    else
                    {
                        CreateCenterFarLeftText(menuWidth, "[ ] " + Options[i], 8);
                    }
                }


                ConsoleKeyInfo pressedKey = Console.ReadKey();

                if (pressedKey.Key == ConsoleKey.UpArrow && optionSelector != 0)
                {
                    optionSelector--;
                }
                if(pressedKey.Key == ConsoleKey.DownArrow && optionSelector != Options.Length - 1)
                {
                    optionSelector++;
                }
                if(pressedKey.Key == ConsoleKey.Enter)
                {
                    if(optionSelector == Options.Length - 5)
                    {
                        ChangeColorScheme();
                        ClearRest();
                    }
                    if(optionSelector == Options.Length - 4)
                    {
                        ChangeDirection();
                        ClearRest();
                    }
                    if(optionSelector == Options.Length - 3)
                    {
                        Console.WriteLine("change delays");
                        Console.ReadKey();
                        ClearRest();
                    }
                    if(optionSelector == Options.Length - 2)
                    {
                        Console.WriteLine("change background");
                        Console.ReadKey();
                        ClearRest();
                    }
                    if (optionSelector == Options.Length - 1)
                    {
                        Exit();
                    }
                }
            }
        }
        static void ChangeColorScheme()
        {
            ClearRest();
            string[] options = { "One Color", "Deafult Color: ", "Color: ", "Multi Color", "Color #1: ", "Add", "Back" };
            int optionSelector = 0;

            while (true)
            {
                Console.SetCursorPosition(0, 3);
                CreateCenterLine(menuWidth);
                CreateCenterText(menuWidth, "Color Scheme");
                CreateCenterLine(menuWidth);
                CreateSpace(menuWidth);

                for(int i = 0; i < options.Length; i++)
                {
                    if(i != options.Length - 1)
                    {
                        if (i == 0 || i == 3)
                        {
                            if(i == 0)
                            {
                                if(OneColor)
                                {
                                    if(i == optionSelector)
                                    {
                                        CreateCenterFarLeftText(menuWidth, "[*] "+options[i] + " - SELECTED", 8);
                                    }
                                    else
                                    {
                                        CreateCenterFarLeftText(menuWidth, "[ ] " + options[i] + " - SELECTED", 8);
                                    }    
                                }
                                else
                                {
                                    if (i == optionSelector)
                                    {
                                        CreateCenterFarLeftText(menuWidth, "[*] " + options[i], 8);
                                    }
                                    else
                                    {
                                        CreateCenterFarLeftText(menuWidth, "[ ] " + options[i], 8);
                                    }
                                }
                            }
                            if (i == 3)
                            {
                                if (!OneColor)
                                {
                                    if (i == optionSelector)
                                    {
                                        CreateCenterFarLeftText(menuWidth, "[*] " + options[i] + " - SELECTED", 8);
                                    }
                                    else
                                    {
                                        CreateCenterFarLeftText(menuWidth, "[ ] " + options[i] + " - SELECTED", 8);
                                    }
                                }
                                else
                                {
                                    if (i == optionSelector)
                                    {
                                        CreateCenterFarLeftText(menuWidth, "[*] " + options[i], 8);
                                    }
                                    else
                                    {
                                        CreateCenterFarLeftText(menuWidth, "[ ] " + options[i], 8);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (i == optionSelector)
                            {
                                CreateCenterFarLeftText(menuWidth, "[*] " + options[i], 12);
                            }
                            else
                            {
                                CreateCenterFarLeftText(menuWidth, "[ ] " + options[i], 12);
                            }
                        }
                    }
                    else
                    {
                        CreateSpace(menuWidth);
                        if (i == optionSelector)
                        {
                            CreateCenterFarLeftText(menuWidth, "[*] " + options[i], 8);
                        }
                        else
                        {
                            CreateCenterFarLeftText(menuWidth, "[ ] " + options[i], 8);
                        }
                    }
                }

                ConsoleKeyInfo pressedKey = Console.ReadKey();

                if (pressedKey.Key == ConsoleKey.UpArrow && optionSelector != 0)
                {
                    optionSelector--;
                }
                if (pressedKey.Key == ConsoleKey.DownArrow && optionSelector != options.Length - 1)
                {
                    optionSelector++;
                }
                if(pressedKey.Key == ConsoleKey.Enter)
                {
                    if (optionSelector == options.Length - 1)
                    {
                        break;
                    }
                    if(optionSelector == 0)
                    {
                        OneColor = true;
                    }
                    if(optionSelector == 3)
                    {
                        OneColor = false;
                    }
                }
            }
        }
        static void ChangeDirection()
        {
            ClearRest();
            string[] options = { "From Left To Right", "From Right To Left", "Back" };
            int optionSelector = 0;

            while (true)
            {
                Console.SetCursorPosition(0, 3);
                CreateCenterLine(menuWidth);
                CreateCenterText(menuWidth, "Direction");
                CreateCenterLine(menuWidth);
                CreateSpace(menuWidth);

                for(int i = 0; i < options.Length; i++)
                {
                    if(i == 0)
                    {
                        if (LeftToRight)
                        {
                            if (optionSelector == i)
                            {
                                CreateCenterFarLeftText(menuWidth, "[*] " + options[i] + " - SELECTED", 8);
                            }
                            else
                            {
                                CreateCenterFarLeftText(menuWidth, "[ ] " + options[i] + " - SELECTED", 8);
                            }
                        }
                        else
                        {
                            if (optionSelector == i)
                            {
                                CreateCenterFarLeftText(menuWidth, "[*] " + options[i], 8);
                            }
                            else
                            {
                                CreateCenterFarLeftText(menuWidth, "[ ] " + options[i], 8);
                            }
                        }
                    }
                    if(i == 1)
                    {
                        if (!LeftToRight)
                        {
                            if (optionSelector == i)
                            {
                                CreateCenterFarLeftText(menuWidth, "[*] " + options[i] + " - SELECTED", 8);
                            }
                            else
                            {
                                CreateCenterFarLeftText(menuWidth, "[ ] " + options[i] + " - SELECTED", 8);
                            }
                        }
                        else
                        {
                            if (optionSelector == i)
                            {
                                CreateCenterFarLeftText(menuWidth, "[*] " + options[i], 8);
                            }
                            else
                            {
                                CreateCenterFarLeftText(menuWidth, "[ ] " + options[i], 8);
                            }
                        }
                    }
                    if(i == 2)
                    {
                        CreateSpace(menuWidth);
                        if (optionSelector == i)
                        {
                            CreateCenterFarLeftText(menuWidth, "[*] " + options[2], 8);
                        }
                        else
                        {
                            CreateCenterFarLeftText(menuWidth, "[ ] " + options[2], 8);
                        }
                    }
                }

                ConsoleKeyInfo pressedKey = Console.ReadKey();

                if (pressedKey.Key == ConsoleKey.UpArrow && optionSelector != 0)
                {
                    optionSelector--;
                }
                if (pressedKey.Key == ConsoleKey.DownArrow && optionSelector != options.Length - 1)
                {
                    optionSelector++;
                }
                if(pressedKey.Key == ConsoleKey.Enter)
                {
                    if(optionSelector == 0)
                    {
                        LeftToRight = true;
                    }
                    if(optionSelector == 1)
                    {
                        LeftToRight = false;
                    }
                    if(optionSelector == 2)
                    {
                        break;
                    }
                }
            }
        }
        static void Exit()
        {
            CenterText("Ludvík's soundcloud: https://soundcloud.com/plastic_heart03");
            CenterText("My github: https://github.com/negativexp");
            Thread.Sleep(3000);
            Environment.Exit(0);
        }

        //text
        static void ClearRest()
        {
            Console.SetCursorPosition(0, 3);
            for(int i = 0; i < Console.WindowHeight - 4; i++)
            {
                Console.WriteLine(new String(' ', Console.WindowWidth));
            }
        }
        static void CreateCenterLine(int width)
        {
            CenterText("!"+new string('-', width)+"!");
        }
        static void CreateCenterText(int width, string text)
        {
            width = (width - text.Length) / 2;
            if(width % 2 == 0)
            {
                CenterText("!"+"".PadLeft(width, ' ') + text + "".PadRight(width, ' ')+"!");
            }
            else
            {
                CenterText("!"+"".PadLeft(width, ' ') + text + "".PadRight(width+1, ' ')+"!");
            }
        }
        static void CreateCenterFarLeftText(int width, string text, int padding)
        {
            int leftOffset = padding;
            int remaningSpace = width - leftOffset - text.Length;

            CenterText("!"+"".PadRight(leftOffset, ' ') + text + "".PadRight(remaningSpace, ' ')+"!");
        }
        static void CreateSpace(int width)
        {
            CenterText("!" + new string(' ', width) + "!");
        }
        static void CenterText(string text)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }
        static int GetCenterPos(string text)
        {
            return (Console.WindowWidth - text.Length) / 2;
        }
    }
}