import Hall from "../cinemaTypes/Hall";
import Movie from "../movieTypes/Movie";
import Price from "../priceTypes/Price"

export default interface Seanse {
    id: number;
    hallId: number;
    startTime: string;
    movie: Movie;
    price: Price;
    hall: Hall;
}

export const defaultSeanse: Seanse = {
    id: 0,
    hallId: 0,
    startTime: '',
    movie: {
        id: 0,
        duration: 0,
        originalTitle: '',
        posterUrl: '',
        releaseDate: new Date(),
        title: '',
        
    },
    hall: {
        id: 0,
        hallNumber: 0,
        cinemaId: 0,
        seats: []
    },
    price: {
        id: 0,
        cost: 0
    }
}