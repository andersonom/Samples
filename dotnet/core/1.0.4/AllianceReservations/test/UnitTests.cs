//using Microsoft.VisualStudio.TestTools.UnitTesting;
using AllianceReservations.Entities;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Collections.Generic;
using AllianceReservations.Data;

namespace AllianceReservations.Tests
{
    public class UnitTests
    {
        [TestCase]
        public void ProgrammerTest()
        {
            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkSqlite()
            .AddDbContext<AllianceReservationsContext>();
            //     .GetService<ILoggerFactory>()
            //     .AddConsole(Configuration.GetSection("Logging"));
            //.AddDbContext<AllianceReservationsContext>()
            //.AddScoped<IFileHandler<Address>, JsonHandler<Address>>()
            //.AddScoped<IFileHandler<Person>, JsonHandler<Person>>()
            //.AddScoped<IFileHandler<Business>, JsonHandler<Business>>()
            //.BuildServiceProvider();
 

            var address = new Address("5455 Apache Trail", "Queen Creek", "AZ", "85243");
            var person = new Person("Jane", "Smith", address);
            var biz = new Business("Alliance Reservations Network", address);

            Assert.That(person.Id, Is.Null.Or.Empty);
            person.Save();
            Assert.That(person.Id, Is.Not.Null.Or.Empty);

            Assert.That(biz.Id, Is.Null.Or.Empty);
            biz.Save();
            Assert.That(biz.Id, Is.Not.Null.Or.Empty);

            //Person savedPerson = Person.Find(person.Id);
            Person savedPerson = new Person(null, null, null).Find(person.Id);
            Assert.IsNotNull(savedPerson);
            Assert.AreSame(person.Address, address);
            //Assert.AreEqual(savedPerson.Address, address);
            Assert.AreEqual(person.Id, savedPerson.Id);
            Assert.AreEqual(person.FirstName, savedPerson.FirstName);
            Assert.AreEqual(person.LastName, savedPerson.LastName);
            //Assert.AreEqual(person, savedPerson);
            Assert.AreNotSame(person, savedPerson);
            Assert.AreNotSame(person.Address, savedPerson.Address);

            //Business savedBusiness = Business.Find(biz.Id);
            Business savedBusiness = new Business(null, null).Find(biz.Id);
            Assert.IsNotNull(savedBusiness);
            Assert.AreSame(biz.Address, address);
            //Assert.AreEqual(savedBusiness.Address, address);
            Assert.AreEqual(biz.Id, savedBusiness.Id);
            Assert.AreEqual(biz.Name, savedBusiness.Name);
            //Assert.AreEqual(biz, savedBusiness);
            Assert.AreNotSame(biz, savedBusiness);
            Assert.AreNotSame(biz.Address, savedBusiness.Address);

            var dictionary = new Dictionary<object, object> { [address] = address, [person] = person, [biz] = biz };
            var teste = new Address("5455 Apache Trail", "Queen Creek", "AZ", "85243");
            Assert.IsTrue(dictionary.ContainsKey(new Address("5455 Apache Trail", "Queen Creek", "AZ", "85243")));
            Assert.IsTrue(dictionary.ContainsKey(new Person("Jane", "Smith", address)));
            Assert.IsTrue(dictionary.ContainsKey(new Business("Alliance Reservations Network", address)));
            Assert.IsFalse(dictionary.ContainsKey(new Address("54553 Apache Trail", "Queen Creek", "AZ", "85243")));
            Assert.IsFalse(dictionary.ContainsKey(new Person("Jim", "Smith", address)));
            Assert.IsFalse(dictionary.ContainsKey(new Business("Alliance Reservation Networks", address)));

            var deletedPersonId = person.Id;
            person.Delete();
            Assert.That(person.Id, Is.Null.Or.Empty);
            //Assert.IsNull(Person.Find(deletedPersonId));
            Assert.IsNull(new Person(null, null, null).Find(deletedPersonId));

            var deletedBizId = biz.Id;
            biz.Delete();
            Assert.That(biz.Id, Is.Null.Or.Empty);
            //Assert.IsNull(Business.Find(deletedBizId));
            Assert.IsNull(new Business(null, null).Find(deletedBizId));
        }
    }
}
