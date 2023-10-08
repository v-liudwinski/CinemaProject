import { Button, Col, Container, Row } from "react-bootstrap";
import useCinemas from "../../../hooks/CinemasHook";
import CustomError from "../../../types/errorTypes/CustomError";

interface DeleteCinemaProps {
    cinemaId: number; 
    close: () => void;
    setRerender: (value: boolean | ((prevVar: boolean) => boolean)) => void;
    setShowError: (value: boolean) => void;
    setOccuredError: (value: CustomError) => void;
}

const DeleteCinema: React.FC<DeleteCinemaProps> = ({ setOccuredError, setShowError, cinemaId, close, setRerender }) => {
    const { deleteCinema } = useCinemas();

    return (
        <>
            <h2 className="text-center mb-4">Видалити кінотеатр?</h2>
            <Container>
                <Row>
                    <Col></Col>
                    <Col>
                        <Button
                            variant="danger"
                            className="btn-lg"
                            onClick={() => {
                                deleteCinema(cinemaId, setShowError, setOccuredError);
                                close();
                                setTimeout(() => {
                                    setRerender(x => !x)
                                }, 1000);
                            }}>Видалити</Button>
                    </Col>
                    <Col></Col>
                </Row>
            </Container>
        </>
    );
};

export default DeleteCinema;
