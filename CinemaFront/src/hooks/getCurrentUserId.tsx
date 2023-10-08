import { DecodedToken, verifyAuthToken } from "./VerifyAuthToken";

export function getCurrentUserId<Number>() {
    const tokenInfo = verifyAuthToken();
    const decodedToken = tokenInfo as DecodedToken;
    const userId = Number(decodedToken.id)
    return userId;
}

