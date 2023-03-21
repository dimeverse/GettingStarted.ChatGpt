using System;
using System.Net.Http;
using System.Text;


if (args.Length > 0)
{

    HttpClient client = new HttpClient();
    client.DefaultRequestHeaders.Add("authorization", "Bearer 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");
    string stringContent = "{\"model\": \"text-davinci-001\", \"prompt\": \"" + args[0] + "\",\"temperature\": 1,\"max_tokens\": 100}";
    var content = new StringContent(stringContent, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/completions", content);
    string responseString = await response.Content.ReadAsStringAsync();
    try
    {

    }
    catch (System.Exception ex)
    {
        Console.WriteLine($"---> Could not deserialize the JSON: {ex.Message}");
    }
    Console.WriteLine(responseString);
}
else
{
    Console.WriteLine("---> you need to provide some inputs first");
}
