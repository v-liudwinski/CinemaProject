import React, { useEffect, useState } from "react";
import { Container } from "react-bootstrap";
import Purchase from "../../../types/purchaseTypes/Purchase";
import PurchaseItem from "../purchases/PurchaseItem";
import http from "../../../http-common";

interface PurchasesUserProps {
    userId: number; 
}

const PurchasesUser: React.FC<PurchasesUserProps> = ({userId}) => {
    const [purchases, setPurchase] = useState<Purchase[]>([]);

    async function fetchPurchase() {
        const response = await http.get<Purchase[]>("/purchase/user/" + userId);
        setPurchase(response.data);
    }

    useEffect(() => {
        fetchPurchase();
    }, []);

    return (
        <>
            {purchases && 
                <Container>
                    {purchases.map(x => <PurchaseItem purchase={x} key={x.id} />)}
                </Container>
            }
            {purchases.length === 0 && <h4 className="text-center">У цього користувача немає покупок.</h4>}
        </>
    );
};

export default PurchasesUser;

