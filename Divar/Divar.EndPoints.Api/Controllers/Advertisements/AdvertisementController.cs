//using Microsoft.AspNetCore.Mvc;
//namespace Divar.EndPoints.Api.Controllers.Advertisements
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class AdvertisementController : ControllerBase
//    {
//        [HttpPost]
//        public IActionResult Post([FromServices] CreateHandler handler, CreateCommand request)
//        {
//            handler.Handle(request);
//            return Ok();
//        }

//        [Route("title")]
//        [HttpPut]
//        public IActionResult Put([FromServices] SetTitleHandler handler, SetTitle request)
//        {
//            handler.Handle(request);
//            return Ok();
//        }

//        [Route("text")]
//        [HttpPut]
//        public IActionResult Put([FromServices] UpdateTextHandler handler, UpdateText request)
//        {
//            handler.Handle(request);
//            return Ok();
//        }

//        [Route("price")]
//        [HttpPut]
//        public IActionResult Put([FromServices] UpdatePriceHandler handler, UpdatePrice request)
//        {
//            handler.Handle(request);
//            return Ok();
//        }

//        [Route("publish")]
//        [HttpPut]
//        public IActionResult Put([FromServices] RequestToPublishHandler handler, RequestToPublish request)
//        {
//            handler.Handle(request);
//            return Ok();
//        }
//    }
//}
