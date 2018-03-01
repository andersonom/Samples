using StudentsManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Domain.Interfaces.Repositories
{
    public interface ICourseRepository : IRepositoryBase<Course>
    {
        Task<PaginatedList<Course>> GetCoursesPagedByNameAsync(string name, int? pageSize, int? page);

        Task<PaginatedList<Course>> GetCoursesPagedAsync( int? pageSize, int? page);

        Task<IEnumerable<Course>> GetCoursesAsync();
    }
}
