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