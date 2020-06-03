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

            Console.ReadLine();

        }

    }
}
