import React, { useState } from "react";
import { Alert, Button, Form } from "react-bootstrap";
import Seanse from "../../../types/seanseTypes/Seanse";
import useSeanses from "../../../hooks/SeanseHook";
import CustomError from "../../../types/errorTypes/CustomError";

type UpdateSeanseFormProps = {
    close: () => void;
    seanse: Seanse;
    setRerender: (value: boolean | ((prevVar: boolean) => boolean)) => void;
    setShowError: (value: boolean) => void;
    setOccuredError: (value: CustomError) => void;
};

const UpdateSeanse: React.FC<UpdateSeanseFormProps> = ({ setOccuredError, setShowError, close, seanse, setRerender }) => {
    const [startTime, setStartTime] = useState(seanse.startTime);
    const [hallId, setHallId] = useState(seanse.hallId);
    const [movieId, setMovieId] = useState(seanse.movie.id);
    const [priceId, setPriceId] = useState(seanse.price.id);   
    const [error, setError] = useState("");
    const { updateSeanse } = useSeanses();


    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        try {
            updateSeanse(seanse.id, startTime, hallId, movieId, priceId, setShowError, setOccuredError)
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
                <Form.Label>Показ </Form.Label>
                <Form.Control
                    type="date"
                    placeholder="Введіть час показу"
                    value={startTime}
                    onChange={(event) => setStartTime(event.target.value)}
                />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicAddress">
                <Form.Label>Id зала</Form.Label>
                <Form.Control
                    type="number"
                    placeholder="Введіть id зала"
                    value={hallId}
                    onChange={(event: any) => setHallId(event.target.value)}
                />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicCity">
                <Form.Label>Id фільму</Form.Label>
                <Form.Control
                    type="number"
                    placeholder="Введіть id фільму"
                    value={movieId}
                    onChange={(event: any) => setMovieId(event.target.value)}
                />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicEmail">
                <Form.Label>Id ціни</Form.Label>
                <Form.Control
                    type="number"
                    placeholder="Введіть Id ціни"
                    value={priceId}
                    onChange={(event: any) => setPriceId(event.target.value)}
                />
            </Form.Group>
            

            {error && <Alert variant="danger">{error}</Alert>}

            <div className="d-grid gap-2">
                <Button variant="outline-primary" type="submit">
                    Редагувати
                </Button>
            </div>
        </Form>
    );
};

export default UpdateSeanse;
