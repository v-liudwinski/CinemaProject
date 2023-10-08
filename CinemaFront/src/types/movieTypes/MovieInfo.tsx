import Movie from "./Movie";
import MovieDetails from "./MovieDetails";
import MovieGenre from "./movieGenre";
import MovieType from "./MovieType";

export default interface MovieInfo {
    id: number;
    originalTitle: string;
    title: string;
    duration: number;
    movieType: string;  
    releaseDate: string; 
    posterUrl: string;
    movieDetails: MovieDetails;
    movieGenre: MovieGenre[]
}

export const defaultMovieInfo: MovieInfo = {
    id: 0,
    originalTitle: '',
    title: '',
    duration: 0,  
    movieType: '',        
    releaseDate: '',  
    posterUrl: '',  
    movieDetails: {
        id: 0,
        description: '',
        producers: '',
        ageLimit: 0,    
        independentRate: 0,
        usersRate: 0,
        country: '',
        movieTrailerUrl: '',
        startDate: '',
        endDate: '',
    },
    movieGenre: []
  
}