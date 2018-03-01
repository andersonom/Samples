using StudentManager.Domain.Interfaces.Repositories;
using StudentsManager.Domain.Models;


namespace StudentsManager.Data.Repositories
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(StudentsManagerContext context) : base(context)
        {
       
        }
    }
}
