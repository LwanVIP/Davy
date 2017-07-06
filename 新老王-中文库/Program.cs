namespace 老王_基础菜单汉化
{
    using EloBuddy.SDK.Events;

    using System;
    using System.IO;
    using System.Reflection;

    internal class Program
    {
        private static readonly string getAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static readonly string dllpath = Path.Combine(getAppDataPath, @"EloBuddy\Addons\Libraries\Lwan_VIPzw.dll");

        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += eventArgs =>
            {
                if (File.Exists(dllpath))
                {
                    File.Delete(dllpath);
                }

                var prdll = Properties.Resources.Lwan_VIPzw;
                using (var fs = new FileStream(dllpath, FileMode.Create))
                {
                    fs.Write(prdll, 0, prdll.Length);
                }

                var a = Assembly.LoadFrom(dllpath);
                var myType = a.GetType("Lwan_VIPzw.Program");
                var main = myType.GetMethod("Main", BindingFlags.Public| BindingFlags.Static);

                main.Invoke(null, null);
            };
        }
    }
}
