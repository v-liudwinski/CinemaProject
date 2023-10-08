import { Button, Col, Container, Row } from "react-bootstrap";
import CustomError from "../../../types/errorTypes/CustomError";
import usePromocodes from "../../../hooks/PromocodesHook";

interface DeletePromocodeProps {
    promocodeId: number; 
    close: () => void;
    setRerender: (value: boolean | ((prevVar: boolean) => boolean)) => void;
    setShowError: (value: boolean) => void;
    setOccuredError: (value: CustomError) => void;
}

const DeletePromocode: React.FC<DeletePromocodeProps> = ({ setOccuredError, setShowError, promocodeId, setRerender, close}) => {
    const { deletePromocode } = usePromocodes();

    return (
        <>
            <h2 className="text-center mb-4">Видалити промокод?</h2>
            <Container>
                <Row>
                    <Col></Col>
                    <Col>
                        <Button variant="danger" className="btn-lg" onClick={() => {
                            deletePromocode(promocodeId, setShowError, setOccuredError);
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

export default DeletePromocode;