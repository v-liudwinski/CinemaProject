import { Button, Col, Container, Row } from "react-bootstrap";
import Price from "../../../types/priceTypes/Price";

interface PriceRowProps {
    price: Price;
    modal: boolean;
    open: () => void;
    setCurrentPriceId: (num: number) => void;
    setCurrentOption: (option: string) => void;
    setSize: (size: string) => void;    
    setShowPrice: (flag: boolean) => void;  
    setPrice: (price: Price) => void;
}

const PriceRow: React.FC<PriceRowProps> = ({ setPrice, setShowPrice, price, open, setCurrentPriceId, setCurrentOption, setSize }) => {
    return (
        <tr>
            <td>{price.id}</td>
            <td>{price.cost}</td>         
            <td>
                <Container>
                    <Row>                       
                        <Col>
                            <Button variant="outline-danger" className="text-white" onClick={() => {
                                setCurrentPriceId(price.id);
                                setPrice(price);
                                setCurrentOption('updatePrice');
                                setSize('lg');
                                open();
                            }}>Редагувати</Button>
                        </Col>
                        <Col>
                            <Button variant="outline-danger" className="text-white" onClick={() => {
                                setCurrentPriceId(price.id);
                                setCurrentOption('deletePrice');
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

export default PriceRow;