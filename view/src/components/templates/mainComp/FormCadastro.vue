<script lang="ts" setup>
import { ref } from 'vue';
import type { Ref } from 'vue';

const selectedFabricanteForm: Ref<null | string> = ref(null)
const selectedCorForm: Ref<null | string> = ref(null)
const anoAtual: number = new Date().getFullYear()
const anoButtonValue: Ref<number> = ref(2015)

const optionFabricantes = [
    { value: null, text: " -- Fabricante -- ", disabled: true },
    { value: "a", text: "Fabricante 1" },
    { value: "b", text: "Fabricante 2" }
]

const optionsCor = [
    { value: null, text: " -- Cor -- ", disabled: true },
    { value: "a", text: "Branco" },
    { value: "b", text: "Preto" },
    { value: "c", text: "Azul" }
]
</script>

<template>
    <BCard variant="dark" text-variant="light">
        <BCardText> Formulário de Cadastro </BCardText>
        <BForm>
            <BFormFloatingLabel label="Modelo do Veículo" label-for="modeloCarro" class="my-2">
                <BFormInput id="modeloCarro" type="text" placeholder="Modelo do carro" />
            </BFormFloatingLabel>

            <BRow>
                <BCol>
                    <BFormSelect size="lg" v-model="selectedCorForm" :options="optionsCor" class="mt-3" />
                </BCol>
                <BCol>
                    <BFormSelect size="lg" v-model="selectedFabricanteForm" :options="optionFabricantes" class="mt-3" />
                </BCol>
            </BRow>

            <label for="anoVeiculo" class="mt-3">Ano do veículo</label>
            <BFormSpinbutton size="lg" id="anoVeiculo" v-model="anoButtonValue" min="1886" :max="anoAtual" class="mb-3" />
            <BButton size="lg" type="submit" variant="outline-light"> Adicionar </BButton>
        </BForm>
    </BCard>
</template>