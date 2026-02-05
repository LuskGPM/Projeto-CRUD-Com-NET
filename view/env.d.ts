/// <reference types="vite/client" />

interface ImportMetaEnv {
  readonly VITE_BASE_URL_API: string
  readonly VITE_ENDPOINT_CARRO: string
  readonly VITE_ENDPOINT_FABRICANTE: string
  // Adicione outras variáveis aqui conforme seu .env crescer
}

interface ImportMeta {
  readonly env: ImportMetaEnv
}