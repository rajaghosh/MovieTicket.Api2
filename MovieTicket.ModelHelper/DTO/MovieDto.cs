namespace MovieTicket.ModelHelper.DTO
{
    public class MovieDto
    {
        public string Name { get; set; }
        public string Language { get; set; }
        public int RunTime { get; set; }
    }

    public class MovieSearchDto : MovieDto
    {
        public string Location { get; set; }
        public List<int> TheatreIds { get; set; }
        public List<int> ScreenIds { get; set; }
    }

    public class AddMovieDto
    {
        public required string Name { get; set; }
        public required string Language { get; set; }
        public string? Description { get; set; }
        public required int RunTime { get; set; }
    }

    public class UpdateMovieDto : AddMovieDto
    {
        public int Id { get; set; }
    }
}
