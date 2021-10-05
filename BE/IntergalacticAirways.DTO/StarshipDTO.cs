using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticAirways.DTO
{
    public class StarshipDTO
	{
			// "name": "CR90 corvette",
			//"model": "CR90 corvette",
			//"manufacturer": "Corellian Engineering Corporation",
			//"cost_in_credits": "3500000",
			//"length": "150",
			//"max_atmosphering_speed": "950",
			//"crew": "30-165",
			//"passengers": "600",
			//"cargo_capacity": "3000000",
			//"consumables": "1 year",
			//"hyperdrive_rating": "2.0",
			//"MGLT": "60",
			//"starship_class": "corvette",
			//"pilots": [],
			//"films": [
			//	"https://swapi.dev/api/films/1/",
			//	"https://swapi.dev/api/films/3/",
			//	"https://swapi.dev/api/films/6/"
			//],
			//"created": "2014-12-10T14:20:33.369000Z",
			//"edited": "2014-12-20T21:23:49.867000Z",
			//"url": "https://swapi.dev/api/starships/2/"
			public string Name { get; set; }
			public string Model { get; set; }
			public string Manufacturer { get; set; }
			public string Passengers { get; set; }
			public IEnumerable<string> Pilots { get; set; }
	}
}
