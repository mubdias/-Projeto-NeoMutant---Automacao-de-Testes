using static NotionTableData.NotionTableData;


namespace UnitTest
{

    [TestClass]
    public class UnitTest1
    {
        public void TestMethod1()
        {
            // Definir o URL da API do Notion
            string notion_api_url = "https://api.notion.com/v1/databases/";
            //Definir o token de acesso do Discord
            string discord_token = "MTIwNDUzMDk0ODc0NjUxNDUxMg.GjSwLf.rDb4LJbDV1UxH7hVa6CR_hO3nq_82cKGWGKWGY";
            // Definir o URL da API do Discord
            string discord_api_url = "https://discord.com/api/v9/channels/";
            // Definir o token de acesso do Notion
            string notion_token = "secret_AuCre5wg7l7EHn3FgCb6UDgWTf1HqwmjLxB5jUTnwi9";
            // Definir o ID do banco de dados do Notion
            string notion_database_id = "7ac29a34592d411a89eb73c6bfd3fdf0";
            // Definir o ID do canal do Discord
            string discord_channel_id = "123456789012345678";

            //Criar uma instância da classe NotionTableData.Root para extrair os dados da resposta
            Root root = new();

            // Definir a query para obter os dados da tabela do Notion
            var query = new { };

            // Obter os dados da tabela do Notion
            var notion_client = new RestClient(notion_api_url);
            var notion_request = new RestRequest(notion_api_url + notion_database_id + "/query", Method.Post);
            notion_request.AddHeader("Authorization", "Bearer " + notion_token);
            notion_request.AddHeader("Notion-Version", "2022-06-28");
            notion_request.AddParameter("application/json", JsonConvert.SerializeObject(query), ParameterType.RequestBody);
            var notion_response = notion_client.Execute(notion_request);

            // Verificar se a requisição foi bem-sucedida
            if (notion_response.StatusCode == System.Net.HttpStatusCode.OK && notion_response.Content != null)
            {


                // Extrair os dados da resposta
                var notion_table_data = JsonConvert.DeserializeObject<Root>(notion_response.Content) ?? throw new Exception("Failed to deserialize Notion table data");

                // Verificar se a tabela possui linhas
                if (notion_table_data != null && notion_table_data.Results != null && notion_table_data.Results.Count > 0)
                {
                    // Percorrer cada linha da tabela
                    foreach (var row in notion_table_data.Results)
                    {
                        // Extrair os dados da linha
                        var nome = row.Properties.Nome?.Title;
                        var telefone = row.Properties.Telefone?.Rich_text;
                        var email = row.Properties.Email?.Rich_text;
                        var cnpj = row.Properties.CNPJ?.Rich_text;
                        var canal = row.Properties.Canal?.Rich_text;

                        // Criar os dados da mensagem do Discord
                        var discord_message_data = new
                        {
                            content = "[MENSAGEM DE AVISO]",
                            username = "NeoMutant",
                            embeds = new[]
                            {
                                new
                                {
                                    description = $"Olá, {nome[0].Plain_text}, tudo bem?\n\nEstamos realizando uma checagem de dados e gostaríamos de confirmar seus dados para melhor atender nossos clientes. Segue abaixo os dados que possuímos:\n\nNome: {nome[0].Plain_text}\nTelefone: {telefone[0].Plain_text}\nE-mail: {email[0].Plain_text}\nCNPJ: {cnpj[0].Plain_text}\n\nPara entrar em contato conosco em caso de alterações, por favor, lige no número 0800-1234567\n\nAtenciosamente,\nEquipe NeoMutant."
                                }
                            }
                        };

                        // Enviar a requisição para enviar a mensagem para o canal do Discord
                        var discord_webhook_url = canal[0].Plain_text;
                        var discord_client = new RestClient(discord_webhook_url);
                        var discord_request = new RestRequest(discord_webhook_url, Method.Post);
                        discord_request.AddHeader("Content-Type", "application/json");
                        discord_request.AddJsonBody(discord_message_data);
                        var discord_response = discord_client.Execute(discord_request);

                        // Verificar se a requisição foi bem-sucedida
                        if (discord_response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            Console.WriteLine("Mensagem enviada com sucesso para o canal do Discord.");
                        }
                        else
                        {
                            Console.WriteLine("Erro ao enviar a mensagem para o canal do Discord.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("A tabela do Notion não possui linhas.");
                }
            }
            else
            {
                Console.WriteLine("Erro ao obter os dados da tabela do Notion.");
            }

        }
    }
}