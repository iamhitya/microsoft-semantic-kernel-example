using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace SemanticKernel.Examples;

public static class Example6
{
    public static async Task RunAsync()
    {
        var kernel = KernelProvider.GetKernel();
        var tasks = new[]
        {
            new { Title = "Write unit tests", Priority = "High", EstimateH = 5 },
            new { Title = "Refactor data layer", Priority = "Medium", EstimateH = 8 },
            new { Title = "Update README", Priority = "Low", EstimateH = 1 },
        };

        var plan = await CreateTaskPlanAsync(kernel, tasks);
        Console.WriteLine("Task Plan:\n" + plan);
    }

    private static async Task<string> CreateTaskPlanAsync(Kernel kernel, object[] tasks)
    {
        var chatService = kernel.GetRequiredService<IChatCompletionService>();
        var taskLines = string.Join("\n", tasks.Select(t => t.ToString()));

        var chat = new ChatHistory();
        chat.AddSystemMessage("You are a helpful project planner. Create a concise prioritized plan with bullet points and short rationale.");
        chat.AddUserMessage($"Given these tasks (with priority and estimate hours), produce an actionable plan with ordering and grouping if needed:\n{taskLines}");

        var settings = new OpenAIPromptExecutionSettings
        {
            Temperature = 0.3,
            MaxTokens = 600
        };

        var response = await chatService.GetChatMessageContentAsync(chat, executionSettings: settings);
        return response.Content ?? string.Empty;
    }
}
