<script lang="ts" setup>
import FormCadastro from './mainComp/FormCadastro.vue';
import ListItems from './mainComp/ListItems.vue';
import MenuComp from './mainComp/MenuComp.vue';
import { computed, inject, ref } from 'vue';

let isGerenciamentoDeCarros = ref(inject("isGerCarros"))

const tituloGerenciamento = computed(() => {
    if (!isGerenciamentoDeCarros.value) return "Gerenciamento de Fabricantes"
    return "Gerenciamento de Carros"
})
</script>

<template>
    <BContainer fluid="sm">
        <BRow>
            <BCol class="d-flex align-items-center justify-content-center mb-3" style="font-size: 2em;">
                {{ tituloGerenciamento }}
            </BCol>
        </BRow> 
        <BRow>
            <BCol cols="3">
                <MenuComp />
            </BCol>
            <BCol cols="5">
                <ListItems />
            </BCol>
            <BCol cols="4">
                <FormCadastro />
            </BCol>
        </BRow>
    </BContainer>
</template>