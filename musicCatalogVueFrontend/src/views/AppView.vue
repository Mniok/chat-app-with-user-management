<template>
  <v-container fluid class="p-0 m-0">
    <LeftNavBar>
      <div
        v-if="currentUser?.bannedUntil && currentUser.bannedUntil > Date.now()"
        class="ban-message d-flex align-center justify-center"
        style="height: 100%"
      >
        <span class="text-white">
          Konto zbanowane do {{ getTimeLocaleString(currentUser.bannedUntil) }}
        </span>
      </div>
      <div v-else>
        <ChatMessage
          v-for="i in chatStore.loadedMessages"
          :key="i.id"
          :message="i"
          class="d-flex flex-column"
        />
        <MessageForm class="d-flex justify-end"/>
      </div>
    </LeftNavBar>
  </v-container>
</template>

<script setup lang="ts">
import { ref, computed, onMounted, onUnmounted } from 'vue';
import ChatMessage from '@/components/ChatMessage.vue';
import MessageForm from '@/components/MessageForm.vue';
import LeftNavBar from '@/components/LeftNavBar.vue';
import { useChatStore } from '@/store/chat';
import { useUserStore } from '@/store/user';
import { useAccountStore } from '@/store/account';
import { getTimeLocaleString } from '@/helpers';
import { User } from '@/models/User';

const chatStore = useChatStore();
const userStore = useUserStore();
const accountStore = useAccountStore();

chatStore.loadMessages()
userStore.loadUsers() // needed here to detect mutes and bans
const chatIntervalHandle = ref(0);
const userIntervalHandle = ref(0);

const currentUser = computed(() => {
  return userStore.usersList.find((user) => user.userName === accountStore.currentUser)
})

onMounted(() => {
  chatIntervalHandle.value = setInterval(chatStore.loadMessages, 1000) // ! here set how ofter chat is refreshed
})
onUnmounted(() => { clearInterval(chatIntervalHandle.value) });


onMounted(() => {
  userIntervalHandle.value = setInterval(userStore.loadUsers, 2000) // ! here set how ofter users management panel is updated (new users, changes to mutes and bans)
})
onUnmounted(() => { clearInterval(userIntervalHandle.value) });
</script>

<style lang="scss">
</style>