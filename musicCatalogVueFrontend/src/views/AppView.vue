
import ChatMessage from '@/components/ChatMessage.vue';
<template>
  <v-container fluid>
    <ChatMessage v-for="i in 100" :key="i"
      class="d-flex flex-column"
      :message="i.toString()"
    />
    <MessageForm class="d-flex justify-end"/>
  </v-container>
</template>

<script setup lang="ts">
import ChatMessage from '@/components/ChatMessage.vue';
import MessageForm from '@/components/MessageForm.vue';

</script>

<style lang="scss">
.chat-message {

}
</style>