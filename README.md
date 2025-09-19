# WorkFlowVacationApi

Projeto exemplo em ASP.NET Core (.NET 7) para gerir pedidos de férias com verificação de sobreposição.

## Requisitos
- .NET 7 SDK
- (opcional) dotnet-ef para migrations

## Como executar
1. Restaurar pacotes:
   ```
   dotnet restore
   ```

2. Executar:
   ```
   dotnet run
   ```

A primeira execução criará `vacations.db` e aplicará o seed definido em `ApplicationDbContext`.

Abra Swagger em:
`https://localhost:5001/swagger` (ou a porta indicada pelo terminal)

## Endpoints principais
- `POST /api/employees` - criar funcionário
- `GET  /api/employees` - listar funcionários
- `POST /api/vacationrequests` - criar pedido de férias (verifica sobreposição)
- `GET /api/vacationrequests` - listar pedidos

## Observações
- Regras de sobreposição: comparador inclusivo (Start <= End && End >= Start).
- Seed com 3 funcionários e 2 pedidos para testar casos do enunciado.

