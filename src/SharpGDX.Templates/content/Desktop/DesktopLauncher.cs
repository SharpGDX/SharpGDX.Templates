using SharpGDX.Desktop;

namespace Desktop
{
    /// <summary>
    ///     Launches the desktop application.
    /// </summary>
    internal class DesktopLauncher
    {
        public static void Main(string[] args)
        {
            CreateApplication();
        }

        private static void CreateApplication()
        {
            _ = new DesktopApplication(new Main(), GetDefaultConfiguration());
        }

        private static DesktopApplicationConfiguration GetDefaultConfiguration()
        {
            var configuration = new DesktopApplicationConfiguration();

            configuration.SetTitle("YourProjectName");

            // Vsync limits the frames per second to what your hardware can display, and helps eliminate
            // screen tearing. This setting doesn't always work on Linux, so the line after is a safeguard.
            configuration.UseVsync(true);

            // Limits FPS to the refresh rate of the currently active monitor, plus 1 to try to match fractional
            // refresh rates. The Vsync setting above should limit the actual FPS to match the monitor.
            configuration.SetForegroundFPS(DesktopApplicationConfiguration.GetDisplayMode().RefreshRate + 1);

            // If you remove the above line and set Vsync to false, you can get unlimited FPS, which can be
            // useful for testing performance, but can also be very stressful to some hardware.
            // You may also need to configure GPU drivers to fully disable Vsync; this can cause screen tearing.
            configuration.SetWindowedMode(640, 480);

            // You can change these files; they are in Desktop/src/main/resources/ .
            configuration.SetWindowIcon("SharpGDX128.png", "SharpGDX64.png", "SharpGDX32.png", "SharpGDX16.png");

            return configuration;
        }
    }
}