<template>
    <div class="text-center">
        <v-dialog
            v-model="isDialogOpen"
            width="500"
        >
            <template v-slot:activator="{ on, attrs }">
                <slot :on="on" :attrs="attrs" />
            </template>
    
            <v-card class="indigo lighten-3">
                <v-card-title class="text-h5 indigo lighten-2">
                    Potwierdź działanie
                </v-card-title>
        
                <v-card-text>
                    {{ text }}
                </v-card-text>
        
                <v-divider></v-divider>

                <v-text-field
                    color="indigo darken-2"
                    v-model="duration"
                    type="time"
                    messages="hh:mm"
                    class="px-10"
                ></v-text-field>

                <v-divider></v-divider>
        
                <v-card-actions>
                    <v-spacer/>
                    <v-btn
                        color="green"
                        @click="confirmHandler"
                    >
                        Potwierdź
                    </v-btn>
                    <v-spacer/>
                    <v-btn
                        color="grey lighten-1"
                        @click="isDialogOpen = false"
                    >
                        Anuluj
                    </v-btn>
                    <v-spacer/>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
const emit = defineEmits<{
    (e: 'confirm', duration: string): void
}>()

const duration = ref("00:00");

const props = defineProps({
  text: String
})

function confirmHandler() {
    console.log('in durationdialog duration:', duration.value)
    emit('confirm', duration.value);
    isDialogOpen.value = false;
}

const isDialogOpen = ref(false);
</script>