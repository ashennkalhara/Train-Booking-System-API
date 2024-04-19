using TrainAPI.Model;

namespace TrainAPI.Data
{
    public class BookingRepository
    {
        private AppDBContext dbContext;

        public BookingRepository(AppDBContext context)
        {
            dbContext = context;
        }

        public bool CreateBooking(Booking booking)
        {
            if (booking != null)
            {
                dbContext.bookings.Add(booking);
                return Save();
            }
            else
                return false;
        }

        public bool Save()
        {
            int count = dbContext.SaveChanges();
            if (count > 0)
                return true;
            else
                return false;
        }

        public IEnumerable<Booking> GetBookings()
        {
            return dbContext.bookings.ToList();
        }


        public Booking GetBooking(int id)
        {
            return dbContext.bookings.FirstOrDefault(booking => booking.BookingId == id);
        }

        public bool RemoveBooking(Booking booking)
        {
            dbContext.bookings.Remove(booking);
            return Save();
        }
    }
}
