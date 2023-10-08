import React, { useState } from "react";
import { Alert, Button, Form } from "react-bootstrap";
import usePrices from "../../../hooks/PricesHook";
import CustomError from "../../../types/errorTypes/CustomError";
import Price from "../../../types/priceTypes/Price";

type CreatePriceFormProps = {
    close: () => void;
    price: Price;
    setRerender: (value: boolean | ((prevVar: boolean) => boolean)) => void;
    setShowError: (value: boolean) => void;
    setOccuredError: (value: CustomError) => void;
};

const CreatePrice: React.FC<CreatePriceFormProps> = ({ setOccuredError, setShowError, close, price, setRerender }) => {
    const [cost, setCost] = useState(0.0);    
    const [error, setError] = useState("");
    const { createPrice } = usePrices();
    
    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        try {
            createPrice(cost, setShowError, setOccuredError);
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
                <Form.Label>Ціна</Form.Label>
                <Form.Control
                    type="number"
                    placeholder="Введіть ціну"
                    value={cost}
                    onChange={(event: any) => setCost(event.target.value)}
                />
            </Form.Group>

            
            {error && <Alert variant="danger">{error}</Alert>}

            <div className="d-grid gap-2">
                <Button variant="outline-primary" size="lg" type="submit">
                    Створити
                </Button>
            </div>
        </Form>
    );
};

export default CreatePrice;