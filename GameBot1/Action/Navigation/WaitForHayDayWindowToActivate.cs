using AhkWrapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameBot1.Action.Navigation
{
    class WaitForHayDayWindowToActivate : Navigation 
    {
        internal override bool CheckPreconditions()
        {
            return true;
        }
        internal override void Execute(StreamWriter fs)
        {
            //WinWait, BlueStacks App Player, 
            //IfWinNotActive, BlueStacks App Player, , WinActivate, BlueStacks App Player, 
            //WinWaitActive, BlueStacks App Player, 
            AutoHotkey.ExecSimple(@"WinWait, BlueStacks App Player, ");
            AutoHotkey.ExecSimple(@"IfWinNotActive, BlueStacks App Player, , WinActivate, BlueStacks App Player, ");
            AutoHotkey.ExecSimple(@"WinWaitActive, BlueStacks App Player, ");
        }
    }
}
