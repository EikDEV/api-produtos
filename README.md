# API de Produtos

Esta API permite o registro e consulta de produtos no sistema.

## Instala��o

1. Clone o reposit�rio.
2. Certifique-se de ter o .NET 8 instalado.
3. Execute o comando `dotnet run` na raiz do projeto para iniciar a API.

## Uso

### Endpoints
- `GET /produtos`: Retorna todos os produtos cadastrados.
- `GET /produtos/por-id`: Retorna o produto cadastrado pelo ID especificado.
    - Par�metros:
        ```
        id: int
        ```
- `GET /produtos/paginado`: Retorna os produtos de forma paginada.
    - Par�metros:
        ```
        page: int,
        pageSize: int
        ```
- `POST /produtos`: Cria um novo produto.
    - Corpo da requisi��o:
        ```json
        {
          "description": "string",
          "price": 0,
          "userId": 0
        }
        ```
- `PUT /produtos/por-id`: Atualiza a descri��o e o pre�o do produto pelo ID especificado.
  - Par�metros:
    ```
    id: int
    ```
  - Corpo da requisi��o:
    ```json
    {
      "description": "string",
      "price": 0
    }
    ```
## Time de desenvolvimento

- Eik Camargo
  - https://www.linkedin.com/in/eik-camargo/