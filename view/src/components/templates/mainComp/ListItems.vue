<script lang="ts" setup>
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';
import { faTrashCan } from '@fortawesome/free-regular-svg-icons';
</script>

<template>
    <BCard variant="dark" text-variant="light">
        <BCardText> Lista de Carros </BCardText>
        <BListGroup style="font-size: 1.2em;">
            <BListGroupItem variant="dark" class="d-flex justify-content-between align-items-center">
                <span>Carro 1</span>
                <FontAwesomeIcon :icon="faTrashCan" style="color: red;"/>
            </BListGroupItem>
            <BListGroupItem variant="dark"> Carro 2 </BListGroupItem>
        </BListGroup>
    </BCard>
</template>