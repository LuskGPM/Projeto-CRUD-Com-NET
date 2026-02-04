<script lang="ts" setup>
import type { CarroItemDto, FabricanteItemDto } from '@/interfaces/schemas';
import { useCacheStore } from '@/stores/cache';
import { computed, inject, ref, type ComputedRef, type Ref } from 'vue';


const modeloCarro: Ref<string | null> = ref(null)
const selectedFabricanteForm: Ref<null | string> = ref(null)
const selectedCorForm: Ref<null | string> = ref(null)
const anoAtual: number = new Date().getFullYear()
const anoButtonValue: Ref<number> = ref(2015)
const nomeFabricante: Ref<string | null> = ref(null)
const isLoading: Ref<boolean, boolean> = ref(false)

const store = useCacheStore()

const isGerenciamentoDeCarros = inject("isGerCarros")

const optionFabricantes = [
    { value: null, text: " -- Fabricante -- ", disabled: true },
]

const optionsCor = [
    { value: null, text: " -- Cor -- ", disabled: true },
    { value: "branco", text: "Branco" },
    { value: "preto", text: "Preto" },
    { value: "azul", text: "Azul" },
    { value: "vermelho", text: "Vermelho" },
    { value: "cinza", text: "Cinza" },
    { value: "N/A", text: "Outro" }
]

const insertItemCadastroComp = async (ExpectedType: "car" | "fab") => {

    isLoading.value = true

    switch (ExpectedType) {
        case 'car':
            if (!anoButtonValue.value || !selectedCorForm.value || !selectedFabricanteForm.value || !modeloCarro.value) return

            const newCarro: CarroItemDto = {
                id: 0,
                ano: anoButtonValue.value,
                cor: selectedCorForm.value,
                fabricanteId: Number(selectedFabricanteForm.value),
                modelo: modeloCarro.value
            }
            selectedCorForm.value = null
            selectedFabricanteForm.value = null
            modeloCarro.value = null

            await store.InsertItem(ExpectedType, newCarro)

            isLoading.value = false

        case 'fab':
            if (!nomeFabricante.value) return

            const newFabricante: FabricanteItemDto = {
                id: 0,
                name: nomeFabricante.value
            }

            nomeFabricante.value = null

            await store.InsertItem(ExpectedType, newFabricante)

            isLoading.value = false
    }
}

const validacaoSelectFabricantes = computed(() => selectedFabricanteForm.value != null)
const validacaoSelectCor = computed(() => selectedCorForm.value != null)
const validacaoModeloCarro = computed(() => modeloCarro.value != null && modeloCarro.value.length >= 2)

const validarFormularioCarro = computed(() => {
    if(selectedCorForm.value && selectedFabricanteForm.value && modeloCarro.value) return false
    return true
})

const validacaoFabricante = computed(() => nomeFabricante.value != null && nomeFabricante.value.length > 3)

</script>

<template>
    <BCard variant="dark" text-variant="light" style="padding: 10px 5px;">
        <BCardText> Formulário de Cadastro </BCardText>
        <BForm v-if="isGerenciamentoDeCarros">
            <BFormFloatingLabel label="Modelo do Veículo" label-for="modeloCarro" class="my-2">
                <BFormInput id="modeloCarro" type="text" placeholder="Modelo do carro" v-model="modeloCarro"
                    :disabled="isLoading" :state="validacaoModeloCarro" />
            </BFormFloatingLabel>

            <BRow>
                <BCol>
                    <BFormSelect size="md" v-model="selectedCorForm" :options="optionsCor" class="mt-3"
                        :disabled="isLoading" :state="validacaoSelectCor" />
                </BCol>
                <BCol>
                    <BFormSelect size="md" v-model="selectedFabricanteForm" :options="optionFabricantes" class="mt-3"
                        :disabled="isLoading" :state="validacaoSelectFabricantes">
                        <BFormSelectOption v-for="fabricante in store.getFabricantes" :key="fabricante.id!"
                            :value="fabricante.id">
                            {{ fabricante.name }}
                        </BFormSelectOption>
                    </BFormSelect>
                </BCol>
            </BRow>

            <label for="anoVeiculo" class="mt-3">Ano do veículo</label>
            <BFormSpinbutton size="lg" id="anoVeiculo" v-model="anoButtonValue" min="1886" :max="anoAtual" class="mb-3"
                :disabled="isLoading" />

            <BButton size="lg" type="button" variant="outline-light" @click="insertItemCadastroComp('car')"
                :disabled="validarFormularioCarro || isLoading">
                <span>{{ isLoading ? "loading..." : "Adicionar" }}</span>
                <BSpinner v-if="isLoading" small />
            </BButton>
        </BForm>

        <BForm v-else>
            <BFormFloatingLabel label="Nome do Fabricante" label-for="nomeFabricante" class="mb-3">
                <BFormInput type="text" id="nomeFabricante" placeholder="nomeFabricante" v-model="nomeFabricante" :state="validacaoFabricante" />
            </BFormFloatingLabel>
            <BButton size="lg" type="button" variant="outline-light" @click="insertItemCadastroComp('fab')" class="d-flex align-items-center justify-content-between" :disabled="isLoading || validacaoFabricante">
                <span>{{ isLoading ? "loading..." : "Adicionar" }}</span>
                <BSpinner v-if="isLoading" small/>
            </BButton>
        </BForm>
    </BCard>
</template>