import React, { useState } from 'react';
import { Button, Form, Modal} from 'react-bootstrap';
import { getCurrentUserId } from '../../hooks/getCurrentUserId';
import UserInfo from '../../types/userTypes/UserInfo';
import http from '../../http-common';

interface UpdateUserFormProps{
  modalCondition?: boolean;
  currentUser: UserInfo;
}

const UpdateUserForm: React.FC<UpdateUserFormProps> = ({ modalCondition, currentUser }) => {
  const [isModalOpen, setIsModalOpen] = useState(modalCondition);

  // Parse the input date string into a Date object
  const date = new Date(currentUser.birthday);

  // Extract the year, month, and day from the Date object
  const year = date.getFullYear();
  const month = String(date.getMonth() + 1).padStart(2, '0'); // Month is zero-indexed, so we add 1
  const day = String(date.getDate()).padStart(2, '0');

  // Construct the output date string in the "YYYY-MM-DD" format
  const outputDate = `${year}-${month}-${day}`;
  
  function handleOpenModal(): void {
    setIsModalOpen(true);
    setEmail(currentUser.email)
    setPassword('')
    setFirstName(currentUser.firstName)
    setLastName(currentUser.lastName)
    setBirthday(outputDate)
    setPhoneNumber(currentUser.phoneNumber)
  }

  const handleCloseModal = () => {
    setIsModalOpen(false);
  };
  
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [birthday, setBirthday] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');

  const [error, setError] = useState('');

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    try {
      const id = getCurrentUserId();
      await http.put(`/users/${id}`, 
        { email, password, firstName, lastName, birthday, phoneNumber }
      );
      window.location.href = "/Account"
    }
    catch(error) {
      setError('Invalid input');
    }
  };
  
  return (
    <>
    <button className="text-white btn btn-outline-primary me-md-2" onClick={handleOpenModal}>
        Оновити інформацію
    </button>
    <Modal show={isModalOpen} onHide={handleCloseModal}>
      <Modal.Header className="bg-dark text-light" closeButton>
        <Modal.Title>Внесення змін</Modal.Title>
      </Modal.Header>
      <Modal.Body className="bg-dark text-light">
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
              Змінити інформацію
            </Button>
          </div>
        </Form>
      </Modal.Body>
    </Modal>
    </>
  );
};

export default UpdateUserForm;