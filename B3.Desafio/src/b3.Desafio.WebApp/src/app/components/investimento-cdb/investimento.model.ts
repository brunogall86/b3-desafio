export interface Response {
    statusCode: Number,
    dados?: object,
    errors?: object[],
    isErrors: boolean
}

export interface InvestimentoRequest{
  valorInicial?: number,
  prazo?: number
}

export interface InvestimentoResponse {
    tipoInvestimento?: string,
    prazo?: number,
    valorInvestido?: string,
    valorFinal?: string,
    valorLiquido?: string,
    rendimentos: RendimentoResponse[]
}

export interface RendimentoResponse {
  valorInicialInvestido?: string,
  mesCalculado?: number,
  valorFinalCalculado?: string
} 