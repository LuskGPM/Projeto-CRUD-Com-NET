<script lang="ts" setup>
import FormCadastro from './mainComp/FormCadastro.vue';
import ListItems from './mainComp/ListItems.vue';
import MenuComp from './mainComp/MenuComp.vue';


</script>

<template>
    <BContainer fluid="sm">
        <Brow>
            <BCol>
                Gerenciamento de Carros
            </BCol>
        </Brow> 
        <BRow>
            <BCol cols="3">
                <MenuComp />
            </BCol>
            <BCol>
                <ListItems />
            </BCol>
            <BCol>
                <FormCadastro />
            </BCol>
        </BRow>
    </BContainer>
</template>