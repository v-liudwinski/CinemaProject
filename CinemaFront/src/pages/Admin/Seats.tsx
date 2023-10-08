import { useContext, useEffect, useState } from "react";
import { Container, Table, Button } from "react-bootstrap";
import CreateSeat from "../../components/Admin/seats/CreateSeat";
import DeleteSeat from "../../components/Admin/seats/DeleteSeat";
import SeatRow from "../../components/Admin/seats/SeatRow";
import UpdateSeat from "../../components/Admin/seats/UpdateSeat";
import AlertDismissible from "../../components/shared/AlertDismissible";
import ModalWindow from "../../components/shared/ModalWindow";
import { ModalContext } from "../../context/ModalContext";
import useSeats from "../../hooks/SeatsHook";
import Seat, { defaultSeat } from "../../types/seatTypes/Seat";
import CustomError, { defaultError } from "../../types/errorTypes/CustomError";

interface SeatsProps {
    setShowSeat: (flag: boolean) => void;
    setShowHall: (flag: boolean) => void;
    hallId: number;
}

const Seats: React.FC<SeatsProps> = ({ hallId, setShowSeat, setShowHall }) => {
    const { modal, open, close } = useContext(ModalContext);
    const [currentOption, setCurrentOption] = useState<string>('');
    const [size, setSize] = useState<string>('');
    const [currentSeatId, setCurrentSeatId] = useState<number>(0);
    const [seat, setSeat] = useState<Seat>(defaultSeat);
    const title: string = currentOption === 'updateSeat' ? `Редагувати місце Id ${currentSeatId}` :
        currentOption === 'createSeat'? `Створити місце` : `Видалити місце Id ${currentSeatId}`
    
    const [showError, setShowError] = useState(false);
    const [occuredError, setOccuredError] = useState<CustomError>(defaultError);

    const [rerender, setRerender] = useState(false);
    const { 
        seats, 
        fetchSeats
    } = useSeats();

    useEffect(() => {
        fetchSeats(hallId);
    }, [rerender]);

    return ( 
        <Container fluid className="p-5 pt-3 text-center">
            {showError && <AlertDismissible func={setShowError} error={occuredError}/>}
            
            {modal && <ModalWindow title={title} 
                close={close}
                modal={modal} 
                size={size}>
                {currentOption ===  'updateSeat' ? 
                <UpdateSeat setShowError={setShowError} setOccuredError={setOccuredError} 
                hallId={hallId} close={close} seat={seat} setRerender={setRerender} /> : 
                currentOption ===  'createSeat' ?
                <CreateSeat setShowError={setShowError} setOccuredError={setOccuredError} 
                hallId={hallId} close={close} setRerender={setRerender} /> :
                <DeleteSeat setShowError={setShowError} setOccuredError={setOccuredError} close={close} seatId={currentSeatId} setRerender={setRerender} />}
            </ModalWindow>}

        <Button variant="outline-danger" className="me-5" size="lg" onClick={() => {
            setShowSeat(false);
            setShowHall(true);
        }}>Зали</Button>

        <Button variant="outline-danger" size="lg" onClick={() => {
            setCurrentOption('createSeat');
            setSize('lg');
            open();
        }}>Створити</Button>

        <Table striped bordered hover className="mt-2 border" variant="dark" responsive>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Ряд</th>
                    <th>Номер</th>
                    <th>Ціна</th>
                    <th>Тип</th>
                    <th>Опції</th>
                </tr>
            </thead>
            <tbody>
                {seats.map(x => 
                <SeatRow 
                    setSeat={setSeat}
                    seat={x} 
                    key={x.id} 
                    open={open}
                    modal={modal}
                    setCurrentSeatId={setCurrentSeatId}
                    setCurrentOption={setCurrentOption}
                    setSize={setSize}
                />)}
            </tbody>
        </Table>

        </Container>
    );
};

export default Seats;