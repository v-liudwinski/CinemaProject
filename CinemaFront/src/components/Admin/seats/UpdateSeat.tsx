import React, { useState } from "react";
import { Alert, Button, Form } from "react-bootstrap";
import useSeats from "../../../hooks/SeatsHook";
import Seat from "../../../types/seatTypes/Seat";
import CustomError from "../../../types/errorTypes/CustomError";

type UpdateSeatFormProps = {
    close: () => void;
    seat: Seat;
    hallId: number;
    setRerender: (value: boolean | ((prevVar: boolean) => boolean)) => void;
    setShowError: (value: boolean) => void;
    setOccuredError: (value: CustomError) => void;
};

const UpdateSeat: React.FC<UpdateSeatFormProps> = ({ setOccuredError, setShowError, hallId, close, seat, setRerender }) => {
    const [seatNumber, setSeatNumber] = useState(seat.seatNumber.toString());
    const [row, setRow] = useState(seat.row.toString());
    const [error, setError] = useState("");
    const { updateSeat } = useSeats();

    const [type, setType] = useState('');

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        try {
            updateSeat(seat.id, hallId, seatNumber, row, type, setShowError, setOccuredError)
            close();
            setTimeout(() => {
                setRerender(x => !x)
            }, 1000);
        } catch {
            setError("Invalid input");
        }
    };

    const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setType(event.target.value);
    };

    return (
        <Form onSubmit={handleSubmit}>
            <Form.Group className="mb-3" controlId="formBasicSeatNumber">
                <Form.Label>Номер місця</Form.Label>
                <Form.Control
                    type="text"
                    placeholder="Введіть номер місця"
                    value={seatNumber}
                    onChange={(event) => setSeatNumber(event.target.value)}/>
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicRow">
                <Form.Label>Ряд</Form.Label>
                <Form.Control
                    type="text"
                    placeholder="Введіть ряд"
                    value={row}
                    onChange={(event) => setRow(event.target.value)}/>
            </Form.Group>

            <Form.Label className="mt-4">Тип місця</Form.Label>
            <Form.Check label="Звичайние" value='1' name="group-2" type='radio' onChange={handleChange} />
            <Form.Check label="Для інвалідів" value='2' name="group-2" type='radio' onChange={handleChange} />
            <Form.Check label="Для поцілунків" value='3' name="group-2" type='radio' onChange={handleChange} />
            <Form.Check label="VIP" value='4' name="group-2" type='radio' onChange={handleChange} />

            {error && <Alert variant="danger">{error}</Alert>}

            <div className="d-grid gap-2 mt-4">
                <Button variant="outline-primary" type="submit">
                    Редагувати
                </Button>
            </div>

            
        </Form>
    );
};

export default UpdateSeat;
