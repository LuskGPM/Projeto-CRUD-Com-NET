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
  <BApp>
    <StructureBody />
  </BApp>
</template>

<style>
* {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}
</style>
