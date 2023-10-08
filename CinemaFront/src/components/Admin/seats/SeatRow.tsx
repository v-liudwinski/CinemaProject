import { Button, Col, Container, Nav, Row } from "react-bootstrap";
import Seat from "../../../types/seatTypes/Seat";

interface SeatRowProps {
    seat: Seat;
    modal: boolean;
    open: () => void;
    setCurrentSeatId: (num: number) => void;
    setCurrentOption: (option: string) => void;
    setSize: (size: string) => void;
    setSeat: (seat: Seat) => void;
}

const SeatRow: React.FC<SeatRowProps> = ({ setSeat, seat, open, setCurrentSeatId, setCurrentOption, setSize }) => {
    return (
        <tr>
            <td>{seat.id}</td>
            <td>{seat.row}</td>
            <td>{seat.seatNumber}</td>
            <td>{seat.seatType.price}</td>
            <td>{seat.seatType.type}</td>
            <td>
                <Container>
                    <Row>
                        <Col>
                            <Button variant="outline-danger" className="text-white" onClick={() => {
                                setSeat(seat);
                                setCurrentSeatId(seat.id);
                                setCurrentOption('updateSeat');
                                setSize('lg');
                                open();
                            }}>Редагувати</Button>
                        </Col>
                        <Col>
                            <Button variant="outline-danger" className="text-white" onClick={() => {
                                setCurrentSeatId(seat.id);
                                setCurrentOption('deleteSeat');
                                setSize('sm');
                                open();
                            }}>Видалити</Button>
                        </Col>
                    </Row>
                </Container>
            </td>
        </tr>
    );
};

export default SeatRow;
