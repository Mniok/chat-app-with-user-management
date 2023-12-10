<template>
    <div>
        <!-- message form -->
        <v-form class="w-100">
            <v-textarea
                dark color="indigo lighten-2" 
                v-model="chatStore.currentMessageContent"
                outlined
                placeholder="Pisz..."
                class="mr-3"
            />
        </v-form>

        <!-- send message button -->
        <v-btn
            icon fab medium
            :disabled="!canMessageBePosted"
            color="indigo lighten-1"
            @click="chatStore.createMessage"
        >
            <v-icon x-large color="indigo lighten-1">
                mdi-send-circle
            </v-icon>
        </v-btn>

        <!-- emoji picker -->
        <v-menu
            v-model="isEmojiPickerOpen"
            :close-on-content-click="false"
            :nudge-width="200"
            offset-x
        >
            <template v-slot:activator="{ on, attrs }">
                <v-btn
                    icon fab medium
                    color="indigo lighten-1"
                    v-bind="attrs"
                    v-on="on"
                >
                    <v-icon x-large color="indigo lighten-1">
                        mdi-emoticon
                    </v-icon>
                </v-btn>
            </template>
            <v-card>
                <VEmojiPicker @select="handlePickedEmoji" />
            </v-card>
        </v-menu>
    </div>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue';
import { useChatStore } from '@/store/chat';
import { VEmojiPicker } from 'v-emoji-picker';

const chatStore = useChatStore();

const isEmojiPickerOpen = ref(false);

const canMessageBePosted = computed(() => {
    return chatStore.currentMessageContent.length;
    // TODO: block if user is muted or banned (though even seeing this shouldn't be possible if banned)
    // TODO: block if prohibited words detected (1984)
})

function handlePickedEmoji(emoji: string) {
    console.log('picked emoji:', emoji);
}
</script>