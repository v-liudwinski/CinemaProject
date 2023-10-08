
export default interface Movie {
    id: number;
    duration: number;
    originalTitle: string;
    posterUrl: string;
    releaseDate: Date;  
    title: string;
}

export const defaultMovie = {
    id: 0,
    duration: 0,
    originalTitle: '',
    posterUrl: '',
    releaseDate: new Date(),
    title: ''
}

