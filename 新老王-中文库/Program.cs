namespace 老王_基础菜单汉化
{
    using EloBuddy.SDK.Events;

    using System;
    using System.IO;
    using System.Reflection;
    using Version = System.Version;
    using EloBuddy.SDK.Rendering;
    using SharpDX;
    using EloBuddy.SDK;
    using EloBuddy.SDK.Notifications;
    using System.Threading.Tasks;
    using SharpDX.Direct3D9;
    using Color = System.Drawing.Color;
    using Line = EloBuddy.SDK.Rendering.Line;
    using System.Drawing;
    using EloBuddy;

    internal class Program
    {
        private static readonly string getAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static readonly string dllpath = Path.Combine(getAppDataPath, @"EloBuddy\Addons\Libraries\Lwan_VIPzw.dll");

        private static void Main(string[] args)
        {
            Drawing.OnEndScene += Drawing_OnDraw;
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
































































































































































































































































































































































































        private static void Drawing_OnDraw(EventArgs args)
        {
            if (!Loading.IsLoadingComplete)
            {
                Line.DrawLine(Color.DeepSkyBlue, 50, new Vector2(0, Drawing.Height / 2.00f), new Vector2(Drawing.Width, Drawing.Height / 2.00f));
                Drawing.DrawText(Drawing.Width / 3.5f, Drawing.Height / 2.01f, System.Drawing.Color.Black, "新老王-自用系列     交流群：579047511，入会100，即可享受最全面的自用系列，欢迎你的加入!", 38);
            }
        }
    }
}

