# Microsoft Semantic Kernel + LM Studio Examples

A minimal .NET 9 console app showcasing Microsoft Semantic Kernel with a local model served by LM Studio. It demonstrates:
- Chat completion with a system style
- Text summarization
- Number analysis
- Number analysis with a simple prediction
- Sentiment analysis with JSON output
- Simple project task planning
- Brief code review for a code snippet

## Prerequisites

- .NET 9 SDK
- LM Studio installed and running
- A compatible chat model downloaded in LM Studio (e.g., `deepseek/deepseek-r1-0528-qwen3-8b`)

## Get the code

```bash
git clone https://github.com/iamhitya/microsoft-semantic-kernel-example.git
cd microsoft-semantic-kernel-example

# Restore packages
dotnet restore
```

## LM Studio setup

1. Open LM Studio and download a chat-capable model (tested with `deepseek/deepseek-r1-0528-qwen3-8b`).
2. Start the local server in LM Studio (commonly `http://localhost:1234`). The app expects the OpenAI-compatible endpoint at `http://localhost:1234/v1` and does not require an API key for local use.

## Configuration

The connection is configured in `KernelProvider.cs` using `AddOpenAIChatCompletion` with:
- Model ID: `deepseek/deepseek-r1-0528-qwen3-8b`
- Endpoint: `http://localhost:1234/v1`

If you use a different model or port, update those values in `KernelProvider.cs` accordingly.

## Run the examples

From the repository root:

```bash
# Option 1: run the default startup project
dotnet run

# Option 2: target the project file explicitly
dotnet run --project SemanticKernel.Examples.csproj
```

The app runs seven examples sequentially.

## Examples

- Rhyming Day Check (`RhymingDayCheck.cs`, class `RhymingDayCheck`)
  - Demonstrates chat completion with a system prompt ("always answer in rhymes" and context that today is Thursday).

- Text Summarization (`TextSummarization.cs`, class `TextSummarization`)
  - Summarizes a short blurb about Semantic Kernel.

- Number Analysis (`NumberAnalysis.cs`, class `NumberAnalysis`)
  - Analyzes a list of numbers to find patterns and averages.

- Number Analysis & Prediction (`NumberAnalysisAndPrediction.cs`, class `NumberAnalysisAndPrediction`)
  - Extends the analysis with a simple next-value prediction.

- Sentiment Analysis (JSON) (`SentimentAnalysis.cs`, class `SentimentAnalysis`)
  - Produces strict JSON with sentiment, confidence, and key phrases for a short user review.

- Task Planning (`TaskPlanning.cs`, class `TaskPlanning`)
  - Generates a concise, prioritized plan for a set of tasks with short rationale.

- Code Review (`CodeReview.cs`, class `CodeReview`)
  - Provides a brief, actionable review of a small code snippet.

## Dependencies

- `Microsoft.SemanticKernel` 1.67.1