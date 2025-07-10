using System.Net;
using _11_Vision_System_Virtek.Domain.Enums;
using _11_Vision_System_Virtek.Domain.Entities;

namespace _11_Vision_System_Virtek.Domain.Interfaces
{
    /// <summary>
    /// Controls a sensor: connects/disconnects, triggers image capture, retrieves image analysis result.
    /// </summary>
    public interface ISensor
    {
        public SensorConfig Config { get; }

        /// <summary>
        /// Establishes a connection with the sensor.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public Task ConnectAsync();
        
        /// <summary>
        /// Closes the connection with the sensor.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public Task DisconnectAsync();
        
        /// <summary>
        /// Triggers an image capture.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public Task TriggerImageCaptureAsync();

        /// <summary>
        /// Retrieves the result of the last image analysis.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public Task GetAnalysisResultAsync();
    }
}