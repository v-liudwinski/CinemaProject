import { Button, Card } from "react-bootstrap";
import http from "../../../http-common";
import { useState } from "react";
import { isAxiosError } from "axios";

interface MovieItemProps {
    posterUrl?: string;
    originalTitle?: string;
    title?: string
}

const MovieItem: React.FC<MovieItemProps> = ({posterUrl, originalTitle, title}) => {
    const [error, setError] = useState('')

    async function handleSubmit() {
        try{
            await http.post("/favourites/add", {});
        }catch(error){
            if(isAxiosError(error)){
                setError(error.message)
            }
            setError("Invalid request")
        }
    }
    
    return (
        <Card onSubmit={handleSubmit} style={{ width: '10rem' }}>
            <Card.Img variant="top" src={posterUrl} />
            <Card.Body>
                <Card.Title>{originalTitle}</Card.Title>
                <Card.Text>
                {title}
                </Card.Text>
                <Button type="submit" variant="outline-dark" className="text-black" size="sm">Додати в улюблені</Button>
                {error && <div>{error}</div>}
            </Card.Body>
        </Card>
    );
};

export default MovieItem;

