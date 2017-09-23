using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Paging.Data;
using Paging.Models;
using System.Linq;


namespace Paging.Controllers
{
    public class HomeController : Controller
    {
        PaginationDbContext _context;

        public HomeController(PaginationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 3;

            return View(await PaginatedList<Pagination>.CreateAsync(
                _context.Paginations.AsQueryable(), page ?? 1, pageSize));

        }
    }
}
