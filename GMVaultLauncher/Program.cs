namespace GMVaultLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            new Launcher(@"C:\Users\Alex\AppData\Local\gmvault\gmvault.bat", args, @"C:\Users\Alex\GDrive\Backup\gmvault\logs\").Launch();
        }
    }
}
