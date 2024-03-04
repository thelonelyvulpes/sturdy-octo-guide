﻿using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using SturdyGuide;

using var loggerFactory = LoggerFactory.Create(x => x.AddConsole().SetMinimumLevel(LogLevel.Debug));
await using var driver = DriverFactory.BuildDriver(loggerFactory);
var driverPlugin = await DriverPlugin.FromDriverAsync(driver);

var kernel = KernelFactory.BuildKernel(loggerFactory, driverPlugin.Add);
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