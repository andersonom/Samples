using SimpleLogin.Domain.Entities;
using SimpleLogin.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogin.Infra.Data.Repositories
{
    public class UserProfileRepository : RepositoryBase<UserProfile>, IUserProfileAppService
    {
    }
}
