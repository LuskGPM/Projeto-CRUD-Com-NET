export const API_CONFIG = {
    baseURL: import.meta.env.VITE_BASE_URL_API, 
    endpoints: {
        gets: {
            carro: {
                all: import.meta.env.VITE_ENDPOINT_CARRO,
                byId: (id: number) => `${import.meta.env.VITE_ENDPOINT_CARRO}/${id}`
            },
            fabricantes: {
                all: import.meta.env.VITE_ENDPOINT_FABRICANTE,
                byId: (id: number) => `${import.meta.env.VITE_ENDPOINT_FABRICANTE}/${id}`
            }
        },
        post: {
            carro: import.meta.env.VITE_ENDPOINT_CARRO,
            fabricantes: import.meta.env.VITE_ENDPOINT_FABRICANTE
        },
        del: {
            carro: (id: number) => `${import.meta.env.VITE_ENDPOINT_CARRO}/${id}`,
            fabricantes: (id: number) => `${import.meta.env.VITE_ENDPOINT_FABRICANTE}/${id}`
        },
        update: import.meta.env.VITE_ENDPOINT_CARRO
    }
}