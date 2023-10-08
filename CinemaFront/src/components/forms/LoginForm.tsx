import React, { useState } from 'react';
import { Button, Form, Modal} from 'react-bootstrap';
import { DecodedToken, verifyAuthToken } from '../../hooks/VerifyAuthToken';
import http from '../../http-common';

interface AuthFormProps{
  openCondition?: boolean;
}

const AuthForm: React.FC<AuthFormProps> = ({openCondition}) => {
  const [isModalOpen, setIsModalOpen] = useState(openCondition);

  const handleCloseModal = () => {
    setIsModalOpen(false);
  };

  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    // Handle login logic here
    try {
      // Send a request to the server to authenticate the user and get a JWT token
      const response = await http.post('/auth/login', {email, password});
      const token = response.data;

      localStorage.setItem('token', token);

      const tokenInfo = verifyAuthToken();
      if (tokenInfo){
        const decodedToken = tokenInfo as DecodedToken;
        localStorage.setItem('role', decodedToken.role);
      }
      sessionStorage.clear()
      window.location.href = "/Account";
    }
    catch {
      // If authentication fails, show an error message
      setError('Invalid email or password');
    }
  };

  const handleEmailChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setEmail(event.target.value);
  };

  const handlePasswordChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setPassword(event.target.value);
  };
  
  return (
    <div>
      <Modal show={isModalOpen} onHide={handleCloseModal}>
        <Modal.Header className="bg-dark text-light" closeButton>
          <Modal.Title>Вхід</Modal.Title>
        </Modal.Header>
        <Modal.Body className="bg-dark text-light">
          <Form onSubmit={handleSubmit}>
            <Form.Group className="mb-3" controlId="formBasicEmail">
              <Form.Label>Електронна пошта</Form.Label>
              <Form.Control type="email" placeholder="Введіть пошту" value={email} onChange={handleEmailChange} />
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicPassword">
              <Form.Label>Пароль</Form.Label>
              <Form.Control type="password" placeholder="Введіть пароль" value={password} onChange={handlePasswordChange} />
            </Form.Group>
            {error && <div>{error}</div>}
            <Button variant="primary" type="submit" className="w-100">
              Увійти
            </Button>
          </Form>
        </Modal.Body>
      </Modal>
    </div>
  );
  };
  
  export default AuthForm;