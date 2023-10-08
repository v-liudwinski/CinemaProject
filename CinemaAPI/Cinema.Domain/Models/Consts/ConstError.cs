namespace Cinema.Domain.Models.Consts;

public static class ConstError
{
    public const string ERROR_BY_ID = "Error occured in GetAsync method, an attempt to reach an element with an unregistered id.";
    public const string ERROR_BY_CREDENTIALS = "Error occured in GetAsync method, an attempt to reach an element with an unregistered email and password.";
    public const string EXISTING_ENTITY = "Error occured, an element with same data already exists.";
    public const string EXISTING_EMAIL = "An user with such email is already signed up.";
    public const string USER_IS_TOO_YOUNG = "User tried to buy movie with age limitation.";
    public static string GetErrorForException(string type, int id)
        => $"{type} with id {id} doesn't exist.";
    
    public static string GetCredentialsErrorExceptionMessage(string type, string login, string password) 
        => $"{type} with login {login} and password {password} does not exist.";
    
    public static string GetErrorForExistingElement(string type)
        => $"{type} already exists.";

    public static string GetInvalidPromocodeException(string type)
        => $"{type} is invalid.";

    public static string GetFavoriteException(int userDetailsId)
        => $"Favourite for userDetails with id {userDetailsId} doesn't exist.";

    public static string GetInvalidCinemaException(int id)
        => $"Cinema with id {id} doesn't have such hall.";

    public static string GetMovieGenreHas(int movieId, int genreId)
        => $"Movie with id {movieId} already has genre with id {genreId}.";
    
    public static string GetMovieGenreDoesntHave(int movieId, int genreId)
        => $"Movie with id {movieId} doesn't have genre with id {genreId}.";

    public static string GetInvalidHallException(int id)
        => $"Hall with id {id} doesn't have such seat.";
    
    public static string GetInvalidTicket(int seatId, int seanseId)
        => $"Ticket for seanse with id {seanseId} and seat with id {seatId} is sold.";

    public static string GetAgeLimitationException(int id)
        => $"User with id {id} tried to buy movie with age limitation.";
}