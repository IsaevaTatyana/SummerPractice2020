using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeMyLibraryDAT
{
    public interface IBookingDAO
    {
        IEnumerable<Booking> GetBookings();

        void AddBooking(Booking booking);

        void RemoveBooking(int BookingID);
    }
}
