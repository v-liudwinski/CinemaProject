export default interface MovieDetails {
        id: number;
        description: string;
        producers: string;
        ageLimit: number;  
        independentRate: number;
        usersRate: number,
        country: string;
        movieTrailerUrl: string;
        startDate: string;
        endDate: string;
}

export const defaultMovieDetails: MovieDetails = {
        id: 0,
        description: '',
        producers: '',
        ageLimit: 0,
        independentRate: 0,
        usersRate: 0,
        country: '',
        movieTrailerUrl: '',
        startDate: '',
        endDate: ''
}