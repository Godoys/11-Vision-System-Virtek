using System.Net;
using _11_Vision_System_Virtek.Domain.Entities;

namespace _11_Vision_System_Virtek.Domain.Interfaces
{
    /// <summary>
    /// Interface to communicate with external camera / vision system.
    /// </summary>
    
    public interface ICameraService
    {
        /// <summary>
        /// Uploads a job file to a camera.
        /// </summary>
        /// <param name="filePath">Constains the path to the job file in the computer.</param>
        public void UploadJob(string filePath, string fileName);

        /// <summary>
        /// Loads the uploaded job file in the camera, and set it as the using job file.
        /// </summary>
        /// <param name="fileName">Constains the name of the uploaded job file.</param>
        public void LoadJob(string fileName);

        /// <summary>
        /// Triggers the manual capturing of an image.
        /// </summary>
        /// <returns>A camera object, that will be used to access analysis results.</returns>
        public dynamic TriggerImageCapture();
    }
}