import image from "../../assets/Main.png";
import "./styles.css";
import SlideShow from "./slideshow";
import { Col, Container, Row } from "react-bootstrap";
import { FC } from "react";
import SoonReliese from "./SoonReliese";

export const MainBlock: FC<{}> = () => {


    return (
        
        <div id="main" style={{ backgroundImage: `url(${image})` }}>
            <Container className="reliese">
                <Row>
                    <Col>
                    <div id="about_cinema" className="m-7 p-5">
                        <h1>Про кінотеатр</h1>
                        <p>
                        Українська мережа кінотеатрів є доволі розвиненою в країні. Вона складається з різноманітних кінотеатрів, що пропонують фільми, від блокбастерів до авторського кіно.                       
                        </p>
                        <p>
                        Багато наших кінотеатріврозташовані в крупних містах, таких як Київ, Львів та інші. Ці кінотеатри часто розташовані у торгових центрах, що забезпечує зручний доступ до них для відвідувачів.

                        </p>
                        <p>У кінотеатрах української мережі часто проводяться прем'єри нових фільмів, які дивляться широкі маси глядачів. 

                          </p>

                         </div>
                    </Col>

                    <Col id="slide">
                        <SlideShow/>
                    </Col>
                </Row>                
            </Container>  

            <Container>
                <Row>
                    {/* <h2 className="text-center text-white my-4">Незабаром у прокаті</h2> */}
                    <SoonReliese />
                </Row>    
            </Container>        
            
        </div>
    );
};
