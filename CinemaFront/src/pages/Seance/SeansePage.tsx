import { useEffect, useState } from "react";
import image from "../../assets/Main.png";
import useSeanses from "../../hooks/SeanseHook";
import SeanseItem from "./SeanseItem";
import { Button, Container } from "react-bootstrap";
import PurchaseTickets from "../../components/UserActions/PurchaseTickets";
import Seanse, { defaultSeanse } from "../../types/seanseTypes/Seanse";

const SeansePage: React.FC<{}> = () => {
    
    const { seanses, fetchSeanses } = useSeanses();
    const [ showSeanses, setShowSeanses ] = useState(false);
    const [ showSeanse, setShowSeanse ] = useState(false);
    const [ seanse, setSeanse ] = useState<Seanse>(defaultSeanse)

    useEffect(() => {
        fetchSeanses();
        setShowSeanses(true)
    }, []);

    return (
        <div style={{ backgroundImage: `url(${image})`}} className="min-vh-100 pt-5">
            
            {showSeanse && <div>
                <Button variant='outline-danger' className="text-white m-5 mb-0" onClick={() => {
                    setShowSeanses(true)
                    setShowSeanse(false)
                }}>Назад</Button>
                
                <PurchaseTickets seanse={seanse} 
                setShowSeanse={setShowSeanse} setShowSeanses={setShowSeanses}/>
            </div>}
            
            {showSeanses &&
            <Container className="p-2">
                {seanses.map(x => {
                    if (new Date(Date.parse(x.startTime.slice(0, 10))) > new Date())
                    return <SeanseItem setShowSeanse={setShowSeanse} seanse={x}
                    setShowSeanses={setShowSeanses} setSeanse={setSeanse} key={x.id} />
                })}
            </Container>}
        </div>
    );
};

export default SeansePage;
