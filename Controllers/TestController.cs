using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaWebApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("test")]
    public class TestController : Controller
    {
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public  ActionResult<string> GetOkStatusAsync()
        {
            Console.WriteLine(DateTime.Now);
            Console.WriteLine($"***** Verifica Funzionamento Web Api *****");

            return Ok("Status Web Api OK");
        }
    }
}