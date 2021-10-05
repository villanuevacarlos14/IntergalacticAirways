using IntergalacticAirways.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IntergalacticAirways.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarshipController : ControllerBase
    {
        private readonly IStarshipService _starshipService;
        public StarshipController(IStarshipService starshipService) 
        {
            _starshipService = starshipService;
        }
 
        [HttpGet("{passengerCount}")]
        public async Task<IActionResult> Get(int passengerCount)
        {
            //there are probably more things I can do to this like logging, errorhandling but 
            //Hadn't got much time to implement because the swapi external api ate too much time and Im not really sure if I did retreive the data correctly XD
            var resp = await _starshipService.RetrieveStarships(passengerCount);
            return Ok(resp);
        }
    }
}
