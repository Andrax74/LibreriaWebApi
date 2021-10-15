using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using LibreriaWebApi.Dtos;
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
        private readonly IMapper mapper;
        public LibriController(ILibriRepository libriRepository,  IMapper mapper)
        {
            this.libriRepository = libriRepository;
            this.mapper = mapper;
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<LibriDto>))]
        public async Task<ActionResult<IEnumerable<LibriDto>>> GetLibriAsync()
        {
            Console.WriteLine(DateTime.Now);
            Console.WriteLine($"***** Ottenimento dati libri *****");

            var libri =  this.libriRepository.SelAll();
            var libriDto = new List<LibriDto>();

            Console.WriteLine($"Numero di record: {libri.Count}");

            if (libri.Count == 0)
            {
                return NotFound(new ErrMsg(string.Format("Non è stato trovato alcun libro"),"404"));
            }
            else
            {
                foreach (var libro in libri)
                {
                    double Prezzo = await this.getPriceArtAsync(libro.Isbn);
                    LibriDto libroDto =  mapper.Map<LibriDto>(libro);
                    libroDto.Prezzo = Prezzo;

                    libriDto.Add(libroDto);
                    
                }
            }

            return Ok(libriDto);
        }

        private async Task<double> getPriceArtAsync(string Isbn)
        {
            var priceApiUri = System.Environment.GetEnvironmentVariable("PRICE_API_URI");

            double prezzo = 0;

            using (var client = new HttpClient())
            {

                try
                {
                    Console.WriteLine($"***** Ottenimento il prezzo dalla PrezziWebApi *****");
                    string endPoint = priceApiUri + "/api/prezzi/" + Isbn;

                    Console.WriteLine($"End Point: {endPoint}");
                    var result = await client.GetAsync(endPoint);
                    
                    Console.WriteLine($"{result}");
                    var response = await result.Content.ReadAsStringAsync();
                    prezzo = Convert.ToDouble(response.Replace(".",","));

                    Console.WriteLine($"Prezzo Ottenuto: {prezzo}");
                }
                catch (HttpRequestException ex)
                {
                    throw new Exception("Errore: Impossibile contattare il servizio PriceArt. " + ex.Message);
                }
                
            }

            return prezzo;
        }

    }
}