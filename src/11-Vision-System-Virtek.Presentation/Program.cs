using System.Net;
using _11_Vision_System_Virtek.Application.UseCases;
using _11_Vision_System_Virtek.Domain.Enums;
using _11_Vision_System_Virtek.Domain.Interfaces;
using _11_Vision_System_Virtek.Infrastructure.Adapters;
using _11_Vision_System_Virtek.Infrastructure.Services;

// Message Broker configuration.

IMessageBrokerService brokerService = new MessageBrokerService("Direct", "ProjectorTest");

// Projector configuration.

IProjector projector = new VirtekProjectorAdapter();
IProjectorService projectorService = new ProjectorService(brokerService, projector);

// Camera configuration.

IPAddress address = IPAddress.Parse("169.254.181.230"); 
ISensor camera = new KeyenceCameraAdapter("", "", address, 63000);
ISensorService cameraService = new SensorService(camera);

// Use cases configuration.

PauseOrContinueProjection pauseOrContinueProjection = new PauseOrContinueProjection(cameraService,  projectorService);

await projector.ConnectAsync();
Console.WriteLine($"Client Id: {projector.ClientId}");
await projector.AddProjectPolygonAsync("Wrong Orientation", 11111, "C:\\Program Files\\Virtek\\Virtek Server\\Workorders\\wo1\\testply.ply");

while (true)
{
    
}





