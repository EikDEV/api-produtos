# API de Produtos

Esta API permite o registro e consulta de produtos no sistema.

## Instalação

1. Clone o repositório.
2. Certifique-se de ter o .NET 8 instalado.
3. Execute o comando `dotnet run` na raiz do projeto para iniciar a API.

## Uso

### Endpoints
- `GET /produtos`: Retorna todos os produtos cadastrados.
- `GET /produtos/por-id`: Retorna o produto cadastrado pelo ID especificado.
    - Parâmetros:
        ```
        id: int
        ```
- `GET /produtos/paginado`: Retorna os produtos de forma paginada.
    - Parâmetros:
        ```
        page: int,
        pageSize: int
        ```
- `POST /produtos`: Cria um novo produto.
    - Corpo da requisição:
        ```json
        {
          "description": "string",
          "price": 0,
          "userId": 0
        }
        ```
- `PUT /produtos/por-id`: Atualiza a descrição e o preço do produto pelo ID especificado.
  - Parâmetros:
    ```
    id: int
    ```
  - Corpo da requisição:
    ```json
    {
      "description": "string",
      "price": 0
    }
    ```
## Time de desenvolvimento

- Eik Camargo
  - https://www.linkedin.com/in/eik-camargo/