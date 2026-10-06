using System.Text.Json;

class Program
{
    static async Task Main(string[] args)
    {
        using HttpClient client = new HttpClient();

        string url = "https://api.adviceslip.com/advice";

        try
        {
            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            JsonDocument document = JsonDocument.Parse(json);

            string advice = document
                .RootElement
                .GetProperty("slip")
                .GetProperty("advice")
                .GetString();

            Console.WriteLine("Conselho de Hoje:");
            Console.WriteLine(advice);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao consultar a API.");
            Console.WriteLine($"Detalhes: {ex.Message}");
        }
    }
}