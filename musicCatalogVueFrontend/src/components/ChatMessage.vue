<template>
    <span>this is a chat message {{ message }}</span>
</template>

<script setup lang="ts">

const props = defineProps({
  message: String
})

const emit = defineEmits(['edit', 'delete']) // TODO
</script>