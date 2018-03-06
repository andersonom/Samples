using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManager.Domain.Interfaces.Repositories;
using StudentsManager.Domain.Models;
using StudentsManager.Domain.Bases;

namespace StudentsManager.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Student")]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;          
        }

        // GET: api/Student
        [HttpGet]
        public async Task<PaginatedList<Student>> Get(int? pageSize, int? page)
        {
            return await _studentRepository.GetStudentsPagedAsync(pageSize, page);
        }

        // GET: api/Student
        [HttpGet("name/{name}")] 
        public async Task<PaginatedList<Student>> GetByName(string name, int? pageSize, int? page)
        {
            return await _studentRepository.GetStudentsPagedByNameAsync(name, pageSize, page);
        }

        // GET: api/Student/5
        [HttpGet("{id}")]//, Name = "Get"
        public async Task<Student> Get(int id)
        {
            return await _studentRepository.GetStudentByIdAsync(id);                       
        }

        // POST: api/Student
        [HttpPost]
        public async void Post([FromBody]Student student)
        {
            await _studentRepository.AddAsync(student);
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody]Student student)
        {
            await _studentRepository.UpdateAsync(id, student);
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
             _studentRepository.Remove(id);
        }
    }
}
