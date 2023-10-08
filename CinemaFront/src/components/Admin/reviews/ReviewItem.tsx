import { useEffect, useState } from "react";
import Review from "../../../types/reviewTypes/Review";
import { Alert, Card, Col, Row } from "react-bootstrap";
import Movie, { defaultMovie } from "../../../types/movieTypes/Movie";
import http from "../../../http-common";

interface ReviewItemProps { 
    review: Review;
}

const ReviewItem: React.FC<ReviewItemProps> = ({review}) => {
    
    
    const [movie, setMovie] = useState<Movie>(defaultMovie);

    async function fetchMovie(movieDetailsId: number) {
        const response = await http.get<Movie>(`/movies/GetMovieByMovieDetailsId/${movieDetailsId}`);
        setMovie(response.data);
    }

    useEffect(() => {
        fetchMovie(review.movieDetailsId);
    }, []);
    
    return (
        <Row className="mb-5">
            <Col  className="text-center">
                <Card style={{ width: '18rem' }}>
                <Card.Img variant="top" src={movie.posterUrl} />
                <Card.Body>
                    <Card.Title>{movie.originalTitle}</Card.Title>
                    <Card.Text>
                    {movie.title}
                    </Card.Text>
                </Card.Body>
                </Card>
            </Col>
            <Col>
            <Alert className="mt-5" variant={review.rate < 3.5 ? 'danger' : review.rate < 7.5 ? 'warning' : 'success'}>
                <Alert.Heading>Оцінка: {review.rate}</Alert.Heading>
                <p>
                    {review.description}
                </p>
                <hr />
            </Alert>
            </Col>
        </Row>
    );
};

export default ReviewItem;