import React, { useState } from "react";
import { Alert, Button, Form } from "react-bootstrap";
import Cinema from "../../../types/cinemaTypes/Cinema";
import useCinemas from "../../../hooks/CinemasHook";
import CustomError from "../../../types/errorTypes/CustomError";

type UpdateCinemaFormProps = {
    close: () => void;
    cinema: Cinema;
    setRerender: (value: boolean | ((prevVar: boolean) => boolean)) => void;
    setShowError: (value: boolean) => void;
    setOccuredError: (value: CustomError) => void;
};

const UpdateCinema: React.FC<UpdateCinemaFormProps> = ({ setOccuredError, setShowError, close, cinema, setRerender }) => {
    const [name, setName] = useState(cinema.name);
    const [address, setAddress] = useState(cinema.address);
    const [city, setCity] = useState(cinema.city);
    const [email, setEmail] = useState(cinema.email);
    const [phoneNumber, setPhoneNumber] = useState(cinema.phoneNumber);
    const [error, setError] = useState("");
    const { updateCinema } = useCinemas();


    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        try {
            updateCinema(cinema.id, email, address, phoneNumber, city, name, setShowError, setOccuredError)
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
                <Form.Label>Назва </Form.Label>
                <Form.Control
                    type="text"
                    placeholder="Введіть назву"
                    value={name}
                    onChange={(event) => setName(event.target.value)}
                />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicAddress">
                <Form.Label>Адреса</Form.Label>
                <Form.Control
                    type="text"
                    placeholder="Введіть адресу"
                    value={address}
                    onChange={(event) => setAddress(event.target.value)}
                />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicCity">
                <Form.Label>Місто</Form.Label>
                <Form.Control
                    type="text"
                    placeholder="Введіть місто"
                    value={city}
                    onChange={(event) => setCity(event.target.value)}
                />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicEmail">
                <Form.Label>Пошта</Form.Label>
                <Form.Control
                    type="email"
                    placeholder="Введіть пошту"
                    value={email}
                    onChange={(event) => setEmail(event.target.value)}
                />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicPhoneNumber">
                <Form.Label>Номер телефону</Form.Label>
                <Form.Control
                    type="tel"
                    placeholder="Введіть номер"
                    value={phoneNumber}
                    onChange={(event) => setPhoneNumber(event.target.value)}
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

export default UpdateCinema;
