using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using SturdyGuide;

await using var driver = DriverFactory.BuildDriver();
var driverPlugin = await DriverPlugin.FromDriverAsync(driver);

var kernel = KernelFactory.BuildKernel(driverPlugin);
var chatService = kernel.GetRequiredService<IChatCompletionService>();
var promptSettings = new OpenAIPromptExecutionSettings
{
    ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
};

var chatHistory = new ChatHistory();
do
{
    Console.Write("User > ");
    var userInput = Console.ReadLine();
    if (string.IsNullOrEmpty(userInput))
        return;

    chatHistory.AddUserMessage(userInput);
    var response = await chatService.GetChatMessageContentAsync(chatHistory, promptSettings, kernel);
    chatHistory.AddMessage(response.Role, response.Content ?? string.Empty);

    Console.WriteLine("Assistant > " + response);
} while (true);