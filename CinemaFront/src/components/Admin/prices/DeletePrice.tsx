import { Button, Col, Container, Row } from "react-bootstrap";
import usePrices from "../../../hooks/PricesHook";
import CustomError from "../../../types/errorTypes/CustomError";

interface DeletePriceProps {
    priceId: number; 
    close: () => void;
    setRerender: (value: boolean | ((prevVar: boolean) => boolean)) => void;
    setShowError: (value: boolean) => void;
    setOccuredError: (value: CustomError) => void;
}

const DeletePrice: React.FC<DeletePriceProps> = ({ setOccuredError, setShowError, priceId, setRerender, close}) => {
    const { deletePrice } = usePrices();

    return (
        <>
            <h2 className="text-center mb-4">Видалити прайс?</h2>
            <Container>
                <Row>
                    <Col></Col>
                    <Col>
                        <Button variant="danger" className="btn-lg" onClick={() => {
                            deletePrice(priceId, setShowError, setOccuredError);
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

export default DeletePrice;