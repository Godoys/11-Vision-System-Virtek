using System.Net;
using _11_Vision_System_Virtek.Application.UseCases;
using _11_Vision_System_Virtek.Domain.Enums;
using _11_Vision_System_Virtek.Domain.Interfaces;
using _11_Vision_System_Virtek.Infrastructure.Adapters;
using _11_Vision_System_Virtek.Infrastructure.Services;

// Message Broker configuration.

IMessageBrokerService brokerService = new MessageBrokerService("Direct", "ProjectorTest");

// Projector configuration.

IProjector projector = new VirtekProjectorAdapter("220e806b-c33b-4ccb-9b7a-de4cc45234e5", "");
IProjectorService projectorService = new ProjectorService(brokerService, projector);

// Camera configuration.

IPAddress address = IPAddress.Parse("169.254.181.230"); 
ICamera camera = new KeyenceCameraAdapter("", "", address, 63000);
ICameraService cameraService = new CameraService(camera);

// Use cases configuration.

PauseOrContinueProjection pauseOrContinueProjection = new PauseOrContinueProjection(cameraService,  projectorService);

while (true)
{
    Console.WriteLine("[*] Write command");
    string command = Console.ReadLine();

    switch (command)
    {
        case "1":
            Console.WriteLine("[*] Connection to Keyence camera and Virtek projector...");
            await camera.ConnectAsync(CameraConnectionType.CM);
            await projectorService.ConnectAsync();
            break;
        case "2":
            Console.WriteLine("[*] Running Pause-or-Continue Projection...");
            pauseOrContinueProjection.Subscribe();
            break;
    }
}





