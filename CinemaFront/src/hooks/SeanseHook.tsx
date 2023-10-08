import CustomError from '../types/errorTypes/CustomError';
import { useState } from "react";
import axios, { AxiosError } from 'axios';
import Seanse from '../types/seanseTypes/Seanse';
import http from '../http-common';

export default function useSeanses() {
    const [seanses, setSeanses] = useState<Seanse[]>([]);
    const [showSeanse, setShowSeanse] = useState<boolean>(true);

    async function fetchSeanses() {
        const response = await http.get<Seanse[]>('/seanses');
        setSeanses(response.data);
        return response.data;
    }

    async function updateSeanse(seanseId: number, startTime: string, hallId: number, movieId: number, priceId: number, setShowError: (value: boolean) => void, setOccuredError: (value: CustomError) => void) {
        try {
            await http.put(`/seanses/${seanseId}`, {startTime, hallId, movieId, priceId});
        
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

    async function createSeanse(startTime: string, hallId: number, movieId: number, priceId: number,
        setShowError: (value: boolean) => void, setOccuredError: (value: CustomError) => void) {
        try {
            await http.post("/seanses", {startTime, hallId, movieId, priceId});
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

    async function deleteSeanse(seanseId: number, setShowError: (value: boolean) => void, 
    setOccuredError: (value: CustomError) => void) {
        try {
            await http.delete(`/seanses/${seanseId}`);
            setSeanses(seanses.filter(x => x.id !== seanseId));
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
        seanses, 
        showSeanse, 
        setShowSeanse,
        deleteSeanse,
        fetchSeanses,
        updateSeanse,
        createSeanse
    };
}