using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoFire.Service
{
    public class ScanAndFire
    {
        public const int SpamFilterIntervalMS = 500;
        
        public Action<string> ServiceLog { get; set; }
        private int actionCount = 0;
        private uint lastColor = 0;
        private AutoHotkey.Interop.AutoHotkeyEngine ahk;
        private SortedList<uint, DateTime> lastKeys;

        public ScanAndFire()
        {
            lastKeys = new SortedList<uint, DateTime>();
            ahk = new AutoHotkey.Interop.AutoHotkeyEngine();
            ahk.ExecRaw("CoordMode, ToolTip, Screen");
            ahk.ExecRaw("CoordMode, Pixel, Screen");
            ahk.ExecRaw("CoordMode, Mouse, Screen");
            ahk.ExecRaw("CoordMode, Caret, Screen");
            ahk.ExecRaw("CoordMode, Menu, Screen");
            Task.Run(new Action(RunService));
        }
        private void Print(string text)
        {
            if (ServiceLog != null)
            {
                ServiceLog(text);
            }
        }

        private void RunService()
        {
            while (true)
            {

                ahk.ExecRaw("state:= GetKeyState(\"Capslock\", \"T\")");
                bool capsOn = (ahk.GetVar("state") == "1");

                if (capsOn)
                {
                    ServiceLoop();
                    Thread.Sleep(50);
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }

        //"0x0A0006"
        private void ServiceLoop()
        {
            actionCount++;
            ahk.ExecRaw("PixelGetColor, color,  3, 3 ");
            string color = ahk.GetVar("color");
            uint colorNumber = Convert.ToUInt32(color, 16);
            uint action = (colorNumber & 0xFF0000)>>16;

            ///uint notUsed = (colorNumber & 0x00FF00) >> 8;

            uint ctrldown = (colorNumber & 0x000001);
            uint altdown = (colorNumber & 0x000002);
            uint shiftdown = (colorNumber & 0x000004);
            uint noRepeat = (colorNumber & 0x000008);
            uint fdown = (colorNumber & 0x000010);
            string actionStr;

            if (action > 14 || action < 1)
            {
                Print(string.Format("\n{0}:Invalid Acction {1} color {2}`n", actionCount, action, color));
                ahk.ExecRaw("SetCapsLockState , off");
                return;
            }
            if(action == 13)
            {
                return;
            }
            if (action == 14)
            {
                ahk.ExecRaw("MouseClick, left");
                return;
            }
            DateTime now = DateTime.Now;

            if (CheckSpam(colorNumber, now)){return;}
            if(noRepeat > 0 && lastColor == colorNumber) { return; }
            
            
            actionStr = GetActionString(action, shiftdown, altdown, ctrldown, fdown);
            ahk.ExecRaw("Send " + actionStr);
            Print(string.Format("\n {0}: {1}: {2}: {3}", 
                actionCount,
                (lastColor == colorNumber)? "Repeat":"",
                now.ToString("hh:mm:ss.fff"), 
                actionStr));
            lastColor = colorNumber;
        }

        private bool CheckSpam(uint colorNumber, DateTime now)
        {
            int keyIndex = lastKeys.IndexOfKey(colorNumber);
            if(keyIndex >= 0)
            {
                DateTime previousKeyTime = lastKeys.Values[keyIndex];
                if (now.Subtract(previousKeyTime).Milliseconds < SpamFilterIntervalMS)
                {
                    return true;
                }
                else
                {
                    //lastKeys.Values[keyIndex] = now;
                    lastKeys[colorNumber] = now;
                    return false;
                }
            }
            else
            {
                lastKeys.Add(colorNumber, now);
                return false;
            }
        }

        private string GetActionString(uint action, uint shiftdown, uint altdown, uint ctrldown, uint fdown)
        {
            string actionStr = "";
            if (shiftdown > 0)
            {
                actionStr += "+";
            }
            if (altdown > 0)
            {
                actionStr += "!";
            }
            if (ctrldown > 0)
            {
                actionStr += "^";
            }

            if (fdown > 0)
            {
                actionStr += "{F" + action + "}";
                return actionStr;
            }


            if (action < 10)
            {
                actionStr += action;
            }
            else if (action == 10)
            {
                actionStr += "0";
            }
            else if (action == 11)
            {
                actionStr += "-";
            }
            else if (action == 12)
            {
                actionStr += "=";
            }
            return actionStr;
        }
    }
}
