

using Microsoft.AspNetCore.Mvc;

namespace ApiAppPetrol
{

[ApiController]
    public class ErrorController : ControllerBase
    {
    
        [Route("/error")]
        public IActionResult Error() => Problem();
    }


}