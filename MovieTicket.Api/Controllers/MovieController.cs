using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.BusinessService.LoggerFactory;
using MovieTicket.BusinessService.Services.Interface;
using MovieTicket.ModelHelper.DTO;
using MovieTicketApi.Helper;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Document = iTextSharp.text.Document;

namespace MovieTicket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeRole("All")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ITheatreService _theatreService;
        private readonly IMovieListingService _movieListingService;
        private readonly ITheatreScreenService _theatreScreenService;
        private readonly ICustomLogger _logger;

        public MovieController(IMovieService movieService,
                                ICustomLogger logger,
                                ITheatreService theatreService,
                                IMovieListingService movieListingService,
                                ITheatreScreenService theatreScreenService)
        {
            _movieService = movieService;
            _logger = logger;
            _theatreService = theatreService;
            _movieListingService = movieListingService;
            _theatreScreenService = theatreScreenService;
        }

        [HttpGet("DownloadPDF")]
        public IActionResult DownloadPDF()
        {
            //using (var stream = new MemoryStream())
            //{
            //    using (var pdfDoc = new Document())
            //    {
            //        PdfWriter.GetInstance(pdfDoc, stream);
            //        pdfDoc.Open();

            //        // Add content to the PDF (e.g., using iTextSharp methods)
            //        var paragraph = new Paragraph("Hello, World!");
            //        pdfDoc.Add(paragraph);

            //        pdfDoc.Close();
            //    }

            //    stream.Position = 0;
            //    return File(stream, "application/pdf", "mypdf.pdf");
            //}

            // Create a new PDF document
            var document = new Document();

            // Create a memory stream to store the PDF
            var memoryStream = new MemoryStream();

            // Create a PDF writer
            var pdfWriter = PdfWriter.GetInstance(document, memoryStream);

            // Open the document
            document.Open();

            // Add text to the PDF
            var paragraph = new Paragraph("Hello, World!");
            document.Add(paragraph);
            paragraph = new Paragraph("Hello, World!");
            document.Add(paragraph);


            // Close the document
            document.Close();
            // Set response headers
            return File(memoryStream.ToArray(), "application/pdf", "mypdf.pdf");
        }



        [HttpGet("GetAllMovie")]
        public async Task<ResponseDto<List<MovieDto>>> GetAll()
        {
            ResponseDto<List<MovieDto>> resp = new ResponseDto<List<MovieDto>>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Result = new List<MovieDto>()
            };

            _logger.InfoLog($"Calling GetAllMovie API started by Id/Role: {HttpContext.UserDetails()}");

            try
            {
                _logger.InfoLog($"Calling GetAllMovieNameAsync service");
                var movies = await _movieService.GetAllMovieNameAsync();

                if (movies.Any())
                {
                    _logger.InfoLog($"Info retrieved successfully for GetAllMovie Api");
                    resp.StatusCode = HttpStatusCode.OK;
                    resp.Result = movies;
                }
                else
                {
                    _logger.InfoLog($"No data retrieved for GetAllMovie Api");
                    resp.StatusCode = HttpStatusCode.NotFound;
                    resp.Result = null;
                    resp.ErrorMessage = "No data retrieved during API execution!. Please check logs";
                }
            }
            catch (Exception ex)
            {
                _logger.ErrorLog($"Exception occurred for GetAllMovie Api. Details {ex.Message}");
                resp.StatusCode = HttpStatusCode.InternalServerError;
                resp.Result = null;
                resp.ErrorMessage = "Exception occurred during API execution!. Please check logs";
            }

            return resp;
        }


        [HttpPost("SearchMovieAtLocation")]
        public async Task<ResponseDto<List<MovieSearchDto>>> SearchMovie([FromQuery][Required] string location)
        {
            ResponseDto<List<MovieSearchDto>> resp = new ResponseDto<List<MovieSearchDto>>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Result = new List<MovieSearchDto>()
            };

            _logger.InfoLog($"Calling SearchMovieAtLocation API started by Id/Role: {HttpContext.UserDetails()}");

            try
            {
                _logger.InfoLog($"Calling AddToMovieAsync service");
                var theatres = await _theatreService.GetAllCoreTheatreNameAsync();
                var theatresAtLocation = theatres.Where(p => p.Location.ToLower().Equals(location.ToLower())).ToList();

                var theatreIdsAtLoc = theatresAtLocation.Select(p => p.Id).ToList();

                var theatreScreens = await _theatreScreenService.GetAllCoreTheatreScreenAsync();
                var screensAtLocation = theatreScreens.Where(p => theatreIdsAtLoc.Contains(p.TheatreId)).ToList();
                var screenIdsAtLoc = screensAtLocation.Select(p => p.Id).ToList();

                var movieListings = await _movieListingService.GetAllCoreMovieListingAsync();
                var movieListingsAtLocation = movieListings.Where(p => screenIdsAtLoc.Contains(p.ScreenId)).ToList();
                var movieIds = movieListingsAtLocation.Select(p => p.Id).ToList();

                var movies = await _movieService.GetSpecificMovieDetailsAsync(movieIds);

                List<MovieSearchDto> search = new List<MovieSearchDto>();

                if (movies.Any())
                {
                    foreach (var movie in movies)
                    {
                        var screens1 = movieListingsAtLocation.Where(p => p.MovieId == movie.Id).Select(p => p.ScreenId).Distinct().ToList() ?? new List<int>();
                        var theatres1 = theatreScreens.Where(p => screens1.Contains(p.TheatreId)).Select(p => p.TheatreId).Distinct().ToList() ?? new List<int>();

                        MovieSearchDto searchObj = new MovieSearchDto()
                        {
                            Name = movie.Name,
                            Language = movie.Language,
                            RunTime = movie.RunningMin,
                            Location = location.ToUpper(),
                            TheatreIds = theatres1,
                            ScreenIds = screens1
                        };
                        search.Add(searchObj);
                    }

                    _logger.InfoLog($"Info retrieved successfully for GetAllMovie Api");
                    resp.StatusCode = HttpStatusCode.OK;
                    resp.Result = search;
                }
                else
                {
                    _logger.InfoLog($"No data retrieved for GetAllMovie Api");
                    resp.StatusCode = HttpStatusCode.NotFound;
                    resp.Result = null;
                    resp.ErrorMessage = "No data retrieved during API execution!. Please check logs";
                }
            }
            catch (Exception ex)
            {
                _logger.ErrorLog($"Exception occurred for AddNewMovie Api. Details {ex.Message}");
                resp.StatusCode = HttpStatusCode.InternalServerError;
                resp.Result = null;
                resp.ErrorMessage = "Exception occured during API execution!. Please check logs";
            }

            return resp;
        }


        [HttpPost("AddNewMovie")]
        public async Task<ResponseDto<string>> PostMovie([FromBody] AddMovieDto movieDto)
        {
            ResponseDto<string> resp = new ResponseDto<string>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Result = String.Empty
            };

            _logger.InfoLog($"Calling AddNewMovie API started by Id/Role: {HttpContext.UserDetails()}");

            try
            {
                _logger.InfoLog($"Calling AddToMovieAsync service");
                var res = await _movieService.AddToMovieAsync(movieDto);

                if (res)
                {
                    _logger.InfoLog($"Info added successfully for AddNewMovie Api");
                    resp.StatusCode = HttpStatusCode.OK;
                    resp.Result = "Movie Info Added Successfully";
                }
                else
                {
                    _logger.InfoLog($"No data added for AddNewMovie Api");
                    resp.StatusCode = HttpStatusCode.NotFound;
                    resp.Result = null;
                    resp.ErrorMessage = "Error occured during API execution!. Please check logs";
                }
            }
            catch (Exception ex)
            {
                _logger.ErrorLog($"Exception occurred for AddNewMovie Api. Details {ex.Message}");
                resp.StatusCode = HttpStatusCode.InternalServerError;
                resp.Result = null;
                resp.ErrorMessage = "Exception occured during API execution!. Please check logs";
            }

            return resp;
        }

        [HttpPut("UpdateMovie")]
        public async Task<ResponseDto<string>> PutMovie([FromBody] UpdateMovieDto movieDto)
        {
            ResponseDto<string> resp = new ResponseDto<string>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Result = String.Empty
            };

            _logger.InfoLog($"Calling UpdateMovie API started by Id/Role: {HttpContext.UserDetails()}");

            try
            {
                _logger.InfoLog($"Calling UpdateMovieAsync service");
                var res = await _movieService.UpdateMovieAsync(movieDto);

                if (res)
                {
                    _logger.InfoLog($"Info updated successfully for UpdateMovie Api");
                    resp.StatusCode = HttpStatusCode.OK;
                    resp.Result = "Movie Info Updated Successfully";
                }
                else
                {
                    _logger.InfoLog($"No data updated for UpdateMovie Api");
                    resp.StatusCode = HttpStatusCode.NotFound;
                    resp.Result = null;
                    resp.ErrorMessage = "Error occured during API execution!. Please check logs";
                }
            }
            catch (Exception ex)
            {
                _logger.ErrorLog($"Exception occurred for UpdateMovie Api. Details {ex.Message}");
                resp.StatusCode = HttpStatusCode.InternalServerError;
                resp.Result = null;
                resp.ErrorMessage = "Exception occured during API execution!. Please check logs";
            }

            return resp;
        }

        [HttpDelete("DeleteMovie")]
        public async Task<ResponseDto<string>> Delete([FromQuery][Required] int movieId)
        {
            ResponseDto<string> resp = new ResponseDto<string>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Result = String.Empty
            };

            _logger.InfoLog($"Calling DeleteMovie API started by Id/Role: {HttpContext.UserDetails()}");

            try
            {
                _logger.InfoLog($"Calling DeleteMovieAsync service");
                var res = await _movieService.DeleteMovieAsync(movieId);

                if (res)
                {
                    _logger.InfoLog($"Info deleted successfully for DeleteMovie Api");
                    resp.StatusCode = HttpStatusCode.OK;
                    resp.Result = "Movie Info Deleted Successfully";
                }
                else
                {
                    _logger.InfoLog($"No data deleted for DeleteMovie Api");
                    resp.StatusCode = HttpStatusCode.NotFound;
                    resp.Result = null;
                    resp.ErrorMessage = "Error occured during API execution!. Please check logs";
                }
            }
            catch (Exception ex)
            {
                _logger.ErrorLog($"Exception occurred for DeleteMovie Api. Details {ex.Message}");
                resp.StatusCode = HttpStatusCode.InternalServerError;
                resp.Result = null;
                resp.ErrorMessage = "Exception occured during API execution!. Please check logs";
            }

            return resp;
        }
    }
}


