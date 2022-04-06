using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DemoPeople
{
    public static class DataAccess
    {
        /// <summary>
        /// Original code was refacturaded to viabilize XUnit use
        /// </summary>
        private static string peopleTextFile = "peoplesFile.txt";
        public static void AddPerson(PersonModel person)
        {
 
            List<PersonModel> people = GetAllPeople();

            AddPersonToPeopleList(people, person);

            List<string> lines = ConvertModelToCSV(people);
            File.WriteAllLines(peopleTextFile, lines);
        }

        public static void AddPersonToPeopleList(List<PersonModel> currentPeople, PersonModel newPerson)
        {
            if (newPerson == null)
                throw new ArgumentNullException("newPerson", "None informed");

            if (string.IsNullOrWhiteSpace(newPerson.FirstName))
                throw new ArgumentException("First name not informed", "newPerson.FirstName");

            if (string.IsNullOrWhiteSpace(newPerson.LastName))
                throw new ArgumentException("Last name not informed", "newPerson.LastName");
          
            currentPeople.Add(newPerson);
        }

        public static List<string> ConvertModelToCSV(List<PersonModel> currentPeople)
        {
            List<string> content =  new List<string>();
            foreach (PersonModel person in currentPeople)
            {
                content.Add($"{person.LastName},{person.FirstName}");
            }

            return content;
        }

        public static List<PersonModel> GetAllPeople()
        {
            string[] lines = File.ReadAllLines(peopleTextFile);
            List<PersonModel> output = new List<PersonModel>();

            foreach (string line in lines)
            {
                output.Add(ConvertLineToPersonModel(line));
            }

            return output;
        }

        public static PersonModel ConvertLineToPersonModel(string line)
        {
            string[] data = line.Split(',');
            return (new PersonModel { FirstName = data[1], LastName = data[0] });
        }


    }
}
