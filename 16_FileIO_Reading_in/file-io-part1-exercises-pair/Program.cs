using System;
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
                       
                        wordCount += ourArrayOfSexyWords.Length;



                        // C:\\NicePlace\\Alice.txt to copy and paste

                        

                        if (line != "" && (line.Contains('.') || line.Contains('?') || line.Contains('!')))
                        {

                            string[] ourArrayOfSexySentences = line.Split(new char[] { '.', '?', '!' });

                            sentenceCount += ourArrayOfSexySentences.Length;
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



