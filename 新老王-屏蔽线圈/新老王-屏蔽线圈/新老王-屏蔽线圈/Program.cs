using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using SharpDX;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;

namespace Drawings_EloBuddy
{
     class Program
    {
        public bool disabledraw
        {
            get { return _setting["disab"].Cast<KeyBind>().CurrentValue; }
        }
        public static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Game_OnGameLoad;
            Game.OnTick += Game_OnTick;
        }

        public static Menu _menu, _setting;
        public static void Game_OnGameLoad(EventArgs args)
        {
            Chat.Print("Degzer Disable Drawings, Activated!");
            _menu = MainMenu.AddMenu("新老王-屏蔽线圈", "新老王-屏蔽线圈");
            _menu.AddGroupLabel("简介");
            _menu.AddLabel("这是一款可以关闭线圈的插件");
            _menu.AddLabel("这款插件可让线圈全部关闭，实现增加FPS");
            _menu.AddGroupLabel("如果你喜欢我的汉化，可以加入VIP及时享受最新汉化脚本");
            _menu.AddGroupLabel("入会价格：老王汉化/98.88   花边自写/450");
            _menu.AddGroupLabel("入会包入会资格以及调试注入，让你花一次钱就准备玩就好了");
            _menu.AddGroupLabel("游戏账号，远程安装调试服务，让你体会下一条龙服务");
            _menu.AddGroupLabel("老王QQ：228124423");
            _menu.AddGroupLabel("老王VIP群：579047511");
            _menu.AddGroupLabel("感谢你得使用!");
            _menu.AddSeparator();

            _setting = _menu.AddSubMenu("新老王-屏蔽线圈设置", "settings");
            _setting.AddGroupLabel("说明");
            _setting.AddLabel("请在下方修改自己的按键，实现手动关闭线圈");
            _setting.AddGroupLabel("基本设置");
            _setting.AddLabel("按键设置");
            _setting.Add("disab", new KeyBind("屏蔽线圈-按键", false, KeyBind.BindTypes.PressToggle, '-'));
        }
        public static void Game_OnTick(EventArgs args)
        {
            try
            {
                if (_setting["disab"].Cast<KeyBind>().CurrentValue == true)
                {
                    Hacks.DisableDrawings = true;
                    Hacks.DisableTextures = true;
                }
                if (_setting["disab"].Cast<KeyBind>().CurrentValue == false)
                {
                    Hacks.DisableTextures = false;
                    Hacks.DisableDrawings = false;
                }
            }
            catch
            {
                //nothing
            }
        }


    }
}
