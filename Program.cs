using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
string[] inputs = new string[1];
inputs[0] = "What command do you use to list all docker images";
if (inputs.Length > 0)
{

    HttpClient client = new HttpClient();
    client.DefaultRequestHeaders.Add("authorization", "Bearer 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");
    string stringContent = "{\"model\": \"text-davinci-001\", \"prompt\": \"" + inputs[0] + "\",\"temperature\": 1,\"max_tokens\": 100}";
    var content = new StringContent(stringContent, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/completions", content);
    string responseString = await response.Content.ReadAsStringAsync();
    try
    {
        var dyData = JsonConvert.DeserializeObject<dynamic>(responseString);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"---> API response is: {dyData!.choices[0].text}");
        Console.ResetColor();
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
