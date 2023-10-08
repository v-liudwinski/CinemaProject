import React, { useState } from "react";
import { Alert, Button, Form } from "react-bootstrap";
import useSeats from "../../../hooks/SeatsHook";
import CustomError from "../../../types/errorTypes/CustomError";

type CreateSeatFormProps = {
    close: () => void;
    hallId: number;
    setRerender: (value: boolean | ((prevVar: boolean) => boolean)) => void;
    setShowError: (value: boolean) => void;
    setOccuredError: (value: CustomError) => void;
};

const CreateSeat: React.FC<CreateSeatFormProps> = ({ setOccuredError, setShowError, hallId, close, setRerender }) => {
    const [seatNumber, setSeatNumber] = useState('');
    const [row, setRow] = useState('');
    const [seatTypeId, setSeatTypeId] = useState('');
    const [error, setError] = useState('');
    const { createSeat } = useSeats();
    
    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        try {
            createSeat(hallId, seatNumber, row, seatTypeId, setShowError, setOccuredError);
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
            <Form.Group className="mb-3" controlId="formBasicSeatNumber">
                <Form.Label>Номер місця</Form.Label>
                <Form.Control
                    type="text"
                    placeholder="Введіть номер місця"
                    value={seatNumber}
                    onChange={(event) => setSeatNumber(event.target.value)}
                />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicRow">
                <Form.Label>Ряд</Form.Label>
                <Form.Control
                    type="text"
                    placeholder="Введіть ряд"
                    value={row}
                    onChange={(event) => setRow(event.target.value)}
                />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicSeatTypeId">
                <Form.Label>Тип місця</Form.Label>
                <Form.Control
                    type="text"
                    placeholder="Введіть тип місця"
                    value={seatTypeId}
                    onChange={(event) => setSeatTypeId(event.target.value)}
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

export default CreateSeat;
