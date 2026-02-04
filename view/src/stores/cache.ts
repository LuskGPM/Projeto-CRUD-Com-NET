import { defineStore } from "pinia";
import { ResponseInstance } from "@/services/responseApi";
import type { CarroItemDto, FabricanteItemDto } from "@/interfaces/schemas";

export const useCacheStore = defineStore('cache', {
    state: () => ({
        carros: [] as CarroItemDto[],
        fabricantes: [] as FabricanteItemDto[],
        page: 1,
        pageSize: 20,
        erroString: "" as string
    }),
    persist: {
        storage: localStorage
    },

    getters: {
        getFabricantes: (state): FabricanteItemDto[] => [...state.fabricantes],

        // Pega 20 items do array state.carros baseado no state.page atual
        paginetedCarros: (state): CarroItemDto[] => {
            const start = (state.page - 1) * state.pageSize
            const end = state.page * state.pageSize
            return [...state.carros].slice(start, end)
        },

        // Pega o tamanho do array de carros e divide pela quantidade máxima de itens por página
        // ex: carros.length = 20 (21 itens) => totalPages = 2
        // ex: carros.length = 19 (20 itens) => totalPages = 1
        totalPages: (state): number => {
            return Math.ceil(state.carros.length / state.pageSize)
        },

        hasNextPage: (state): boolean => state.page > Math.ceil(state.carros.length / state.pageSize),
        hasPrevPage: (state): boolean => state.page > 1
    },

    actions: {
        setPage(page: number) {
            if (page > 0 && page <= this.totalPages)
                this.page = page;
        },
        async loadCache() {
            try {
                if (this.carros.length === 0)
                    this.carros = await ResponseInstance.GetAllAsync("car") as CarroItemDto[]

                if (this.fabricantes.length === 0)
                    this.fabricantes = await ResponseInstance.GetAllAsync("fab") as FabricanteItemDto[]
            } catch (error: any) { this.erroString = error.message ?? `Erro: ${error}` }
        },
        async InsertItem(ExpectedType: "car" | "fab", newObject: CarroItemDto | FabricanteItemDto) {
            const response = await ResponseInstance.PostAsync(ExpectedType, newObject)

            if (ExpectedType == "car") this.carros.unshift(response as CarroItemDto)
            else this.fabricantes.unshift(response as FabricanteItemDto)
        },
        async DeleteItem(ExpectedType: "car" | "fab", Id: number) {
            await ResponseInstance.DeleteAsync(ExpectedType, Id)

            if (ExpectedType == "car") this.carros = [...this.carros].filter(carro => carro.id !== Id)
            else this.fabricantes = this.fabricantes = [...this.fabricantes].filter(fabricante => fabricante.id !== Id)
        }
    }
})