using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace SemanticKernel.Examples;

public static class SentimentAnalysis
{
    public static async Task RunAsync()
    {
        var kernel = KernelProvider.GetKernel();
        string review = "I love the camera quality, but the battery drains too fast and it gets warm during video calls.";

        var result = await AnalyzeSentimentAsync(kernel, review);
        Console.WriteLine("Sentiment JSON:\n" + result);
    }

    private static async Task<string> AnalyzeSentimentAsync(Kernel kernel, string text)
    {
        var chatService = kernel.GetRequiredService<IChatCompletionService>();

        var chat = new ChatHistory();
        chat.AddSystemMessage(
            "You are a precise sentiment analyzer.\n" +
            "Return only strict JSON with the following schema: {\"sentiment\": one of [\"positive\", \"neutral\", \"negative\"], \"confidence\": number 0..1, \"keyPhrases\": string[] }. No markdown, no extra text."
        );
        chat.AddUserMessage($"Analyze the sentiment of this review and extract key phrases:\n{text}");

        var settings = new OpenAIPromptExecutionSettings
        {
            Temperature = 0.2,
            MaxTokens = 400
        };

        var response = await chatService.GetChatMessageContentAsync(chat, executionSettings: settings);
        return response.Content ?? string.Empty;
    }
}
