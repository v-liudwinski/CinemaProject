import Favourite from "../favouriteTypes/Favourite";
import Review from "../reviewTypes/Review";

export interface UserDetails {
    id: number;
    favourites: Favourite[];
    reviews: Review[];
}