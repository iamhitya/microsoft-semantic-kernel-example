using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace SemanticKernel.Examples;

public static class Example2
{
    public static async Task RunAsync()
    {
        var kernel = KernelProvider.GetKernel();
        string text = """
                      Semantic Kernel is a lightweight SDK that helps developers integrate local or cloud AI models, 
                      prompts, and external data sources into their .NET or Python applications.
                      """;

        var summary = await SummarizeAsync(kernel, text);
        Console.WriteLine("Summary:\n" + summary);
    }

    private static async Task<string> SummarizeAsync(Kernel kernel, string input)
    {
        var chatService = kernel.GetRequiredService<IChatCompletionService>();

        var chat = new ChatHistory();
        chat.AddSystemMessage("You are a concise assistant that summarizes text clearly and briefly.");
        chat.AddUserMessage($"Summarize this:\n{input}");

        var settings = new OpenAIPromptExecutionSettings
        {
            Temperature = 0.5,
            MaxTokens = 16384
        };

        var response = await chatService.GetChatMessageContentAsync(chat, executionSettings: settings);
        return response.Content ?? string.Empty;
    }
}
