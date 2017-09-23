using System;
using System.Collections.Generic;

namespace AllianceReservations.Data.Handlers.Interfaces
{
    public interface IFileHandler<T> where T : class
    {
        List<T> GetList(Type T);
        void SaveList(List<T> list, Type T);
    }
}
