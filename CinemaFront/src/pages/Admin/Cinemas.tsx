import { Container, Table, Button, Row, Col } from "react-bootstrap";
import CinemaRow from "../../components/Admin/cinemas/CinemaRow";
import CreateCinema from "../../components/Admin/cinemas/CreateCinema";
import DeleteCinema from "../../components/Admin/cinemas/DeleteCinema";
import UpdateCinema from "../../components/Admin/cinemas/UpdateCinema";
import AlertDismissible from "../../components/shared/AlertDismissible";
import ModalWindow from "../../components/shared/ModalWindow";
import useCinemas from "../../hooks/CinemasHook";
import { useContext, useEffect, useState } from "react";
import { ModalContext } from "../../context/ModalContext";
import Cinema, { defaultCinema } from "../../types/cinemaTypes/Cinema";
import CustomError, { defaultError } from "../../types/errorTypes/CustomError";

interface CinemasProps {
    setShowHall: (flag: boolean) => void;
    setShowCinema: (flag: boolean) => void;
    setCinemaId: (id: number) => void;
}

const Cinemas: React.FC<CinemasProps> = ({ setCinemaId, setShowHall, setShowCinema }) => {
    const { modal, open, close } = useContext(ModalContext);
    const [currentOption, setCurrentOption] = useState<string>('');
    const [size, setSize] = useState<string>('');
    const [currentCinemaId, setCurrentCinemaId] = useState<number>(0);
    const [cinema, setCinema] = useState<Cinema>(defaultCinema);
    const title: string = currentOption === 'updateCinema' ? `Редагувати кінотеатр Id ${currentCinemaId}` :
        currentOption === 'createCinema'? `Створити кінотеатр` : `Видалити кінотеатр Id ${currentCinemaId}`
    
    const [showError, setShowError] = useState(false);
    const [occuredError, setOccuredError] = useState<CustomError>(defaultError);

    const [rerender, setRerender] = useState(false);
    const { cinemas, fetchCinemas } = useCinemas();

    useEffect(() => {
        fetchCinemas();
    }, [rerender]);

    return ( 
        <Container fluid className="p-5 pt-2 text-center">
            {showError && <AlertDismissible func={setShowError} error={occuredError}/>}
            
            {modal && <ModalWindow title={title} 
                close={close}
                modal={modal}
                size={size}>
                {currentOption ===  'updateCinema' ? 
                <UpdateCinema setShowError={setShowError} setOccuredError={setOccuredError} 
                close={close} cinema={cinema} setRerender={setRerender} /> : 
                currentOption ===  'createCinema' ?
                <CreateCinema setShowError={setShowError} setOccuredError={setOccuredError}
                close={close} setRerender={setRerender} /> :
                <DeleteCinema setShowError={setShowError} setOccuredError={setOccuredError}
                close={close} cinemaId={currentCinemaId} setRerender={setRerender} />}
            </ModalWindow>}

            <Button variant="outline-danger" size="lg" onClick={() => {
                setCurrentOption('createCinema');
                open();
                setSize('lg');
            }}>Створити</Button>
               
            <Table striped bordered hover className="mt-2 border" variant="dark" responsive>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Назва</th>
                        <th>Місто</th>
                        <th>Адреса</th>
                        <th>Пошта</th>
                        <th>Номер телефону</th>
                        <th>Опції</th>
                    </tr>
                </thead>
                <tbody>
                    {cinemas.map(x => 
                    <CinemaRow 
                        setCinema={setCinema}
                        setCinemaId={setCinemaId}
                        setShowHall={setShowHall}
                        setShowCinema={setShowCinema}
                        cinema={x}
                        key={x.id} 
                        open={open}
                        modal={modal}
                        setCurrentCinemaId={setCurrentCinemaId}
                        setCurrentOption={setCurrentOption}
                        setSize={setSize}
                    />)}
                </tbody>
            </Table>
        </Container>
    )
};

export default Cinemas;