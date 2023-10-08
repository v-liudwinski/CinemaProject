import React, { useState } from "react";
import { Alert, Button, Form } from "react-bootstrap";
import useHalls from "../../../hooks/HallsHook";
import CustomError from "../../../types/errorTypes/CustomError";

type CreateHallFormProps = {
    close: () => void;
    cinemaId: number;
    setRerender: (value: boolean | ((prevVar: boolean) => boolean)) => void;
    setShowError: (value: boolean) => void;
    setOccuredError: (value: CustomError) => void;
};

const CreateHall: React.FC<CreateHallFormProps> = ({ setOccuredError, setShowError, cinemaId, close, setRerender }) => {
    const [hallNumber, setHallNumber] = useState('');
    const [error, setError] = useState("");
    const { createHall } = useHalls();
    
    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        try {
            createHall(cinemaId, hallNumber, setShowError, setOccuredError);
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
            <Form.Group className="mb-3" controlId="formHallNumber">
                <Form.Label>Номер залу</Form.Label>
                <Form.Control
                    type="number"
                    placeholder="Введіть номер"
                    value={hallNumber}
                    onChange={(event) => setHallNumber(event.target.value)}
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

export default CreateHall;
