using MovieTicket.BusinessService.LoggerFactory;
using MovieTicket.BusinessService.Services.Interface;
using MovieTicket.DBHelper.DatabaseContext.Repo;
using MovieTicket.DBHelper.Entities;
using MovieTicket.ModelHelper.DTO;


namespace MovieTicket.BusinessService.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IMovieTicketRepository<MovieMaster> _repo;
        private readonly ICustomLogger _logger;

        public MovieService(IMovieTicketRepository<MovieMaster> repo, ICustomLogger logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<List<MovieDto>> GetAllMovieNameAsync()
        {
            try
            {
                _logger.InfoLog($"For GetAllMovieNameAsync Service DB Call Initiated...");
                var movies = await _repo.GetAllAsync();
                _logger.InfoLog($"For GetAllMovieNameAsync Service DB Call Completion...");

                List<MovieDto> result = new List<MovieDto>();
                foreach (var item in movies)
                {
                    MovieDto movieObj = new MovieDto()
                    {
                        Name = item.Name,
                        Language = item.Language,
                        RunTime = item.RunningMin
                    };
                    result.Add(movieObj);
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.ErrorLog($"Exception while executing GetAllMovieNameAsync. Details - {ex.Message}");
                return new List<MovieDto>();
            }
        }

        public async Task<List<MovieMaster>> GetSpecificMovieDetailsAsync(List<int> movieIds)
        {
            try
            {
                var movies = await _repo.GetAllAsync();
                return movies.Where(p => movieIds.Contains(p.Id)).ToList();
            }
            catch (Exception ex)
            {
                return new List<MovieMaster>();
            }
        }


        public async Task<bool> AddToMovieAsync(AddMovieDto movieDto)
        {
            try
            {
                var movieObj = new MovieMaster()
                {
                    Name = movieDto.Name,
                    Language = movieDto.Language,
                    Description = movieDto.Description,
                    RunningMin = movieDto.RunTime
                };

                await _repo.AddAsync(movieObj);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateMovieAsync(UpdateMovieDto movieDto)
        {
            try
            {
                var movieObj = new MovieMaster()
                {
                    Id = movieDto.Id,
                    Name = movieDto.Name,
                    Language = movieDto.Language,
                    Description = movieDto.Description,
                    RunningMin = movieDto.RunTime
                };

                await _repo.UpdateAsync(movieObj);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteMovieAsync(int movieId)
        {
            try
            {
                var da = await _repo.GetByIdAsync(movieId);
                if (da == null)
                    return false;
                else
                {
                    await _repo.DeleteAsync(da);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
