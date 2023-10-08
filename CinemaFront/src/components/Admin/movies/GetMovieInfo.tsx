import MovieInfo from "../../../types/movieTypes/MovieInfo";
import { Card, Container, Row } from "react-bootstrap";
import { useEffect } from "react";

interface GetMovieInfoProps {
    movie: MovieInfo; 
    getMovie: (movieId: number) => void;
    movieId: number; 
}

const GetMovieInfo: React.FC<GetMovieInfoProps> = ({ getMovie, movie, movieId }) => {

    useEffect(() => {
        getMovie(movieId);
    }, [])

    return (
        <>{movie.movieDetails !== undefined &&
            <Container>
                <Row>               
                    <Card style={{ width: '17rem'}}>                
                        <Card.Img variant="top" src={movie.posterUrl} />                              
                    </Card>  
                                
                    <Card style={{ width: '28rem' }}>               
                    <Card.Title>{movie.title}</Card.Title>  
                    <Card.Body>
                        <Card.Text>{movie.movieDetails.description}</Card.Text>                                                  
                    </Card.Body>
                    <Card.Footer>
                        <Card.Text>Країна: {movie.movieDetails.country}</Card.Text> 
                        <Card.Text>Продюсер: {movie.movieDetails.producers}</Card.Text> 
                        <Card.Text>Вікові обмеження: {movie.movieDetails.ageLimit}</Card.Text>
                        <Card.Text>Рейтинг: {movie.movieDetails.independentRate}</Card.Text>                                                   
                        <Card.Text>Опис: {movie.movieDetails.description}</Card.Text>                                                   
                        <Card.Text>Країна: {movie.movieDetails.country}</Card.Text>                                                   
                        <Card.Text>Трейлер: {movie.movieDetails.movieTrailerUrl}</Card.Text>   
                                                                     
                    </Card.Footer>
                    </Card>      
                </Row>
            </Container>}
        </>
    )
}

export default GetMovieInfo;