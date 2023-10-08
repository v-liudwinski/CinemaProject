import { Button, Col, Container, Row } from "react-bootstrap";
import User from "../../../types/userTypes/User";

interface UserRowProps {
    user: User;
    modal: boolean;
    open: () => void;
    setCurrentUserId: (num: number) => void;
    setCurrentOption: (option: string) => void;
    setSize: (size: string) => void;
}

const UserRow: React.FC<UserRowProps> = ({ user, open, setCurrentUserId, setCurrentOption, setSize }) => {
    return (
        <tr>
            <td>{user.id}</td>
            <td>{user.firstName}</td>
            <td>{user.lastName}</td>
            <td>{user.email}</td>
            <td>{user.phoneNumber}</td>
            <td>{user.birthday.slice(0, 10)}</td>
            <td>{user.roleName}</td>
            <td>
                <Container>
                    <Row>
                        <Col>
                            <Button variant="outline-danger" className="text-white"  onClick={() => {
                                setCurrentUserId(user.id);
                                open();
                                setCurrentOption('showUser');
                                setSize('lg');
                            }}>Інформація</Button>
                        </Col>
                        <Col>
                            <Button variant="outline-danger" className="text-white"  onClick={() => {
                                setCurrentUserId(user.id);
                                open();
                                setCurrentOption('purchasesUser');
                                setSize('xl');
                            }}>Покупки</Button>
                        </Col>
                        <Col>
                            <Button variant="outline-danger" className="text-white"  onClick={() => {
                                setCurrentUserId(user.id);
                                open();
                                setCurrentOption('updateUser');
                                setSize('lg');
                            }}>Редагувати</Button>
                        </Col>
                        <Col>
                            <Button variant="outline-danger" className="text-white" onClick={() => {
                                setCurrentUserId(user.id);
                                open();
                                setCurrentOption('deleteUser');
                                setSize('sm');
                            }}>Видалити</Button>
                        </Col>
                    </Row>
                </Container>
            </td>
        </tr>
    );
};

export default UserRow;
