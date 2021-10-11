using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticAirways.DTO
{
    public class ResultOrError<T> where T : class
    {
        public T Data { get; set; }
        public bool IsError { get; set; }
        public Exception Error { get; set; }
    }
}
