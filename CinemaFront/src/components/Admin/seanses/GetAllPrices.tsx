import Button from 'react-bootstrap/Button';
import { Link } from 'react-router-dom';

export function GetAllPrices() {    
    return (
    
      <Link to="/admin/pricemanagement">
          <Button variant="outline-danger"  size="lg">Подивитись всі ціни</Button> 
      </Link>    
    );
  }
 