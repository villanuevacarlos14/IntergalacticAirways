using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticeAirways.DataAccess.Model
{
    public class Starship
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Passengers { get; set; }
        public IEnumerable<string> Pilots { get; set; }
    }
}
