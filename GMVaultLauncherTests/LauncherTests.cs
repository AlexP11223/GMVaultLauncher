using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GMVaultLauncher;
using GMVaultLauncher.Helpers;
using Xunit;

namespace GMVaultLauncherTests
{
    public class LauncherTests : IDisposable
    {
        public static readonly string AppDir = AppDomain.CurrentDomain.BaseDirectory + @"\";
        public static readonly string LogDir = AppDir + @"logs\";

        [Fact]
        public void WritesLog()
        {
            var launcher = new Launcher(LogDir, "ping", new[] {"......."});
            launcher.Launch();

            Assert.True(File.Exists(launcher.LogFilePath));
            Assert.Contains(".....", File.ReadAllText(launcher.LogFilePath));
        }

        [Fact]
        public void WritesLogOnError()
        {
            var launcher = new Launcher(LogDir, "not-exists", new[] {""});
            launcher.Launch();

            Assert.True(File.Exists(launcher.LogFilePath));
            Assert.Contains("Exception", File.ReadAllText(launcher.LogFilePath));
        }

        [Fact]
        public void WritesStderrToLog()
        {
            var launcher = new Launcher(LogDir, AppDir + "stderr.bat", new[] {""});
            launcher.Launch();

            Assert.Contains("stdout message", File.ReadAllText(launcher.LogFilePath));
            Assert.Contains("stderr message", File.ReadAllText(launcher.LogFilePath));
        }

        public void Dispose()
        {
            if (Directory.Exists(LogDir))
            {
                FileHelper.DeleteDirWithFiles(LogDir);
            }
        }
    }
}
