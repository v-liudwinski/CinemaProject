import { useState } from "react";
import http from '../http-common';
import Seat from "../types/seatTypes/Seat";
import axios, { AxiosError } from "axios";
import CustomError from "../types/errorTypes/CustomError";

interface TicketsAdd {
    seanseId: number,
    seatId: number
}

export default function usePurchases() {
    const [showPromocode, setShowPromocode] = useState<boolean>(true);
    const [freeSeats, setFreeSeats] = useState<Seat[]>([]);
    const pdf = "https://localhost:7282/api/purchase/ticket/";

    const downloadFileAtUrl = (value: number) => {
        fetch(pdf + value)
            .then((response) => response.blob())
            .then((blob) => {
                const blobURL = window.URL.createObjectURL(new Blob([blob]));
                const aTag = document.createElement("a");
                aTag.href = blobURL;
                aTag.setAttribute("download", 'ticket.pdf');
                document.body.appendChild(aTag);
                aTag.click();
                aTag.remove();
            })
    }

    const getFreeSeats = async (seanseId: number) => {
        const response = await http.get(`seats/seanse/${seanseId}`);
        setFreeSeats(response.data);
    }

    const purchasing = async (userDetailsId: number, promocode: string, seatIds: number[], snsId: number,
        setShowError: (value: boolean) => void, setOccuredError: (value: CustomError) => void) => {
        const tickets: TicketsAdd[] = [];
        
        seatIds.map(x => tickets.push({ seatId: x, seanseId: snsId }));
        try {
            await http.post('/purchase', {userDetailsId, promocode, tickets});
        }
        catch (error) {
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
        showPromocode, 
        setShowPromocode,
        downloadFileAtUrl,
        purchasing,
        freeSeats,
        getFreeSeats
    };
}