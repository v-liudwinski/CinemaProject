import { Container, Table, Button } from "react-bootstrap";
import AlertDismissible from "../../components/shared/AlertDismissible";
import ModalWindow from "../../components/shared/ModalWindow";
import { useContext, useEffect, useState } from "react";
import { ModalContext } from "../../context/ModalContext";
import CustomError, { defaultError } from "../../types/errorTypes/CustomError";
import PromocodeRow from "../../components/Admin/promocodes/PromocodeRow";
import UpdatePromocode from "../../components/Admin/promocodes/UpdatePromocode";
import CreatePromocode from "../../components/Admin/promocodes/CreatePromocode";
import DeletePromocode from "../../components/Admin/promocodes/DeletePromocode";
import { Promocode, defaultPromocode } from "../../types/promocodeTypes/Promocode";
import usePromocodes from "../../hooks/PromocodesHook";
import AdminPage from "../../components/ui/AdminPage";
import image from "../../assets/Main.png";

const Promocodes: React.FC<{}> = () => {
    const { modal, open, close } = useContext(ModalContext);
    const [currentOption, setCurrentOption] = useState<string>('');
    const [size, setSize] = useState<string>('');
    const [currentPromocodeId, setCurrentPromocodeId] = useState<number>(0);
    const [promocode, setPromocode] = useState<Promocode>(defaultPromocode);
    const title: string = currentOption === 'updatePromocode' ? `Редагувати промокод Id ${currentPromocodeId}` :
        currentOption === 'createPromocode'? `Створити промокод` : `Видалити промокод Id ${currentPromocodeId}`
    
    const [showError, setShowError] = useState(false);
    const [occuredError, setOccuredError] = useState<CustomError>(defaultError);

    const [rerender, setRerender] = useState(false);
    const { promocodes, fetchPromocodes } = usePromocodes();

    useEffect(() => {
        fetchPromocodes();
    }, [rerender]);

    return ( 
        <div style={{ backgroundImage: `url(${image})`}} className="min-vh-100">
        <AdminPage />
        <Container fluid className="p-5 pt-2 text-center">
            {showError && <AlertDismissible func={setShowError} error={occuredError}/>}
            
            {modal && <ModalWindow title={title} 
                close={close}
                modal={modal}
                size={size}>
                {currentOption ===  'updatePromocode' ? 
                <UpdatePromocode setShowError={setShowError} setOccuredError={setOccuredError} 
                close={close} promocode={promocode} setRerender={setRerender} /> : 
                currentOption ===  'createPromocode' ?
                <CreatePromocode setShowError={setShowError} setOccuredError={setOccuredError}
                close={close} setRerender={setRerender} /> :
                <DeletePromocode setShowError={setShowError} setOccuredError={setOccuredError}
                close={close} promocodeId={currentPromocodeId} setRerender={setRerender} />}
            </ModalWindow>}

            <Button variant="outline-danger" size="lg" onClick={() => {
                setCurrentOption('createPromocode');
                setPromocode(promocode);
                open();
                setSize('lg');
            }}>Створити</Button>
               
        <Table striped bordered hover className="mt-2 border" variant="dark" responsive>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Промокод</th>
                    <th>Ціна</th>
                    <th>Опції</th>
                </tr>
            </thead>
            <tbody>
                {promocodes.map(x => 
                <PromocodeRow 
                    setPromocode={setPromocode}                                    
                    promocode={x}
                    key={x.id} 
                    open={open}
                    modal={modal}
                    setCurrentPromocodeId={setCurrentPromocodeId}
                    setCurrentOption={setCurrentOption}
                    setSize={setSize}
                />)}
            </tbody>
        </Table>
        </Container>
        </div>
    )
};

export default Promocodes;