import { User } from '@/models/User';
import { useAccountStore } from '@/store/account'
import axios from 'axios';

export async function getUsers(): Promise<User[]>  {
    const response = await axios.get(`https://localhost:7026/api/User`, {
        headers: { 'Authorization': `bearer ${useAccountStore().accessToken}` }
    })
    return response.data;
    
}

export async function muteUser(userId: number, mutedUntil: number): Promise<User> {
    const response = await axios.post(`https://localhost:7026/api/User/mute`,
    { userId, mutedUntil },
    {
        headers: { 'Authorization': `bearer ${useAccountStore().accessToken}` }
    })
    return response.data;
}

export async function unmuteUser(userId: number): Promise<User> {
    const response = await axios.post(`https://localhost:7026/api/User/unmute`,
    { userId },
    {
        headers: { 'Authorization': `bearer ${useAccountStore().accessToken}` }
    })
    return response.data;
}

export async function banUser(userId: number, bannedUntil: number): Promise<User> {
    const response = await axios.post(`https://localhost:7026/api/User/ban`,
    { userId, bannedUntil },
    {
        headers: { 'Authorization': `bearer ${useAccountStore().accessToken}` }
    })
    return response.data;
}

export async function unbanUser(userId: number): Promise<User> {
    const response = await axios.post(`https://localhost:7026/api/User/unban`,
    { userId },
    {
        headers: { 'Authorization': `bearer ${useAccountStore().accessToken}` }
    })
    return response.data;
}