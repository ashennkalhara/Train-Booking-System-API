using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrainAPI.Data;
using TrainAPI.DTO;
using TrainAPI.Model;

namespace TrainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController:Controller
    {
        private readonly IMapper mapper;
        private readonly BookingRepository repository;

        public BookingController(BookingRepository bookingRepository, IMapper _mapper)
        {
            this.repository = bookingRepository;
            mapper = _mapper;
        }


        [HttpPost]
        public ActionResult CreateBooking(BookingCreateDTO bookingCreate)
        {
            var booking = mapper.Map<Booking>(bookingCreate);
            if (repository.CreateBooking(booking))
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookingReadDTO>> GetBookings()
        {
            var bookings = repository.GetBookings();
            return Ok(mapper.Map<IEnumerable<BookingReadDTO>>(bookings));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBooking(int id)
        {
            var booking = repository.GetBooking(id);
            if (booking != null)
            {
                repository.RemoveBooking(booking);
                return Ok();
            }
            else
                return NotFound();
        }


    }
}
