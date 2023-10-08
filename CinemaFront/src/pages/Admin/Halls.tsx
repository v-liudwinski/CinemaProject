import { useContext, useEffect, useState } from "react";
import { Container, Table, Button } from "react-bootstrap";
import AlertDismissible from "../../components/shared/AlertDismissible";
import ModalWindow from "../../components/shared/ModalWindow";
import { ModalContext } from "../../context/ModalContext";
import useHalls from "../../hooks/HallsHook";
import CreateHall from "../../components/Admin/halls/CreateHall";
import DeleteHall from "../../components/Admin/halls/DeleteHall";
import HallRow from "../../components/Admin/halls/HallRow";
import UpdateHall from "../../components/Admin/halls/UpdateHall";
import Hall, { defaultHall } from "../../types/cinemaTypes/Hall";
import CustomError, { defaultError } from "../../types/errorTypes/CustomError";

interface HallsProps {
    setShowSeat: (flag: boolean) => void;
    setShowHall: (flag: boolean) => void;
    setShowCinema: (flag: boolean) => void;
    setHallId: (id: number) => void;
    cinemaId: number;
}

const Halls: React.FC<HallsProps> = ({ setHallId, cinemaId, setShowSeat, setShowHall, setShowCinema }) => {

    const { modal, open, close } = useContext(ModalContext);
    const [currentOption, setCurrentOption] = useState<string>('');
    const [size, setSize] = useState<string>('');
    const [currentHallId, setCurrentHallId] = useState<number>(0);
    const [hall, setHall] = useState<Hall>(defaultHall);
    const title: string = currentOption === 'updateHall' ? `Редагувати зал Id ${currentHallId}` :
        currentOption === 'createHall'? `Створити зал` : `Видалити зал Id ${currentHallId}`
        
    const [showError, setShowError] = useState(false);
    const [occuredError, setOccuredError] = useState<CustomError>(defaultError);

    const [rerender, setRerender] = useState(false);
    const {
        halls,
        fetchHalls
    } = useHalls();

    useEffect(() => {
        fetchHalls(cinemaId);
    }, [rerender]);

    return ( 
        <Container fluid className="p-5 pt-3 text-center">
            {showError && <AlertDismissible func={setShowError} error={occuredError}/>}
            
            {modal && <ModalWindow title={title} 
                close={close}
                modal={modal} 
                size={size}>
                {currentOption === 'updateHall' ?
                <UpdateHall setShowError={setShowError} setOccuredError={setOccuredError}  
                cinemaId={cinemaId} close={close} hall={hall} setRerender={setRerender} /> : 
                currentOption === 'createHall' ?
                <CreateHall setShowError={setShowError} setOccuredError={setOccuredError} 
                cinemaId={cinemaId} close={close} setRerender={setRerender} /> :
                <DeleteHall setShowError={setShowError} setOccuredError={setOccuredError} 
                close={close} hallId={currentHallId} setRerender={setRerender} />}
            </ModalWindow>}

        <Button variant="outline-danger" size="lg" className="me-5" onClick={() => {
            setShowHall(false);
            setShowCinema(true);
        }}>Кінотеатри</Button>

        <Button variant="outline-danger" size="lg" onClick={() => {
            setCurrentOption('createHall');
            open();
            setSize('lg');
        }}>Створити</Button>

        <Table striped bordered hover className="mt-2 border" variant="dark" responsive>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Номер залу</th>
                    <th>Опції</th>
                </tr>
            </thead>
            <tbody>
                {halls.map(x => 
                <HallRow 
                    setHall={setHall}
                    setHallId={setHallId}
                    setShowCinema={setShowCinema}
                    setShowHall={setShowHall}
                    setShowSeat={setShowSeat}
                    hall={x} 
                    key={x.id} 
                    open={open}
                    modal={modal}
                    setCurrentHallId={setCurrentHallId}
                    setCurrentOption={setCurrentOption}
                    setSize={setSize}
                />)}
            </tbody>
        </Table>
        </Container>
    )
};

export default Halls;