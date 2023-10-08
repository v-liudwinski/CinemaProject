import { Button, Col, Container, Row } from "react-bootstrap";
import useSeats from "../../../hooks/SeatsHook";
import CustomError from "../../../types/errorTypes/CustomError";

interface DeleteSeatProps {
    seatId: number; 
    close: () => void;
    setRerender: (value: boolean | ((prevVar: boolean) => boolean)) => void;
    setShowError: (value: boolean) => void;
    setOccuredError: (value: CustomError) => void;
}

const DeleteSeat: React.FC<DeleteSeatProps> = ({ setOccuredError, setShowError, seatId, close, setRerender }) => {
    const { deleteSeat } = useSeats();
    
    return (
        <>
            <h2 className="text-center mb-4">Видалити місце?</h2>
            <Container>
                <Row>
                    <Col></Col>
                    <Col>
                        <Button variant="danger" className="btn-lg" onClick={() => {
                            deleteSeat(seatId, setShowError, setOccuredError);
                            close();
                            setTimeout(() => {
                                setRerender(x => !x)
                            }, 1000);
                        }}>Видалити </Button>
                    </Col>
                    <Col></Col>
                </Row>
            </Container>
        </>
    )
}

export default DeleteSeat;