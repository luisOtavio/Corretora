# Corretora
    
## CI

![](https://github.com/luisOtavio/Corretora/blob/main/.github/workflows/dotnet/badge.svg)

## Construir e Executar
```
cd ./src
docker-compose build
docker-compose up -d
```
### Serviços

- Web app: http://localhost:8103
- Swagger: http://localhost:8102/swagger
- Seq: http://localhost:5340
- Banco de dados SQL Server: 
  - servidor: 127.0.0.1,5344
  - senha: Pass@word
  
  
## Ambiente de desenvolvimento

#### Frameworks utilizados
 - API: .NET 5
- Frontend: Angular 11
#### Como executar o frontend
```
cd src\Web\angular
ng serve -o
```

## Contas para testes


| Cliente            | CPF           | Conta   |
| -------------------|:-------------:| -------:|
| José da Silva      | 92414263067   | 300123  |
| Maria de Paula     | 60849126053   | 204125  |
