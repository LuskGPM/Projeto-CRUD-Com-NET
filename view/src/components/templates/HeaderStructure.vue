<script lang="ts" setup>

</script>

<template>
    <BNavbar v-b-color-mode = "'dark'" toggleable="lg" variant="dark" class="nav-bar-scroll">
        <BNavbarBrand tag="h1" class="mb-0">Estoque de Carros</BNavbarBrand>

        <BNavbarToggle target="nav-scroll" />

        <BCollapse id="nav-scroll" is-nav>
            <BNavbarNav class="ms-auto">
                <BNavItem href="#">
                    Toggle Mode
                </BNavItem>
            </BNavbarNav>
        </BCollapse>
    </BNavbar>
</template>