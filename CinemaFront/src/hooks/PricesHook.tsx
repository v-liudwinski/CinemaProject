import { useState } from "react";
import axios, { AxiosError } from 'axios';
import Price from "../types/priceTypes/Price";
import http from '../http-common';
import CustomError from "../types/errorTypes/CustomError";

export default function usePrices() {

    const [prices, setPrices] = useState<Price[]>([]);
    const [showPrice, setShowPrice] = useState<boolean>(true);


    async function fetchPrices() {
        const response = await http.get<Price[]>('/prices');
        setPrices(response.data);
    }

    async function updatePrice(priceId: number, cost: number, setShowError: (value: boolean) => void, setOccuredError: (value: CustomError) => void) {
        try {
            await http.put(`/prices/${priceId}`, {cost});
        
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

    async function createPrice(cost: number, setShowError: (value: boolean) => void, setOccuredError: (value: CustomError) => void) {
        try {
            await http.post("/prices", {cost});
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

    async function deletePrice(priceId: number, setShowError: (value: boolean) => void, 
    setOccuredError: (value: CustomError) => void) {
        try {
            await http.delete(`/prices/${priceId}`);
            setPrices(prices.filter(x => x.id !== priceId));
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
        prices, 
        showPrice, 
        setShowPrice,
        deletePrice,
        fetchPrices,
        updatePrice,
        createPrice
    };
}