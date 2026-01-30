<script lang="ts" setup>
import { ref } from 'vue';

const show = ref(true)
</script>

<template>
    <div>
        <BButton variant="primary" @click="show = !show">Clique</BButton>
        <BModal v-model="show">Test</BModal>
    </div>
</template>