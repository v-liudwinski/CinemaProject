import React, { useState } from 'react';
import Button from 'react-bootstrap/Button';
import Offcanvas from 'react-bootstrap/Offcanvas';

export function Sales() {
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  return (
    <>
      <Button className='sales-button bg-black' style={{border: 'none'}} onClick={handleShow}>
        Акції та знижки
      </Button>

      <Offcanvas show={show} onHide={handleClose}>
        <Offcanvas.Header closeButton>
          <Offcanvas.Title>Акції та знижки</Offcanvas.Title>
        </Offcanvas.Header>
        <Offcanvas.Body>
            <p>Особливий тариф для дошкільнят/школярів/студентів/пенсіонерів - це знижка у розмірі  10 грн від стандартної вартості квитка на сеанси і тільки на місця сектору GOOD. Тарифи діють після першого вікенду прокату фільму та не сумуються з іншими акціями.</p>

            <p>Спеціальний тариф надається студентам тільки стаціонарної форми навчання, і тільки при наявності оригінального студентського квитка, виданого ВНЗ України (1 студенський квиток = 1 квиток у кіно зі знижкою).</p>

            <p>Акційний тариф для школярів надається при наявності учнівського квитка або документа, що його замінює (1 учнівський квиток = 1 квиток у кіно зі знижкою)</p>

            <p>Тариф «Дитячий» діє виключно на фільми з віковим обмеженням ЗА (0+) та надає вибір: або батьки тримають дітей на руках і не оплачують квиток, або ж купують дитині квиток по тарифу мінус 10 грн. </p>
            <p>Квитки по тарифу «Пенсіонер» можна придбати лише при наявності пенсійного посвідчення, що посвідчують особу та підтверджують її статус (1 пенсійне посвідчення = 1 квиток у кіно зі знижкою).</p>
        </Offcanvas.Body>
      </Offcanvas>
    </>
  );
}

