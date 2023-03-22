using GettingStarted.ChatGpt;

// create one argument/prompt
string[] inputs = new string[1];
string query = "hi, I did implement you in my console app for text completion. Now how can I implement you inside grasshopper/rhino3d and make you aware of my grasshopper definition objects and algorithm for a certain process ??";
inputs[0] = query;

string model = "text-davinci-003";

if (inputs.Length > 0)
{
    // create request body parameters string content
    var stringContent = OpenAIUtils.CreateChatRequestBodyContent(model, inputs[0], 1, 1000);
    string responseString = await OpenAIUtils.InvokeChatAsync(stringContent);

    // try to parse the response string to a json
    try
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n---> API response is: {responseString}\n");
        Console.ResetColor();
    }
    catch (System.Exception ex)
    {
        Console.WriteLine($"---> Could not deserialize the JSON: {ex.Message}");
    }
}
else
{
    Console.WriteLine("---> you need to provide some inputs first");
}