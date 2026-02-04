<script setup lang="ts">
import { onMounted, ref, provide, type Ref } from 'vue';
import { useCacheStore } from './stores/cache';
import StructureBody from './components/StructureBody.vue';
import { BApp } from 'bootstrap-vue-next';

const store = useCacheStore()

let isGerenciamentoDeCarros: Ref<boolean, boolean> = ref(true)

const buttonToggleToFabricantes = () => {
  isGerenciamentoDeCarros.value = false
}

const buttonToggleToCarros = () => {
  isGerenciamentoDeCarros.value = true
}

onMounted(() => {
  store.loadCache()
})

provide("isGerCarros", isGerenciamentoDeCarros)
provide("buttonFabricantes", buttonToggleToFabricantes)
provide("buttonCarros", buttonToggleToCarros)

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
