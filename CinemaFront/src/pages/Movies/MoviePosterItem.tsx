import { Card, Button } from "react-bootstrap"
import MovieInfo from "../../types/movieTypes/MovieInfo";
import { useNavigate } from "react-router";
import { useEffect, useState } from "react";
import { addLike, bringLike } from "../../hooks/addLike";
import { getCurrentUserId } from "../../hooks/getCurrentUserId";
import http from "../../http-common";

interface MoviePosterItemProps {
    movie: MovieInfo;
    setShowMovies: (value: boolean | ((prevVar: boolean) => boolean)) => void;
    setShowMovie: (value: boolean | ((prevVar: boolean) => boolean)) => void;
    setMovie: (value: MovieInfo) => void;
}

const MoviePosterItem: React.FC<MoviePosterItemProps> = ({ movie, setShowMovies, setShowMovie, setMovie}) => {
    const navigate = useNavigate()
    const [likeState, setLikeState] = useState(true)

    async function handleLike(movieId:number) {
        await addLike(movieId)
        setLikeState(false)
    }
    
    async function handleUnlike(movieId:number) {
        await bringLike(movieId)
        setLikeState(true)
    }

    useEffect(() => {
        handleLikeState();
    }, [])
    
    async function handleLikeState() {
        const favourite = await http.get(`favourites/${getCurrentUserId()}&${movie.id}`)
        if (favourite !== null){
            setLikeState(false)
        }
    }

    return (
        <Card style={{ width: '14rem' }} className="movie px-0 m-5 p-0 bg-black border">
            <Card.Img onClick={() => navigate(`/movies/singlemovie/${movie.id}`)} className="mt-3 cursor-state" variant="top" src={movie.posterUrl} />
            <Card.Body>
                <Card.Text onClick={() => navigate(`/movies/singlemovie/${movie.id}`)} className="text-light cursor-state">{movie.originalTitle}</Card.Text>
                <Card.Text onClick={() => navigate(`/movies/singlemovie/${movie.id}`)} className="text-light cursor-state">{movie.title}</Card.Text>
            </Card.Body>
            <Card.Footer>
                {likeState ?
                    <div className="col text-center">
                        <Button onClick={() => handleLike(movie.id)} variant="outline-secondary">
                            <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="gray" className="bi bi-heart-fill" viewBox="0 0 16 16">
                                <path fill-rule="evenodd" d="M8 1.314C12.438-3.248 23.534 4.735 8 15-7.534 4.736 3.562-3.248 8 1.314z"/>
                            </svg>
                        </Button>
                    </div> 
                    :
                    <div className="col text-center">
                        <Button onClick={() => handleUnlike(movie.id)} variant="outline-danger">
                            <svg xmlns="https://www.svgrepo.com/show/346774/dislike.svg" width="20" height="20" fill="red" className="bi bi-heart-fill" viewBox="0 0 16 16">
                                <path fill-rule="evenodd" d="M8 1.314C12.438-3.248 23.534 4.735 8 15-7.534 4.736 3.562-3.248 8 1.314z"/>
                            </svg>
                        </Button>
                    </div>
                }
            </Card.Footer>
        </Card>
    )
}

export default MoviePosterItem;