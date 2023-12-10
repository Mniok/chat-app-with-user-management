<template>
    <div>
        <v-form class="w-100">
            <v-textarea
                dark color="indigo lighten-2" 
                v-model="chatStore.currentMessageContent"
                outlined
                placeholder="Pisz..."
                class="mr-3"
            />
        </v-form>
        <v-btn
            icon fab medium
            :disabled="!canMessageBePosted"
            color="indigo lighten-1"
        >
            <v-icon x-large color="indigo lighten-1">
                mdi-send-circle
            </v-icon>
        </v-btn>
    </div>
</template>

<script setup lang="ts">
import { computed } from 'vue';
import { useChatStore } from '@/store/chat';

const chatStore = useChatStore();

const canMessageBePosted = computed(() => {
    return chatStore.currentMessageContent.length;
    // TODO: block if user is muted or banned (though even seeing this shouldn't be possible if banned)
    // TODO: block if prohibited words detected (1984)
})
</script>