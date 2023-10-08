using Cinema.Domain.Models.Enums;

namespace Cinema.Domain.Models.Entities;

public class MovieType
{
    public int Id { get; set; }
    public MovieTypeEnum MediaType { get; set; }
}