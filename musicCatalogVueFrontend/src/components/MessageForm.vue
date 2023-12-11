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
                :error-messages="(currentUser?.mutedUntil && currentUser.mutedUntil > Date.now())
                    ? [`Jesteś wyciszony do ${getTimeLocaleString(currentUser.mutedUntil)}`]
                    : []"
                class="mr-3"
                @keyup="handlePostMessageOnEnter"
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
import { useUserStore } from '@/store/user';
import { useAccountStore } from '@/store/account';
import { VEmojiPicker } from 'v-emoji-picker';
import { getTimeLocaleString } from '@/helpers';

const chatStore = useChatStore();
const userStore = useUserStore();
const accountStore = useAccountStore();

const isEmojiPickerOpen = ref(false);
const postContentTextarea = ref();

const canMessageBePosted = computed(() => {
    return chatStore.currentMessageContent.length
        && !(currentUser.value?.mutedUntil && currentUser.value.mutedUntil > Date.now())
        && !(currentUser.value?.bannedUntil && currentUser.value.bannedUntil > Date.now());
    // TODO: block if prohibited words detected (1984), either that turn them into asterisks
})

const currentUser = computed(() => {
  return userStore.usersList.find((user) => user.userName === accountStore.currentUser)
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

function handlePostMessageOnEnter(keyEvent: KeyboardEvent) {
    if (keyEvent.key === 'Enter' && !keyEvent.shiftKey && canMessageBePosted.value) {
        chatStore.createMessage()
    }
}
</script>