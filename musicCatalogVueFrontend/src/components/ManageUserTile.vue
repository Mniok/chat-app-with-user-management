<template>
    <div>
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
            
            <div class="manage-user-tile__actions-container d-flex flex-row">
                <!-- mute action -->
                <DurationDialog
                    :text="`Na jak dlugo chcesz wyciszyć użytkownika ${user?.userName}?`"
                    @confirm="handleMute"
                > 
                    <template v-slot="{ on, attrs }">
                        <v-btn
                            icon fab small
                            color="red lighten-1"
                            v-bind="attrs"
                            v-on="on"
                        >
                            <v-icon medium color="red lighten-1">
                                mdi-message-bulleted-off
                            </v-icon>
                        </v-btn>
                    </template>
                </DurationDialog>

                <!-- unmute action -->
                <ConfirmDialog
                    :text="`Czy na pewno chcesz zdjąć wyciszenie z użytkownika ${user?.userName}?`"
                    @confirm="handleUnmute"
                > 
                    <template v-slot="{ on, attrs }">
                        <v-btn
                            icon fab small
                            color="green lighten-1"
                            v-bind="attrs"
                            v-on="on"
                        >
                            <v-icon medium color="green lighten-1">
                                mdi-message-bulleted
                            </v-icon>
                        </v-btn>
                    </template>
                </ConfirmDialog>

                <!-- ban action -->
                <DurationDialog
                    :text="`Na jak dlugo chcesz zbanować użytkownika ${user?.userName}?`"
                    @confirm="handleBan"
                > 
                    <template v-slot="{ on, attrs }">
                        <v-btn
                            icon fab small
                            color="red lighten-1"
                            v-bind="attrs"
                            v-on="on"
                        >
                            <v-icon medium color="red lighten-1">
                                mdi-gavel
                            </v-icon>
                        </v-btn>
                    </template>
                </DurationDialog>

                <!-- unban action -->
                <ConfirmDialog
                    :text="`Czy na pewno chcesz odbanować użytkownika ${user?.userName}?`"
                    @confirm="handleUnban"
                > 
                    <template v-slot="{ on, attrs }">
                        <v-btn
                            icon fab small
                            color="green lighten-1"
                            v-bind="attrs"
                            v-on="on"
                        >
                            <v-icon medium color="green lighten-1">
                                mdi-gavel
                            </v-icon>
                        </v-btn>
                    </template>
                </ConfirmDialog>
            </div>
        </div>
        <v-divider dark />
    </div>
</template>

<script setup lang="ts">
import { PropType } from 'vue';
import { User } from '@/models/User';
import ConfirmDialog from '@/components/Dialogs/ConfirmDialog.vue'
import DurationDialog from '@/components/Dialogs/DurationDialog.vue'
import { useUserStore } from '@/store/user';

const userStore = useUserStore();

const props = defineProps({
  user: Object as PropType<User>
})

function getTimeLocaleString(timestamp: number) {
    const dateObject = new Date(timestamp);
    return dateObject.toLocaleString();
}

function handleMute(duration: string) {
    if (!props.user) return;
    userStore.muteUserById(props.user.userId, Date.now() + getMsFromDuration(duration));
}
function handleUnmute() {
    if (!props.user) return;
    userStore.unmuteUserById(props.user.userId);
}

function handleBan(duration: string) {
    if (!props.user) return;
    userStore.banUserById(props.user.userId, Date.now() + getMsFromDuration(duration));
}
function handleUnban() {
    if (!props.user) return;
    userStore.unbanUserById(props.user.userId);
}

function getMsFromDuration(duration: string) {
    let hours: string, minutes: string;
    [hours, minutes] = duration.split(":");
    return (parseInt(hours)*60*60 + parseInt(minutes)*60) *1000;
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