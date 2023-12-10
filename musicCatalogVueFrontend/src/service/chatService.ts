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

export async function postChatMessage(content: string, timePosted: number): Promise<APIChatMessage> {
    const response = await axios.post(`https://localhost:7026/api/ChatMessage/post`,
    { content, timePosted },
    {
        headers: { 'Authorization': `bearer ${useAccountStore().accessToken}` }
    })
    console.log('posted message!', response.data);
    return response.data;
}