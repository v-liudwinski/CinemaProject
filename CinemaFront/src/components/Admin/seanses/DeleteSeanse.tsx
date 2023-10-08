import { Button, Col, Container, Row } from "react-bootstrap";
import useSeanses from "../../../hooks/SeanseHook";
import CustomError from "../../../types/errorTypes/CustomError";

interface DeleteSeanseProps {
    seanseId: number; 
    close: () => void;
    setRerender: (value: boolean | ((prevVar: boolean) => boolean)) => void;
    setShowError: (value: boolean) => void;
    setOccuredError: (value: CustomError) => void;
}

const DeleteSeanse: React.FC<DeleteSeanseProps> = ({ setOccuredError, setShowError, seanseId, setRerender, close}) => {
    const { deleteSeanse } = useSeanses();

    return (
        <>
            <h2 className="text-center mb-4">Видалити сеанс?</h2>
            <Container>
                <Row>
                    <Col></Col>
                    <Col>
                        <Button variant="danger" className="btn-lg" onClick={() => {
                            deleteSeanse(seanseId, setShowError, setOccuredError);
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

export default DeleteSeanse;