import React, { useState } from "react";
import { Alert, Button, Form } from "react-bootstrap";
import CustomError from "../../../types/errorTypes/CustomError";
import usePromocodes from "../../../hooks/PromocodesHook";
import { Promocode } from "../../../types/promocodeTypes/Promocode";

type UpdatePromocodeFormProps = {
    close: () => void;
    promocode: Promocode;
    setRerender: (value: boolean | ((prevVar: boolean) => boolean)) => void;
    setShowError: (value: boolean) => void;
    setOccuredError: (value: CustomError) => void;
};

const UpdatePromocode: React.FC<UpdatePromocodeFormProps> = ({ setShowError, setOccuredError, close, promocode, setRerender }) => {
    const [name, setName] = useState(promocode.name);
    const [percentage, setPercentage] = useState(promocode.percentage);   
    const [error, setError] = useState("");
    const { updatePromocode } = usePromocodes();

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        try {
            updatePromocode(promocode.id, name, percentage, setShowError, setOccuredError)
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
                <Form.Label>Назва промокоду</Form.Label>
                <Form.Control
                    type="text"
                    placeholder="Введіть назву промокоду"
                    value={name}
                    onChange={(event: any) => setName(event.target.value)}
                />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicPercentage">
                <Form.Label>Відсоток</Form.Label>
                <Form.Control
                    type="number"
                    placeholder="Введіть відсоток"
                    value={percentage}
                    onChange={(event: any) => setPercentage(event.target.value)}
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

export default UpdatePromocode;
