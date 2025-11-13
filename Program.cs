using SemanticKernel.Examples;

Console.WriteLine("Rhyming Day Check");
await RhymingDayCheck.RunAsync();

Console.WriteLine("\nText Summarization");
await TextSummarization.RunAsync();

Console.WriteLine("\nNumber Analysis");
await NumberAnalysis.RunAsync();

Console.WriteLine("\nNumber Analysis & Prediction");
await NumberAnalysisAndPrediction.RunAsync();

Console.WriteLine("\nSentiment Analysis (JSON)");
await SentimentAnalysis.RunAsync();

Console.WriteLine("\nTask Planning");
await TaskPlanning.RunAsync();

Console.WriteLine("\nCode Review");
await CodeReview.RunAsync();