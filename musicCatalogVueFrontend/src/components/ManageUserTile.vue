<template>
    <div class="manage-user-tile__container mb-4 d-flex flex-row">
        <div class="manage-user-tile__info-container d-flex flex-column w-100">
            <span>
                <span class="manage-user-tile__username text-white">{{ user?.userName }}</span>
                <span class="manage-user-tile__timestamp ml-2"> (Utworzony {{ user?.createdAt }})</span>
            </span>

            <!-- muted notice -->
            <span
                v-if="user?.mutedUntil && user.mutedUntil > Date.now()"
                class="manage-user-tile__important-info"
            >
                <v-icon small color="red" class="mr-2 pb-1 pl-1">mdi-message-bulleted-off</v-icon>
                <span>Użytkownik wyciszony do {{ getTimeLocaleString(user.mutedUntil) }}</span>
            </span>

            <!-- banned notice -->
            <span
                v-if="user?.bannedUntil && user.bannedUntil > Date.now()"
                class="manage-user-tile__important-info"
            >
                <v-icon small color="red" class="mr-2 pb-1 pl-1">mdi-gavel</v-icon>
                <span>Użytkownik zbanowany do {{ getTimeLocaleString(user.bannedUntil) }}</span>
            </span>
        </div>
        
        <div class="manage-user-tile__actions-container">
            <!-- mute action -->

            <!-- unmute action -->
            <ConfirmDialog
                :text="`Czy na pewno chcesz zdjąć wyciszenie z użytkownika ${user?.userName}?`"
                @confirm="handleUnmute"
            > 
                <template v-slot="{ on, attrs }">
                    <v-btn
                        icon fab medium
                        color="green lighten-1"
                        v-bind="attrs"
                        v-on="on"
                    >
                        <v-icon large color="green lighten-1">
                            mdi-message-bulleted
                        </v-icon>
                    </v-btn>
                </template>
            </ConfirmDialog>

            <!-- ban action -->

            <!-- unban action -->
        </div>
    </div>
</template>

<script setup lang="ts">
import { PropType } from 'vue';
import { User } from '@/models/User';
import ConfirmDialog from '@/components/Dialogs/ConfirmDialog.vue'
import { useUserStore } from '@/store/user';

const userStore = useUserStore();

const props = defineProps({
  user: Object as PropType<User>
})

function getTimeLocaleString(timestamp: number) {
    const dateObject = new Date(timestamp);
    return dateObject.toLocaleString();
}

function handleUnmute() {
    if (!props.user) return;
    userStore.unmuteUserById(props.user.userId);
}
</script>

<style lang="scss">
.manage-user-tile__username {
    font-weight: bold;
}

.manage-user-tile__timestamp {
    color: grey;
    font-size: small;
}

.manage-user-tile__important-info {
    color: #FF4433; // vuetify red
    font-style: italic;
}
</style>