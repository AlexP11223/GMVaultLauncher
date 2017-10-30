using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMVaultLauncher.Helpers;

namespace GMVaultLauncher
{
    public class Launcher
    {
        public string LogDir { get; }
        public string LogFilePath { get; }

        private readonly string _appPath;

        private readonly string[] _cmdArgs;

        public Launcher(string appPath, string[] cmdArgs, string logDir)
        {
            _cmdArgs = cmdArgs;
            _appPath = appPath;
            LogDir = logDir;
            LogFilePath = LogDir + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss", CultureInfo.InvariantCulture) + ".txt";
        }

        public void Launch()
        {
            FileHelper.CreateDirectoryIfNotExist(LogDir);

            try
            {
                var output = Run(_appPath, _cmdArgs);
                AppendLog(output);
            }
            catch (Exception ex)
            {
                AppendLog(ex.ToString());
            }
        }

        private static string Run(string app, string[] args)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = app,
                    Arguments = String.Join(" ", args.Select(arg => arg.Contains(' ') ? $"\"{arg}\"" : arg)),

                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Minimized,

                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                }
            };

            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            string err = process.StandardError.ReadToEnd();

            process.WaitForExit(TimeSpan.FromHours(8).Milliseconds);

            return output + Environment.NewLine + err;
        }

        private void AppendLog(string text)
        {
            File.AppendAllText(LogFilePath, text + Environment.NewLine);
        }
    }
}
