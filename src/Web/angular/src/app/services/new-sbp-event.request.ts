export interface NewSbpEventRequest {
  event: string;
  target: TargetDto;
  origin: OriginDto;
  amount: number;
}

export interface TargetDto {
  bank: string;
  branch: string;
  account: string;
}

export interface OriginDto {
  bank: string;
  branch: string;
  cpf: string;
}
