namespace GettingStarted.ChatGpt
{
    public static class OpenAI
    {
        public static string Uri = "https://api.openai.com/v1/completions";

        [Serializable]
        public struct RequestMessage
        {
            public string role;
            public string content;
        }

        [Serializable]
        public struct Request
        {
            public string model;
            public string prompt;
            public double temperature;
            public int max_tokens;
        }
    }
}