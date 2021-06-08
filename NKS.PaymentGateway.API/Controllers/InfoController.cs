namespace NKS.Payments.API.Controllers
{
    using Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class InfoController : Controller
    {
        [HttpGet]
        public ActionResult<InfoModel> Get()
        {
            return Ok(new InfoModel());
        }
    }
}
