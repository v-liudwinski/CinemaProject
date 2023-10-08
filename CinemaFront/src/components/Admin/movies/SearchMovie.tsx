import { useEffect } from "react";
import MovieInfo from "../../../types/movieTypes/MovieInfo";
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Stack from 'react-bootstrap/Stack';


interface SearchMovieProps {
    movieTitle: string; 
    movie: MovieInfo; 
    findByTitle: (movieTitle: string) => void;
}

const SearchMovie: React.FC<SearchMovieProps> = ({movieTitle, findByTitle, movie}) => {
    
    useEffect(() => {
        findByTitle(movieTitle);
    }, []);

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        findByTitle(movieTitle);
    };

    return (
        <Form onSubmit={handleSubmit}>
            <Stack direction="horizontal" gap={3}>
            <Form.Control className="me-auto" placeholder="Введіть назву фільму..." />
            <Button variant="outline-dark"className='text-white'>Пошук</Button>
            <div className="vr" />       
            </Stack>
        </Form>       
    )
}

export default SearchMovie;