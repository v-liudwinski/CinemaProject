import { Button, Card, Col, Container, Form, ListGroup, ListGroupItem, Row } from "react-bootstrap";
import Seanse from "../../types/seanseTypes/Seanse";
import SeatsForPurchase from "./SeatsForPurchase";
import { useEffect, useState } from "react";
import usePurchases from "../../hooks/PurchasesHook";
import CustomError, { defaultError } from "../../types/errorTypes/CustomError";
import AlertDismissible from "../shared/AlertDismissible";
import { getCurrentUserId } from '../../hooks/getCurrentUserId'
import { PayPalScriptProvider, PayPalButtons } from "@paypal/react-paypal-js";
import http from "../../http-common";
import { use } from "i18next";
import PurchaseDone from "../shared/PurchaseDone";
import { useNavigate } from "react-router-dom";

interface PurchaseTicketsProps {
    seanse: Seanse;
    setShowSeanses: (value: boolean | ((prevVar: boolean) => boolean)) => void;
    setShowSeanse: (value: boolean | ((prevVar: boolean) => boolean)) => void;
}

const PurchaseTickets: React.FC<PurchaseTicketsProps> = ({ setShowSeanse, setShowSeanses, seanse }) => {
    const [seatIds, setSeatIds] = useState<number[]>([]);
    const [promocode, setPromocode] = useState('');
    const { purchasing } = usePurchases();
    const [showError, setShowError] = useState(false);
    const [occuredError, setOccuredError] = useState<CustomError>(defaultError);
    const currentId = getCurrentUserId();
    const [promocodePercent, setPromocodePercent] = useState(0);
    const [sum, setSum] = useState(0);
    const [showPayPal, setShowPayPal] = useState(false);
    const [toOrder, setToOrder] = useState(true);
    const [orderCompleted, setOrderCompleted] = useState(false);
    const navigate = useNavigate();

    useEffect(() => {
        setSum(0);

        seatIds.map(x => {
            setSum(prev => prev + seanse.price.cost + seanse.hall.seats.filter(i => i.id === x)[0].seatType.price)
            
        })
    }, [seatIds])

    const getColor = (color: string) => {
        return color === 'Normal'? 'Звичайне' : 
            color === 'ForDisablers' ? 'Для інвалідів' :
            color === 'ForKissing' ? 'Для поцілунків' : 'VIP'
    }

    const addOrRemoveItemFromArray = (item: number) => {
        if (seatIds.includes(item)) {
            setSeatIds((prevState) =>
            prevState.filter((existing) => existing !== item));
        }
        else {
            setSeatIds((prevState) => [item, ...prevState]);
        }
    }

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        const response = await http.get('/promocodes/getpromocode?promocode=' + promocode);
        setPromocodePercent(response.data.percentage);
    };

    const initialOptions = {
        "client-id": "AXoWYNFdXPVlP8CiWBQn2RaYLPPeimFUXfT52QiwwXYWqtGVd8XGzu2-stzPNR7MwNkyiMIXE7o_hjXg",
        currency: "USD",
    };

    return (
        <Container className='p-5 pt-3'>
            <Row>
            <Col className="mt-3">
                <Card className='bg-dark text-white'>
                    <Row>
                        <Col sm={2}> 
                            <img src={seanse.movie.posterUrl} className="w-100" 
                                alt={`Постер ${seanse.movie.title}`} />
                        </Col>
                        <Col sm={4}>
                            <Card.Body className="mt-4">
                                <Card.Title>Сеанси №{seanse.id}</Card.Title>
                                <Card.Subtitle className="mb-2 text-muted">
                                Зал №{seanse.hall.hallNumber}
                                </Card.Subtitle>
                                <Card.Text>Початок сеансу: {new Date(seanse.startTime).toLocaleTimeString().slice(0, 5)}</Card.Text>
                            </Card.Body>
                            <ListGroup className="list-group-flush">
                                <ListGroupItem className='bg-dark text-white'>
                                    <strong>Фільм:</strong> {seanse.movie.title}
                                </ListGroupItem>
                                <ListGroupItem className='bg-dark text-white'>
                                    <strong>Оригінальна назва:</strong> {seanse.movie.originalTitle}
                                </ListGroupItem>
                            </ListGroup>
                        </Col>

                        <Col sm={4}>
                            <ListGroup className="mt-5">
                                <ListGroupItem className='bg-dark text-white'>
                                    <strong>Тривалість:</strong> {seanse.movie.duration} хвилин
                                </ListGroupItem>
                                <ListGroupItem className='bg-dark text-white'>
                                    <strong>Дата виходу:</strong> {new Date(seanse.movie.releaseDate).toLocaleDateString()}
                                </ListGroupItem>
                            </ListGroup>
                            <Card.Body>
                                <Card.Text>
                                    <strong>Ціна квитка:</strong> {seanse.price.cost} грн.
                                </Card.Text>
                            </Card.Body>
                        </Col>
                    </Row>
                </Card>
            </Col>
            </Row>
            <Col className="text-center align-items-center">
                <SeatsForPurchase seanseId={seanse.id} addOrRemoveItemFromArray={addOrRemoveItemFromArray}  
                seats={seanse.hall.seats} setSeatIds={setSeatIds} seatIds={seatIds} 
                setShowPayPal={setShowPayPal} setToOrder={setToOrder} />
            </Col>
            <Row className="mt-4">
                {seatIds.map((x, index) => {
                    return (
                        <Card className="mt-3 bg-dark text-white" key={index}>
                            <Row>
                                <Col>
                                    <Card.Body>
                                        <Card.Title>Квиток №{index + 1}</Card.Title>
                                        <Card.Text>
                                            <strong>Ціна квитка: </strong> 
                                            {seanse.price.cost + seanse.hall.seats.filter(i => i.id === x)[0].seatType.price} грн. 
                                        </Card.Text>
                                    </Card.Body>
                                </Col>
                                <Col>
                                    <Card.Body>
                                        <Col><Card.Title>Місце</Card.Title></Col>
                                        <Card.Text>
                                            {getColor(seanse.hall.seats.filter(i => i.id === x)[0].seatType.type)} | 
                                            Ряд: {seanse.hall.seats.filter(i => i.id === x)[0].row} |
                                            Місце: {seanse.hall.seats.filter(i => i.id === x)[0].seatNumber}
                                        </Card.Text>
                                    </Card.Body>
                                </Col>
                            </Row>
                        </Card>
                    );
                })}
            </Row>
            {seatIds.length !== 0 && 
            <div>
                <Row className="mb-3">
                    <Col></Col>
                    <Col>
                        <Card style={{ width: '48rem' }} className="mt-3 bg-dark text-white">
                            <Card.Body>
                                <Card.Title>Всього квитків: {seatIds.length}</Card.Title>
                                <Card.Text>
                                    <strong>Ціна: {promocodePercent === 0? sum : 
                                    ((100 - promocodePercent) * sum) / 100} грн.</strong> 
                                </Card.Text>
                            </Card.Body>
                        </Card>
                    </Col>
                    <Col></Col>
                </Row>

                <Row className="mb-5">
                    <Col></Col>
                    <Col>
                        {showPayPal === false && 
                        <Form onSubmit={handleSubmit}>
                            <Row>
                                <Col sm='7'>
                                    <Form.Group className="mb-3" controlId="formBasicPromocode">
                                        <Form.Control
                                            type="text"
                                            placeholder="Промокод"
                                            value={promocode}
                                            onChange={(event: any) => setPromocode(event.target.value)}/>
                                    </Form.Group>
                                </Col>
                                <Col></Col>
                                <Col>
                                    <Button className='mb-3' variant="danger" type="submit">
                                        Використати
                                    </Button>
                                </Col>
                            </Row>

                            {showError && <AlertDismissible func={setShowError} error={occuredError}/>}
                        </Form>}
                        
                        {toOrder && 
                        <Button className="w-100 mb-3" variant="danger" onClick={() => {
                            setShowPayPal(true);
                            setToOrder(false);
                        }}>Оформити замовлення</Button>}
                        
                        {showPayPal && 
                        <PayPalScriptProvider options={initialOptions}>
                            <PayPalButtons style={{ layout: "horizontal" }} 
                            createOrder={(data, actions) => {
                                return actions.order.create({
                                    purchase_units: [
                                        {
                                            amount: {
                                                value: ((promocodePercent === 0? sum : 
                                                    ((100 - promocodePercent) * sum) / 100) / 39).toFixed(2),
                                            },
                                        },
                                    ],
                                });
                            }}
                            
                            onApprove={(data, actions) => {
                                return actions.order!.capture().then((details) => {
                                    purchasing(currentId, promocode, seatIds, seanse.id, setShowError, setOccuredError);
                                    setOrderCompleted(true);
                                    setTimeout(() => {
                                        navigate('/')
                                    }, 2000);
                                });
                            }}/>
                        </PayPalScriptProvider>}
                    </Col>
                    <Col></Col>
                    {orderCompleted && <PurchaseDone func={setOrderCompleted} />}
                </Row>
            </div>}
        </Container>
    );
};

export default PurchaseTickets;
