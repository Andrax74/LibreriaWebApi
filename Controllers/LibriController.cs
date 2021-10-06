using System.Collections.Generic;
using LibreriaWebApi.Models;
using LibreriaWebApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaWebApi.Controllers 
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/libri")]
    public class LibriController : Controller
    {
        private readonly ILibriRepository libriRepository;

        public LibriController(ILibriRepository libriRepository)
        {
            this.libriRepository = libriRepository;
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Libri>))]
        public ActionResult<IEnumerable<Libri>> GetLibri()
        {
            var libri =  this.libriRepository.SelAll();
            
            if (libri.Count == 0)
            {
                return NotFound(new ErrMsg(string.Format("Non è stato trovato alcun libro"),"404"));
            }

            return Ok(libri);
        }

    }
}