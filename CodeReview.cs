using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace SemanticKernel.Examples;

public static class CodeReview
{
    public static async Task RunAsync()
    {
        var kernel = KernelProvider.GetKernel();
        var code = @"public int Add(int a, int b){return a+b;}";

        var review = await ReviewCodeAsync(kernel, code, language: "C#");
        Console.WriteLine("Code Review:\n" + review);
    }

    private static async Task<string> ReviewCodeAsync(Kernel kernel, string code, string language)
    {
        var chatService = kernel.GetRequiredService<IChatCompletionService>();

        var chat = new ChatHistory();
        chat.AddSystemMessage("You are a senior software engineer. Provide a brief, actionable code review focusing on correctness, readability, and potential edge cases.");
        chat.AddUserMessage($"Review this {language} snippet and list improvements in bullets. Keep it short.\n```{language}\n{code}\n``` ");

        var settings = new OpenAIPromptExecutionSettings
        {
            Temperature = 0.4,
            MaxTokens = 500
        };

        var response = await chatService.GetChatMessageContentAsync(chat, executionSettings: settings);
        return response.Content ?? string.Empty;
    }
}
