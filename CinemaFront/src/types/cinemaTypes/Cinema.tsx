import Hall from "./Hall";

export default interface Cinema { 
    id: number;
    name: string;
    address: string;
    city: string;
    email: string;
    phoneNumber: string;
    halls: Hall[];
}

export const defaultCinema: Cinema = {
    id: 0,
    name: '',
    address: '',
    city: '',
    email: '',
    phoneNumber: '',
    halls: []
}