using System;

namespace AllianceReservations.Util
{
    public static class Util
    {
        //Not Used, passing type by param on GetList
        public static string GetAssemblyNameByType(this Type type)
        {
            var fileName = type.FullName;
            string namespaceCut = "AllianceReservations.Entities.";

            fileName = fileName.Substring(fileName.IndexOf(namespaceCut) + namespaceCut.Length);
            fileName = fileName.Substring(0,fileName.IndexOf(','));
             
            return fileName;
        }
    }

}