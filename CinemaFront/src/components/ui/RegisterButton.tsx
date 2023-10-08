import React, { useState } from 'react';
import { Modal } from 'react-bootstrap';
import RegisterForm from '../forms/RegisterForm';
import AuthForm from '../forms/LoginForm';

const RegisterButton: React.FC = () => {
    const [isModalOpen, setIsModalOpen] = useState(false);
    const condition = sessionStorage.getItem('condition');
    const conditionBool = Boolean(condition);
  
    const handleOpenModal = () => {
      setIsModalOpen(true);
    };
  
    const handleCloseModal = () => {
      setIsModalOpen(false);
    };
  
    return (
      <>
        <div>
          <button className="nav-link px-2 text-white" onClick={handleOpenModal}>Реєстрація</button>
          <Modal show={isModalOpen} onHide={handleCloseModal}>
            <Modal.Header className="bg-dark text-light" closeButton>
              <Modal.Title>Реєстрація</Modal.Title>
            </Modal.Header>
            <Modal.Body className="bg-dark text-light">
              <RegisterForm onClose={handleCloseModal} />
            </Modal.Body>
          </Modal>
        </div>
        <>
          {conditionBool ? <AuthForm openCondition={conditionBool} /> : null}
        </>
      </>
    );
  };
  
  export default RegisterButton;