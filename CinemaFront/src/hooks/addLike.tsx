import http from "../http-common";
import { getCurrentUserId } from "./getCurrentUserId";

export async function addLike(movieId:number) {
    const userDetailsId = getCurrentUserId()
    await http.post('favourites/add', {userDetailsId, movieId})
}

export async function bringLike(movieId:number) {
    const userDetailsId = getCurrentUserId()
    await http.delete(`/favourites/${userDetailsId}&${movieId}`)
}