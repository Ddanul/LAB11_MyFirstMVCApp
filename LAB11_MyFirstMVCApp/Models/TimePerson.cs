using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LAB11_MyFirstMVCApp.Models
{
    //public class with properties matching csv file
    public class TimePerson
    {
        //properties for each person/thing of the year
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Birth_Year { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        //method which returns a list of person objects depending on the years selected
        public static List<TimePerson> GetPersons(int begYear, int endYear)
        {
            //declared new list of people
            List<TimePerson> people = new List<TimePerson>();
            //declares a path for current lab directory to be used for file reader
            string path = Environment.CurrentDirectory;
            //combines previous path to wwwroot path and file containg all info
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\personOfTheYear.csv"));
            //setting a variable to store an array of all the information being read from the csv file
            string[] myFile = File.ReadAllLines(newPath);

            //iterating through each string extracted from file
            for (int i = 1; i < myFile.Length; i++)
            {
                //separating strings where commas are used and storing new values into another array
                string[] fields = myFile[i].Split(',');
                //adding separated strings from array into list previously declared
                people.Add(new TimePerson
                {
                    Year = Convert.ToInt32(fields[0]),
                    Honor = fields[1],
                    Name = fields[2],
                    Country = fields[3],
                    Birth_Year = (fields[4] == "") ? 0 : Convert.ToInt32(fields[4]),
                    DeathYear = (fields[5] == "") ? 0 : Convert.ToInt32(fields[5]),
                    Title = fields[6],
                    Category = fields[7],
                    Context = fields[8],
                });
            }

            //This is where the information is actually filtered using the dates selected by the user.
            List<TimePerson> listofPeople = people.Where(p => (p.Year >= begYear) && (p.Year <= endYear)).ToList();
            //returning the list
            return listofPeople;
        }
    }
}
