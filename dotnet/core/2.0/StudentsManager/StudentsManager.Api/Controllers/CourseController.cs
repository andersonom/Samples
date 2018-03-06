using System.Collections.Generic; 
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using StudentManager.Domain.Interfaces.Repositories; 
using StudentsManager.Domain.Bases;
using StudentsManager.Domain.Models;

namespace StudentsManager.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Course")]
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        // GET: api/Course
        [HttpGet("Paged")]
        public async Task<PaginatedList<Course>> Get(int? pageSize, int? page)
        {
            return await _courseRepository.GetCoursesPagedAsync(pageSize, page);
        }

        [HttpGet]
        public async Task<IEnumerable<Course>> Get()
        {
            return await _courseRepository.GetCoursesAsync();
        }

        // GET: api/Course
        [HttpGet("name/{name}")]
        public async Task<PaginatedList<Course>> GetByName(string name, int? pageSize, int? page)
        {
            return await _courseRepository.GetCoursesPagedByNameAsync(name, pageSize, page);
        }

        // GET: api/Course/5
        [HttpGet("{id}")]//, Name = "Get"
        public async Task<Course> Get(int id)
        {
            return await _courseRepository.GetByIdAsync(id);
        }

        // POST: api/Course
        [HttpPost]
        public async void Post([FromBody]Course course)
        {
            await _courseRepository.AddAsync(course);
        }

        // PUT: api/Course/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody]Course course)
        {
            await _courseRepository.UpdateAsync(id, course);
        }

        // DELETE: api/Course/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _courseRepository.Remove(id);
        }

    }
}
