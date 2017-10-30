using System;
using System.Diagnostics;
using System.Linq;

namespace GMVaultLauncher
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length < 2)
            {
                string appName = Process.GetCurrentProcess().ProcessName;
                Console.WriteLine($"Usage: {appName} app_path log_dir args");
                Console.WriteLine($@"Example: {appName} gmvault.bat logs\ sync -t quick name@gmail.com -e");
                return 1;
            }

            new Launcher(args[0], args.Skip(2).ToArray(), args[1]).Launch();

            return 0;
        }
    }
}
