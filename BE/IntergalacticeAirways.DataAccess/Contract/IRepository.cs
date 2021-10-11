using IntergalacticAirways.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticeAirways.DataAccess.Contract
{
    public interface IRepository
    {
        Task<ResultOrError<T>> Retrieve<T>(string url) where T : class;
    }
}
