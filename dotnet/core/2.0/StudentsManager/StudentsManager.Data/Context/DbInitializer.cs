using StudentsManager.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsManager.Data
{
    public class DbInitializer
    {
        public async Task Initialize(StudentsManagerContext context)
        {
            context.Database.EnsureCreated();

            if (context.Student.Any())
            {
                return;
            }

            context.Student.Add(new Student()
            {
                FirstName = "Anderson",
                Surname = "Martins",
                Gender = "Male",
                DOB = "Unknown",
                Course = new Course() { Name = "Computer Science" },
                Addresses = new List<Address>() { new Address() { Street = "Eng Manoel Ferramenta Jr Street 363", PostalCode = "11086-400", City = "Santos", State = "Sao Paulo", Country = "Brazil" } }
            });

            context.Student.Add(new Student()
            {
                FirstName = "Roberta",
                Surname = "Martins",
                Gender = "Female",
                DOB = "Unknown",
                Course = new Course() { Name = "Pedagody" },
                Addresses = new List<Address>() { new Address() { Street = "Rua Santo Melarato 41", PostalCode = "11390-030", City="Sao Vicente", State = "Sao Paulo", Country= "Brazil" } }
            });

            await context.SaveChangesAsync();
        }
    }
}
