import SeatType from "./SeatType";

export default interface Seat {
    id: number;
    row: number;
    seatNumber: number;
    seatType: SeatType;
}

export const defaultSeat: Seat = {
    id: 0,
    row: 0,
    seatNumber: 0,
    seatType: {
        id: 0,
        price: 0,
        type: ''
    }
}