import React, { useState } from "react";
import { Alert, Button, Form } from "react-bootstrap";
import Price from "../../../types/priceTypes/Price";
import usePrices from "../../../hooks/PricesHook";
import CustomError from "../../../types/errorTypes/CustomError";

type UpdatePriceFormProps = {
    close: () => void;
    price: Price;
    setRerender: (value: boolean | ((prevVar: boolean) => boolean)) => void;
    setShowError: (value: boolean) => void;
    setOccuredError: (value: CustomError) => void;
};

const UpdatePrice: React.FC<UpdatePriceFormProps> = ({ setOccuredError, setShowError, close, price, setRerender }) => {
    const [cost, setCost] = useState(price.cost);       
    const [error, setError] = useState("");
    const { updatePrice } = usePrices();


    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        try {
            updatePrice(price.id, cost, setShowError, setOccuredError)
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
                <Form.Label>Ціна </Form.Label>
                <Form.Control
                    type="number"
                    placeholder="Введіть ціну"
                    value={cost}
                    onChange={(event: any) => setCost(event.target.value)}
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

export default UpdatePrice;
