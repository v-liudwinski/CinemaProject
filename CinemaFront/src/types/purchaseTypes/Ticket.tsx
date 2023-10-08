import Seanse from "../seanseTypes/Seanse";
import Seat from "../seatTypes/Seat";

export default interface Ticket {
    id: number;
    price: number;
    seanse: Seanse;
    seat: Seat;
}