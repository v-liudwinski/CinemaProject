import {FC} from 'react';
import { Link } from 'react-router-dom';
import AuthButton from './AuthButton';
import RegisterButton from './RegisterButton';
import MainLogo from './logo';
import { Col, Container, Row } from 'react-bootstrap';

export const Header: FC<{}> = () => {
    const token = localStorage.getItem("token");
    const role = localStorage.getItem("role");
      
    return (   

        <nav className="navbar navbar-expand-lg bg-black text-white border-bottom" id="main_header">                    
            <Link to="/">
                <MainLogo/>
            </Link>
            <div className="navbarNav collapse navbar-collapse">
                <Container>
                    <Row>
                        <Col>
                        <ul className=" header_list navbar-nav text-white">
                            <li className="nav-item text-white">
                                <Link to="/upcoming" style={{ textDecoration: 'none' }} className="nav-link px-2 text-white">
                                    Популярні</Link>                      
                            </li> 
                            <li className="nav-item">
                                <Link to="/movies/moviepostermanager" style={{ textDecoration: 'none' }} className="nav-link px-2 text-white">
                                    Фільми</Link>
                            </li>
                            <li className="nav-item">
                                <Link to="/movies/seances" style={{ textDecoration: 'none' }} className="nav-link px-2 text-white">
                                    Сеанси</Link>
                            </li>
                        </ul> 
                        
                        </Col>
                        <Col>
                        <div className="collapse navbar-collapse float">

                            <ul className=" header_list navbar-nav text-white">
                            {token
                            ?
                            role === "Admin"
                            ? 
                            <>

                                <li className="nav-item">
                                <Link to="/admin/cinemamanagement" style={{ textDecoration: 'none' }} className="nav-link px-2 text-white">
                                    Адмін</Link>
                                </li>
                                <li className="nav-item">
                                <Link to="/account" style={{ textDecoration: 'none' }} className="nav-link px-2 text-white">
                                    Особистий Кабінет</Link>
                                </li>
                            </>
                            :
                            <>
                                <li className="nav-item">
                                <Link to="/account" style={{ textDecoration: 'none' }} className="nav-link px-2 text-white">
                                    Особистий Кабінет</Link>
                                </li>
                            </>
                            :
                            <>
                                <li>
                                <AuthButton />
                                </li>
                                <li>
                                <RegisterButton />
                                </li>
                            </>
                            }
                                </ul>
                            </div>
                           </Col>
                       </Row>
                     </Container>
                     </div> 
                                          
        </nav>                  
    )
}

export default Header;