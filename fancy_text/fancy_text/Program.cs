﻿using System.Threading;

namespace fancy_text
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "FTG - by newoutsider <3";
            //PlayIntro();
            DisplayMenu();
        }

        static void PlayIntro()
        {
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

        static void DisplayMenu()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            int menuWidth = 100;
            int optionSelector = 0;
            string introTitle = "Fancy Text Generator";
            string introAuthor = "Made by newoutsider <3";

            string[] Options =
            {
                    "Change Colors",
                    "Change Direction",
                    "Change Delays",
                    "Change Background",
                    "Go back to the note",
                    "Exit"
            };

            CenterText(introTitle);
            CenterText(introAuthor);
            Console.SetCursorPosition(0, 3);
            CenterText("!".PadRight(menuWidth - 2, '-') + "!");
            CenterText("Welcome!");
            CenterText("!".PadRight(menuWidth - 2, '-') + "!");

            while (true)
            {
                Console.SetCursorPosition(0, 6);
                for (int i = 0; i < Options.Length; i++)
                {
                    if (i == optionSelector)
                    {
                        CenterText("!".PadRight((menuWidth / 10), ' ') + "[*] " + Options[i].PadRight((menuWidth / 10) * 9 - 6, ' ') + "!");
                    }
                    else
                    {
                        CenterText("!".PadRight((menuWidth / 10), ' ') + "[ ] " + Options[i].PadRight((menuWidth / 10) * 9 - 6, ' ') + "!");
                    }
                }
                CenterText("!".PadRight(menuWidth - 2, '-') + "!");


                ConsoleKeyInfo pressedKey = Console.ReadKey();

                if (pressedKey.Key == ConsoleKey.UpArrow && optionSelector != 0)
                {
                    optionSelector--;
                }
                if(pressedKey.Key == ConsoleKey.DownArrow && optionSelector != Options.Length - 1)
                {
                    optionSelector++;
                }
            }
        }

        static int GetCenterPos(string text)
        {
            return (Console.WindowWidth - text.Length) / 2;
        }

        static void CenterText(string text)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }

        static void CenterTextOnLine(string text)
        {
            Console.Write(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }

    }
}