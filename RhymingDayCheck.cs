using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace SemanticKernel.Examples;

public static class RhymingDayCheck
{
    public static async Task RunAsync()
    {
        var kernel = KernelProvider.GetKernel();
        var chatService = kernel.GetRequiredService<IChatCompletionService>();

        var chat = new ChatHistory();
        chat.AddSystemMessage("Always answer in rhymes. Today is Thursday.");
        chat.AddUserMessage("What day is it today?");

        var settings = new OpenAIPromptExecutionSettings
        {
            Temperature = 0.7,
            MaxTokens = 800
        };

        var response = await chatService.GetChatMessageContentAsync(chat, executionSettings: settings);
        Console.WriteLine("Response:\n" + response.Content);
    }
}
