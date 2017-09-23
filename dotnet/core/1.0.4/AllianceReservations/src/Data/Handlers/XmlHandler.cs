using AllianceReservations.Data.Handlers.Interfaces;
using AllianceReservations.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace AllianceReservations.Data.Handlers
{
    public class XmlHandler<T> : IFileHandler<T> where T : class
    {
        public void SaveList(List<T> list, Type type)
        {
            var serializer = new XmlSerializer(typeof(List<T>));

            string path = String.Format("E:\\{0}.XML", type.Name);// this.GetType().GetAssemblyNameByType());

            var file = File.Create(path);

            using (StreamWriter writer = new StreamWriter(file))
            {
                serializer.Serialize(writer, list);
            }
        }

        public List<T> GetList(Type type)
        {
            return GetListStatic(type);
        }

        public static List<T> GetListStatic(Type type)
        {
            List<T> list = null;
            string path = String.Format("E:\\{0}.xml", type.Name);

            var serializer = new XmlSerializer(typeof(List<T>));

            if (File.Exists(path))
            {
                using (XmlReader reader = XmlReader.Create(path))
                {
                    list = serializer.Deserialize(reader) as List<T>;
                }
            }
            else
            {
                list = new List<T>();
            }

            return list as List<T>;
        }
    }
}
