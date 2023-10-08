import React, { useState } from 'react';
import Button from 'react-bootstrap/Button';
import Offcanvas from 'react-bootstrap/Offcanvas';

export function Contacts() {
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  return (
    <>
      <Button className='sales-button bg-black' style={{border: 'none'}} onClick={handleShow}>
        Контакти
      </Button>

      <Offcanvas show={show} onHide={handleClose}>
        <Offcanvas.Header closeButton>
          <Offcanvas.Title>Контакти</Offcanvas.Title>
        </Offcanvas.Header>
        <Offcanvas.Body>
            <p>Адреса: м.Київ вул.Володимірівська, 2</p>
            <p>Телефон: 098-234-4455</p>
            
        </Offcanvas.Body>
      </Offcanvas>
    </>
  );
}

