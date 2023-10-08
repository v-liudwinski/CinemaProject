import User from "../types/userTypes/User";
import { useEffect, useState } from "react";
import axios from 'axios';
import { getCurrentUserId } from './getCurrentUserId';
import UserInfo, { defaultUser } from '../types/userTypes/UserInfo';
import http from '../http-common';

export default function useUsers() {
    
    const [users, setUsers] = useState<User[]>([]);
    const [user, setUser] = useState<UserInfo>(defaultUser);
    const [currentUser, setCurrentUser] = useState<UserInfo>(defaultUser)
    const [show, setShow] = useState(false);

    async function fetchUsers() {
        const response = await http.get<User[]>("/users/GetAllUsers");
        setUsers(response.data);
    }

    async function getUser(userId: number) {
        try {
            const response = await http.get<UserInfo>(`/users/GetUserInfo/${userId}`);
            setUser(response.data);
        } catch (error) {
            throw new Error(`Failed to get user with ID ${userId}.`);
        }
    }

    async function updateUserRole(userId: number, role: number) {
        await http.put(`/users/updateuserrole/${userId}/${role}`);
    }

    async function getCurrentUser() {
        try{
            const userId = getCurrentUserId()
            const response = await http.get<UserInfo>(`/users/GetUserInfo/${userId}`);
            setCurrentUser(response.data)
        } catch(error) {
            throw new Error(`Failed to get user with ID`);
        }
    }

    async function deleteUser(userId: number) {
        await http.delete(`/users/${userId}`);
        setUsers(users.filter(x => x.id !== userId));
    }

    useEffect(() => {
        fetchUsers();
        getCurrentUser();
    }, []);

    return { fetchUsers, users, show, deleteUser, setShow,  getUser, user, getCurrentUser, currentUser, updateUserRole }
}