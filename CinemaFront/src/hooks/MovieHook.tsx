import CustomError from '../types/errorTypes/CustomError';
import { useEffect, useState } from "react";
import axios, { AxiosError, isAxiosError } from 'axios';
import MovieInfo, {defaultMovieInfo} from '../types/movieTypes/MovieInfo';
import http from '../http-common';
import Movie from '../types/movieTypes/Movie';
import { getCurrentUserId } from './getCurrentUserId';

export default function useMovie(movieId?: number) {
    
    const [movies, setMovies] = useState<MovieInfo[]>([]);
    const [movie, setMovie] = useState<MovieInfo>(defaultMovieInfo);
    const [showMovie, setShowMovie] = useState<boolean>(true);
    const [favouriteMovies, setFavouriteMovies] = useState<Movie[]>([])
    const [errorMessage, setErrorMessage] = useState('')
    const [currentMovieId, setCurrentMovieId] = useState(movieId)

    async function getMoviesByUserFavourite() {
        try{
            const userId = await getCurrentUserId()
            const response = await http.get<Movie[]>(`/movies/GetMoviesByUserFavourites/${userId}`)
            setFavouriteMovies(response.data)
        }catch(error){
            if(isAxiosError(error)){
                setErrorMessage(error.message)
            }
            setErrorMessage("Invalid request!")
        }
    }

    async function fetchMovies() {
        const response = await http.get<MovieInfo[]>('/movies/GetAllMovies');
        setMovies(response.data);
    }

    async function addMovieItem(movieId: number) {
        const response = await http.get<MovieInfo>(`/movies/GetMoviesByIdAsync/${movieId}`);
        setMovie(response.data);
      }

      async function findByTitle(title: string) {
        const response = await http.get<MovieInfo[]>(`/movies/GetAllMovies?SearchTerm=${title}`);
        setMovies(response.data);
       
    }

    async function updateMovie(id: number, originalTitle: string, title: string, duration: number, type: string, 
                                releaseDate: string, posterUrl: string, description: string, producer: string, ageLimit: number,
                                rate: number, country: string, movieTrailerUrl: string, startDate: string, endDate: string, setShowError: (value: boolean) => void, setOccuredError: (value: CustomError) => void) {
        try {
            const response = await http.put(`/movies/UpdateMovie/${id}`, {originalTitle, title, duration, type, releaseDate, posterUrl, description,
                                producer, ageLimit, rate, country,  movieTrailerUrl, startDate, endDate});
                                setMovie(response.data);
                                
        } catch (error) {
            if (axios.isAxiosError(error)) {
                const serverError = error as AxiosError<CustomError>;
                if (serverError && serverError.response) {
                    setOccuredError(serverError.response.data as CustomError);
                    setShowError(true);
                }
            }
        }
    }

    async function createMovie(originalTitle: string, title: string, duration: number, type: string, releaseDate: string, posterUrl: string,
                                description: string, producer: string, ageLimit: number, rate: number, 
                                country: string, genreId: number, movieTrailerUrl: string, startDate: string, endDate: string, setShowError: (value: boolean) => void, setOccuredError: (value: CustomError) => void) {
        try {
          const response =  await http.post("/movies/AddMovie", {originalTitle, title, duration, type, releaseDate, posterUrl, description,
                                producer, ageLimit, rate, country, genreId, movieTrailerUrl, startDate, endDate});
                                setMovies(movies.filter(x => x.id !== movieId));
        } catch (error) {
            if (axios.isAxiosError(error)) {
                const serverError = error as AxiosError<CustomError>;
                if (serverError && serverError.response) {
                    setOccuredError(serverError.response.data as CustomError);
                    setShowError(true);
                }
            }
        }
    }

    async function getMovie() {       
        const response = await http.get<MovieInfo>(`/movies/GetMovieInfo/${currentMovieId}`);
        setMovie(response.data);    
    }  


    async function deleteMovie(movieId: number, setShowError: (value: boolean) => void, 
    setOccuredError: (value: CustomError) => void) {
        try {
            await http.delete(`/movies/DeleteMovie/${movieId}`);
            setMovies(movies.filter(x => x.id !== movieId));
        } catch (error) {
            if (axios.isAxiosError(error)) {
                const serverError = error as AxiosError<CustomError>;
                if (serverError && serverError.response) {
                    setOccuredError(serverError.response.data as CustomError);
                    setShowError(true);
                }
            }
        }
    }

    useEffect(() => {
        getMoviesByUserFavourite();
        getMovie();
        fetchMovies();
    }, []);

    return { 
        movies,
        movie, 
        showMovie,
        favouriteMovies,
        errorMessage,
        setShowMovie,
        addMovieItem,
        deleteMovie,
        fetchMovies,
        updateMovie,
        createMovie,
        findByTitle,
        getMovie,
        getMoviesByUserFavourite,
        setMovie,
        currentMovieId

    };
}