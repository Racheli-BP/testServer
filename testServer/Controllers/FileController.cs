using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Collections;

namespace testServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly PersonService _personService;

        public FileController(PersonService personService)
        {
           _personService = personService;
        }

        // POST api/<FileController>
        [HttpPost]
        public async Task<IEnumerable[]> Post(IFormFile file)
        {
            return await _personService.AddPeople(file);
        }

        // PUT api/<FileController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
