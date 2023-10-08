import { useEffect } from "react";
import { Button, Col, Container, Row } from "react-bootstrap";
import useMovie from "../../../hooks/MovieHook";
import CustomError from "../../../types/errorTypes/CustomError";
import MovieInfo from "../../../types/movieTypes/MovieInfo";

interface DeleteMovieProps {
    movieId: number; 
    close: () => void;
    setRerender: (value: boolean | ((prevVar: boolean) => boolean)) => void;
    setShowError: (value: boolean) => void;
    setOccuredError: (value: CustomError) => void;
}

const DeleteMovie: React.FC<DeleteMovieProps> = ({ setOccuredError, setShowError, movieId, close, setRerender }) => {
    const { deleteMovie } = useMovie();
   
    return (
        <>
            <h2 className="text-center mb-4">Видалити фільм?</h2>
            <Container>
                <Row>
                    <Col></Col>
                    <Col>
                        <Button
                            variant="danger" size="lg"
                            className="btn-lg"
                            onClick={() => {
                                deleteMovie(movieId, setShowError, setOccuredError);                                
                                window.location.href='/admin/moviemanagement'
                                close();
                                setTimeout(() => {
                                    setRerender(x => !x)
                                }, 1000);
                            }}>Видалити</Button>
                    </Col>
                    <Col></Col>
                </Row>
            </Container>
        </>
    );
};

export default DeleteMovie;