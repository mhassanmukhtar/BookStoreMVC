using BookStoreMVC.Models;

namespace BookStoreMVC.DLLs
{
    public interface IBookingDLL
    {
        Task<bool> CreateBooking(Booking booking, string uri);
    }
}
