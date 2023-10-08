import React, { useState } from 'react';
import Button from 'react-bootstrap/Button';
import Offcanvas from 'react-bootstrap/Offcanvas';

export function Help() {
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  return (
    <>
      <Button className='sales-button bg-black' style={{border: 'none'}} onClick={handleShow}>
        Допомога
      </Button>

      <Offcanvas show={show} onHide={handleClose}>
        <Offcanvas.Header closeButton>
          <Offcanvas.Title>Допомога</Offcanvas.Title>
        </Offcanvas.Header>
        <Offcanvas.Body>
            <p>Якщо у вас є питання, ви можете написати нам листа на admin@gmail.com.</p>
            <p>Або подзвоніть нам на телефон: Або подзвоніть нам на телефон098-234-4455</p>
            
        </Offcanvas.Body>
      </Offcanvas>
    </>
  );
}

