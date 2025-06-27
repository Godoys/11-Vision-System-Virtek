using System.Net;
using _11_Vision_System_Virtek.Domain.Interfaces;
using _11_Vision_System_Virtek.Domain.Enums;

namespace _11_Vision_System_Virtek.Infrastructure.Adapters
{
    public class KeyenceCameraAdapter : ICamera
    {
        public string Username { get; private set;  }
        
        public string Password { get; private set; }
        
        public IPAddress Address { get; private set; }

        public CameraState State { get;  private set; }
        
        public ResultStatus LastAnalysisResult { get; private set; }

        KeyenceCameraAdapter(string username, string password, IPAddress address)
        {
            Username = username;
            Password = password;
            Address = address;
            State = CameraState.Offline;
            LastAnalysisResult = ResultStatus.None;
        }

        public void UpdateUsername(string newUsername)
        {
            Username = newUsername;
        }

        public void UpdatePassword(string newPassword)
        {
            Password = newPassword;
        }

        public void UpdateAddress(IPAddress newAddress)
        {
            Address = newAddress;
        }

        public void UpdateState(CameraState newState)
        {
            State = newState;
        }

        public void UpdateResult(ResultStatus newResult)
        {
            LastAnalysisResult = newResult;
        }

        public Task ConnectAsync(CameraConnectionType connectionType)
        {
            throw new NotImplementedException();
        }

        public Task DisconnectAsync(CameraConnectionType connectionType)
        {
            throw new NotImplementedException();
        }

        public Task UploadJobAsync(string jobPath, string jobName)
        {
            throw new NotImplementedException();
        }

        public Task LoadJobAsync(string jobName)
        {
            throw new NotImplementedException();
        }

        public Task TriggerImageCaptureAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetAnalysisResultAsync()
        {
            throw new NotImplementedException();
        }
    }
}