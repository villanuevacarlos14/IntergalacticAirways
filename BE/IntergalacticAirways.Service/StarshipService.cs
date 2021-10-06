using AutoMapper;
using IntergalacticAirways.DTO;
using IntergalacticeAirways.DataAccess.Contract;
using IntergalacticeAirways.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticAirways.Service
{
    public interface IStarshipService 
    {
        Task<IEnumerable<StarshipDTO>> RetrieveStarships(int passengerCount);
    }
    public class StarshipService : IStarshipService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public StarshipService(IRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<StarshipDTO>> RetrieveStarships(int passengerCount)
        {
            //do crazy things here for the business logic
            //really not sure about this: cant find a way to query all starships data w/o it being paginated 
            //tried looking for a filter also on swapi documentation but they only provide filtering it out by name?
            //So to get all the data, I dont know of another way but to loop through the paginated response? I really think this is wrong :D (- points :'()
            var list = new List<StarshipDTO>();
            var response = await _repository.Retrieve<IntergalacticeAirways.DataAccess.Model.Response.StarshipResponse>("https://swapi.dev/api/starships");
            list.AddRange(_mapper.Map<IEnumerable<StarshipDTO>>(response.Results));
            while (!string.IsNullOrEmpty(response.Next))
            {
                //sorry swapi for bombarding you with requests XD
                //this approach probably will fail 
                //implement Polly retries?
                var nextResp = await _repository.Retrieve<IntergalacticeAirways.DataAccess.Model.Response.StarshipResponse>(response.Next);
                list.AddRange(_mapper.Map<IEnumerable<StarshipDTO>>(nextResp.Results));
                response.Next = nextResp.Next;
            }

            //some of the passengers that is returned by the api are strings, filter them out :D
            var getOnlyStarshipsThatHavePassengersAndCanAccomodatePassengerCount = list.Where(x => {
                if (int.TryParse(x.Passengers, out int v))
                {
                    if (v >= passengerCount)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            })
            .ToList();

            return getOnlyStarshipsThatHavePassengersAndCanAccomodatePassengerCount;
        }
    }
}
