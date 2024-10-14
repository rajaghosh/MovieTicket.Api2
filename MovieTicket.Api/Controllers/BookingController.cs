using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.BusinessService.Services.Interface;
using MovieTicket.ModelHelper.DTO;
using MovieTicketApi.Helper;
using System.Net;

namespace MovieTicket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeRole("All")]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly ITheatreService _theatreService;
        private readonly ITheatreScreenService _theatreScreenService;
        public BookingController(IBookingService bookingService, ITheatreService theatreService, ITheatreScreenService theatreScreenService)
        {
            _bookingService = bookingService;
            _theatreService = theatreService;
            _theatreScreenService = theatreScreenService;
        }

        [HttpGet("GetAllBookings")]
        public async Task<List<BookingDto>> GetAll()
        {
            var bookings = await _bookingService.GetAllBookingNameAsync();
            return bookings;
        }

        [HttpPost("AddNewBooking")]
        public async Task<HttpStatusCode> PostMovie([FromBody] AddBookingDto bookingDto)
        {
            var res = await _bookingService.AddToBookingAsync(bookingDto);
            return res > 0 ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
        }


        [HttpPost("AddNewBookingPdf")]
        public async Task<IActionResult> PostMoviePdf([FromBody] AddBookingDto bookingDto)
        {
            var res = await _bookingService.AddToBookingAsync(bookingDto);
            //return res == true ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;

            if (res > 0)
            {
                var screens = await _theatreScreenService.GetAllCoreTheatreScreenAsync();
                var screen = screens.Where(p => p.Id == bookingDto.ScreenId).First();

                var theatres = await _theatreService.GetAllCoreTheatreNameAsync();
                var theatreName = theatres.Where(p => p.Id == screen.TheatreId).First();

                // Create a new PDF document
                var document = new Document();

                // Create a memory stream to store the PDF
                var memoryStream = new MemoryStream();

                // Create a PDF writer
                var pdfWriter = PdfWriter.GetInstance(document, memoryStream);

                // Open the document
                document.Open();

                // Add text to the PDF
                var paragraph = new Paragraph($"Ticket Booked (Booking Id - {res.ToString()}) for {bookingDto.DoneFor}");
                document.Add(paragraph);
                paragraph = new Paragraph($"Seat Alloted : {bookingDto.Row.ToString()} {bookingDto.SeatNo}");
                document.Add(paragraph);
                paragraph = new Paragraph($"Show Timing : {bookingDto.BookingDateTime.ToString("MM/dd/yyyy")} at {bookingDto.BookingDateTime.ToString("HH:mm")}");
                document.Add(paragraph);

                paragraph = new Paragraph($"Theatre/Screen/Location : {theatreName.Name} / {screen.ScreenName} / {theatreName.Location}");
                document.Add(paragraph);

                // Close the document
                document.Close();
                // Set response headers
                return File(memoryStream.ToArray(), "application/pdf", "Booking.pdf");
            }
            else
            {
                // Create a new PDF document
                var document = new Document();

                // Create a memory stream to store the PDF
                var memoryStream = new MemoryStream();

                // Create a PDF writer
                var pdfWriter = PdfWriter.GetInstance(document, memoryStream);

                // Open the document
                document.Open();

                // Add text to the PDF
                var paragraph = new Paragraph($"Ticket Booked Not Possible Now");
                document.Add(paragraph);

                // Close the document
                document.Close();
                // Set response headers
                return File(memoryStream.ToArray(), "application/pdf", "Booking.pdf");
            }

        }

        //public IActionResult DownloadPDF()
        //{
        //    //using (var stream = new MemoryStream())
        //    //{
        //    //    using (var pdfDoc = new Document())
        //    //    {
        //    //        PdfWriter.GetInstance(pdfDoc, stream);
        //    //        pdfDoc.Open();

        //    //        // Add content to the PDF (e.g., using iTextSharp methods)
        //    //        var paragraph = new Paragraph("Hello, World!");
        //    //        pdfDoc.Add(paragraph);

        //    //        pdfDoc.Close();
        //    //    }

        //    //    stream.Position = 0;
        //    //    return File(stream, "application/pdf", "mypdf.pdf");
        //    //}

        //    // Create a new PDF document
        //    var document = new Document();

        //    // Create a memory stream to store the PDF
        //    var memoryStream = new MemoryStream();

        //    // Create a PDF writer
        //    var pdfWriter = PdfWriter.GetInstance(document, memoryStream);

        //    // Open the document
        //    document.Open();

        //    // Add text to the PDF
        //    var paragraph = new Paragraph("Hello, World!");
        //    document.Add(paragraph);
        //    paragraph = new Paragraph("Hello, World!");
        //    document.Add(paragraph);


        //    // Close the document
        //    document.Close();
        //    // Set response headers
        //    return File(memoryStream.ToArray(), "application/pdf", "mypdf.pdf");
        //}


        [HttpPut("UpdateBooking")]
        public async Task<HttpStatusCode> PutMovie(UpdateBookingDto bookingDto)
        {
            var res = await _bookingService.UpdateBookingAsync(bookingDto);
            return res == true ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
        }

        [HttpDelete("DeleteBooking")]
        public async Task<HttpStatusCode> Delete(int bookingId)
        {
            var res = await _bookingService.DeleteBookingAsync(bookingId);
            return res == true ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
        }
    }
}
