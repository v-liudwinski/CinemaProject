import { useEffect, useState } from "react";
import http from '../http-common';
import Review from '../types/reviewTypes/Review';
import { getCurrentUserId } from './getCurrentUserId';

export default function useReviews(movieId?: number) {
    const [reviewsByUser, setReviewsByUser] = useState<Review[]>([]);
    const [reviewsByMovie, setReviewsByMovie] = useState<Review[]>([]);
    
    async function getReviewsByUserId() {
        const userId = getCurrentUserId()
        const response = await http.get<Review[]>(`reviews/by-user-id?id=${userId}`)
        setReviewsByUser(response.data)
    }

    async function getReviewsByMovieId() {
        const response = await http.get<Review[]>(`/reviews/by-movie-id?id=${movieId}`)
        setReviewsByMovie(response.data)
    }

    useEffect(() => {
        getReviewsByUserId();
        getReviewsByMovieId();
    }, []);

    return { 
        reviewsByUser,
        reviewsByMovie,
        getReviewsByUserId,
        getReviewsByMovieId
    };
}