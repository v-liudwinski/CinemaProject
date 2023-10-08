namespace Cinema.Domain.Models.ViewModels;

public class SeanseInfoViewModel
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public MovieViewModel Movie { get; set; }
    public HallInfoViewModel Hall { get; set; }
}
