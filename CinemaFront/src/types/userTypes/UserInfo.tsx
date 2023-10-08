import User from "./User";
import { UserDetails } from "./UserDetails";

 
export default interface UserInfo extends User {
    userDetails: UserDetails;
}

export const defaultUser: UserInfo = { 
    id: 0, 
    lastName: "", 
    roleName: '', 
    firstName: '', 
    phoneNumber: '', 
    email: '', 
    birthday: '',
    userDetails: {
        id: 0,
        reviews: [],
        favourites: []
    }
}