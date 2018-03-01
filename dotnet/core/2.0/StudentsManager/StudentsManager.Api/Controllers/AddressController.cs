using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManager.Domain.Interfaces.Repositories;
using StudentsManager.Domain.Models;

namespace StudentsManager.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Address")]
    public class AddressController : Controller
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        // GET: api/Student/5
        [HttpGet("{id}")]//, Name = "Get"
        public async Task<Address> Get(int id)
        {
            return await _addressRepository.GetByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async void Put(int id, [FromBody]Address address)
        {
            await _addressRepository.UpdateAsync(id, address);
        }
    }
}