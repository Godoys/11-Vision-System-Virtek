using System.Net;
using _11_Vision_System_Virtek.Domain.Entities;
using _11_Vision_System_Virtek.Domain.Enums;

namespace _11_Vision_System_Virtek.Domain.Interfaces
{
    /// <summary>
    /// Orchestrates services related to external camera systems.
    /// </summary>
    
    public interface ISensorService
    {
        /// <summary>
        /// Triggers the camera to capture an image and performs analysis of the image.
        /// </summary>
        /// <returns>The result status of the most recent image analysis.</returns>
        public Task<SensorResultStatus> GetLastAnalysisResultAsync();
    }
}