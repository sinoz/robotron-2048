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
        /// The title of the application.
        /// </summary>
        public const string ApplicationTitle = "Robotron: 2084";

        /// <summary>
        /// The set resolution of the application.
        /// </summary>
        public static int appWidth, appHeight;

        /// <summary>
        /// The device type.
        /// </summary>
        public static DeviceType deviceType;
    }
}
