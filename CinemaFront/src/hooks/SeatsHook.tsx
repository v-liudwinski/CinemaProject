import CustomError from '../types/errorTypes/CustomError';
import { useState } from "react";
import axios, { AxiosError } from 'axios';
import http from '../http-common';
import Seat, { defaultSeat } from '../types/seatTypes/Seat';
import Hall from '../types/cinemaTypes/Hall';

export default function useSeats() {

    const [seats, setSeats] = useState<Seat[]>([]);
    const [seat, setSeat] = useState<Seat>(defaultSeat);
    const [showSeat, setShowSeat] = useState<boolean>(false);
    const [hallId, setHallId] = useState<number>(0);

    async function fetchSeats(hallId: number) {
        const response = await http.get<Hall>(`/halls/${hallId}`);
        setSeats(response.data.seats);
    }

    async function getSeat(seatId: number) {
        try {
            const response = await http.get<Seat>(`/Seats/${seatId}`);
            setSeat(response.data);
        } catch (error) {
            throw new Error(`Failed to get Seat with ID ${seatId}.`);
        }
    }

    async function updateSeat(seatId: number, hallId: number, seatNumber: string, 
        row: string, seatTypeId: string, setShowError: (value: boolean) => void,
        setOccuredError: (value: CustomError) => void) {
        try {
            await http.put(`/seats/${seatId}`, { hallId, seatNumber, row, seatTypeId });
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

    async function createSeat(hallId: number, seatNumber: string, row: string, seatTypeId: string,
        setShowError: (value: boolean) => void, setOccuredError: (value: CustomError) => void) {
        try {
            await http.post("/seats", { hallId, seatNumber, row, seatTypeId});
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

    async function deleteSeat(seatId: number, setShowError: (value: boolean) => void, 
        setOccuredError: (value: CustomError) => void) {
        try {
            await http.delete(`/Seats/${seatId}`);
            setSeats(seats.filter(x => x.id !== seatId));
        } catch (error) {
            if (axios.isAxiosError(error)) {
                const serverError = error as AxiosError<CustomError>;
                if (serverError && serverError.response) {
                    setOccuredError(serverError.response.data as CustomError);
                    setShowSeat(true);
                }
            }
        }
    }

    return { 
        seat,
        seats, 
        showSeat, 
        setShowSeat, 
        getSeat, 
        deleteSeat, 
        fetchSeats,
        hallId,
        setHallId,
        updateSeat,
        createSeat
    };
}