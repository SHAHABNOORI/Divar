using Microsoft.AspNetCore.Mvc;
using Divar.Core.ApplicationService.Advertisements.CommandHandlers;
using Divar.Core.Commands.Advertisements.Commands;

namespace Divar.EndPoints.Api.Controllers.Advertisements
{
    [ApiController]
    [Route("[controller]")]
    public class AdvertisementController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromServices] CreateHandler handler, CreateCommand request)
        {
            handler.Handle(request);
            return Ok();
        }

        [Route("title")]
        [HttpPut]
        public IActionResult Put([FromServices] UpdateTitleHandler handler, UpdateTitleCommand request)
        {
            handler.Handle(request);
            return Ok();
        }

        [Route("text")]
        [HttpPut]
        public IActionResult Put([FromServices] UpdateDescriptionHandler handler, UpdateDescriptionCommand request)
        {
            handler.Handle(request);
            return Ok();
        }

        [Route("price")]
        [HttpPut]
        public IActionResult Put([FromServices] UpdatePriceHandler handler, UpdatePriceCommand request)
        {
            handler.Handle(request);
            return Ok();
        }

        [Route("publish")]
        [HttpPut]
        public IActionResult Put([FromServices] RequestToPublishHandler handler, RequestToPublishCommand request)
        {
            handler.Handle(request);
            return Ok();
        }
    }
}
