import { defineStore } from 'pinia'
import axios from 'axios';
import { vueApp } from '../main';   //// dla routera
import { ChatMessage } from '@/models/ChatMessage';
import { getPosts } from '@/service/chatService';

interface ChatStoreState {
    currentMessageContent: string;
    loadedMessages: ChatMessage[];
}

export const useChatStore = defineStore('chatStore', {

  state: (): ChatStoreState => ({
    currentMessageContent: '',
    loadedMessages: []
  }),

  actions: {
    async loadMessages() {
        const messagesData = await getPosts();
        console.log('in store', messagesData)
        this.loadedMessages = messagesData.map((messageData) => {
            return {
                id: messageData.id,
                content: messageData.content,
                timePosted: messageData.timePosted,
                uploaderName: messageData.uploadedBy.userName,
                uploaderId: messageData.uploadedBy.userId,
                wasEdited: messageData.wasEdited,
                wasRemoved: messageData.wasRemoved
            }
        })
    }

  },


})
