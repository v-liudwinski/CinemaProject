import jwt_decode from 'jwt-decode';

export interface DecodedToken {
  id: string;
  exp: number;
  role: string;
}

export function verifyAuthToken() {
  const token = localStorage.getItem('token');
  if (!token) {
    // Token not found in localStorage
    console.log("error");
    return false;
  }
  try {
    const decodedToken = jwt_decode<DecodedToken>(token);
    return decodedToken;
  } catch (error) {
    // Invalid token
    console.log(error);
  }
}