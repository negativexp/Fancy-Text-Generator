using System.Net.Security;
using System.Reflection.Metadata;
using System.Threading;
using System.Transactions;

namespace fancy_text
{
    class Program
    {
        static int menuWidth = 80;
        static bool OneColor = true;
        static List<ConsoleColor> oneColor = new List<ConsoleColor>() { ConsoleColor.White, ConsoleColor.Red };
        static List<ConsoleColor> multiColors = new List<ConsoleColor>() { ConsoleColor.Red, ConsoleColor.DarkGreen, ConsoleColor.DarkRed };
        static bool LeftToRight = true;

        static void Main(string[] args)
        {
            Console.Title = "FTG - by newoutsider <3";
            //PlayIntro();
            DisplayMenu();
        }

        //intro
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
            string[] options = { "One Color", "Multi Color", "Options", "Back" };
            int optionSelector = 0;

            while (true)
            {
                Console.SetCursorPosition(0, 3);
                CreateCenterLine(menuWidth);
                CreateCenterText(menuWidth, "Color Scheme");
                CreateCenterLine(menuWidth);
                CreateSpace(menuWidth);

                for (int i = 0; i < options.Length; i++)
                {
                    if(i != options.Length - 1)
                    {
                        if(i == 0)
                        {
                            if (OneColor)
                            {
                                if (optionSelector == i)
                                {
                                    CreateCenterFarLeftText(menuWidth, "[*]  " + options[i] + " - SELECTED", 8);
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
                                    CreateCenterFarLeftText(menuWidth, "[*]  " + options[i], 8);
                                }
                                else
                                {
                                    CreateCenterFarLeftText(menuWidth, "[ ] " + options[i], 8);
                                }
                            }
                        }
                        else if(i == 1)
                        {
                            if (!OneColor)
                            {
                                if (optionSelector == i)
                                {
                                    CreateCenterFarLeftText(menuWidth, "[*]  " + options[i] + " - SELECTED", 8);
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
                                    CreateCenterFarLeftText(menuWidth, "[*]  " + options[i], 8);
                                }
                                else
                                {
                                    CreateCenterFarLeftText(menuWidth, "[ ] " + options[i], 8);
                                }
                            }
                        }
                        else
                        {
                            if (optionSelector == i)
                            {
                                CreateCenterFarLeftText(menuWidth, "[*]  " + options[i], 8);
                            }
                            else
                            {
                                CreateCenterFarLeftText(menuWidth, "[ ] " + options[i], 8);
                            }
                        }
                    }
                    else
                    {
                        CreateSpace(menuWidth);

                        if (i == optionSelector)
                        {
                            CreateCenterFarLeftText(menuWidth, "[*]  " + options[i], 8);
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
                    if(optionSelector == 1)
                    {
                        OneColor = false;
                    }
                    if(optionSelector == 2)
                    {
                        if(OneColor)
                        {
                            OneColorOptionsMenu();
                            ClearRest();
                        }
                        else
                        {
                            MultiColorOptionsMenu();
                            ClearRest();
                        }
                    }
                }
            }
        }
        static void OneColorOptionsMenu()
        {
            ClearRest();
            string[] options = { "Deafult Color: ", "Color: ", "Back" };
            int optionSelector = 0;

            while (true)
            {
                Console.SetCursorPosition(0, 3);
                CreateCenterLine(menuWidth);
                CreateCenterText(menuWidth, "One Color Options");
                CreateCenterLine(menuWidth);
                CreateSpace(menuWidth);

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == 0)
                    {
                        if (i == optionSelector)
                        {
                            CreateCenterFarLeftText(menuWidth, "[*]  " + options[i] + oneColor[0], 8);
                        }
                        else
                        {
                            CreateCenterFarLeftText(menuWidth, "[ ] " + options[i] + oneColor[0], 8);
                        }
                    }
                    if (i == 1)
                    {
                        if (i == optionSelector)
                        {
                            CreateCenterFarLeftText(menuWidth, "[*]  " + options[i] + oneColor[1], 8);
                        }
                        else
                        {
                            CreateCenterFarLeftText(menuWidth, "[ ] " + options[i] + oneColor[1], 8);
                        }
                    }
                    if (i == 2)
                    {
                        CreateSpace(menuWidth);
                        if (i == optionSelector)
                        {
                            CreateCenterFarLeftText(menuWidth, "[*]  " + options[i], 8);
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
                if (pressedKey.Key == ConsoleKey.Enter)
                {
                    if (optionSelector == 0)
                    {
                        ConsoleColor? value = TypeConsoleColor();
                        if (value != null)
                        {
                            oneColor[0] = (ConsoleColor)value;
                        }
                    }
                    if (optionSelector == 1)
                    {
                        ConsoleColor? value = TypeConsoleColor();
                        if (value != null)
                        {
                            oneColor[1] = (ConsoleColor)value;
                        }
                    }
                    if (optionSelector == options.Length - 1)
                    {
                        break;
                    }
                }
            }
        }
        static void MultiColorOptionsMenu()
        {
            ClearRest();
            List<string> options = new List<string>();
            for(int i = 0; i < multiColors.Count; i++)
            {
                options.Add("Color #" + i + ": " + multiColors[i]);
            }
            options.Add("Add");
            options.Add("Back");

            bool removeBool = false;
            int optionSelector = 0;

            while (true)
            {
                Console.SetCursorPosition(0, 3);
                CreateCenterLine(menuWidth);
                CreateCenterText(menuWidth, "Multi Color Options ");
                CreateCenterText(menuWidth, " Press \"del\" to delete.");
                CreateCenterLine(menuWidth);
                CreateSpace(menuWidth);

                for (int i = 0; i < options.Count; i++)
                {
                    if(i < multiColors.Count)
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
                    else
                    {
                        if(i == options.Count - 1)
                        {
                            CreateSpace(menuWidth);
                            if (optionSelector == i)
                            {
                                CreateCenterFarLeftText(menuWidth, "[*] " + options[i], 8);
                            }
                            else
                            {
                                CreateCenterFarLeftText(menuWidth, "[ ] " + options[i], 8);
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

                }

                ConsoleKeyInfo pressedKey = Console.ReadKey();

                if (pressedKey.Key == ConsoleKey.UpArrow && optionSelector != 0)
                {
                    optionSelector--;
                }
                if (pressedKey.Key == ConsoleKey.DownArrow && optionSelector != options.Count - 1)
                {
                    optionSelector++;
                }
                if (pressedKey.Key == ConsoleKey.Enter)
                {
                    if(optionSelector == options.Count - 2)
                    {
                        //add
                        ConsoleColor? value = TypeConsoleColor();
                        if (value != null)
                        {
                            multiColors.Add((ConsoleColor)value);
                            options.Insert(multiColors.Count - 1, "Color #" + multiColors.Count + ": " + value);
                        }
                    }
                    if (optionSelector == options.Count - 1)
                    {
                        break;
                    }
                }
                if(pressedKey.Key == ConsoleKey.Delete)
                {
                    if(optionSelector < multiColors.Count)
                    {
                        options.RemoveRange(0, multiColors.Count);
                        multiColors.RemoveAt(optionSelector);
                        for (int i = 0; i < multiColors.Count; i++)
                        {
                            options.Insert(i, "Color #" + i + ": " + multiColors[i]);
                        }
                        ClearRest();
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
                                CreateCenterFarLeftText(menuWidth, "[*]  " + options[i] + " - SELECTED", 8);
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
                                CreateCenterFarLeftText(menuWidth, "[*]  " + options[i], 8);
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
                                CreateCenterFarLeftText(menuWidth, "[*]  " + options[i] + " - SELECTED", 8);
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
                                CreateCenterFarLeftText(menuWidth, "[*]  " + options[i], 8);
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
                            CreateCenterFarLeftText(menuWidth, "[*]  " + options[2], 8);
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
        static void ChangeDelays()
        {
            ClearRest();
            string[] options = { "Start Delay: ", "End Delay: ", "Color Scheme Delay: ", "Back" };
            int optionSelector = 0;

            while(true)
            {

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
        static ConsoleColor? TypeConsoleColor()
        {
            Console.CursorLeft = 28;
            Console.Write(":");
            string value = Console.ReadLine();
            Console.CursorTop = Console.CursorTop - 1;
            Console.CursorLeft = 28;
            Console.Write(new string(' ', 50));

            value.ToLower();
            if (value == "black")
            {
                return ConsoleColor.Black;
            }
            else if (value == "darkblue")
            {
                return ConsoleColor.DarkBlue;
            }
            else if (value == "darkgreen")
            {
                return ConsoleColor.DarkGreen;
            }
            else if (value == "darkcyan")
            {
                return ConsoleColor.DarkCyan;
            }
            else if (value == "darkred")
            {
                return ConsoleColor.DarkRed;
            }
            else if (value == "darkmagenta")
            {
                return ConsoleColor.DarkMagenta;
            }
            else if (value == "darkyellow")
            {
                return ConsoleColor.DarkYellow;
            }
            else if (value == "gray")
            {
                return ConsoleColor.Gray;
            }
            else if (value == "darkgray")
            {
                return ConsoleColor.DarkGray;
            }
            else if (value == "blue")
            {
                return ConsoleColor.Blue;
            }
            else if (value == "green")
            {
                return ConsoleColor.Green;
            }
            else if (value == "cyan")
            {
                return ConsoleColor.Cyan;
            }
            else if (value == "red")
            {
                return ConsoleColor.Red;
            }
            else if (value == "magenta")
            {
                return ConsoleColor.Magenta;
            }
            else if (value == "yellow")
            {
                return ConsoleColor.Yellow;
            }
            else if (value == "white")
            {
                return ConsoleColor.White;
            }
            else
            {
                return null;
            }
        }
    }
}