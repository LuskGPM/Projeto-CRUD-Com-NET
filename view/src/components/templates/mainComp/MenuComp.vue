<script lang="ts" setup>
import { useCacheStore } from '@/stores/cache';
import { inject } from 'vue';

// All provides in src/app.vue
const buttonToggleFabricantes = inject("buttonFabricantes")
const buttonToggleCarros = inject("buttonCarros")

const store = useCacheStore()
</script>

<template>
    <BCard bg-variant="dark" text-variant="light" style="padding: 10px 5px;">
        <BCardText> Menu de Objetos </BCardText>
        <BListGroup style="font-size: 1.2em;">
            <BListGroupItem button @click="buttonToggleCarros" class="d-flex justify-content-between align-items-center" variant="dark">
                Carros
                <BBadge variant="dark" pill> {{ store.paginetedCarros.length }} </BBadge>
            </BListGroupItem>
            <BListGroupItem button  @click="buttonToggleFabricantes" class="d-flex justify-content-between align-items-center" variant="dark">
                Fabricantes
                <BBadge variant="dark" pill> {{ store.getFabricantes.length }} </BBadge>
            </BListGroupItem>
        </BListGroup>
    </BCard>
</template>

<style scoped></style>