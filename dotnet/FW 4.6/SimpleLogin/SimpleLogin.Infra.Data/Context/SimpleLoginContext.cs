using SimpleLogin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogin.Infra.Data.Context
{
    public class SimpleLoginContext : DbContext
    {

        // public SimpleLoginContext()
        //    : base(@"Data Source=.;Initial Catalog=SimpleLoginContext;Integrated Security=True;MultipleActiveResultSets=True")
        //{
        //    Debug.Write(Database.Connection.ConnectionString);
        //}
        public SimpleLoginContext( )
            : base(@"Server=.;Database=SimpleLoginContext;Integrated Security=True; Trusted_Connection=True;MultipleActiveResultSets=true")
        {

        }

        DbSet<UserProfile> UserProfiles { get; set; }
    }
}
