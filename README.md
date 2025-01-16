# Desafio: Chatbot + API RESTful (Integração com GitHub)

Este repositório contém:

O código-fonte de uma API RESTful (em .NET) que integra com a API pública do GitHub, obtendo os 5 repositórios em C# mais antigos do repositório da Take.
O fluxo (exportado em .json) do Chatbot construído na plataforma BLiP, seguindo o fluxo conversacional disponibilizado no desafio.

## 1. Contexto do Desafio

Construir um chatbot na plataforma BLiP que siga exatamente este fluxo conversacional.
Ao clicar na opção “Desafio” no carrossel do fluxo, o bot deve listar informações sobre os 5 (cinco) repositórios de linguagem C# mais antigos do GitHub da Take.
A imagem de cada card no carrossel deve ser o avatar da Blip no GitHub e o título do card deve ser o nome do repositório, enquanto o subtítulo exibe a descrição do repositório.
Não devemos fazer a chamada à API do GitHub diretamente do fluxo no Builder. Em vez disso, criamos uma API intermediária (no caso, em .NET) que faz a requisição à API pública do GitHub.
Seguir boas práticas de Clean Code e SOLID na criação da API.

## 2. Passo a Passo: API RESTful

### 2.1 Objetivo da API

A API expõe um endpoint (por exemplo:

GET /api/GitHub/GetRepositoriesBlip
que retorna um JSON no formato esperado pelo BLiP, contendo o carrossel com 5 repositórios de C# mais antigos do repositório takenet.

### 2.2 Tecnologias Utilizadas

.NET 6 (para compatibilidade com o Heroku).
Newtonsoft.Json para serialização JSON.
HttpClient para chamar a API do GitHub.

### 2.3 Como Executar

Clonar o repositório e acessar a pasta GitHubAPI.
Restaurar pacotes (caso utilize dotnet restore ou via Visual Studio / VS Code).
Executar o projeto:
dotnet run
A aplicação subirá em uma porta local (por exemplo http://localhost:5000 ou https://localhost:5001).

### 2.34 Endpoints Disponíveis

GET /api/GitHub/GetRepositoriesBlip
Retorna o JSON pronto para o BLiP renderizar como carrossel, listando os 5 repositórios em C# mais antigos do takenet.

GET /api/GitHub/GetOldestFiveCSharpRepositories
Retorna os 5 repositórios mais antigos de C# da Take.

GET PARAM /api/Github/GetByRepositoryName
Retorna repositório buscado pelo parámetro NOME.

GET /api/GitHub/GetAllRepositories
Retorna todos os repositórios da Take.

## 3. Passo a Passo: Chatbot na BLiP

### 3.1 Fluxo Conversacional

O fluxo segue fielmente o documento do desafio:

Mensagem de boas-vindas (apresentação do bot, valores da Take etc.).
Menu principal com opções.
Ao clicar em “Desafio”, o bot chama nossa API intermediária para buscar os 5 repositórios.
O bot então exibe um carrossel contendo nome, descrição e imagem do avatar do GitHub da Blip.

### 3.2 Como Importar o Fluxo

Acesse o BLiP Portal.
Crie um bot “A partir do zero”.
Vá em Builder > Configurações (engrenagem) > Import flow.
Selecione o arquivo .json deste repositório.
Publique o fluxo para testá-lo.

### 3.3 Configurar a Ação HTTP no Builder

No bloco “Desafio” (ou conforme sua estrutura), há uma ação de Requisição HTTP:
Método: GET
URL: o endpoint da API
Em seguida, o conteúdo do bloco utiliza {{respostacarrosselbody@json}} para exibir o carrossel.

## 4. Próximos Passos (Não realizado em decorrência da deadline justa)

Incluir mais testes unitários na API.
Adicionar dados de logging, segurança (caso seja necessário tokens ou chaves), entre outros.

