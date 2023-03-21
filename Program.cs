using System.Text;
using Newtonsoft.Json;


string[] inputs = new string[1];
inputs[0] = "What is rhino?";

if (inputs.Length > 0)
{
    string apiKey = Environment.GetEnvironmentVariable("apiKey")!;
    HttpClient client = new HttpClient();
    client.DefaultRequestHeaders.Add("authorization", $"Bearer {apiKey}");
    string stringContent = "{\"model\": \"text-davinci-001\", \"prompt\": \"" + inputs[0] + "\",\"temperature\": 1,\"max_tokens\": 100}";
    var content = new StringContent(stringContent, Encoding.UTF8, "application/json");
    HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/completions", content);
    string responseString = await response.Content.ReadAsStringAsync();
    try
    {
        var dyData = JsonConvert.DeserializeObject<dynamic>(responseString);
        var guess = GuessCommand(dyData!.choices[0].text);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n---> API response is: {guess}\n");
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
static string GuessCommand(string raw)
{
    Console.WriteLine("---> GPT-3 API Returned Text:");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(raw);

    var lastIndex = raw.LastIndexOf("\n");
    string guess = raw.Substring(lastIndex + 1);

    Console.ResetColor();
    TextCopy.ClipboardService.SetText(guess);
    return guess;
}