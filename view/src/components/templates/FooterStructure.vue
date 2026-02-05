<template>
    <footer class="bg-dark text-light py-5 mt-5">
        <BContainer>
            <BRow>
                <BCol lg="4" class="mb-4 mb-lg-0">
                    <h5 class="text-uppercase fw-bold mb-4">
                        Projeto Gerenciamento de Veículos
                    </h5>
                    <p class="text-secondary">
                        Gerencie sua frota de veículos com facilidade e rapidez.
                        Sistema desenvolvido com .NET 10 e Vue.js 3.
                    </p>
                    <p class="text-secondary">
                        Não-Compatível com Celular
                    </p>
                </BCol>
            </BRow>

            <hr class="my-4 border-secondary" />

            <BRow class="align-items-center">
                <BCol md="6" class="text-center text-md-start">
                    <span class="text-secondary small">
                        © {{ new Date().getFullYear() }} Todos os direitos reservados.
                    </span>
                </BCol>
                <BCol md="6" class="text-center text-md-end mt-2 mt-md-0">
                    <span class="text-secondary small">Desenvolvido por Lucas Melo com bootstrap-vue-next</span>
                </BCol>
            </BRow>
        </BContainer>
    </footer>
</template>

<style scoped>
footer {
    border-top: 1px solid #444;
}

</style>