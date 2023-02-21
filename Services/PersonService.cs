using AutoMapper;
using Common;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using Services;
using Services.Entities;
using System;
using System.Collections;
using System.Net.Http.Json;

namespace testServer
{
    public class PersonService:IPerson
    {
        static HttpClient http = new HttpClient();
        private readonly IMapper _mapper;

        public PersonService(IMapper mapper)
        {
            http.BaseAddress = new Uri("https://api-sq.azurewebsites.net");
            _mapper = mapper;
        }

        public async Task<IEnumerable<object>[]> AddPeople(IFormFile file)
        {
            HttpResponseMessage response;
            IEnumerable<Person> people = _mapper.Map<List<Person>>(((ExcelWorksheet)file).ConvertSheetToObjects<PersonModel>());
            
            List<Person> answer = new List<Person>();
            List<PersonModel> notValid = new List<PersonModel>();

            foreach (Person person in people)
            {
                if (Validations.IsValidTZ(person.Tz))
                {
                    response = await http.PostAsJsonAsync("api/People", person);
                    response.EnsureSuccessStatusCode();
                    answer.Add(await response.Content.ReadFromJsonAsync<Person>());
                }
                else notValid.Add(_mapper.Map<PersonModel>(person));
            }

            IEnumerable<object>[] arr = { answer, notValid };
            return arr;
        }




    }
}
