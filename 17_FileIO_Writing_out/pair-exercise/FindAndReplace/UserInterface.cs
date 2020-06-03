using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace FindAndReplace
{
   public class UserInterface
    {
      
       

        public void Run()
        {
            Console.WriteLine("Please enter a search phrase: ");

            string searchPhrase = Console.ReadLine();

            Console.WriteLine("Please enter the replace phrase: ");

            string replacePhrase = Console.ReadLine();

            Console.WriteLine("Please enter the source file path (this must be an existing file) (input): ");

            string filePath = Console.ReadLine();

            Console.WriteLine("Please enter the destination file path (this must NOT be an existing file) (output): ");

            string fileDestination = Console.ReadLine();

            string replaceLine = "";

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string sourceLine = sr.ReadLine();

                        replaceLine += sourceLine.Replace(searchPhrase, replacePhrase);
                    }
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: Program will exit now");
                Console.WriteLine(e.Message);
            }
            try
            {
                using  (StreamWriter sw = new StreamWriter(fileDestination, false))
                {
                    sw.Write(replaceLine);
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: Program will exit now");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Search & Replace Successful! New file has been created in desired loacation! CONGRATULATIONS!");
            Console.ReadLine();

        }
                //C:\\HappyPlace\\ALICE.txt
                //C:\\HappyPlace\\newALICE.txt
    }
}
