using System.Net;
using _11_Vision_System_Virtek.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using _11_Vision_System_Virtek.Infrastructure.Services;
using _11_Vision_System_Virtek.Application.UseCases;
using _11_Vision_System_Virtek.Domain.Entities;
using _11_Vision_System_Virtek.Domain.Enums;

IPAddress address = IPAddress.Parse("192.168.0.1");

ICameraService cameraService = new CameraService("", "", address);

ConnectToCameraUseCase service = new ConnectToCameraUseCase(cameraService);

service.ConnectToCamera();