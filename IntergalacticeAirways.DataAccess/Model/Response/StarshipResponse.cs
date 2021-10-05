using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticeAirways.DataAccess.Model.Response
{
    public class StarshipResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public IEnumerable<Starship> Results { get; set; }
    }
}
