import { useEffect } from "react";
import UserInfo from "../../../types/userTypes/UserInfo";
import { Accordion, Alert, Container } from "react-bootstrap";
import ReviewItem from "../reviews/ReviewItem";
import FavouriteItem from "../favorites/FavoriteItem";

interface ShowUserProps {
    userId: number; 
    user: UserInfo;
    getUser: (id: number) => void;
}

const ShowUser: React.FC<ShowUserProps> = ({userId, getUser, user}) => {
    
    useEffect(() => {
        getUser(userId);
    }, []);

    return (
        <>
            <h2>{user.firstName} {user.lastName}</h2>
            <Alert variant="secondary">
                <h5>Номер телефону: {user.phoneNumber}</h5>
                <h5>Пошта: {user.email}</h5>
            </Alert>
            <Alert variant="primary">
                <h5>Дата народження: {user.birthday}</h5>
            </Alert>

            {user.userDetails.reviews.length > 0 &&
            <Container className="text-center mb-3">
            <Accordion defaultActiveKey="1">
                <Accordion.Item eventKey="0">
                    <Accordion.Header><h4 className="text-center">Відгуки</h4></Accordion.Header>
                    <Accordion.Body>
                        {user.userDetails.reviews.map(x => <ReviewItem review={x} key={x.id} />)}
                    </Accordion.Body>
                </Accordion.Item>
            </Accordion>
            </Container>}
            
            {user.userDetails.favourites.length > 0 &&
            <Container className="text-center">
            <Accordion defaultActiveKey="1">
                <Accordion.Item eventKey="0">
                    <Accordion.Header><h4 className="text-center">Улюблені</h4></Accordion.Header>
                    <Accordion.Body>
                        {user.userDetails.favourites.map((x, index) => <FavouriteItem favourite={x} key={index} />)}
                    </Accordion.Body>
                </Accordion.Item>
            </Accordion>
            </Container>}
        </>
    )
}

export default ShowUser;