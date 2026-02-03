<script lang="ts" setup>
import HeaderStructure from './templates/HeaderStructure.vue';
import MainStructure from './templates/MainStructure.vue';


</script>

<template>

    <body>
        <header>
            <HeaderStructure />
        </header>
        <main>
            <MainStructure />
        </main>
        <footer>

        </footer>
    </body>
</template>

<style scoped>
body {
    width: 100dvw;
    height: 100dvh;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
}
</style>