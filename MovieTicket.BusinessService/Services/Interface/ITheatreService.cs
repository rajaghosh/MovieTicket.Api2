using MovieTicket.DBHelper.Entities;
using MovieTicket.ModelHelper.DTO;

namespace MovieTicket.BusinessService.Services.Interface
{
    public interface ITheatreService
    {
        Task<List<TheatreDto>> GetAllTheatreNameAsync(); 
        Task<List<TheatreMaster>> GetAllCoreTheatreNameAsync();
        Task<List<TheatreMaster>> GetSpecificTheatreDetailsAsync(List<int> theatreIds);
        Task<bool> AddToTheatreAsync(AddTheatreDto theatreDto);
        Task<bool> UpdateTheatreAsync(UpdateTheatreDto theatreDto);
        Task<bool> DeleteTheatreAsync(int theatreId);
    }
}
