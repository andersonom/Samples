using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using AllianceReservations.Util;
using AllianceReservations.Data.Handlers.Interfaces;

namespace AllianceReservations.Data.Handlers
{
    public class JsonHandler<T> : IFileHandler<T> where T : class
    {
        public static List<T> GetListStatic(Type type)
        {
            List<T> list;
            string path = String.Format("E:\\{0}.json", type.Name);// this.GetType().GetAssemblyNameByType());

            String jsonList = String.Empty;

            if (File.Exists(path))
                jsonList = File.ReadAllText(path);

            if (!String.IsNullOrEmpty(jsonList))
                list = JsonConvert.DeserializeObject<List<T>>(jsonList);
            else
                list = new List<T>();

            return list;
        }

        public List<T> GetList(Type type)
        {
            return GetListStatic(type);
        }
         

        public void SaveList(List<T> list, Type type)
        {
            string json = JsonConvert.SerializeObject(list);

            string fileName = type.Name;

            File.WriteAllText(String.Format("E:\\{0}.json", fileName), json);
        } 
    }
}
