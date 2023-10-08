import Ticket from "./Ticket";

export default interface Purchase {
    id: number;
    price: number;
    promocode: string;
    purchaseDate: string;
    userDetailsId: number;
    tickets: Ticket[];
}