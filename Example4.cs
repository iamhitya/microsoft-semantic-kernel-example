using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace SemanticKernel.Examples;

public static class Example4
{
    public static async Task RunAsync()
    {
        var kernel = KernelProvider.GetKernel();
        int[] numbers = { 2, 4, 8, 16, 32 };

        string result = await AnalyzeAndPredictAsync(kernel, numbers);
        Console.WriteLine("AI Analysis & Prediction:\n" + result);
    }

    private static async Task<string> AnalyzeAndPredictAsync(Kernel kernel, int[] numbers)
    {
        var chatService = kernel.GetRequiredService<IChatCompletionService>();
        var numberList = string.Join(", ", numbers);

        var chat = new ChatHistory();
        chat.AddSystemMessage("You are a smart data analyst that explains number patterns clearly, calculates key metrics, and predicts the next number in a sequence.");
        chat.AddUserMessage($"Analyze this sequence: [{numberList}]. Explain the trend, compute the average, and predict the next number. Keep your answer concise and structured.");

        var settings = new OpenAIPromptExecutionSettings
        {
            Temperature = 0.3,
            MaxTokens = 400
        };

        var response = await chatService.GetChatMessageContentAsync(chat, executionSettings: settings);
        return response.Content ?? string.Empty;
    }
}
