﻿using MovieTicket.ModelHelper.DTO;

namespace MovieTicket.BusinessService.Services.Interface
{
    public interface IBookingService
    {
        Task<List<BookingDto>> GetAllBookingNameAsync();
        Task<int> AddToBookingAsync(AddBookingDto bookingDto);
        Task<bool> UpdateBookingAsync(UpdateBookingDto bookingDto);
        Task<bool> DeleteBookingAsync(int bookingId);
    }
}
