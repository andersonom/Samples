using AllianceReservations.Data.Handlers;
using AllianceReservations.Data.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AllianceReservations.Data
{
    public class Crud<T> where T : class
    {
        private static readonly IFileHandler<T> _fileHandler = new XmlHandler<T>();

        public Guid? Id { get; set; }

        //public static T Find(Guid? id)
        public T Find(Guid? id)
        {
            List<T> list = _fileHandler.GetList(typeof(T));

            return list.FirstOrDefault(i => (i as Crud<T>).Id.Equals(id)) as T;
        }

        public void Save()
        {
            List<T> list = _fileHandler.GetList(typeof(T));

            Id = Guid.NewGuid();

            //if (list.FirstOrDefault(i=> i.))
            //{

            //}
            list.Add(this as T);

            _fileHandler.SaveList(list, this.GetType());
        }

        public void Delete()
        {
            var item = Find(this.Id);

            List<T> list = _fileHandler.GetList(this.GetType());

            list.Remove(item);

            _fileHandler.SaveList(list, this.GetType());            
        }
    }
}
