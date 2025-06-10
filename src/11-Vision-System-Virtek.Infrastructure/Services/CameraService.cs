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
        
        /// <summary>
        /// Uploads a Job file to a camera, then load it as the current job being used.
        /// </summary>
        /// <param name="filePath">File path to the Job file.</param>
        /// <param name="fileName">File name of the Job file.</param>
        public async Task LoadJobAsync(string filePath, string fileName)
        {
            // Uploads the job file to the camera.
            await _camera.UploadJob(filePath, fileName);
            
            // Loads the job file and set it as the default for image analysis.
            await _camera.LoadJob(fileName);
        }

        /// <summary>
        /// Gets the result status of the image analysis done by a camera and raises an event based on the result status.
        /// </summary>
        /// <returns>The result status of the most recent image analysis.</returns>
        public async Task<ResultStatus> GetImageResultAsync()
        {
            // Triggers an image capture.
            await _camera.TriggerImageCapture();
            
            // Updates the result variable of camera.
            await _camera.GetResult();
            
            // Gets the result status from the camera and return it.
            return _camera.Result;
        }
        
        // --------------------------------
        //   Private Methods Declaration
        // --------------------------------
    }
}