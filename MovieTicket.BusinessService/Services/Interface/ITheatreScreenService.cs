using MovieTicket.DBHelper.Entities;
using MovieTicket.ModelHelper.DTO;

namespace MovieTicket.BusinessService.Services.Interface
{
    public interface ITheatreScreenService
    {
        Task<List<TheatreScreenDto>> GetAllTheatreScreenAsync();
        Task<List<TheatreScreen>> GetAllCoreTheatreScreenAsync();
        Task<List<TheatreScreenTotalDto>> GetSpecificTheatreScreenDetailsAsync(List<int> theatreScreenIds);
        Task<bool> AddToTheatreScreenAsync(AddTheatreScreenDto theatreScreenDto);
        Task<bool> UpdateTheatreScreenAsync(UpdateTheatreScreenDto theatreScreenDto);
        Task<bool> DeleteTheatreScreenAsync(int theatreScreenId);
    }
}
