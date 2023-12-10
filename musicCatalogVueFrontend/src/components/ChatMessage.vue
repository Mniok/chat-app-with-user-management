<template>
    <div class="message__container">
        <span class="message__username text-white">{{ message?.uploaderName }}</span>
        <span class="message__content text-white">{{ message?.content }}</span><br>
    </div>
</template>

<script setup lang="ts">
import { PropType } from 'vue';
import { ChatMessage } from '@/models/ChatMessage';

const props = defineProps({
  message: Object as PropType<ChatMessage>
})

const emit = defineEmits(['edit', 'delete']) // TODO
</script>

<style lang="scss">
.message__username {
    font-weight: bold;

}
</style>