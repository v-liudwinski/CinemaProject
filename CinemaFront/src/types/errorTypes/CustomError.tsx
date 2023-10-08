export default interface CustomError {
    Message: string;
    StatusCode: number;
}

export const defaultError: CustomError = { 
    Message: "", 
    StatusCode: 200 
};
