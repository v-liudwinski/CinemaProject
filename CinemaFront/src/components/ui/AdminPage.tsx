import Nav from 'react-bootstrap/Nav';

function AdminPage() {
  return (
    <Nav justify variant="tabs" defaultActiveKey="/home" className='bg-black'>
      <Nav.Item>
      <Nav.Link href="/admin/cinemamanagement" className="navbar-link">Кінотеатри</Nav.Link>
      </Nav.Item>
      <Nav.Item>
      <Nav.Link href="/admin/seansemanagement" className="navbar-link">Сеанси</Nav.Link>
      </Nav.Item>
      <Nav.Item>
      <Nav.Link href="/admin/moviemanagement" className="navbar-link">Фільми</Nav.Link>
      </Nav.Item>
      <Nav.Item>
      <Nav.Link href="/admin/users" className="navbar-link">Користувачі</Nav.Link>
      </Nav.Item>
      <Nav.Item>
      <Nav.Link href="/admin/promocodes" className="navbar-link">Промокоди</Nav.Link>
      </Nav.Item>
    </Nav>
  );
}

export default AdminPage;
  
  