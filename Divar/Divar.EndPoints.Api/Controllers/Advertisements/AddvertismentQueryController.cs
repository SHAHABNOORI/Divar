using Divar.Core.Domain.Advertisements.Data;
using Divar.Core.Queries.Advertisements.Queries;
using Microsoft.AspNetCore.Mvc;


namespace Divar.EndPoints.Api.Controllers.Advertisements
{
    [ApiController]
    [Route("[controller]")]
    public class AddvertismentQueryController : ControllerBase
    {
        private readonly IAdvertisementQueryService _service;

        public AddvertismentQueryController(IAdvertisementQueryService service)
        {
            _service = service;
        }


        [HttpGet]
        public IActionResult Get([FromQuery]GetActiveAdvertisement request)
        {
            return new OkObjectResult(_service.Query(request));
        }
    }
}
