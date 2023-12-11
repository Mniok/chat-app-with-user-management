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
import { ref, onMounted, onUnmounted } from 'vue';
import ChatMessage from '@/components/ChatMessage.vue';
import MessageForm from '@/components/MessageForm.vue';
import LeftNavBar from '@/components/LeftNavBar.vue';
import { useChatStore } from '@/store/chat';
import { useUserStore } from '@/store/user';

const chatStore = useChatStore();
const userStore = useUserStore();

chatStore.loadMessages()
userStore.loadUsers() // needed here to detect mutes and bans
const chatIntervalHandle = ref(0);
const userIntervalHandle = ref(0);

onMounted(() => {
  chatIntervalHandle.value = setInterval(chatStore.loadMessages, 2000) // ! here set how ofter chat is refreshed
})
onUnmounted(() => { clearInterval(chatIntervalHandle.value) });


onMounted(() => {
  userIntervalHandle.value = setInterval(userStore.loadUsers, 5000) // ! here set how ofter users management panel is updated (new users, changes to mutes and bans)
})
onUnmounted(() => { clearInterval(userIntervalHandle.value) });
</script>

<style lang="scss">
</style>