
import type { Carro_Or_Fabricante, CarroItemDto, FabricanteItemDto } from "@/interfaces/schemas"
import { API_CONFIG } from "@/.config/api.config";
import type { AxiosInstance, HttpStatusCode } from "axios";
import api_instance from "./api"

class ApiResponseService {
    private api: AxiosInstance = api_instance;

    // car = CarroItemDto | fab = FabricantesItemDto
    public async GetAllAsync(ExpectedType: "car" | "fab"): Promise<CarroItemDto[] | FabricanteItemDto[]> {
        switch (ExpectedType) {
            case "car":
                return await this.api(API_CONFIG.endpoints.gets.carro.all)
            case "fab":
                return await this.api(API_CONFIG.endpoints.gets.fabricantes.all)
        }
    }

    // GetById somente utilizado em casos extremamente específicos
    // Recomendado fazer a busca individual na memória do Pinia
    public async GetByIdAsync(ExpectedType: "car" | "fab", Id: number): Promise<Carro_Or_Fabricante> {
        switch (ExpectedType) {
            case "car":
                return await this.api(API_CONFIG.endpoints.gets.carro.byId(Id))
            case "fab":
                return await this.api(API_CONFIG.endpoints.gets.fabricantes.byId(Id))
        }
    }

    public async PostAsync(ExpectedType: "car" | "fab", Object: Carro_Or_Fabricante): Promise<Carro_Or_Fabricante> {
        switch (ExpectedType) {
            case "car":
                return await this.api.post(API_CONFIG.endpoints.post.carro, Object)
            case "fab":
                return await this.api.post(API_CONFIG.endpoints.post.fabricantes, Object)
        }
    }

    // Apenas carro possuí opção de Update
    public async PatchCarAsync(Object: CarroItemDto): Promise<CarroItemDto> {
        return await this.api.patch(API_CONFIG.endpoints.update, Object)
    }

    public async DeleteAsync(ExpectedType: "car" | "fab", Id: number): Promise<HttpStatusCode.NoContent> {
        switch (ExpectedType) {
            case "car":
                return await this.api.delete(API_CONFIG.endpoints.del.carro(Id))
            case "fab":
                return await this.api.delete(API_CONFIG.endpoints.del.fabricantes(Id))
        }
    }
}

export const ResponseInstance: ApiResponseService = new ApiResponseService()
