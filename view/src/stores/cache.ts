import { defineStore } from "pinia";
import { ResponseInstance } from "@/services/responseApi";
import type { CarroItemDto, FabricanteItemDto } from "@/interfaces/schemas";

export const useCacheStore = defineStore('cache', {
    state: () => ({
        carros: [] as CarroItemDto[],
        fabricantes: [] as FabricanteItemDto[]
    }),
    getters: {
        
    },

    actions: {
        async GetAllCarros() {
            this.carros = await ResponseInstance.GetAllAsync("car") as CarroItemDto[]
        }
    }
})