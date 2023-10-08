import { Container, Table, Button } from "react-bootstrap";
import MoviesRow from "../../components/Admin/movies/MoviesRow";
import CreateMovie from "../../components/Admin/movies/CreateMovie";
import DeleteMovie from "../../components/Admin/movies/DeleteMovie";
import UpdateMovie from "../../components/Admin/movies/UpdateMovie";
import GetMovieInfo from "../../components/Admin/movies/GetMovieInfo";
import AlertDismissible from "../../components/shared/AlertDismissible";
import ModalWindow from "../../components/shared/ModalWindow";
import useMovie from "../../hooks/MovieHook";
import { useContext, useEffect, useState } from "react";
import { ModalContext } from "../../context/ModalContext";
import CustomError, { defaultError } from "../../types/errorTypes/CustomError";


interface MoviesProps {
    setShowMovie: (flag: boolean) => void;  
}

const Movie: React.FC<MoviesProps> = ({ setShowMovie }) => {
    const { modal, open, close } = useContext(ModalContext);
    const [currentOption, setCurrentOption] = useState<string>('');
    const [size, setSize] = useState<string>('');
    const [currentMovieId, setCurrentMovieId] = useState<number>(0);     
    const [showError, setShowError] = useState(false);
    const [occuredError, setOccuredError] = useState<CustomError>(defaultError);
    const [rerender, setRerender] = useState(false);
    const { movie, setMovie, movies, fetchMovies, getMovie } = useMovie();

    useEffect(() => {
        fetchMovies();
    }, [rerender]);
   
    return ( 
        <Container fluid className="p-5 pt-2 text-center">   
            {showError && <AlertDismissible func={setShowError} error={occuredError}/>}

            {modal && <ModalWindow title="Заповніть форму" 
                close={close}
                modal={modal}
                size={size}>
                {
                    currentOption === 'showMovie'
                    ? <GetMovieInfo  getMovie={getMovie} movie={movie} movieId={currentMovieId} />                  
                    : currentOption ===  'updateMovie' 
                    ? <UpdateMovie  getMovie={getMovie} movieId={currentMovieId} setShowError={setShowError} setOccuredError={setOccuredError} 
                    close={close} movie={movie} setRerender={setRerender} /> 
                    : currentOption ===  'createMovie'
                    ? <CreateMovie setShowError={setShowError} setOccuredError={setOccuredError}
                    close={close} setRerender={setRerender} /> 
                    : <DeleteMovie setShowError={setShowError} setOccuredError={setOccuredError}
                    close={close} movieId={currentMovieId} setRerender={setRerender} />}
            </ModalWindow>}

            <Button className="me-3" variant="outline-danger" size="lg" onClick={() => {
                setCurrentOption('createMovie');
                setMovie(movie);
                setShowMovie(true);
                open();
                setSize('lg');
            }}>Створити новий фільм</Button>          
            
            {/* { movies.map(x =>  */}
                <MoviesRow
                    setMovie={setMovie}                  
                    setShowMovie={setShowMovie}                   
                    movie={movie}                                
                    key={movie.id} 
                    open={open}
                    modal={modal}
                    setCurrentMovieId={setCurrentMovieId}
                    setCurrentOption={setCurrentOption}
                    setSize={setSize}
                />
            {/* )} */}
        </Container>
    )
};

export default Movie;