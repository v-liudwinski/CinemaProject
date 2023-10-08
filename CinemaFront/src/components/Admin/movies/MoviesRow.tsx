import { Button, Col, Container, Row, Table } from "react-bootstrap";
import MovieInfo from "../../../types/movieTypes/MovieInfo";
import { useState } from "react";
import useMovie from "../../../hooks/MovieHook";


interface MoviesRowProps {
    movie: MovieInfo;   
    modal: boolean;
    open: () => void;
    setCurrentMovieId: (num: number) => void;
    setCurrentOption: (option: string) => void;
    setSize: (size: string) => void;    
    setShowMovie: (flag: boolean) => void;   
    setMovie: (movie: MovieInfo) => void;
}

const MoviesRow: React.FC<MoviesRowProps> = ({ setMovie, setShowMovie, open, movie, setCurrentMovieId, setCurrentOption, setSize }) => {
    
    const [query, setQuery] = useState("");   
    const {findByTitle, movies} = useMovie();  
    const [publish, setPublish] = useState(false);
  

   const OnChange = (event: any) => {
    event.preventDefault();
    setQuery(event.target.value);
    findByTitle(event.target.value);
  
   }  
    
    return (
        <>
        <div className="add-page">
                <div className="container">
                    <div className="add-content">
                        <div className="input-wrapper">
                            <label className="text-white p-4">Пошук</label>
                            <input type="text" className="result"
                            value={query}
                            key={movie.id}
                            onChange={OnChange}
                            />
                        </div>                        
                  
                       {movies.length > 0 && (
                           <Container>
                             <Table striped bordered hover className="mt-2 border" variant="dark" responsive>                                
                                <thead>
                                    <tr>                                        
                                    <th>Id</th>
                                    <th>Оригінальна назва</th>
                                    <th>Назва</th>
                                    <th>Дата реліза</th>
                                    <th>Тривалість</th>
                                    <th>Тип</th>                                          
                                    <th>Опції</th>                  
                                        </tr>
                                        </thead>                                     
                                        <tbody>
                                                {movies.map(movie => (
                                                    <tr>
                                                        <td>{movie.id}</td>
                                                        <td>{movie.originalTitle}</td>
                                                        <td>{movie.title}</td>
                                                        <td>{new Date(movie.releaseDate).toLocaleDateString()}</td>
                                                        <td>{movie.duration}</td> 
                                                        <td>{movie.movieType}</td>                                                  
                                                        <td>
                        <Container>
                            <Row>                                
                         <Col>
                            <Button variant="outline-danger" className="text-white" onClick={() => {
                                setCurrentMovieId(movie.id); 
                                setMovie(movie);
                                open();
                                                          
                                setCurrentOption('showMovie');
                                setSize('lg');
                            }}>
                                Інформація
                            </Button>
                        </Col>     
                        <Col>
                        <Button variant="outline-danger" className="text-white" onClick={() => {
                            setCurrentMovieId(movie.id);
                            setMovie(movie);
                            open();                               
                            setCurrentOption('updateMovie');
                            setShowMovie(true);
                            setSize('lg');
                            }}>Редагувати
                        </Button>
                        </Col>
                        <Col>
                         <Button variant="outline-danger" className="text-white" onClick={() => {
                            setCurrentMovieId(movie.id);
                            open();
                            setCurrentOption('deleteMovie');
                            setSize('sm');
                            }}>
                            Видалити
                          </Button>
                        </Col>
                </Row>
        
        </Container>
                                                        </td>
                                                    </tr>                                                    
                                                ))}
                                        </tbody>                                
                            </Table>
                           </Container>
                        )}                       
                        
                    </div>
                </div>

            </div>
        </>
    );
};

export default MoviesRow;