import { Button, Card, Col, Row } from 'react-bootstrap'
import Ticket from '../../../types/purchaseTypes/Ticket';
import usePurchases from '../../../hooks/PurchasesHook';

interface TicketGroupProps {
    ticket: Ticket
}

export default function TicketGroup({ticket}: TicketGroupProps) {
  const seatType = ticket.seat.seatType.type === 'Normal' ? 'Звичайний'
    : ticket.seat.seatType.type === 'ForDisablers' ? 'Для інвалідів' 
    : ticket.seat.seatType.type === 'ForKissing' ? 'Для поцілунків' : "VIP";

  const { downloadFileAtUrl } = usePurchases();

  return (
    <Row>
      <Card className='m-5 mt-3 mb-0 text-center'  style={{width: '55rem'}}>
        <Row>
          <Card.Img className="img-thumbnail" style={{ width: '12rem' }} variant="top" src={ticket.seanse.movie.posterUrl} />

          <Col>
            <Card.Body>
              <Card.Title>
                <h5>Квиток: {ticket.id}</h5> 
                <h5>Ціна квитка: {ticket.price} ₴</h5>
              </Card.Title>
              <Card.Text>
                Сеанс: {ticket.seanse.id}<br></br>
                Зал: {ticket.seanse.hallId}<br></br>
                Дата початку: {ticket.seanse.startTime}<br></br>

                Назва фільму: {ticket.seanse.movie.title}<br></br>
                Назва фільму в оригіналі: {ticket.seanse.movie.originalTitle}<br></br>
                Тривалість: {ticket.seanse.movie.duration}
              </Card.Text>
            </Card.Body>
            <Card.Footer>
              <small className="text-muted">
                Місце: Ряд {ticket.seat.row} |
                Номер {ticket.seat.seatNumber} |
                Тип місця {seatType}
              </small>
              <Button className='ms-5' onClick={() => downloadFileAtUrl(ticket.id)}>Download</Button>
            </Card.Footer>
          </Col>
        </Row>
      </Card>
    </Row>
  )
}
