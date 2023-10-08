export default interface Review {
    id: number;
    description: string;
    rate: number;
    movieDetailsId: number;
    userDetailsId: number;
}