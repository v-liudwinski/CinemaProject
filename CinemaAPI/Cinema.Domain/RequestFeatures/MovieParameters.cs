namespace Cinema.Domain.RequestFeatures;

public class MovieParameters : RequestParameters
{
    public string? SearchTerm { get; set; } = string.Empty;
    public MovieParameters()
    {
        OrderBy = "name";
    }
}
