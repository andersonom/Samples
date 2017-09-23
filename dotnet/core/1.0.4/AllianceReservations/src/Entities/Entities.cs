using AllianceReservations.Data;
using System.Collections.Generic;

namespace AllianceReservations.Entities
{
    public class Person : Crud<Person>
    {
        private static readonly List<Person> Persons = new List<Person>();

        public Address Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person()//Needed default contructor because of XML
        {

        }

        public Person(string name, string lastName, Address address)
        {
            Id = null;
            FirstName = name;
            LastName = lastName;
            Address = address;
        }
    }

    public class Address : Crud<Address>
    {
        public string Place { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public Address()//Needed default contructor because of XML
        {

        }

        public Address(string place, string district, string state, string zip)
        {
            Place = place;
            District = district;
            State = state;
            Zip = zip;
        }
    }

    public class Business : Crud<Business>
    {

        public Address Address { get; set; }
        public string Name { get; set; }

        public Business()//Needed default contructor because of XML
        {

        }

        public Business(string name, Address address)
        {
            Id = null;
            Name = name;
            Address = address;
        }
    }
}
