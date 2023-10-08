import { Button, Col, Container, Row } from "react-bootstrap";
import Hall from "../../../types/cinemaTypes/Hall";

interface HallRowProps {
    hall: Hall;
    modal: boolean;
    open: () => void;
    setCurrentHallId: (num: number) => void;
    setCurrentOption: (option: string) => void;
    setSize: (size: string) => void;
    setShowSeat: (flag: boolean) => void;
    setShowHall: (flag: boolean) => void;
    setShowCinema: (flag: boolean) => void;
    setHallId: (id: number) => void;
    setHall: (x: Hall) => void;
}

const HallRow: React.FC<HallRowProps> = ({ setHall, setHallId, hall, open, setCurrentHallId, setCurrentOption, setSize, setShowHall, setShowSeat }) => {
    
    return (
        <tr>
            <td>{hall.id}</td>
            <td>{hall.hallNumber}</td>
            <td>
                <Container>
                    <Row>
                        <Col>
                            <Button variant="outline-danger" className="text-white" onClick={() => {
                                setShowHall(false);
                                setShowSeat(true);
                                setHallId(hall.id);
                                }}>Місця</Button>
                        </Col>
                        <Col>
                            <Button variant="outline-danger" className="text-white" onClick={() => {
                                setHall(hall);
                                setCurrentHallId(hall.id);
                                setCurrentOption('updateHall');
                                setSize('lg');
                                open();
                            }}>Редагувати</Button>
                        </Col>
                        <Col>
                            <Button variant="outline-danger" className="text-white" onClick={() => {
                                setCurrentHallId(hall.id);
                                setCurrentOption('deleteHall');
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

export default HallRow;
