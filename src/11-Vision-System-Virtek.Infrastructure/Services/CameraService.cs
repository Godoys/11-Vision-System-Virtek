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
    public class CameraService : ICameraService
    {
        private readonly ICamera _camera;

        public CameraService(ICamera camera)
        {
            _camera = camera;
        }
        
        // --------------------------------
        //    Public Methods Declaration
        // --------------------------------
        
        public async Task UploadAndLoadJobAsync(string filePath, string fileName)
        {
            // Uploads the job file to the camera.
            await _camera.UploadJobAsync(filePath, fileName);
            
            // Loads the job file and set it as the default for image analysis.
            await _camera.LoadJobAsync(fileName);
        }
        
        public async Task<ResultStatus> GetLastAnalysisResultAsync()
        {
            // Triggers an image capture.
            await _camera.TriggerImageCaptureAsync();
            
            // Updates the result variable of camera.
            await _camera.GetAnalysisResultAsync();

            // Delays 1s for image result analysis gets updated.
            await Task.Delay(1000);
            
            // Gets the result status from the camera and return it.
            return _camera.LastAnalysisResult;
        }
        
        // --------------------------------
        //   Private Methods Declaration
        // --------------------------------
    }
}