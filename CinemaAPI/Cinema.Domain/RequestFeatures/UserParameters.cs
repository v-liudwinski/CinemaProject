namespace Cinema.Domain.RequestFeatures;

public class UserParameters : RequestParameters
{
    public string? SearchTerm { get; set; } = string.Empty;
    public UserParameters()
    {
        OrderBy = "name";
    }
}
