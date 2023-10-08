import React, { useEffect, useState } from 'react';
import { Col, Container, Row } from 'react-bootstrap';
import useMovie from '../../hooks/MovieHook';
import MovieItemShow from '../../pages/Home/MovieItemShow';
import MovieInfo, {defaultMovieInfo} from '../../types/movieTypes/MovieInfo';

    

function SoonReliese() {
    const { movies, fetchMovies } = useMovie();
    const [ showMovies, setShowMovies ] = useState(false);
    const [ showMovie, setShowMovie ] = useState(false);
    const [ movie, setMovie ] = useState<MovieInfo>(defaultMovieInfo);

    useEffect(() => {
        fetchMovies();
        setShowMovies(true)
    }, []);

    return (
        <>
        <h2 className="text-center text-white my-4">Незабаром у прокаті</h2>        
                      
                        <div> 
                        {showMovies &&

                                <Row>
                                        {
                                            movies.map(item =>                 
                                                <MovieItemShow movie={item}/>
                                        )}                              
                                </Row>} 
                        </div>          
 
    </>
    )
}

export default SoonReliese;