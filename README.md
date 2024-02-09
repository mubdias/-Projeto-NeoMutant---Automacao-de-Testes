# <> Projeto NeoMutantAutomation <>

	> Projeto de automação de testes de API com Webhooks.

1. Objetivo:

	> Este projeto tem como objetivo buscar dados de uma tabela no Notion utilizando uma API
	  e enviar uma mensagem no Discord utilizando os dados obtidos por meio de Webhooks.


2. Arquivos:

> UnitTest1.cs: 

	> Contém a classe de teste UnitTest1 com o método TestMethod1 responsável por buscar os dados 
	  da tabela do Notion e enviar uma mensagem no Discord.

> NotionTableData.cs: 

	> Contém a classe NotionTableData com as propriedades necessárias para armazenar os dados
	  da tabela do Notion que foram coletados por meio da API. E foram convertidos de JSON para objeto.

> GlobalUsings.cs:

	> Contém os using globais do projeto NeoMutantAutomation.

3. Dependências:

	> Newtonsoft.Json: 
	> Esta biblioteca foi utilizada para serializar e desserializar objetos JSON.

	> RestSharp: 
	> Esta biblioteca foi utilizada para fazer requisições HTTP.

4. Variáveis de configuração:

	> notion_token: Token de acesso do Notion.
	> discord_token: Token de acesso do Discord.
	> notion_database_id: ID do banco de dados do Notion.
	> notion_api_url: URL da API do Notion.
	> discord_api_url: URL da API do Discord.

5. Fluxo de execução da automação TestMethod1:

	1. Faz uma requisição para obter os dados da tabela do Notion.
	2. Verifica se a requisição foi bem-sucedida.
	3. Extrai os dados da resposta.
	4. Verifica se a tabela possui linhas.
	5. Percorre cada linha da tabela.
	6. Extrai os dados da linha.
	7. Cria os dados da mensagem do Discord.
	8. Envia a requisição para enviar a mensagem para o canal do Discord.
	9. Verifica se a requisição foi bem-sucedida.
	10. Exibe uma mensagem de sucesso ou erro.

6. Observações:

	> É necessário substituir os valores das variáveis notion_token, discord_token, 
	  notion_database_id, notion_api_url e discord_api_url pelos valores corretos antes de executar o teste.

	> Estima-se que melhorias podem ser feitas no código para que a substituição dos valores das 
	  variáveis, seja feita por meio de uma página no Notion ou por meio de um arquivo de configuração.
