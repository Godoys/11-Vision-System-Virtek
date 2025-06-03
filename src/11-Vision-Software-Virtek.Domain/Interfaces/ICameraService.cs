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
        /// Connects to a camera / vision system.
        /// </summary>
        /// <param name="forceConnect">When true, will break an existing connection and connect; False, will prohibit a connection if one already exists</param>
        /// <param name="asynchronous">When true, will return without waiting for the connection to be complete; False, will wait for connection to complete</param>
        public void Connect(bool forceConnect = false, bool asynchronous = false);
    }
}