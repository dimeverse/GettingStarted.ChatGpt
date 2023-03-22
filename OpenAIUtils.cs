using System.Text;
using Newtonsoft.Json;

namespace GettingStarted.ChatGpt
{
    public class OpenAIUtils
    {
        public static StringContent CreateChatRequestBodyContent(string model, string prompt, double temperature, int maxTokens)
        {
            var request = new OpenAI.Request();
            request.model = model;
            request.prompt = prompt;
            request.temperature = temperature;
            request.max_tokens = maxTokens;
            var requestBody = JsonConvert.SerializeObject(request);
            var stringContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
            return stringContent;
        }
        public static async Task<string> InvokeChatAsync(StringContent stringContent)
        {
            // get the openai secret api key
            string apiKey = Environment.GetEnvironmentVariable("apiKey")!;

            // create an instance of a http client object
            HttpClient client = new HttpClient();

            // add the web request headers
            client.DefaultRequestHeaders.Add("authorization", $"Bearer {apiKey}");

            // create an async post request using the openai uri
            HttpResponseMessage response = await client.PostAsync(OpenAI.Uri, stringContent);

            // read the request response string
            string responseString = await response.Content.ReadAsStringAsync();
            var dyData = JsonConvert.DeserializeObject<dynamic>(responseString);
            if (dyData != null && dyData.choices != null && dyData.choices.Count > 0 && dyData.choices[0] != null && dyData.choices[0].text != null)
            {
                return dyData.choices[0].text;
            }
            else
            {
                return string.Empty;
            }
        }

    }
}