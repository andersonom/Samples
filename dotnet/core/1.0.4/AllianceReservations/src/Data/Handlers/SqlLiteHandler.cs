using AllianceReservations.Data.Handlers.Interfaces;
using AllianceReservations.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AllianceReservations.Data
{
    public class AllianceReservationsContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Business> Businesses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=AllianceReservations.db");
        }
    }
}

namespace AllianceReservations.Data.Handlers
{
    public class SqlLiteHandler<T> : IFileHandler<T> where T : class
    {
        private static readonly AllianceReservationsContext _context = new AllianceReservationsContext();
  
        public void Delete()
        {
            var classType = typeof(T);
            var classProps = classType.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
            var inheritedProps = classType.GetTypeInfo().BaseType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var obj = Find((int)inheritedProps[0].GetValue(this));
            _context.Set<T>().Remove(obj);
            _context.SaveChanges();
        }

        public T Find(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetList(Type T)//Params Not used
        {
            return _context.Set<T>().ToList() as List<T>;
        }

        public void SaveList(List<T> list, Type T)//Params Not used
        {
            _context.Set<T>().AddRange(list);
        }
    }
}
