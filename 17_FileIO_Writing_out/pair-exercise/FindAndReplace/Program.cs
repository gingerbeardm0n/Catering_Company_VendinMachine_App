﻿using System;
using System.IO;

namespace FindAndReplace
{
    class Program
    {
        static void Main(string[] args)
        {

            UserInterface userInterface = new UserInterface();
            userInterface.Run();

            Console.WriteLine("Please enter a search phrase: ");

            string searchPhrase = Console.ReadLine();

            Console.WriteLine("Please enter the replace phrase: ");

            string replacePhrase = Console.ReadLine();

            Console.WriteLine("Please enter the source file path (this must be an existing file) (input): ");

            string filePath = Console.ReadLine();

            Console.WriteLine("Please enter the destination file path (this must NOT be an existing file) (output): ");

            string fileDestination = Console.ReadLine();


        }
    }
}
