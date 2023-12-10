<template>
    <div>
        <!-- message form -->
        <v-form class="w-100">
            <v-textarea
                ref="postContentTextarea"
                dark color="indigo lighten-2" 
                v-model="chatStore.currentMessageContent"
                outlined
                placeholder="Pisz..."
                class="mr-3"
            />
        </v-form>

        <div class="d-flex flex-column">
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
    </div>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue';
import { useChatStore } from '@/store/chat';
import { VEmojiPicker } from 'v-emoji-picker';

const chatStore = useChatStore();

const isEmojiPickerOpen = ref(false);
const postContentTextarea = ref();

const canMessageBePosted = computed(() => {
    return chatStore.currentMessageContent.length;
    // TODO: block if user is muted or banned (though even seeing this shouldn't be possible if banned)
    // TODO: block if prohibited words detected (1984)
})

function handlePickedEmoji(emoji: {
  data: string;
  category: string;
  aliases: string[];
}) {
    // console.log('cursor pos:', postContentTextarea.value?.selectionStart)
    // console.log('picked emoji:', emoji, emoji.data);
    // console.log('textarea ref:', postContentTextarea, postContentTextarea.value)
    // console.log('cursor pos:', postContentTextarea.value?.selectionStart)
    // TODO: add emoji at cursor position
    // ! EDIT: doesn't seem possible in vuetify2 - selectionStart and selectionEnd don't show up in vue devtools, and opening emojipicker deselects text in textarea anyway
    chatStore.currentMessageContent += emoji.data;
}
</script>