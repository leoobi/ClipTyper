namespace TypeClipboard
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
            Form f = MainPaster.GetInstance();
            Application.Run(f);
        }
    }
}