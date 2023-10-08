import Carousel from 'react-bootstrap/Carousel';
import first from "../../assets/1.jpg";
import second from "../../assets/2.jpg";
import third from "../../assets/3.jpg";
import "./styles.css";

function SlideShow() {
    return (
      <div >
        <Carousel >
        <Carousel.Item interval={5000}>
          <img
            className="d-block w-100"
            src={first}
            alt="First slide"
          />
          <Carousel.Caption>
            
          </Carousel.Caption>
        </Carousel.Item>
        <Carousel.Item interval={4000}>
          <img
            className="d-block w-100"
            src={second}
            alt="Second slide"
          />
          <Carousel.Caption>
            
          </Carousel.Caption>
        </Carousel.Item>
        <Carousel.Item>
          <img
            className="d-block w-100"
            src={third}
            alt="Third slide"
          />
          <Carousel.Caption>
            
          </Carousel.Caption>
        </Carousel.Item>
      </Carousel>
      </div>
    );
  }
  
  export default SlideShow;