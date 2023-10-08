import { Button, Col, Container, Row } from "react-bootstrap";
import useHalls from "../../../hooks/HallsHook";
import CustomError from "../../../types/errorTypes/CustomError";

interface DeleteHallProps {
    hallId: number; 
    close: () => void;
    setRerender: (value: boolean | ((prevVar: boolean) => boolean)) => void;
    setShowError: (value: boolean) => void;
    setOccuredError: (value: CustomError) => void;
}

const DeleteHall: React.FC<DeleteHallProps> = ({ setOccuredError, setShowError, hallId, setRerender, close}) => {
    const { deleteHall } = useHalls();

    return (
        <>
            <h2 className="text-center mb-4">Видалити зал?</h2>
            <Container>
                <Row>
                    <Col></Col>
                    <Col>
                        <Button variant="danger" className="btn-lg" onClick={() => {
                            deleteHall(hallId, setShowError, setOccuredError);
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

export default DeleteHall;