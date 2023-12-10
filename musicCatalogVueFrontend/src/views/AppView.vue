<template>
  <v-container fluid class="p-0 m-0">
    <LeftNavBar>
      <ChatMessage
        v-for="i in 100"
        :key="i"
        :message="i.toString()"
        class="d-flex flex-column"
      />
      <MessageForm class="d-flex justify-end"/>
    </LeftNavBar>
  </v-container>
</template>

<script setup lang="ts">
import ChatMessage from '@/components/ChatMessage.vue';
import MessageForm from '@/components/MessageForm.vue';
import LeftNavBar from '@/components/LeftNavBar.vue';

</script>

<style lang="scss">
.chat-message {

}
</style>