<template>
    <v-container fluid class="p-0 m-0">
      <LeftNavBar>
        <div class="d-flex flex-column py-8 px-12">
            <ManageUserTile
                v-for="i in userStore.usersList"
                :key="i.userId"
                :user="i"
            />
        </div>
      </LeftNavBar>
    </v-container>
</template>
  
<script setup lang="ts">
import { ref, onMounted, onUnmounted } from 'vue';
import ManageUserTile from '@/components/ManageUserTile.vue';
import LeftNavBar from '@/components/LeftNavBar.vue';
import { useUserStore } from '@/store/user';

const userStore = useUserStore();

userStore.loadUsers()
const intervalHandle = ref(0);

onMounted(() => {
intervalHandle.value = setInterval(userStore.loadUsers, 5000) // ! here set how ofter users management panel is updated (new users, changes to mutes and bans)
})
onUnmounted(() => { clearInterval(intervalHandle.value) });
</script>

<style lang="scss">
</style>