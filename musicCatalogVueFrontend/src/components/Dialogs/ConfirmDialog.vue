<template>
    <div class="text-center">
        <v-dialog
            v-model="isDialogOpen"
            width="500"
        >
            <template v-slot:activator="{ on, attrs }">
                <slot :on="on" :attrs="attrs" />
            </template>
    
            <v-card>
                <v-card-title class="text-h5 grey lighten-2">
                    Potwierdzenie
                </v-card-title>
        
                <v-card-text>
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                </v-card-text>
        
                <v-divider></v-divider>
        
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn
                    color="primary"
                    text
                    @click="confirmHandler"
                    >
                    I accept
                    </v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
const emit = defineEmits<{
  (e: 'confirm'): void
}>()

function confirmHandler() {
    isDialogOpen.value = false;
    emit('confirm');
}

const isDialogOpen = ref(false);
</script>