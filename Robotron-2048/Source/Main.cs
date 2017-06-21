using System;

namespace Robotron_2048.Source
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new RobotronGame())
                game.Run();
        }
    }
}
