using System.Net;
using _11_Vision_System_Virtek.Domain.Enums;

namespace _11_Vision_System_Virtek.Domain.Interfaces
{
    public interface ICamera
    {
        string Username { get; }
        string Password { get; }
        IPAddress Address { get; }
        CameraState State { get; }
        ResultStatus LastAnalysisResult { get; }

        /// <summary>
        /// Changes the camera's username.
        /// </summary>
        /// <param name="newUsername">The new login username.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public void UpdateUsername(string newUsername);
        
        /// <summary>
        /// Changes the camera's password.
        /// </summary>
        /// <param name="newPassword">The new login password.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public void UpdatePassword(string newPassword);
        
        /// <summary>
        /// Changes the camera's address.
        /// </summary>
        /// <param name="newAddress">The new IP address.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public void UpdateAddress(IPAddress newAddress);
        
        /// <summary>
        /// Changes the camera's state.
        /// </summary>
        /// <param name="newState">The new camera state.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public void UpdateState(CameraState newState);
        
        /// <summary>
        /// Changes the camera's last image analysis result.
        /// </summary>
        /// <param name="newResult">The new image analysis result.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public void UpdateResult(ResultStatus newResult);

        /// <summary>
        /// Establishes a connection with the camera.
        /// </summary>
        /// <param name="connectionType">Type of connection to use.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public Task ConnectAsync(CameraConnectionType connectionType);
        
        /// <summary>
        /// Closes the connection with the camera.
        /// </summary>
        /// <param name="connectionType">Type of connection used.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public Task DisconnectAsync(CameraConnectionType connectionType);
        
        /// <summary>
        /// Uploads a job file to a camera.
        /// </summary>
        /// <param name="jobPath">File path to a job file.</param>
        /// <param name="jobName">File name of a job file</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public Task UploadJobAsync(string jobPath, string jobName);

        /// <summary>
        /// Activate a pre-uploaded job for analysis.
        /// </summary>
        /// <param name="jobName">The name of the job file.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public Task LoadJobAsync(string jobName);
        
        /// <summary>
        /// Triggers an image capture
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public Task TriggerImageCaptureAsync();

        /// <summary>
        /// Retrieves the result of the last image analysis
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public Task GetAnalysisResultAsync();
    }
}