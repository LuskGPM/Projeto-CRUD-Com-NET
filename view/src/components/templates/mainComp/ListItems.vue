<script lang="ts" setup>
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';
import { faTrashCan } from '@fortawesome/free-regular-svg-icons';
import { useCacheStore } from '@/stores/cache';

import { inject } from 'vue';

const store = useCacheStore()

const isGerenciamentoDeCarros = inject("isGerCarros")

const deleteItem = async (ExpectedType: "car" | "fab", Id: number) => {
    await store.DeleteItem(ExpectedType, Id)
}
</script>

<template>
    <BCard variant="dark" text-variant="light" style="padding: 10px 5px;">
        <BCardText> Lista de {{ isGerenciamentoDeCarros ? "Carros" : "Fabricantes"}} </BCardText>

        <BListGroup v-if="!isGerenciamentoDeCarros">
            <BListGroupItem variant="dark" class="d-flex justify-content-between align-items-center" v-for="fabricante in store.getFabricantes" :key="fabricante.id">
                <span>{{ fabricante.name }}</span>
                <BButton @click="deleteItem('fab', fabricante.id)" variant="danger">
                    <FontAwesomeIcon :icon="faTrashCan" />
                </BButton>
            </BListGroupItem>
        </BListGroup>

        <BListGroup style="font-size: 1.2em;" v-else>
            <BListGroupItem variant="dark" class="d-flex justify-content-between align-items-center" v-for="carro in store.paginetedCarros" :key="carro.id">
                <span>{{ carro.modelo }}</span>
                <BButton @click="deleteItem('car', carro.id)" variant="danger" >
                    <FontAwesomeIcon :icon="faTrashCan" />
                </BButton>
            </BListGroupItem>
            <BListGroupItem variant="dark" v-if="store.paginetedCarros.length == 0"> Sem Carros cadastrados </BListGroupItem>
        </BListGroup>
    </BCard>
</template>