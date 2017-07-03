using System;

namespace DesktopGL
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class DesktopLauncher
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new DesktopGame())
                game.Run();
        }
    }
}
