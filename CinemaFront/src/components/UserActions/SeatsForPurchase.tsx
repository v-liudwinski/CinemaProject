import { Button, OverlayTrigger, Tooltip } from "react-bootstrap";
import Seat from "../../types/seatTypes/Seat";
import { useEffect } from "react";
import usePurchases from "../../hooks/PurchasesHook";
     
interface PurchaseTicketsProps {
    seats: Seat[];
    setSeatIds: (value: number[] | ((prevVar: number[]) => number[])) => void;
    seatIds: number[];
    addOrRemoveItemFromArray: (value: number) => void;
    seanseId: number;
    setShowPayPal: React.Dispatch<React.SetStateAction<boolean>>;
    setToOrder: React.Dispatch<React.SetStateAction<boolean>>;
}

const SeatsForPurchase: React.FC<PurchaseTicketsProps> = ({ setShowPayPal, setToOrder, seatIds, seanseId, addOrRemoveItemFromArray, seats }) => {
    var max = 0;
    const { freeSeats, getFreeSeats } = usePurchases();

    useEffect(() => {
        getFreeSeats(seanseId)
    }, [])

    const getColor = (color: string) => {
        return color === 'Normal'? 'success' : 
            color === 'ForDisablers' ? 'primary' :
            color === 'ForKissing' ? 'danger' : 'warning'
    }

    const getTooltip = (color: string) => {
        return color === 'Normal'? 'Звичайне' : 
            color === 'ForDisablers' ? 'Для інвалідів' :
            color === 'ForKissing' ? 'Для поцілунків' : 'VIP'
    }

    return (
        <div>
            {seats.sort((a, b) => {
                if(a.row > b.row) return 1; 
                if(a.row < b.row) return -1; 

                if(a.seatNumber > b.seatNumber) return 1; 
                if(a.seatNumber < b.seatNumber) return -1;

                return 1;
            }).map(x => {

            if (max < x.row) {
                max = x.row;
                return (
                    <>
                        <br />
                        <OverlayTrigger overlay={<Tooltip id="tooltip-disabled">{getTooltip(x.seatType.type)}</Tooltip>}>
                        <span className="d-inline-block">
                        <Button key={x.id} variant={freeSeats.some(e => e.id === x.id) !== true ? 'secondary' : 
                            getColor(x.seatType.type)} className={seatIds.some(e => e === x.id) === true ? 'p-2 m-1 border' : 'p-2 m-1'}
                            onClick={() => {
                            if(freeSeats.some(e => e.id === x.id)) {
                                addOrRemoveItemFromArray(x.id);
                                setShowPayPal(false);
                                setToOrder(true);
                        }}}>{x.row}/{x.seatNumber}</Button>
                        </span>
                        </OverlayTrigger>
                    </>
                );
            }

            return <OverlayTrigger overlay={<Tooltip id="tooltip-disabled">{getTooltip(x.seatType.type)}</Tooltip>}>
                <span className="d-inline-block">
                <Button key={x.id} variant={freeSeats.some(e => e.id === x.id) !== true ? 'secondary' : 
                    getColor(x.seatType.type)} className={seatIds.some(e => e === x.id) === true ? 'p-2 m-1 border' : 'p-2 m-1'}
                    onClick={() => {
                    if(freeSeats.some(e => e.id === x.id)) {
                        addOrRemoveItemFromArray(x.id);
                        setShowPayPal(false);
                        setToOrder(true);
                    }}}>{x.row}/{x.seatNumber}</Button>
                </span>
            </OverlayTrigger>})}
        </div>
    )
};

export default SeatsForPurchase;