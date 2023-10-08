import { Container, Table, Button, Row, Col } from "react-bootstrap";
import PriceRow from "../../components/Admin/prices/priceRow";
import CreatePrice from "../../components/Admin/prices/CreatePrice";
import DeletePrice from "../../components/Admin/prices/DeletePrice";
import UpdatePrice from "../../components/Admin/prices/UpdatePrice";
import AlertDismissible from "../../components/shared/AlertDismissible";
import ModalWindow from "../../components/shared/ModalWindow";
import usePrices from "../../hooks/PricesHook";
import { useContext, useEffect, useState } from "react";
import { ModalContext } from "../../context/ModalContext";
import Price, {defaultPrice} from "../../types/priceTypes/Price";
import CustomError, { defaultError } from "../../types/errorTypes/CustomError";
import image from "../../assets/Main.png";

interface PricesProps {    
    setShowPrice: (flag: boolean) => void;   
}

const Prices: React.FC<PricesProps> = ({ setShowPrice }) => {
    const { modal, open, close } = useContext(ModalContext);
    const [currentOption, setCurrentOption] = useState<string>('');
    const [size, setSize] = useState<string>('');
    const [currentPriceId, setCurrentPriceId] = useState<number>(0);
    const [price, setPrice] = useState<Price>(defaultPrice);
    const title: string = currentOption === 'updatePrice' ? `Редагувати прайс Id ${currentPriceId}` :
        currentOption === 'createPrice'? `Створити прайс` : `Видалити прайс Id ${currentPriceId}`
    
    const [showError, setShowError] = useState(false);
    const [occuredError, setOccuredError] = useState<CustomError>(defaultError);

    const [rerender, setRerender] = useState(false);
    const { prices, fetchPrices } = usePrices();

    useEffect(() => {
        fetchPrices();
    }, [rerender]);

    return ( 
        <Container fluid className="p-5 pt-2 text-center min-vh-100" style={{ backgroundImage: `url(${image})`}}>
            {showError && <AlertDismissible func={setShowError} error={occuredError}/>}
            
            {modal && <ModalWindow title={title} 
                close={close}
                modal={modal}
                size={size}>
                {currentOption ===  'updatePrice' ? 
                <UpdatePrice setShowError={setShowError} setOccuredError={setOccuredError} 
                close={close} price={price} setRerender={setRerender} /> : 
                currentOption ===  'createPrice' ?
                <CreatePrice setShowError={setShowError} setOccuredError={setOccuredError}
                close={close} price={price} setRerender={setRerender} /> :
                <DeletePrice setShowError={setShowError} setOccuredError={setOccuredError}
                close={close} priceId={currentPriceId} setRerender={setRerender} />}
            </ModalWindow>}

            <Button variant="outline-danger" size="lg" onClick={() => {
                setCurrentOption('createPrice');
                setPrice(price);
                open();
                setSize('md');
            }}>Створити</Button>
               
        <Table striped bordered hover className="mt-2 border" variant="dark" responsive>
            <thead>
                <tr>
                    <th>Id</th>                   
                    <th>Ціна</th>                   
                    <th>Опції</th>
                </tr>
            </thead>
            <tbody>
                {prices.map(x => 
                <PriceRow
                    setPrice={setPrice}                                    
                    setShowPrice={setShowPrice}
                    price={x}
                    key={x.id} 
                    open={open}
                    modal={modal}
                    setCurrentPriceId={setCurrentPriceId}
                    setCurrentOption={setCurrentOption}
                    setSize={setSize}
                />)}
            </tbody>
        </Table>
        </Container>
    )
};

export default Prices;