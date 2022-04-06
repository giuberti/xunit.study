using System;
using Xunit;
using DemoPeople;
using System.Collections.Generic;

namespace DemoPeopleTests
{
    public class DataAccessTests
    {
        [Fact]
        public void AddPersonToPeopleList_ShouldWork()
        {
            PersonModel expectedPerson = new PersonModel { FirstName = "Joe", LastName = "Doe" };
            List<PersonModel> actualPeople = new List<PersonModel>();

            actualPeople.Add(expectedPerson);

            Assert.True(actualPeople.Count == 1);
            Assert.Contains<PersonModel>(expectedPerson, actualPeople);
        }

        [Theory]
        [InlineData("", "Pinkman", "newPerson.FirstName")]
        [InlineData("Jesse", "", "newPerson.LastName")]
        public void AddPersonToPeopleList_ShouldRaiseInvalidNames(string firstName, string lastName, string param)
        {
            PersonModel expectedPerson = new PersonModel { FirstName = firstName, LastName = lastName };
            List<PersonModel> actualPeople = new List<PersonModel>();

            actualPeople.Add(expectedPerson);

            Assert.Throws<ArgumentException>(param, () => DataAccess.AddPersonToPeopleList(actualPeople, expectedPerson));
        }


        [Fact]
        public void ConvertLineToPersonModel_ShouldWork()
        {
            PersonModel expectedPerson = new PersonModel { FirstName = "Joe", LastName = "Doe" };
            string line = "Doe,Joe";

            PersonModel actualPerson = DataAccess.ConvertLineToPersonModel(line);
            
            Assert.IsType<PersonModel>(DataAccess.ConvertLineToPersonModel(line));
            Assert.True(expectedPerson.Equals(actualPerson));       // should return TRUE, but returns FALSE
        }
    }
}
