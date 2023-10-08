import React, { useEffect, useState } from "react";
import { Alert, Button, Col, Container, Form, Row } from "react-bootstrap";
import MovieInfo from "../../../types/movieTypes/MovieInfo";
import MovieGenre from "../../../types/movieTypes/movieGenre";
import useMovie from "../../../hooks/MovieHook";
import CustomError from "../../../types/errorTypes/CustomError";

type UpdateMovieFormProps = {
    close: () => void;
    movie: MovieInfo; 
    movieId: number;   
  
    setRerender: (value: boolean | ((prevVar: boolean) => boolean)) => void;
    setShowError: (value: boolean) => void;
    setOccuredError: (value: CustomError) => void;
    getMovie: (id: number) => void;
};


const UpdateMovie: React.FC<UpdateMovieFormProps> = ({ getMovie, movieId, setOccuredError, setShowError, close, movie, setRerender }) => {
    const [originalTitle, setOriginalTitle] = useState('');
    const [title, setTitle] = useState('');
    const [duration, setDuration] = useState(0);
    const [movieTypeId, setType] = useState('');
    const [releaseDate, setReleaseDate] = useState('');
    const [posterUrl, setPosterUrl] = useState('');
    const [description, setDescription] = useState('');
    const [ageLimit, setAgeLimit] = useState(0);
    const [country, setCountry] = useState('');
    const [genreId, setGenre] = useState(0);
    const [independentRate, setRate] = useState(0);
    const [producers, setProducer] = useState('');
    const [movieTrailerUrl, setTrailer] = useState('');  
    const [startdate, setStartDate] = useState('');
    const [endDate, setEndDate] = useState('');
    const [error, setError] = useState("");
    const { updateMovie } = useMovie();

    useEffect(() => {
        getMovie(movie.id);
    }, []);

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        try {
            updateMovie(movieId, originalTitle, title, duration, movieTypeId, releaseDate, posterUrl, description,
                producers, ageLimit, independentRate, country, movieTrailerUrl, startdate,
                endDate, setShowError, setOccuredError);
                console.log(movie)
            close();
            setTimeout(() => {
                setRerender(x => !x)
            }, 1000);
        } catch {
            setError("Invalid input");
        }
    };

    useEffect(() => {
        getMovie(movieId);       
        setOriginalTitle(movie.originalTitle);
        setTitle(movie.title);
        setDuration(movie.duration);
        setType(movie.movieType);
        setReleaseDate(movie.releaseDate);
        setPosterUrl(movie.posterUrl);
        setDescription(movie.movieDetails.description);
        setAgeLimit(movie.movieDetails.ageLimit);
        setCountry(movie.movieDetails.country);
       
        setRate(movie.movieDetails.independentRate);       
        setProducer(movie.movieDetails.producers);
        setTrailer(movie.movieDetails.movieTrailerUrl); 
        setStartDate(new Date(movie.movieDetails.startDate).toLocaleDateString());
        setEndDate(new Date(movie.movieDetails.endDate).toLocaleDateString());      
    }, [])


    return (
        <div>
        {movie.movieDetails !== undefined &&
        <Form onSubmit={handleSubmit}>
            <Container>
                <Row>
                <Col>
                        <Form.Group className="mb-3" controlId="formBasicName">
                        <Form.Label>Оригінальна назва </Form.Label>
                        <Form.Control
                            type="text"
                            placeholder="Введіть оригінальну назву"
                            value={originalTitle}
                            onChange={(event) => setOriginalTitle(event.target.value)}
                        />
                        </Form.Group>
                </Col>

                <Col>
                        <Form.Group className="mb-3" controlId="formBasicAddress">
                        <Form.Label>Назва</Form.Label>
                        <Form.Control
                            type="text"
                            placeholder="Введіть назву"
                            value={title}
                            onChange={(event) => setTitle(event.target.value)}
                            />
                        </Form.Group>
                 </Col>
                </Row>
            </Container>

            <Container>
                <Row>
                    <Col>
                        <Form.Group className="mb-3" controlId="formBasicCity">
                        <Form.Label>Тривалість</Form.Label>
                        <Form.Control
                        type="number"
                        placeholder="Введіть триваліѝть фільму"
                        value={duration}
                        onChange={(event: any) => setDuration(event.target.value)}
                        />
                        </Form.Group>
                    </Col>

                    <Col>
                        <Form.Group className="mb-3" controlId="formBasicEmail">
                            <Form.Label>Тип</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder="Введіть тип фільму"
                                value={movieTypeId}
                                onChange={(event: any) => setType(event.target.value)}
                            />
                         </Form.Group>   
                    </Col>
                </Row>
            </Container>

            <Container>
                <Row>
                    <Col>
                        <Form.Group className="mb-3" controlId="formBasicPhoneNumber">
                        <Form.Label>Дата релізу</Form.Label>
                        <Form.Control
                        type="text"
                        placeholder="Введіть дату релізу"
                        value={releaseDate}
                        onChange={(event) => setReleaseDate(event.target.value)}
                        />
                        </Form.Group>
                    </Col>

                    <Col>
                        <Form.Group className="mb-3" controlId="formBasicPhoneNumber">
                        <Form.Label>Постер Url</Form.Label>
                        <Form.Control
                        type="text"
                        placeholder="Введіть Url постеру"
                        value={posterUrl}
                        onChange={(event) => setPosterUrl(event.target.value)}
                        />
                        </Form.Group>
                    
                    </Col>
                </Row>
            </Container>

            <Container>
                <Row>
                    <Col>
                        <Form.Group className="mb-3" controlId="formBasicPhoneNumber">
                        <Form.Label>Опиc</Form.Label>
                        <Form.Control
                        type="text"
                        placeholder="Введіть опис"
                        value={description}
                        onChange={(event) => setDescription(event.target.value)}
                        />
                        </Form.Group></Col>

                    <Col>
                        <Form.Group className="mb-3" controlId="formBasicPhoneNumber">
                        <Form.Label>Вікові обмеженнѝ</Form.Label>
                        <Form.Control
                        type="number"
                        placeholder="Введіть вік"
                        value={ageLimit}
                        onChange={(event: any) => setAgeLimit(event.target.value)}
                        />
                        </Form.Group>
                     </Col>
                </Row>
            </Container>
            
            <Container>
                <Row>
                    <Col>
                        <Form.Group className="mb-3" controlId="formBasicPhoneNumber">
                        <Form.Label>Продюcер</Form.Label>
                        <Form.Control
                        type="text"
                        placeholder="Введіть продюсера"
                        value={producers}
                        onChange={(event) => setProducer(event.target.value)}
                         />
                         </Form.Group>
                    </Col>

                    <Col>
                        <Form.Group className="mb-3" controlId="formBasicPhoneNumber">
                        <Form.Label>Країна походження</Form.Label>
                        <Form.Control
                        type="text"
                        placeholder="Введіть країну"
                        value={country}
                        onChange={(event) => setCountry(event.target.value)}
                            />
                        </Form.Group>
                    </Col>
                </Row>
            </Container>
            
            <Container>
                <Row>
                    <Col>
                        <Form.Group className="mb-3" controlId="formBasicPhoneNumber">
                        <Form.Label>Url трейлера</Form.Label>
                        <Form.Control
                        type="text"
                        placeholder="Введіть Url трейлера"
                        value={movieTrailerUrl}
                        onChange={(event) => setTrailer(event.target.value)}
                            />
                        </Form.Group>

                    </Col>

                    <Col>
                    <Form.Group className="mb-3" controlId="formBasicPhoneNumber">
                            <Form.Label>Незалежний рейтинг</Form.Label>
                            <Form.Control
                            type="number"
                            placeholder="Введіть рейтинг"
                            value={independentRate}
                            onChange={(event: any) => setRate(event.target.value)}
                            />
                        </Form.Group>                    
                    </Col>
                </Row>
            </Container> 
                        
            <Container>
                <Row>
                <Col>
                        <Form.Group className="mb-3" controlId="formBasicPhoneNumber">
                        <Form.Label>Дата початку</Form.Label>
                        <Form.Control
                        type="text"
                        placeholder="Введіть дату початку"
                        value={startdate}
                        onChange={(event) => setStartDate(event.target.value)}
                            />
                        </Form.Group>
                    </Col>
                    <Col>
                        <Form.Group className="mb-3" controlId="formBasicPhoneNumber">
                        <Form.Label>Дата закінчення</Form.Label>
                        <Form.Control
                        type="text"
                        placeholder="Введіть дату закінчення"
                        value={endDate}
                        onChange={(event) => setEndDate(event.target.value)}
                            />
                        </Form.Group>
                    </Col>
                  
                </Row>
            </Container>   

             {/* <Container>
                <Row>                
                    <Col>
                        <Form.Group className="mb-3" controlId="formBasicPhoneNumber">
                        <Form.Label>Жанр</Form.Label>
                        <Form.Control
                        type="number"
                        placeholder="Введіть жанр id"
                        value={genreId}
                        onChange={(event: any) => setGenre(event.target.value)}
                            />
                        </Form.Group>
                    </Col>
                    
                </Row>
            </Container>                  */}

  
            {error && <Alert variant="danger">{error}</Alert>}

            <div className="d-grid gap-2">
                <Button variant="outline-primary" size="lg" type="submit">
                    Редагувати
                </Button>
            </div>
        </Form>}
        </div>
    );
};

export default UpdateMovie;
