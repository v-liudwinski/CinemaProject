import React, { useEffect, useState } from 'react';
import useMovie from '../../hooks/MovieHook';
import { useParams } from "react-router-dom";
import image from "../../assets/Main.png";
import http from '../../http-common';
import { Button, Card, CardGroup, Col, Container, Form, Row } from 'react-bootstrap';
import { getCurrentUserId } from '../../hooks/getCurrentUserId';
import useReviews from '../../hooks/ReviewHook';
import { addLike, bringLike } from '../../hooks/addLike';

type Rating = 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10;

const SingleMovie: React.FC<{}> = () => {

  const { id } = useParams<{ id: string }>();
  const movieDetailsId = Number(id);
  const userDetailsId = Number(getCurrentUserId())
  const { movie } = useMovie(movieDetailsId)
  const [description, setDescription] = useState('');
  const [rate, setRate] = useState<Rating>(0);
  const { reviewsByMovie } = useReviews(movieDetailsId)
  const [likeState, setLikeState] = useState(true)
  
  const releaseYear = new Date(movie.releaseDate).getFullYear().toString()
  const startDate = new Date(movie.movieDetails.startDate).toLocaleDateString()
  const endDate = new Date(movie.movieDetails.endDate).toLocaleDateString()

  async function updateUserRate() {
    await http.put(`/movies/users-rate/${id}`);
  }

  const handleCommentChange = (event: React.ChangeEvent<HTMLTextAreaElement>) => {
    setDescription(event.target.value);
  };

  const handleRatingChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const value = parseInt(event.target.value, 10) as Rating;
    if(value > 10){
      setRate(10)
    }else if(value < 0){
      setRate(0)
    }
    setRate(value);
  };

  async function handleSubmit (event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault();
    await http.post("/reviews", {description, rate, movieDetailsId, userDetailsId});
    setDescription('')
    setRate(0)
    window.location.href = `/movies/singlemovie/${movieDetailsId}`
  };

  async function handleLike(movieId:number) {
    await addLike(movieId)
    setLikeState(false)
  }

  async function handleUnlike(movieId:number) {
    await bringLike(movieId)
    setLikeState(true)
  }

  useEffect(() => {
    if (reviewsByMovie.length !== 0 || reviewsByMovie !== undefined) {
      updateUserRate();
    }
    handleLikeState();
  }, [])

  async function handleLikeState() {
    const favourite = await http.get(`favourites/${userDetailsId}&${movieDetailsId}`)
      if (favourite !== null){
        setLikeState(false)
      }
  }

  return (
    <div style={{ backgroundImage: `url(${image})`}} className="min-vh-100">
      <div className="container pt-2 py-5 bg-transparent">
        <div className="row">
          <div className="col-12 col-md-8 mx-auto">
            <div className="card mt-3 bg-dark text-light">
              <div className="card-header">
                <h2 className="card-title mb-0">{ movie.originalTitle }</h2>
                <h2 className="card-title mb-0">{ movie.title }</h2>
              </div>
              <div className="card-body">
                <div className="row">
                  <div className="col-12 col-md-4">
                    <img className="img-fluid w-100" src={movie.posterUrl} />
                  </div>
                  <div className="col-12 col-md-8">
                    <p><strong>Тривалість:</strong> {movie.duration} хвилин</p>
                    <p><strong>Дата виходу:</strong> {releaseYear}</p>
                    <p><strong>Продюсери:</strong> {movie.movieDetails.producers}</p>
                    <p><strong>Вікові обмеження:</strong> {movie.movieDetails.ageLimit}</p>
                    <p><strong>Країна:</strong> {movie.movieDetails.country}</p>
                    <p><strong>У прокаті з:</strong> {startDate}</p>
                    <p><strong>У прокаті по:</strong> {endDate}</p>
                    <p><strong>Оцінка критиків:</strong> {movie.movieDetails.independentRate}</p>
                    <p><strong>Оцінка глядачів:</strong> {movie.movieDetails.usersRate.toFixed(1)}</p>
                    {likeState ? 
                      <button onClick={() => handleLike(movieDetailsId)} className="btn btn-outline-primary">Поставити вподобайку</button>
                      :
                      <button onClick={() => handleUnlike(movieDetailsId)} className="btn btn-outline-danger">Прибрати вподобайку</button>
                    }
                  </div>
                </div>
              </div>
              <div className="card-footer">
                <p><strong>Опис:</strong></p>
                <p>{movie.movieDetails.description}</p>
              </div>
            </div>
          </div>
        </div>
        <div className="row">
          <div className="col-12 col-md-8 mx-auto">
            <div className="card mt-3 bg-dark text-light">
              <div className="card-header">
                <h2 className="card-title mb-0">Коментарі:</h2>
              </div>
              <div className="card-body">
                <div className="row">
                  <div className="col-12 col-md-8">
                    <Form onSubmit={handleSubmit}>
                      <Form.Group controlId="comment">
                        <Form.Label>Коментар:</Form.Label>
                        <Form.Control placeholder="Залиште свій коментар тут..." as="textarea" rows={3} value={description} onChange={handleCommentChange} required />
                      </Form.Group>
                      <Form.Group className="pt-3 w-25" controlId="rating">
                        <Form.Label>Оцінка:</Form.Label>
                        <Form.Control type="number" min="0" max="10" value={rate} onChange={handleRatingChange} required />
                      </Form.Group>
                      <Button className="mt-3" variant="outline-primary" type="submit">Залишити коментар</Button>
                    </Form>
                  </div>
                </div>
              </div>
              <div className="card-footer">
                { reviewsByMovie.map(item => (
                  <Card className="mt-3 px-3 text-light bg-secondary" key={item.id}>
                    <CardGroup>
                      <Form.Label></Form.Label>
                    </CardGroup>
                    <CardGroup>
                      <Form.Label className="me-3">Коментар:</Form.Label>
                      <Form.Text className="text-light">{item.description}</Form.Text>
                    </CardGroup>
                    <CardGroup className="pt-3 w-25">
                      <Form.Label className="me-3">Оцінка:</Form.Label>
                      <Form.Text className="text-light">{item.rate}</Form.Text>
                    </CardGroup>
                  </Card>
                )) }
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}

export default SingleMovie;