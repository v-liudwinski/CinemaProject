import { Button, Col, Container, Row } from "react-bootstrap";

interface DeleteUserProps {
    userId: number; 
    deleteUser: (id: number) => void;
    close: () => void;
    setRerender: (value: boolean | ((prevVar: boolean) => boolean)) => void;
}

const DeleteUser: React.FC<DeleteUserProps> = ({ setRerender, userId, deleteUser, close }) => {
    return (
        <>
            <h3 className="text-center mb-4">Видалити цього користувача?</h3>
            <Container>
                <Row>
                    <Col></Col>
                    <Col>
                        <Button variant="danger" className="btn-lg" onClick={() => {
                            deleteUser(userId);
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
    )
}

export default DeleteUser;