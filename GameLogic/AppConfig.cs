using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    /// <summary>
    /// Contains configuration data related to the application.
    /// </summary>
    public sealed class AppConfig
    {
        /// <summary>
        /// The set resolution of the application.
        /// </summary>
        public static int appWidth, appHeight;

        /// <summary>
        /// The device type.
        /// </summary>
        public static DeviceType deviceType;
    }

    /// <summary>
    /// The type of device.
    /// </summary>
    public enum DeviceType
    {
        Android, Desktop
    }
}
