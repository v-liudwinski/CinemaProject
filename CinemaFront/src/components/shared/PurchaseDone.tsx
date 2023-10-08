import Alert from "react-bootstrap/Alert";
import { useEffect } from "react";

interface PurchaseDoneProps {
    func: (show: boolean) => void;
}

const PurchaseDone: React.FC<PurchaseDoneProps> = ({ func }) => {

    useEffect(() => {
        setTimeout(() => {
            func(false);
        }, 4000);
    }, []);

    return (
        <Alert variant="success" className="text-center fixed-top" onClose={() => func(false)} 
        dismissible style={{top:'10%', left:'10%', transform: 'translateY(-50%)', textAlign: 'center', width: '80%'}}>
            <Alert.Heading>Покупка успішно завершена!</Alert.Heading>
            <p>Ви можете перевірити всі свої покупки в власному кабінеті.</p>
        </Alert>
    );
}

export default PurchaseDone;
