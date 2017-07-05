using System;
using System.IO;
using System.Reflection;
using EloBuddy.SDK.Events;

namespace UB_AIO
{
    class Program
    {
        private static readonly string getAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static readonly string dllPath = Path.Combine(getAppDataPath, @"EloBuddy\Addons\Libraries\Lwan_VIPSeries1.dll");

        private static void Main(string[] eventArgs)
        {
            Loading.OnLoadingComplete += Args =>
            {
                if (File.Exists(dllPath))
                {
                    File.Delete(dllPath);
                }

                var prdll = Properties.Resource.Lwan_VIPSeries1;
                using (var fs = new FileStream(dllPath, FileMode.Create))
                {
                    fs.Write(prdll, 0, prdll.Length);
                }
                var dllfile = Assembly.LoadFrom(dllPath);
                var type = dllfile.GetType("Lwan_VIPSeries1.dhy");
                var main = type.GetMethod("Main");
                main.Invoke(null, null /*new object[] { new string[] { } }*/);
            };
        }
    }
}
