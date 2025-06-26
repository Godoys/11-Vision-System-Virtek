using _11_Vision_System_Virtek.Domain.Interfaces;
using _11_Vision_System_Virtek.Infrastructure.Adapters;
using _11_Vision_System_Virtek.Infrastructure.Services;

IMessageBrokerService messageBrokerService = new MessageBrokerService("Direct", "testQueue");
IProjector projector = new VirtekProjectorAdapter("220e806b-c33b-4ccb-9b7a-de4cc45234e5", "24039611");
IProjectorService projectorService = new ProjectorService(messageBrokerService, projector);

await projectorService.ConnectAsync();

string projectionEntity = await projector.GetCurrentProjectionEntityAsync();

Console.WriteLine("[!] Projector Entity:");
Console.WriteLine(projectionEntity);

CancellationToken cts = CancellationToken.None;

Console.WriteLine("[!] Waiting for Next Step event...");
await projectorService.CheckCurrentProjectionEntityAsync(cts);
