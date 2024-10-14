using MovieTicket.DBHelper.Entities;
using MovieTicket.ModelHelper.DTO;

namespace MovieTicket.BusinessService.Services.Interface
{
    public interface IMovieService
    {
        Task<List<MovieDto>> GetAllMovieNameAsync();
        Task<List<MovieMaster>> GetSpecificMovieDetailsAsync(List<int> movieIds);
        Task<List<MovieDto>> GetSpecificMovieDetailsDtoAsync(List<int> movieIds);
        Task<bool> AddToMovieAsync(AddMovieDto movieDto);
        Task<bool> UpdateMovieAsync(UpdateMovieDto movieDto);
        Task<bool> DeleteMovieAsync(int movieId);
    }
}
