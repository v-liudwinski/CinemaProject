export interface Promocode {
    id: number;
    name: string;
    percentage: number;
}

export const defaultPromocode: Promocode = {
    id: 0,
    name: '',
    percentage: 0
}