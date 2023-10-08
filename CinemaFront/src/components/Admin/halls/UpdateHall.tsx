import React, { useState } from "react";
import { Alert, Button, Form } from "react-bootstrap";
import useHalls from "../../../hooks/HallsHook";
import Hall from "../../../types/cinemaTypes/Hall";
import CustomError from "../../../types/errorTypes/CustomError";

type UpdateHallFormProps = {
    close: () => void;
    hall: Hall;
    cinemaId: number;
    setRerender: (value: boolean | ((prevVar: boolean) => boolean)) => void;
    setShowError: (value: boolean) => void;
    setOccuredError: (value: CustomError) => void;
};

const UpdateHall: React.FC<UpdateHallFormProps> = ({ setOccuredError, setShowError, cinemaId, close, hall, setRerender }) => {
    const [hallNumber, setHallNumber] = useState(hall.hallNumber.toString());
    const [error, setError] = useState("");
    const { updateHall } = useHalls();

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        try {
            updateHall(hall.id, cinemaId, hallNumber, setShowError, setOccuredError);
            close();
            setTimeout(() => {
                setRerender(x => !x);
            }, 1000);
        } catch {
            setError("Invalid input");
        }
    };

    return (
        <Form onSubmit={handleSubmit}>
            <Form.Group className="mb-3" controlId="formBasicHallNumber">
                <Form.Label>Номер залу</Form.Label>
                <Form.Control
                    type="number"
                    placeholder="Введіть номер залу"
                    value={hallNumber}
                    onChange={(event) => setHallNumber(event.target.value)}
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

export default UpdateHall;
