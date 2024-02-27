using Microsoft.SemanticKernel.ChatCompletion;
using SturdyGuide;

var kernel = KernelFactory.BuildKernel();
var chatService = kernel.GetRequiredService<IChatCompletionService>();

var chatHistory = new ChatHistory();
do
{
    Console.Write("User > ");
    var userInput = Console.ReadLine();
    if (string.IsNullOrEmpty(userInput))
        return;

    chatHistory.AddUserMessage(userInput);
    var response = await chatService.GetChatMessageContentAsync(chatHistory);
    chatHistory.AddMessage(response.Role, response.Content ?? string.Empty);

    Console.WriteLine("Assistant > " + response);
} while (true);