# Desafio: Chatbot + API RESTful (Integração com GitHub)

Este repositório contém:

O código-fonte de uma API RESTful (em .NET) que integra com a API pública do GitHub, obtendo os 5 repositórios em C# mais antigos do repositório da Take.<br/>
O fluxo (exportado em .json) do Chatbot construído na plataforma BLiP, seguindo o fluxo conversacional disponibilizado no desafio.

## 1. Contexto do Desafio

Construir um chatbot na plataforma BLiP que siga exatamente este fluxo conversacional. <br/>
Ao clicar na opção “Desafio” no carrossel do fluxo, o bot deve listar informações sobre os 5 (cinco) repositórios de linguagem C# mais antigos do GitHub da Take.<br/>
A imagem de cada card no carrossel deve ser o avatar da Blip no GitHub e o título do card deve ser o nome do repositório, enquanto o subtítulo exibe a descrição do repositório. <br/>
Não devemos fazer a chamada à API do GitHub diretamente do fluxo no Builder. Em vez disso, criamos uma API intermediária (no caso, em .NET) que faz a requisição à API pública do GitHub. <br/>
Seguir boas práticas de Clean Code e SOLID na criação da API.

## 2. Passo a Passo: API RESTful

### 2.1 Objetivo da API

A API expõe um endpoint (por exemplo): <br/>

GET /api/GitHub/GetRepositoriesBlip <br/>
que retorna um JSON no formato esperado pelo BLiP, contendo o carrossel com 5 repositórios de C# mais antigos do repositório takenet.

### 2.2 Tecnologias Utilizadas

.NET 6 (para compatibilidade com o Heroku). <br/>
Newtonsoft.Json para serialização JSON. <br/>
HttpClient para chamar a API do GitHub. <br/>

### 2.3 Como Executar

Clonar o repositório e acessar a pasta GitHubAPI. <br/>
Restaurar pacotes (caso utilize dotnet restore ou via Visual Studio / VS Code). <br/>
Executar o projeto: <br/>
dotnet run <br/>
A aplicação subirá em uma porta local (por exemplo http://localhost:5000 ou https://localhost:5001). <br/>

### 2.34 Endpoints Disponíveis

GET /api/GitHub/GetRepositoriesBlip <br/> <br/>
Retorna o JSON pronto para o BLiP renderizar como carrossel, listando os 5 repositórios em C# mais antigos do takenet. <br/>

GET /api/GitHub/GetOldestFiveCSharpRepositories <br/> <br/>
Retorna os 5 repositórios mais antigos de C# da Take. <br/>

GET PARAM /api/Github/GetByRepositoryName <br/> <br/>
Retorna repositório buscado pelo parámetro NOME. <br/>

GET /api/GitHub/GetAllRepositories <br/> <br/>
Retorna todos os repositórios da Take. <br/>

## 3. Passo a Passo: Chatbot na BLiP

### 3.1 Fluxo Conversacional

O fluxo segue fielmente o documento do desafio: <br/>

Mensagem de boas-vindas (apresentação do bot, valores da Take etc.). <br/>
Menu principal com opções. <br/>
Ao clicar em “Desafio”, o bot chama nossa API intermediária para buscar os 5 repositórios. <br/>
O bot então exibe um carrossel contendo nome, descrição e imagem do avatar do GitHub da Blip. <br/>

### 3.2 Como Importar o Fluxo

Acesse o BLiP Portal. <br/>
Crie um bot “A partir do zero”. <br/>
Vá em Builder > Configurações (engrenagem) > Import flow. <br/>
Selecione o arquivo .json deste repositório. <br/>
Publique o fluxo para testá-lo. <br/>

### 3.3 Configurar a Ação HTTP no Builder

No bloco “Desafio” (ou conforme sua estrutura), há uma ação de Requisição HTTP: <br/>
Método: GET <br/>
URL: o endpoint da API <br/>
Em seguida, o conteúdo do bloco utiliza {{respostacarrosselbody@json}} para exibir o carrossel. <br/>

## 4. Próximos Passos (Não realizado em decorrência da deadline justa)

Incluir mais testes unitários na API. <br/>
Adicionar dados de logging, segurança (caso seja necessário tokens ou chaves), entre outros. <br/>

