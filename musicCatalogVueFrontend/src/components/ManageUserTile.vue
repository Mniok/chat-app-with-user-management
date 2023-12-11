<template>
    <div class="manage-user-tile__container mb-4">
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
</template>

<script setup lang="ts">
import { PropType } from 'vue';
import { User } from '@/models/User';

const props = defineProps({
  user: Object as PropType<User>
})

function getTimeLocaleString(timestamp: number) {
    const dateObject = new Date(timestamp);
    return dateObject.toLocaleString();
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