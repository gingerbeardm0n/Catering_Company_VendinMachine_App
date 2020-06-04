using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class FileAccess
    {
        // This class should contain any and all details of access to files

        private string fullPath = @"c:\Catering\cateringsystem.csv";

        public List<CateringItem> ReadItems()
        {
            List<CateringItem> items = new List<CateringItem>();

            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string unsplit = sr.ReadLine();
                        string[] split = unsplit.Split('|');

                        CateringItem tempObject = new CateringItem();
                        tempObject.Code = split[0];
                        tempObject.Name = split[1];
                        tempObject.Price = decimal.Parse(split[2]);
                        tempObject.Type = split[3];

                        items.Add(tempObject);


                    }
                }
            }
            catch
            {
                items = new List<CateringItem>();
            }

            return items;
        }

    }
}
