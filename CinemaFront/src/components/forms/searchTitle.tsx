import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Stack from 'react-bootstrap/Stack';


function SearchTitle() {
    return (
      <Stack direction="horizontal" gap={3}>
        <Form.Control className="me-auto" placeholder="Add your item here..." />
        <Button variant="outline-dark"className='text-white'>Пошук</Button>
        <div className="vr" />       
      </Stack>
    );
  }
  
  export default SearchTitle;