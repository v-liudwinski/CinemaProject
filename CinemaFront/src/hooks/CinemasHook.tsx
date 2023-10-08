import CustomError from '../types/errorTypes/CustomError';
import { useState } from "react";
import axios, { AxiosError } from 'axios';
import Cinema from '../types/cinemaTypes/Cinema';
import http from '../http-common';

export default function useCinemas() {

    const [cinemas, setCinemas] = useState<Cinema[]>([]);
    const [showCinema, setShowCinema] = useState<boolean>(true);

    async function fetchCinemas() {
        const response = await http.get<Cinema[]>('/cinemas');
        setCinemas(response.data);
    }

    async function updateCinema(cinemaId: number, email: string, address: string, phoneNumber: string, city: string, 
        name: string, setShowError: (value: boolean) => void, setOccuredError: (value: CustomError) => void) {
        try {
            await http.put(`/cinemas/${cinemaId}`, {email, address, phoneNumber, city, name});
        
        } catch (error) {
            if (axios.isAxiosError(error)) {
                const serverError = error as AxiosError<CustomError>;
                if (serverError && serverError.response) {
                    setOccuredError(serverError.response.data as CustomError);
                    setShowError(true);
                }
            }
        }
    }

    async function createCinema(email: string, address: string, phoneNumber: string, city: string, name: string,
        setShowError: (value: boolean) => void, setOccuredError: (value: CustomError) => void) {
        try {
            await http.post("/cinemas", {email, address, name, city, phoneNumber});
        } catch (error) {
            if (axios.isAxiosError(error)) {
                const serverError = error as AxiosError<CustomError>;
                if (serverError && serverError.response) {
                    setOccuredError(serverError.response.data as CustomError);
                    setShowError(true);
                }
            }
        }
    }

    async function deleteCinema(cinemaId: number, setShowError: (value: boolean) => void, 
    setOccuredError: (value: CustomError) => void) {
        try {
            await http.delete(`/cinemas/${cinemaId}`);
            setCinemas(cinemas.filter(x => x.id !== cinemaId));
        } catch (error) {
            if (axios.isAxiosError(error)) {
                const serverError = error as AxiosError<CustomError>;
                if (serverError && serverError.response) {
                    setOccuredError(serverError.response.data as CustomError);
                    setShowError(true);
                }
            }
        }
    }

    return { 
        cinemas, 
        showCinema, 
        setShowCinema,
        deleteCinema,
        fetchCinemas,
        updateCinema,
        createCinema
    };
}