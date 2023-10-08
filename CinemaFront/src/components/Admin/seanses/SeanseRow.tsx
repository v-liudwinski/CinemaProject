import { Button, Col, Container, Row } from "react-bootstrap";
import Seanse from "../../../types/seanseTypes/Seanse";

interface SeanseRowProps {
    seanse: Seanse;
    modal: boolean;
    open: () => void;
    setCurrentSeanseId: (num: number) => void;
    setCurrentOption: (option: string) => void;
    setSize: (size: string) => void;    
    setShowSeanse: (flag: boolean) => void;  
    setSeanse: (seanse: Seanse) => void;
}

const SeanseRow: React.FC<SeanseRowProps> = ({ setSeanse, setShowSeanse, seanse, open, setCurrentSeanseId, setCurrentOption, setSize }) => {
    return (
        <tr>
            <td>{seanse.id}</td>
            <td>{new Date(seanse.startTime).toLocaleTimeString().slice(0, 5)}</td>
            <td>{seanse.hallId}</td>
            <td>{seanse.movie.title}</td>
            <td>{seanse.price.cost}</td>         
            <td>
                <Container>
                    <Row>                       
                        <Col>
                            <Button variant="outline-danger" className="text-white" onClick={() => {
                                setCurrentSeanseId(seanse.id);
                                setSeanse(seanse);
                                setCurrentOption('updateSeanse');
                                setSize('lg');
                                open();
                            }}>Редагувати</Button>
                        </Col>
                        <Col>
                            <Button variant="outline-danger" className="text-white" onClick={() => {
                                setCurrentSeanseId(seanse.id);
                                setCurrentOption('deleteSeanse');
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

export default SeanseRow;