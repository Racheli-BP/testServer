using Microsoft.AspNetCore.Http;
using Services.Entities;
using System.Collections;

namespace Services
{
    public interface IPerson
    {

        public Task<IEnumerable<object>[]> AddPeople(IFormFile file);

    }
}