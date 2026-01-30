<script setup lang="ts">
import { onMounted } from 'vue';
import { useCacheStore } from './stores/cache';
import StructureBody from './components/StructureBody.vue';
import { BApp } from 'bootstrap-vue-next';

const store = useCacheStore()

onMounted(() => {
  store.loadCache()
})
</script>

<template>
  <StructureBody />
</template>

<style>
</style>
