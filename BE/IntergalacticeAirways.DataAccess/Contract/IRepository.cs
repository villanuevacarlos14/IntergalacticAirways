using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticeAirways.DataAccess.Contract
{
    public interface IRepository
    {
        Task<T> Retrieve<T>(string url) where T : class;
    }
}
