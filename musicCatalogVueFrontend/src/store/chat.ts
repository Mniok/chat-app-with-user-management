import { defineStore } from 'pinia'
import axios from 'axios';
import { vueApp } from '../main';   //// dla routera
import { ChatMessage } from '@/models/ChatMessage';
import { getPosts, postChatMessage } from '@/service/chatService';
import Filter from 'bad-words';

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
    },

    async createMessage(): Promise<void> {
      const wordsFilter = new Filter();
      const cleanMessageContent = wordsFilter.clean(this.currentMessageContent)
      const response = await postChatMessage(cleanMessageContent, Date.now());
      if (response.id)
        this.currentMessageContent = '';
      this.loadMessages();
    }

  },


})
