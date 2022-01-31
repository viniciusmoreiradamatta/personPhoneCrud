using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {
        private readonly IPersonFacade _personFacade;

        public PersonController(IPersonFacade personFacade)
        {
            _personFacade = personFacade;
        }

        [HttpGet]
        public async Task<ActionResult<PersonListResponse>> Get() => Response(await _personFacade.FindAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonResponse>> Get(int id) => Response(await _personFacade.FindById(id));

        [HttpPost]
        public async Task<IActionResult> Post(PersonRequest person)
        {
            var newPerson = await _personFacade.Add(person);

            return Response(newPerson.PersonObject.Id, newPerson);
        }

        [HttpPut]
        public async Task<IActionResult> Put(PersonRequest person)
        {
            var newPerson = await _personFacade.Modify(person);

            return Response(newPerson.PersonObject.Id, newPerson);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var newPerson = await _personFacade.Delete(id);

            return Response(newPerson.PersonObject.Id, newPerson);
        }
    }
}