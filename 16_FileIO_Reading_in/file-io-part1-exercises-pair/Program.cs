﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace file_io_part1_exercises_pair
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input desired filesystem path to have amount of words and amount of sentences computed");
            string input = Console.ReadLine();

            try
            {
                using (StreamReader thisDoesntMatter = new StreamReader(input))
                {
                    int wordCount = 0;
                    int sentenceCount = 0;

                    while (!thisDoesntMatter.EndOfStream)
                    {
                        // Read in the line
                        string line = thisDoesntMatter.ReadLine();

                        string[] ourArrayOfSexyWords = line.Split(" ");

                        
                        foreach (string testString in ourArrayOfSexyWords)
                        {
                            if (testString != "" && testString != " ")
                            {
                                wordCount++;
                            }
                        }
                        // Brandon - C:\\NicePlace\\Alice.txt to copy and paste
                        // Joel - C:\\HappyPlace\\ALICE.txt 


                        ///string[] ourArrayOfSexySentences = line.Split(new char[] { '.', '?', '!' });

                        int i = 0;


                        for (i = 0; i < line.Length - 1; i++)
                        {
                            string punctuation = line.Substring(i, 2);


                            if (punctuation == "! " || punctuation == ". " || punctuation == "? " || punctuation == "!\"" || punctuation == ".\"" || punctuation == "?\"")
                            {

                                sentenceCount++;

                            }
                        }

                        
                    }
                    Console.WriteLine("Word Count: " + wordCount);
                    Console.WriteLine("Sentence Count: " + sentenceCount);
                }
            }

            catch (IOException e) //catch a specific type of Exception
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}



