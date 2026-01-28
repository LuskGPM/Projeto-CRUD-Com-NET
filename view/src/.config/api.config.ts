export const API_CONFIG = {
    baseURL: "https://localhost:7140/api/services/",
    endpoints: {
        gets: {
            carro: {
                all: "/carro",
                byId: (id: number) => `/carro/${id}`
            },
            fabricantes: {
                all: "/fabricantes",
                byId: (id: number) => `/fabricantes/${id}`
            }
        },
        post: {
            carro: "/carro",
            fabricantes: "/fabricantes"
        },
        del: {
            carro: (id: number) =>  `/carro/${id}`,
            fabricantes: (id: number) =>  `/fabricantes/${id}`
        },
        update: "/carro"
    }
}
