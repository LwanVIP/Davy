namespace 新老王_自用系列
{
    using EloBuddy.SDK.Events;

    using System;
    using System.IO;
    using System.Reflection;

    internal class Program
    {
        private static readonly string getAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static readonly string dllPath = Path.Combine(getAppDataPath, @"EloBuddy\Addons\Libraries\Lwan_MoonEvade.dll");

        private static void Main(string[] eventArgs)
        {
            Loading.OnLoadingComplete += Args =>
            {
                if (File.Exists(dllPath))
                {
                    File.Delete(dllPath);
                }

                //Add the Version check later

                var prdll = Properties.Resources.Lwan_MoonEvade;
                using (var fs = new FileStream(dllPath, FileMode.Create))
                {
                    fs.Write(prdll, 0, prdll.Length);
                }

                var dllpath = Assembly.LoadFrom(dllPath);
                var main = dllpath.GetType("Moon_Walk_Evade.Program").GetMethod("Main");
                main.Invoke(null, null);
            };
        }
    }
}