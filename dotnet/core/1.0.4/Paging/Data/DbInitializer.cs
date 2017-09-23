using System;
using System.Linq;
using System.Threading.Tasks;
using Paging.Models;
using System.Collections.Generic;

namespace Paging.Data
{
    public class DbInitializer
    {
        public async Task Initialize(PaginationDbContext context)
        {
            context.Database.EnsureCreated();

            if(context.Paginations.Any())
            {
             return;
            } 
            
                  for (int i = 0; i < 1000; i++)
                  {
                      context.Paginations.Add(new Pagination(){Item=String.Format("Item {0}",i+1)});
                      await context.SaveChangesAsync();                 
                  }
        }
    }
}