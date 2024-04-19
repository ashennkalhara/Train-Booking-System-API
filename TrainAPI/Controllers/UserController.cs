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
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult CreateUser(UserCreateDTO userCreateDTO)
        {
            var user = _mapper.Map<User>(userCreateDTO);
            if (_userRepository.CreateUser(user))
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<UserReadDTO> GetUser(int id)
        {
            var user = _userRepository.GetUser(id);
            if (user != null)
                return Ok(_mapper.Map<UserReadDTO>(user));
            else
                return NotFound();
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserReadDTO>> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            return Ok(_mapper.Map<IEnumerable<UserReadDTO>>(users));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var user = _userRepository.GetUser(id);
            if (user != null)
            {
                _userRepository.RemoveUser(user);
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, UserCreateDTO updateDTO)
        {
            var user = _mapper.Map<User>(updateDTO);
            user.UserId = id;
            if (_userRepository.UpdateUser(user))
                return Ok();
            else
                return NotFound();
        }

        [HttpPost("Login")]
        public ActionResult Login([FromBody] LoginDTO loginDTO)
        {
            if (loginDTO == null || string.IsNullOrWhiteSpace(loginDTO.Username) || string.IsNullOrWhiteSpace(loginDTO.Password))
            {
                return BadRequest("Username and password are required.");
            }

            bool isValidUser = _userRepository.IsValidUser(loginDTO.Username, loginDTO.Password);

            if (isValidUser)
            {
                return Ok("Login successful.");
            }
            else
            {
                return Unauthorized("Invalid username or password.");
            }
        }

    }
}
