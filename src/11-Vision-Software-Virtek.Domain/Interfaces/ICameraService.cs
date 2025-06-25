using System.Net;
using _11_Vision_System_Virtek.Domain.Entities;
using _11_Vision_System_Virtek.Domain.Enums;

namespace _11_Vision_System_Virtek.Domain.Interfaces
{
    /// <summary>
    /// Orchestrates services related to external camera systems.
    /// </summary>
    
    public interface ICameraService
    {
        /// <summary>
        /// Uploads a Job file and activates it for analysis.
        /// </summary>
        /// <param name="filePath">Local path to the Job file.</param>
        /// <param name="fileName">Name for the Job file on the camera.</param>
        public Task UploadAndLoadJobAsync(string filePath, string fileName);
        
        /// <summary>
        /// Triggers the camera to capture an image and performs analysis of the image.
        /// </summary>
        /// <returns>The result status of the most recent image analysis.</returns>
        public Task<ResultStatus> GetLastAnalysisResultAsync();
    }
}