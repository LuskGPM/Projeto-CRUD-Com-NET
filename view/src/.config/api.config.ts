import urlApi from "./app.config.json"

export const API_CONFIG = {
    baseURL: urlApi.BaseUrlApi,
    endpoints: {
        gets: {
            carro: {
                all: urlApi.BaseEndpoints.Carro,
                byId: (id: number) => `${urlApi.BaseEndpoints.Carro}/${id}`
            },
            fabricantes: {
                all: urlApi.BaseEndpoints.Fabricante,
                byId: (id: number) => `${urlApi.BaseEndpoints.Fabricante}/${id}`
            }
        },
        post: {
            carro: urlApi.BaseEndpoints.Carro,
            fabricantes: urlApi.BaseEndpoints.Fabricante
        },
        del: {
            carro: (id: number) =>  `${urlApi.BaseEndpoints.Carro}/${id}`,
            fabricantes: (id: number) =>  `${urlApi.BaseEndpoints.Fabricante}/${id}`
        },
        update: "/carro"
    }
}
