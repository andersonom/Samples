using System.Collections.Generic;

namespace StudentsManager.Domain.Models
{
    public class Student
    {
        public int Id { get; set; }        
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public virtual List<Address> Addresses { get; set; }
        public virtual Course Course  { get; set; }
        public int CourseId { get; set; }
    }
}