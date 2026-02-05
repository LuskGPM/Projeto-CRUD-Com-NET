<script lang="ts" setup>
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';
import { faTrashCan } from '@fortawesome/free-regular-svg-icons';
import { faPencil } from '@fortawesome/free-solid-svg-icons';

import { useCacheStore } from '@/stores/cache';

import { computed, inject, ref, type Ref } from 'vue';
import { BOffcanvas } from 'bootstrap-vue-next';
import type { CarroItemDto } from '@/interfaces/schemas';

const store = useCacheStore()

const isGerenciamentoDeCarros = inject("isGerCarros")

const deleteItem = async (ExpectedType: "car" | "fab", Id: number): Promise<void> => {
    await store.DeleteItem(ExpectedType, Id)
}

const showOffCanvas: Ref<boolean, boolean> = ref(false)
const carroSelected = ref<CarroItemDto | null>(null)

const toggleOffCanvas = (carroToEdit: CarroItemDto): void => {
    carroSelected.value = { ...carroToEdit }
    showOffCanvas.value = !showOffCanvas.value
}
const anoAtual: number = new Date().getFullYear()

const isLoading: Ref<boolean, boolean> = ref(false)

const optionsCor = [
    { value: null, text: " -- Cor -- ", disabled: true },
    { value: "branco", text: "Branco" },
    { value: "preto", text: "Preto" },
    { value: "azul", text: "Azul" },
    { value: "vermelho", text: "Vermelho" },
    { value: "cinza", text: "Cinza" },
    { value: "N/A", text: "Outro" }
]

const optionFabricantes = [
    { value: null, text: " -- Fabricante -- ", disabled: true },
]

const HandleEditCarro = async (): Promise<void> => {
    if (carroSelected.value == null) return

    isLoading.value = true
    const editCarro: CarroItemDto = {
        ano: carroSelected.value.ano,
        cor: carroSelected.value.cor,
        fabricanteId: Number(carroSelected.value.fabricanteId),
        id: carroSelected.value.id,
        modelo: carroSelected.value.modelo
    }

    await store.UpdateCarro(editCarro)
    isLoading.value = false
    showOffCanvas.value = false
}

const validacaoModeloCarro = computed(() => carroSelected.value?.modelo != null && carroSelected.value?.modelo.length >= 2)
const validacaoSelectCor = computed(() => carroSelected.value?.cor != null)
const validacaoSelectFabricantes = computed(() => carroSelected.value?.fabricanteId != null)

const validarFormularioCarro = computed(() => {
    if (carroSelected.value?.modelo && carroSelected.value?.cor && carroSelected.value?.fabricanteId) return false
    return true
})

</script>

<template>
    <BCard variant="dark" text-variant="light" style="padding: 10px 5px;">
        <BCardText> Lista de {{ isGerenciamentoDeCarros ? "Carros" : "Fabricantes" }} </BCardText>

        <BListGroup v-if="!isGerenciamentoDeCarros" style="font-size: 1.2em;">
            <BListGroupItem variant="dark" class="d-flex justify-content-between align-items-center"
                v-for="fabricante in store.getFabricantes" :key="fabricante.id">
                <span>{{ fabricante.name }}</span>
                <BButton @click="deleteItem('fab', fabricante.id)" variant="danger">
                    <FontAwesomeIcon :icon="faTrashCan" />
                </BButton>
            </BListGroupItem>
        </BListGroup>

        <BListGroup style="font-size: 1.2em;" v-else>
            <BListGroupItem variant="dark" class="d-flex justify-content-between align-items-center"
                v-for="carro in store.paginetedCarros" :key="carro.id">
                <span>{{ carro.modelo }} | {{ carro.ano }}</span>
                <div class="d-flex" style="gap: 10px;">
                    <BButton variant="success" @click="toggleOffCanvas(carro)">
                        <FontAwesomeIcon :icon="faPencil" />
                    </BButton>
                    <BButton @click="deleteItem('car', carro.id)" variant="danger">
                        <FontAwesomeIcon :icon="faTrashCan" />
                    </BButton>
                </div>
            </BListGroupItem>
            <BListGroupItem variant="dark" v-if="store.paginetedCarros.length == 0">
                Sem Carros cadastrados
            </BListGroupItem>
        </BListGroup>
    </BCard>

    <BOffcanvas class="m-2" placement="end" v-model="showOffCanvas" v-if="carroSelected" title="Detalhes do Veículo">
        
        <BForm v-if="isGerenciamentoDeCarros">
            <BFormFloatingLabel label="Modelo do Veículo" label-for="modeloCarro" class="my-2">
                <BFormInput id="modeloCarro" type="text" placeholder="Modelo do carro" v-model="carroSelected.modelo"
                    :disabled="isLoading" :state="validacaoModeloCarro" />
            </BFormFloatingLabel>

            <BRow>
                <BCol>
                    <BFormSelect size="md" v-model="carroSelected.cor" :options="optionsCor" class="mt-3"
                        :disabled="isLoading" :state="validacaoSelectCor" />
                </BCol>
                <BCol>
                    <BFormSelect size="md" v-model="carroSelected.fabricanteId" :options="optionFabricantes" class="mt-3"
                        :disabled="isLoading" :state="validacaoSelectFabricantes">
                        <BFormSelectOption v-for="fabricante in store.getFabricantes" :key="fabricante.id!"
                            :value="fabricante.id">
                            {{ fabricante.name }}
                        </BFormSelectOption>
                    </BFormSelect>
                </BCol>
            </BRow>

            <label for="anoVeiculo" class="mt-3">Ano do veículo</label>
            <BFormSpinbutton size="lg" id="anoVeiculo" v-model="carroSelected.ano" min="1886" :max="anoAtual" class="mb-3"
                :disabled="isLoading" />

            <BButton size="lg" type="button" variant="outline-dark" @click="HandleEditCarro"
                :disabled="validarFormularioCarro || isLoading">
                <span>{{ isLoading ? "loading..." : "Editar" }}</span>
                <BSpinner v-if="isLoading" small />
            </BButton>
        </BForm>
    </BOffcanvas>
</template>