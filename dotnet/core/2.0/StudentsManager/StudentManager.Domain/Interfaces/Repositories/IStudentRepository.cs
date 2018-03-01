using StudentsManager.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManager.Domain.Interfaces.Repositories
{
    public interface IStudentRepository : IRepositoryBase<Student>
    { 
        Task<PaginatedList<Student>> GetStudentsPagedAsync(int? pageSize, int? page);

        Task<PaginatedList<Student>> GetStudentsPagedByNameAsync(string name, int? pageSize = 1, int? page = 1);

        Task<Student> GetStudentByIdAsync(int id); //Necessary until EF Core 2.1 lazy loading be available         
    }
}
