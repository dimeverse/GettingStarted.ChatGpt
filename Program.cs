using GettingStarted.ChatGpt;

// create one argument/prompt
string[] inputs = new string[1];
inputs[0] = "What is rhino?";
string model = "text-davinci-001";

if (inputs.Length > 0)
{
    // create request body parameters string content
    var stringContent = OpenAIUtils.CreateChatRequestBodyContent(model, inputs[0], 1, 100);
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