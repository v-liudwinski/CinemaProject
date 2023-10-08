import Alert from "react-bootstrap/Alert";
import CustomError from "../../types/errorTypes/CustomError";
import { useEffect } from "react";

interface ButtonProps {
  func: (show: boolean) => void;
  error: CustomError;
}

const AlertDismissible: React.FC<ButtonProps> = ({ func, error}) => {

    useEffect(() => {
        setTimeout(() => {
            func(false);
        }, 4000);
    }, []);

    return (
        <Alert variant="danger" className="text-center fixed-top" onClose={() => func(false)} 
        dismissible style={{top:'10%', left:'10%', transform: 'translateY(-50%)', textAlign: 'center', width: '80%'}}>
            <Alert.Heading>{error.StatusCode}</Alert.Heading>
            <p>{error.Message}</p>
        </Alert>
    );
}

export default AlertDismissible;
