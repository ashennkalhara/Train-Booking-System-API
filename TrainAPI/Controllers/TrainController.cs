using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TrainAPI.DTO;
using TrainAPI.Model;
using TrainAPI.Data;
using System.Collections.Generic;

namespace TrainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly TrainRepository repository;

        public TrainController(TrainRepository trainRepository, IMapper _mapper)
        {
            this.repository = trainRepository;
            mapper = _mapper;
        }

        [HttpPost]
        public ActionResult CreateTrain(TrainCreateDTO trainCreate)
        {
            var train = mapper.Map<Train>(trainCreate);
            if (repository.CreateTrain(train))
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet("{id}", Name = "GetTrainByID")]
        public ActionResult<TrainReadDTO> GetTrain(int id)
        {
            var train = repository.GetTrain(id);
            if (train != null)
                return Ok(mapper.Map<TrainReadDTO>(train));
            else
                return NotFound();
        }

        [HttpGet]
        public ActionResult<IEnumerable<TrainReadDTO>> GetTrains()
        {
            var trains = repository.GetTrains();
            return Ok(mapper.Map<IEnumerable<TrainReadDTO>>(trains));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTrain(int id)
        {
            var train = repository.GetTrain(id);
            if (train != null)
            {
                repository.RemoveTrain(train);
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTrain(int id, TrainCreateDTO updateDTO)
        {
            var train = mapper.Map<Train>(updateDTO);
            train.TrainId = id;
            if (repository.UpdateTrain(train))
                return Ok();
            else
                return NotFound();
        }

        [HttpPost("Search")]
        public ActionResult<IEnumerable<TrainReadDTO>> SearchTrains([FromBody] SearchDTO searchDTO)
        {
            var trains = repository.SearchTrains(searchDTO.StartStation, searchDTO.DestinationStation, searchDTO.Date);

            if (trains != null)
            {
                return Ok(mapper.Map<IEnumerable<TrainReadDTO>>(trains));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
