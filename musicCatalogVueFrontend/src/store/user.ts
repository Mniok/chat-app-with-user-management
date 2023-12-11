import { defineStore } from 'pinia'
import axios from 'axios';
import { vueApp } from '../main';   //// dla routera
import { User } from '@/models/User';
import { getUsers, muteUser, unmuteUser, banUser, unbanUser } from '@/service/userService';

interface UserStoreState {
    usersList: User[];
}

export const useUserStore = defineStore('userStore', {

  state: (): UserStoreState => ({
    usersList: []
  }),

  actions: {
    async loadUsers(): Promise<void> {
        this.usersList = await getUsers();
    },

    async muteUserById(userId: number, mutedUntil: number): Promise<void> {
        muteUser(userId, mutedUntil);
        this.loadUsers();
    },

    async unmuteUserById(userId: number): Promise<void> {
        unmuteUser(userId);
        this.loadUsers();
    },

    async banUserById(userId: number, bannedUntil: number): Promise<void> {
        banUser(userId, bannedUntil);
        this.loadUsers();
    },

    async unbanUserById(userId: number): Promise<void> {
        unbanUser(userId);
        this.loadUsers();
    },

  },


})
