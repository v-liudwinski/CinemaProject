import {AxiosError, isAxiosError} from 'axios';
import React, { useState } from 'react';
import { Button, Form } from 'react-bootstrap';
import http from '../../http-common';

type RegisterFormProps = {
  onClose: () => void;
};

const RegisterForm: React.FC<RegisterFormProps> = ({ onClose }) => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [birthday, setBirthday] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');

  const [error, setError] = useState('');

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    try{
      await http.post('/users', {
        email, password, firstName, lastName, birthday, phoneNumber
      });
      
      sessionStorage.setItem('condition', 'true');
      onClose();
    }
    catch(responseError)
    {
      if(isAxiosError(responseError)){
        setError((responseError as AxiosError).message)
      }
      sessionStorage.setItem('condition', 'false');
    }
  };

  return (
    <Form onSubmit={handleSubmit}>
      <Form.Group className="mb-3" controlId="formBasicEmail">
        <Form.Label>Електронна пошта</Form.Label>
        <Form.Control type="email" placeholder="Введіть пошту" value={email} onChange={(event) => setEmail(event.target.value)} />
      </Form.Group>

      <Form.Group className="mb-3" controlId="formBasicPassword">
        <Form.Label>Пароль</Form.Label>
        <Form.Control type="password" placeholder="Введіть пароль" value={password} onChange={(event) => setPassword(event.target.value)} />
      </Form.Group>

      <Form.Group className="mb-3" controlId="formBasicFirstName">
        <Form.Label>Ім'я</Form.Label>
        <Form.Control type="text" placeholder="Введіть ім'я" value={firstName} onChange={(event) => setFirstName(event.target.value)} />
      </Form.Group>

      <Form.Group className="mb-3" controlId="formBasicLastName">
        <Form.Label>Прізвище</Form.Label>
        <Form.Control type="text" placeholder="Введіть прізвище" value={lastName} onChange={(event) => setLastName(event.target.value)} />
      </Form.Group>

      <Form.Group className="mb-3" controlId="formBasicBirthday">
        <Form.Label>День народження</Form.Label>
        <Form.Control type="date" placeholder="Введіть День народження" value={birthday} onChange={(event) => setBirthday(event.target.value)} />
      </Form.Group>

      <Form.Group className="mb-3" controlId="formBasicPhoneNumber">
        <Form.Label>Мобільний номер</Form.Label>
        <Form.Control type="tel" placeholder="Введіть номер" value={phoneNumber} onChange={(event) => setPhoneNumber(event.target.value)} />
      </Form.Group>

      {error && <div>{error}</div>}
      <div className="d-grid gap-2">
        <Button variant="outline-primary" type="submit">
          Зареєструватися
        </Button>
      </div>
    </Form>
  );
};

export default RegisterForm;