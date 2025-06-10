using System.Net;
using _11_Vision_System_Virtek.Domain.Entities;
using _11_Vision_System_Virtek.Domain.Enums;

namespace _11_Vision_System_Virtek.Domain.Interfaces
{
    /// <summary>
    /// Interface to communicate with external camera / vision system.
    /// </summary>
    
    public interface ICameraService
    {
        /// <summary>
        /// Uploads a Job file to a camera, then load it as the current job being used.
        /// </summary>
        /// <param name="filePath">File path to the Job file.</param>
        /// <param name="fileName">File name of the Job file.</param>
        public Task LoadJobAsync(string filePath, string fileName);
        
        /// <summary>
        /// Gets the result status of the image analysis done by a camera and raises an event based on the result status.
        /// </summary>
        /// <returns>The result status of the most recent image analysis.</returns>
        public Task<ResultStatus> GetImageResultAsync();
    }
}