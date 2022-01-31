using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberTypeController : BaseController
    {
        private readonly IPhoneNumberTypeFacade _phoneNumberTypeFacade;

        public PhoneNumberTypeController(IPhoneNumberTypeFacade phoneNumberTypeFacade)
        {
            _phoneNumberTypeFacade = phoneNumberTypeFacade;
        }

        [HttpGet]
        public async Task<ActionResult<PhoneNumberTypeResponse>> Get() =>
            Response(await _phoneNumberTypeFacade.FindAllAsync());
    }
}