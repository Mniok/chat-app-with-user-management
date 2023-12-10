import { APIChatMessage } from '@/models/APIChatMessage';
import { useAccountStore } from '@/store/account'
import axios from 'axios';

export async function getPosts(): Promise<APIChatMessage[]>  {
    const response = await axios.get(`https://localhost:7026/api/ChatMessage/messages`, {
        headers: { 'Authorization': `bearer ${useAccountStore().accessToken}` }
    })
    console.log('messages!', response.data);
    return response.data;
    
}