using StudentsManager.Domain.Bases;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManager.Domain.Interfaces.Services
{
    public interface IAPIClient<T> where T : class
    {
        Task<PaginatedList<T>> GetPaginatedListFromAPI(string uri);
        Task<IEnumerable<T>> GetListFromAPI(string uri);
        Task<T> GetEntityFromAPI(string uri);
        Task PostEntityToAPI(string uri, T entity);
        Task PutEntityToAPI(string uri, T entity);
        Task DeleteEntityFromAPI(string uri);
    }
}
