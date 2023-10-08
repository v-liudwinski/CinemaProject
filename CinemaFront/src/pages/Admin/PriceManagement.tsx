import usePrices from "../../hooks/PricesHook";
import AdminPage from "../../components/ui/AdminPage";
import Prices from "./Prices";
import image from "../../assets/Main.png";

const PriceManagement: React.FC<{}> = () => {
    const { showPrice, setShowPrice } = usePrices();       
   
    return (
        <div style={{ backgroundImage: `url(${image})`}}>
            <AdminPage/>           
            {showPrice && <Prices setShowPrice={setShowPrice} />}
            
        </div>
    );
};

export default PriceManagement;
