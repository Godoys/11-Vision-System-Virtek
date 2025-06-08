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
        ResultState Result { get; }

        /// <summary>
        /// Updates Username with newUsername value.
        /// </summary>
        /// <param name="newUsername">Holds the value of the new username to be set.</param>
        public void UpdateUsername(string newUsername);
        
        /// <summary>
        /// Updates the Password with newPassword value.
        /// </summary>
        /// <param name="newPassword">Holds the value of the new password to be set.</param>
        public void UpdatePassword(string newPassword);
        
        /// <summary>
        /// Updates the Address with newAddress value.
        /// </summary>
        /// <param name="newAddress">Holds the value of the new password to be set.</param>
        public void UpdateAddress(IPAddress newAddress);
        
        /// <summary>
        /// Updates the State with newState value.
        /// </summary>
        /// <param name="newState">Holds the value of the new state to be set.</param>
        public void UpdateState(CameraState newState);
        
        /// <summary>
        /// Updates the Result with newResult value.
        /// </summary>
        /// <param name="newResult">Holds the value of the new state to be set.</param>
        public void UpdateResult(ResultState newResult);

        /// <summary>
        /// Connects to a camera.
        /// </summary>
        public Task Connect(CameraConnectionType connectionType);
        
        /// <summary>
        /// Disconnects from a camera.
        /// </summary>
        public Task Disconnect(CameraConnectionType connectionType);
        
        /// <summary>
        /// Uploads a job file to a camera.
        /// </summary>
        /// <param name="jobPath">File path to a job file.</param>
        /// <param name="jobName">File name of a job file</param>
        public Task UploadJob(string jobPath, string jobName);

        /// <summary>
        /// Sets the stored job file in camera as the one to be used in image analysis.
        /// </summary>
        /// <param name="jobName">File name of a job file</param>
        public Task LoadJob(string jobName);
    }
}