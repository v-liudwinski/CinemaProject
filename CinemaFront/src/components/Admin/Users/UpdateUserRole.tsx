import React, { useState } from "react";
import { Alert, Button, Form } from "react-bootstrap";
import useUsers from "../../../hooks/UsersHook";

type UpdateUserProps = {
    close: () => void;
    userId: number; 
    setRerender: (value: boolean | ((prevVar: boolean) => boolean)) => void;
};

const UpdateUserRole: React.FC<UpdateUserProps> = ({ userId, close, setRerender }) => {
    const [role, setRole] = useState(0);
    const [error, setError] = useState('');
    const { updateUserRole } = useUsers();

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        try {
            updateUserRole(userId, role);
            close();
            setTimeout(() => {
                setRerender(x => !x);
            }, 1000);
        } catch {
            setError("Invalid input");
        }
    };

    const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setRole(event.target.value === 'admin'? 1 : 2);
    };

    return (
        <Form onSubmit={handleSubmit} className="p-3 text-center">
            <Form.Check inline label="Admin" value='admin' name="group-1" type='radio' onChange={handleChange} />
            <Form.Check inline label="User" value='user' name="group-1" type='radio' onChange={handleChange} />

            {error && <Alert variant="danger">{error}</Alert>}

            <div className="d-grid gap-2 mt-4">
                <Button variant="outline-primary" type="submit">
                    Редагувати
                </Button>
            </div>
        </Form>
    );
};

export default UpdateUserRole;
