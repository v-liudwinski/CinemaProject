import CustomError from '../types/errorTypes/CustomError';
import { useState } from "react";
import axios, { AxiosError } from 'axios';
import http from '../http-common';
import Hall, { defaultHall } from '../types/cinemaTypes/Hall';

export default function useHalls() {

    const [halls, setHalls] = useState<Hall[]>([]);
    const [hall, setHall] = useState<Hall>(defaultHall);
    const [showHall, setShowHall] = useState(false);
    const [cinemaId, setCinemaId] = useState<number>(0);

    async function fetchHalls(cinemaId: number) {
        const response = await http.get<Hall[]>(`/halls/gethallsbycinemaid/${cinemaId}`);
        setHalls(response.data);
    }

    async function getHall(hallId: number) {
        try {
            const response = await http.get<Hall>(`/halls/${hallId}`);
            setHall(response.data);
        } catch (error) {
            throw new Error(`Failed to get hall with ID ${hallId}.`);
        }
    }

    async function updateHall(hallId: number, cinemaId: number, hallNumber: string,
        setShowError: (value: boolean) => void, setOccuredError: (value: CustomError) => void) {
        try {
            await http.put(`/halls/${hallId}`, {hallNumber, cinemaId});
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

    async function createHall(cinemaId: number, hallNumber: string,
        setShowError: (value: boolean) => void, setOccuredError: (value: CustomError) => void) {
        try {
            await http.post("/halls", {hallNumber, cinemaId});
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

    async function deleteHall(hallId: number,
        setShowError: (value: boolean) => void, setOccuredError: (value: CustomError) => void) {
        try {
            await http.delete(`/halls/${hallId}`);
            setHalls(halls.filter(x => x.id !== hallId));
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
        hall,
        halls, 
        showHall, 
        setShowHall,
        getHall, 
        deleteHall,
        cinemaId,
        fetchHalls,
        setCinemaId,
        updateHall,
        createHall
    };
}