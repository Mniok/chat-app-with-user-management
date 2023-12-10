<template>
  <v-container fluid class="p-0 m-0">
    <LeftNavBar>
      <ChatMessage
        v-for="i in chatStore.loadedMessages"
        :key="i.id"
        :message="i"
        class="d-flex flex-column"
      />
      <MessageForm class="d-flex justify-end"/>
    </LeftNavBar>
  </v-container>
</template>

<script setup lang="ts">
import { onUnmounted } from 'vue';
import ChatMessage from '@/components/ChatMessage.vue';
import MessageForm from '@/components/MessageForm.vue';
import LeftNavBar from '@/components/LeftNavBar.vue';
import { useChatStore } from '@/store/chat';

const chatStore = useChatStore();

chatStore.loadMessages()
const intervalHandle = setInterval(chatStore.loadMessages, 2000) // ! here set how ofter chat is refreshed

onUnmounted(() => { clearInterval(intervalHandle) });
</script>

<style lang="scss">
</style>