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

await camera.ConnectAsync();
await projectorService.ConnectAsync();
pauseOrContinueProjection.Subscribe();

while (true)
{
    
}





