# API de Controle de Livros em Leitura

Esta API foi desenvolvida para facilitar o controle de livros que estou atualmente lendo. Ela oferece operações CRUD (Create, Read, Update, Delete) básicas, juntamente com algumas rotas adicionais para gerenciar a leitura, como alterar a página atual e marcar o livro como concluído.

## Funcionalidades Principais

- **CRUD de Livros:** A API permite criar, visualizar, atualizar e excluir livros da lista de leitura.
- **Gerenciamento de Progresso:** Além das operações CRUD, a API oferece rotas para atualizar a página atual do livro em leitura e marcar o livro como concluído.

## Endpoints Disponíveis

### Livros

- `GET /books`: Retorna a lista de todos os livros em leitura.
- `GET /books/{id}`: Retorna detalhes de um livro específico.
- `POST /books`: Adiciona um novo livro à lista de leitura.
- `PUT /books/{id}`: Atualiza os detalhes de um livro existente.
- `DELETE /books/{id}`: Remove um livro da lista de leitura.

### Gerenciamento de Leitura

- `PATCH /books/change-page/{id}`: Atualiza a página atual de um livro em leitura.
- `PATCH /books/finalize/{id}`: Marca um livro como concluído.
