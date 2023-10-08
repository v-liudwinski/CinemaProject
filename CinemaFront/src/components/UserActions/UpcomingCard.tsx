import { Card, Col, ListGroup, ListGroupItem, Row } from "react-bootstrap";
import Upcoming from "../../types/upcomingTypes/Upcoming";
import { useEffect, useState } from "react";
import axios from "axios";

interface UpcomingCardProps {
    upcoming: Upcoming;
}

const UpcomingCard: React.FC<UpcomingCardProps> = ({ upcoming }) => {
    const [titleToTranslate, setTitleToTranslate] = useState('')
    const [translatedTitle, setTranslatedTitle] = useState('')
    const [descriptionToTranslate, setDescriptionToTranslate] = useState('')
    const [translatedDescription, setTranslatedDescription] = useState('')

    const optionsTitle = {
        method: 'POST',
        url: 'https://microsoft-translator-text.p.rapidapi.com/translate',
        params: {
          'to[0]': 'uk',
          'api-version': '3.0',
          from: 'en',
          profanityAction: 'NoAction',
          textType: 'plain'
        },
        headers: {
          'content-type': 'application/json',
          'X-RapidAPI-Key': '6f1ff8a5fbmsh3fdee9686faa26cp1a9aadjsne182caf0bc12',
          'X-RapidAPI-Host': 'microsoft-translator-text.p.rapidapi.com'
        },
        data: `[{"Text":"${titleToTranslate}"}]`
      };

      const optionsDescription = {
        method: 'POST',
        url: 'https://microsoft-translator-text.p.rapidapi.com/translate',
        params: {
          'to[0]': 'uk',
          'api-version': '3.0',
          from: 'en',
          profanityAction: 'NoAction',
          textType: 'plain'
        },
        headers: {
          'content-type': 'application/json',
          'X-RapidAPI-Key': '6f1ff8a5fbmsh3fdee9686faa26cp1a9aadjsne182caf0bc12',
          'X-RapidAPI-Host': 'microsoft-translator-text.p.rapidapi.com'
        },
        data: `[{"Text":"${descriptionToTranslate}"}]`
      };

    async function translate() {
        setTitleToTranslate(upcoming.title)
        setDescriptionToTranslate(upcoming.overview)

        axios.request(optionsTitle).then(function (response) {
            setTranslatedTitle(response.data[0].translations[0].text)
        }).catch(function (error) {
            console.error(error);
        });

        axios.request(optionsDescription).then(function (response) {
            setTranslatedDescription(response.data[0].translations[0].text)
        }).catch(function (error) {
            console.error(error);
        });
    }

    useEffect(() => {
        //translate();
    });

    return (
            <Card className="mb-5 bg-dark text-white">
                <Row>
                    <Col sm={3}>
                        <Card.Body>
                            <Card.Title className="text-center">{translatedTitle === '' ? upcoming.title : translatedTitle}</Card.Title>
                            <img src={"https://image.tmdb.org/t/p/w300/" + upcoming.poster_path} alt='Постер' />
                        </Card.Body>
                    </Col>
                    <Col>
                        <ListGroup className="list-group-flush mt-5">
                            <ListGroupItem  className="bg-dark text-white mt-2">
                                <strong>Мова оригіналу:</strong> {upcoming.original_language}
                            </ListGroupItem>
                            <ListGroupItem className="bg-dark text-white mt-2">
                                <strong>Швидкий огляд:</strong> {translatedDescription === '' ? upcoming.overview : translatedDescription}
                            </ListGroupItem>
                        </ListGroup>
                        <Card.Body>
                            <Card.Text className="mt-4">
                                <strong>Популярність:</strong> {upcoming.popularity}
                            </Card.Text>
                            <Card.Text className="mt-4">
                                <strong>Дата виходу:</strong> {upcoming.release_date} 
                            </Card.Text>
                            <Card.Text className="mt-4">
                                <strong>Середня оцінка:</strong> {upcoming.vote_average}/10 
                            </Card.Text>
                            <Card.Text className="mt-4">
                                <strong>Кількість оцінок:</strong> {upcoming.vote_count} 
                            </Card.Text>
                            <Card.Text className="mt-4">
                                <strong>Джерело даних: </strong>IMDB
                            </Card.Text>
                        </Card.Body>
                    </Col>
                </Row>
            </Card>
        )
    }

export default UpcomingCard;