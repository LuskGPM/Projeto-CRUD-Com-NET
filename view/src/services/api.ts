import { API_CONFIG } from "@/.config/api.config";
import type { AxiosInstance } from "axios";
import axios from "axios";

class ApiService {
    private constructor() { }

    private static api_instance: AxiosInstance;

    public static getInstance(): AxiosInstance {
        if (!this.api_instance) {
            this.api_instance = axios.create({
                baseURL: API_CONFIG.baseURL
            });
            // Interceptador de requisição
            this.api_instance.interceptors.request.use(
                (config) => config,
                (error) => Promise.reject(error)
            )
            // Interceptador de resposta
            this.api_instance.interceptors.response.use(
                (response) => response.data,
                (error) => Promise.reject(error)
            )
        }
        return this.api_instance
    }
}

export default ApiService.getInstance();
