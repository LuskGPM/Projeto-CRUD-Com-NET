export interface CarroItemDto {
    id: number;
    fabricanteId: number;
    modelo: string;
    cor: string;
    ano: number;
}

export interface FabricanteItemDto {
    id: number;
    name: string;
}

export type Carro_Or_Fabricante = CarroItemDto | FabricanteItemDto;

