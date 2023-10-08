import { useEffect, useState } from "react";
import Favourite from "../../../types/favouriteTypes/Favourite";
import MovieItem from "../movies/MovieItem";
import { Col, Row } from "react-bootstrap";
import Movie, { defaultMovie } from "../../../types/movieTypes/Movie";
import http from "../../../http-common";

interface FavouriteItemProps { 
    favourite: Favourite;
}

const FavouriteItem: React.FC<FavouriteItemProps> = ({favourite}) => {
    
    const [movie, setMovie] = useState<Movie>(defaultMovie);

    async function fetchMovie(movieDetailsId: number) {
        const response = await http
            .get<Movie>(`/movies/GetMovieByMovieDetailsId/${movieDetailsId}`);
        setMovie(response.data);
    }

    useEffect(() => {
        fetchMovie(favourite.movieId);
    }, []);
    
    return (
        <Row className="mb-5">
            <Col>
                <MovieItem posterUrl={movie.posterUrl} title={movie.title} originalTitle={movie.originalTitle} />
            </Col>
        </Row>
    );
};

export default FavouriteItem;