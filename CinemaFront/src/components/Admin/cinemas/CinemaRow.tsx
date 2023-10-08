import { Button, Col, Container, Row } from "react-bootstrap";
import Cinema from "../../../types/cinemaTypes/Cinema";

interface CinemaRowProps {
    cinema: Cinema;
    modal: boolean;
    open: () => void;
    setCurrentCinemaId: (num: number) => void;
    setCurrentOption: (option: string) => void;
    setSize: (size: string) => void;
    setShowHall: (flag: boolean) => void;
    setShowCinema: (flag: boolean) => void;
    setCinemaId: (id: number) => void;
    setCinema: (cinema: Cinema) => void;
}

const CinemaRow: React.FC<CinemaRowProps> = ({ setCinema, setCinemaId, setShowHall, setShowCinema, cinema, open, setCurrentCinemaId, setCurrentOption, setSize }) => {
    return (
        <tr>
            <td>{cinema.id}</td>
            <td>{cinema.name}</td>
            <td>{cinema.city.slice(0, 10)}</td>
            <td>{cinema.address}</td>
            <td>{cinema.email}</td>
            <td>{cinema.phoneNumber}</td>
            <td>
                <Container>
                    <Row>
                        <Col>
                            <Button variant="outline-danger" className="text-white" onClick={() => {
                                setShowHall(true);
                                setShowCinema(false);
                                setCurrentCinemaId(cinema.id);
                                setCinemaId(cinema.id);
                            }}>Зали</Button>
                        </Col>
                        <Col>
                            <Button variant="outline-danger" className="text-white" onClick={() => {
                                setCurrentCinemaId(cinema.id);
                                setCinema(cinema);
                                setCurrentOption('updateCinema');
                                setSize('lg');
                                open();
                            }}>Редагувати</Button>
                        </Col>
                        <Col>
                            <Button variant="outline-danger" className="text-white" onClick={() => {
                                setCurrentCinemaId(cinema.id);
                                setCurrentOption('deleteCinema');
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

export default CinemaRow;
