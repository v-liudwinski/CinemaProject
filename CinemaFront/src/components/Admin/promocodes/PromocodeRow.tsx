import { Button, Col, Container, Row } from "react-bootstrap";
import { Promocode } from "../../../types/promocodeTypes/Promocode";

interface PromocodeRowProps {
    promocode: Promocode;
    modal: boolean;
    open: () => void;
    setCurrentPromocodeId: (num: number) => void;
    setCurrentOption: (option: string) => void;
    setSize: (size: string) => void;    
    setPromocode: (Promocode: Promocode) => void;
}

const PromocodeRow: React.FC<PromocodeRowProps> = ({ setPromocode, promocode, open, setCurrentPromocodeId, setCurrentOption, setSize }) => {
    return (
        <tr>
            <td>{promocode.id}</td>
            <td>{promocode.name}</td>
            <td>{promocode.percentage}</td>         
            <td>
                <Container>
                    <Row>                       
                        <Col>
                            <Button variant="outline-danger" className="text-white" onClick={() => {
                                setCurrentPromocodeId(promocode.id);
                                setPromocode(promocode);
                                setCurrentOption('updatePromocode');
                                setSize('lg');
                                open();
                            }}>Редагувати</Button>
                        </Col>
                        <Col>
                            <Button variant="outline-danger" className="text-white" onClick={() => {
                                setCurrentPromocodeId(promocode.id);
                                setCurrentOption('deletePromocode');
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

export default PromocodeRow;