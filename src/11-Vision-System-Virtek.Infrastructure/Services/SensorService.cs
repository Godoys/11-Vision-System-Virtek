using System.Net;
using _11_Vision_System_Virtek.Domain.Entities;
using _11_Vision_System_Virtek.Domain.Enums;
using _11_Vision_System_Virtek.Domain.Interfaces;
using Cognex.InSight;
using Cognex.InSight.Ftp;
using Cognex.InSight.NativeMode;
using System.Text.RegularExpressions;

namespace _11_Vision_System_Virtek.Infrastructure.Services
{
    /// <summary>
    /// Handles end-to-end flow: upload a job, trigger image capture, fetch result and wrap into domain outcomes.
    /// </summary>
    public class SensorService : ISensorService
    {
        private readonly ISensor _sensor;
        
        // -------------------------------
        //  Public Methods Implementation
        // -------------------------------

        public SensorService(ISensor sensor) => _sensor = sensor;
        
        public async Task<ResultStatus> GetLastAnalysisResultAsync()
        {
            // Triggers an image capture.
            await _sensor.TriggerImageCaptureAsync();
            
            // Updates the result variable of camera.
            await _sensor.GetAnalysisResultAsync();
            
            // Gets the result status from the camera and return it.
            return _sensor.Config.LastResult;
        }
    }
}