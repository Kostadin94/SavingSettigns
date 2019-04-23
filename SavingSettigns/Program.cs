using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace SavingSettigns
{
    class Program
    {
        private static LoginWindow lWindow;
        public static MainWindow mWindow;

        public static int reinit = 0;
        public static User user;
        public static Settings settings;
        internal static Application app;
        [System.STAThreadAttribute()]
        static void Main(string[] args)
        {
            Logger.WriteToFile("Program: Program started");
            RunProgram();
        }



        /// <summary>
        /// Starts the main program
        /// </summary>
        static void RunProgram()
        {
            app = new Application();
            app.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            Logger.WriteToFile("Program: Application initialized");

            lWindow = new LoginWindow();
            lWindow.Closed += new EventHandler(lWindow_Closed);

            Logger.WriteToFile("Program: Login window displayed");
            app.Run(lWindow);
        }

        private static void lWindow_Closed(object sender, EventArgs e)
        {
            if (user != null)
            {
                mWindow = new MainWindow();
                settings = new Settings(user.Username + "Settings.xml");
                settings.Init();
                mWindow.Closed += new EventHandler(MainWindow_Closed);
                mWindow.Show();
                Logger.WriteToFile("Program: Main window displayed");
            }
            else
            {
                Logger.WriteToFile("Program: Application closing");
                app.Shutdown();
            }
        }
        private static void MainWindow_Closed(object sender, EventArgs e)
        {
            if (reinit == 1)
            {
                reinit = 0;
                user = null;
                Logger.WriteToFile("Program: Returning to login window");
                lWindow = new LoginWindow();
                lWindow.Closed += lWindow_Closed;
                lWindow.Show();
            }
            else
            {
                Logger.WriteToFile("Program: Application closing");
                app.Shutdown();
            }
        }

    }
}
