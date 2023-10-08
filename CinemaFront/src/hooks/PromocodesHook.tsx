import { useState } from "react";
import CustomError from '../types/errorTypes/CustomError';
import axios, { AxiosError } from 'axios';
import http from '../http-common';
import { Promocode } from "../types/promocodeTypes/Promocode";

export default function usePromocodes() {
    const [promocodes, setPromocodes] = useState<Promocode[]>([]);
    const [showPromocode, setShowPromocode] = useState<boolean>(true);

    async function fetchPromocodes() {
        
        const response = await http.get<Promocode[]>('/promocodes');
        setPromocodes(response.data);
    }

    async function updatePromocode(promocodeId: number, name: string, percentage: number, setShowError: (value: boolean) => void, setOccuredError: (value: CustomError) => void) {
        try {
            await http.put(`/promocodes/${promocodeId}`, {name , percentage});
        
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

    async function createPromocode(name: string, percentage: number,
        setShowError: (value: boolean) => void, setOccuredError: (value: CustomError) => void) {
        try {
            await http.post("/promocodes", {name, percentage});
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

    async function deletePromocode(promocodeId: number, setShowError: (value: boolean) => void, 
    setOccuredError: (value: CustomError) => void) {
        try {
            await http.delete(`/promocodes/${promocodeId}`);
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
        promocodes, 
        showPromocode, 
        setShowPromocode,
        deletePromocode,
        fetchPromocodes,
        updatePromocode,
        createPromocode
    };
}