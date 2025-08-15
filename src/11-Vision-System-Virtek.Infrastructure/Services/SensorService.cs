using _11_Vision_System_Virtek.Domain.Enums;
using _11_Vision_System_Virtek.Domain.Interfaces;

namespace _11_Vision_System_Virtek.Infrastructure.Services
{
    /// <summary>
    /// Handles end-to-end flow: upload a job, trigger image capture, fetch result and wrap into domain outcomes.
    /// </summary>
    public class SensorService(ISensor sensor) : ISensorService
    {
        private readonly ISensor _sensor = sensor;
        
        // -------------------------------
        //  Public Methods Implementation
        // -------------------------------
        
        public async Task<SensorResultStatus> GetLastAnalysisResultAsync()
        {
            // Triggers an image capture.
            await _sensor.TriggerImageCaptureAsync();
            
            // 500 milliseconds delay to wait for Config.LastAnalysisResult to be updated.
            await Task.Delay(500);
            
            // Gets the result status from the camera and return it.
            return _sensor.Config.LastSensorResult;
        }
    }
}