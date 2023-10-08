import React, { useState } from "react";
import { Alert, Button, Form } from "react-bootstrap";
import useSeanses from "../../../hooks/SeanseHook";
import CustomError from "../../../types/errorTypes/CustomError";
import Seanse from "../../../types/seanseTypes/Seanse";

type CreateSeanseFormProps = {
    close: () => void;
    seanse: Seanse;
    setRerender: (value: boolean | ((prevVar: boolean) => boolean)) => void;
    setShowError: (value: boolean) => void;
    setOccuredError: (value: CustomError) => void;
};

const CreateSeanse: React.FC<CreateSeanseFormProps> = ({ setOccuredError, setShowError, close, setRerender }) => {
    const [startTime, setStartTime] = useState('');
    const [hallId, setHallId] = useState(0);
    const [movieId, setMovieId] = useState(0);
    const [priceId, setPriceId] = useState(0);
    const [error, setError] = useState("");
    const { createSeanse } = useSeanses();
    
    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        try {
            createSeanse(startTime, hallId, movieId, priceId, setShowError, setOccuredError);
            close();
            setTimeout(() => {
                setRerender(x => !x)
            }, 1000);
        } catch {
            setError("Invalid input");
        }
    };

    return (
        <Form onSubmit={handleSubmit}>
            <Form.Group className="mb-3" controlId="formBasicName">
                <Form.Label>Час показу</Form.Label>
                <Form.Control
                    type="date"
                    placeholder="Введіть час показу"
                    value={startTime}
                    onChange={(event) => setStartTime(event.target.value)}
                />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicAddress">
                <Form.Label>Зал id</Form.Label>
                <Form.Control
                    type="number"
                    placeholder="Введіть id залу"
                    value={hallId}
                    onChange={(event: any) => setHallId(event.target.value)}
                />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicCity">
                <Form.Label>Фільм id</Form.Label>
                <Form.Control
                    type="number"
                    placeholder="Введіть id фільму"
                    value={movieId}
                    onChange={(event: any) => setMovieId(event.target.value)}
                />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicEmail">
                <Form.Label>Ціна id</Form.Label>
                <Form.Control
                    type="number"
                    placeholder="Введіть id ціни"
                    value={priceId}
                    onChange={(event: any) => setPriceId(event.target.value)}
                />
            </Form.Group>
            

            {error && <Alert variant="danger">{error}</Alert>}

            <div className="d-grid gap-2">
                <Button variant="outline-primary" type="submit">
                    Створити
                </Button>
            </div>
        </Form>
    );
};

export default CreateSeanse;