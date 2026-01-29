<script setup lang="ts">
import { onMounted } from 'vue';
import { useCacheStore } from './stores/cache';

const store = useCacheStore()

onMounted(() => {
  store.loadCache()
})
</script>

<template>
  <h1>Meu site</h1>
  <p> Primeiro paragrafo </p>
  <p>
    {{ store.getFabricantes }}
  </p>
</template>
<style scoped></style>
