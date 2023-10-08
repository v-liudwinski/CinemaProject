import Button from 'react-bootstrap/Button';
import { Link } from 'react-router-dom';

export function PublishMovie() {    
    return (
    
      <Link to="/admin/addmovie">
          <Button variant="outline-danger"  size="lg">Опублікувати</Button> 
      </Link>    
    );
  }