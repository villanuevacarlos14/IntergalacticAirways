using AutoMapper;
using IntergalacticAirways.DTO;
using IntergalacticeAirways.DataAccess.Contract;
using IntergalacticeAirways.DataAccess.Model;
using IntergalacticeAirways.DataAccess.Model.Response;
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
            var result = new ResultOrError<IEnumerable<StarshipDTO>>();
           
            //call the api first so I can get the total number of data
            var response = await _repository.Retrieve<IntergalacticeAirways.DataAccess.Model.Response.StarshipResponse>("https://swapi.dev/api/starships");

            //if first api call is error throw the error
            if (response.IsError) 
            {
                throw response.Error;
            }
            
            //calculate total pages
            var totalPages = (int)Math.Ceiling((double)response.Data.Count / 10);

            //initialise the list of tasks
            var listOfTasks = new List<Task<ResultOrError<StarshipResponse>>>();

            //loop through total pages
            for (int x = 1; x <= totalPages; x++) 
            {
                //sorry swapi for bombarding you with requests XD
                listOfTasks.Add(_repository.Retrieve<StarshipResponse>($"https://swapi.dev/api/starships/?page={x}"));
            }

            var results = (await Task.WhenAll(listOfTasks)).ToList();
            var list = new List<StarshipDTO>();
            results.ForEach(res => {

                //can handle the error here
                if (res.IsError)
                {
                    //
                    //handle error here maybe implement a retry?
                    //or just throw the error to stop the appliocation
                }
                else 
                {
                    list.AddRange(_mapper.Map<IEnumerable<StarshipDTO>>(res.Data.Results));
                }

            });


            /// this can be handled with a setting on the startup pipeline or modify the set/get of the property
            /// setting up the json serialization but didnt want to spend more time :D
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
              
                return false;
            });

            return getOnlyStarshipsThatHavePassengersAndCanAccomodatePassengerCount.ToList();
        }
    }
}
