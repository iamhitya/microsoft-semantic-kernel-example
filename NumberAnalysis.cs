using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace SemanticKernel.Examples;

public static class NumberAnalysis
{
    public static async Task RunAsync()
    {
        var kernel = KernelProvider.GetKernel();
        var numbers = new[] { 3, 7, 12, 18, 25, 30 };

        var analysis = await AnalyzeNumbersAsync(kernel, numbers);
        Console.WriteLine("AI Analysis:\n" + analysis);
    }

    private static async Task<string> AnalyzeNumbersAsync(Kernel kernel, int[] numbers)
    {
        var chatService = kernel.GetRequiredService<IChatCompletionService>();
        var numberList = string.Join(", ", numbers);

        var chat = new ChatHistory();
        chat.AddSystemMessage("You are a helpful data analyst. You explain number patterns clearly and logically.");
        chat.AddUserMessage($"Analyze this list of numbers: [{numberList}]. Find the average, describe the trend, and mention any interesting pattern.");

        var settings = new OpenAIPromptExecutionSettings
        {
            Temperature = 0.3,
            MaxTokens = 1000
        };

        var response = await chatService.GetChatMessageContentAsync(chat, executionSettings: settings);
        return response.Content ?? string.Empty;
    }
}
