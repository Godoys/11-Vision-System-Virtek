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
        /// <param name="filePath">System path to the Job file.</param>
        public void LoadJobAsync(string filePath);
        
        /// <summary>
        /// Gets the result status of the image analysis done by a camera and raises an event based on the result status.
        /// </summary>
        public void GetImageResultAsync();
    }
}