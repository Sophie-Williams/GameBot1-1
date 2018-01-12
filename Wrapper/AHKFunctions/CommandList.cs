using AhkWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhkWrapper.AHKFunctions
{


    public static class CommandList
    {
        public static void MouseClick(Point p)
        {
            AutoHotkey.ExecSimple(string.Format("mousemove {0}, {1} ", p.X, p.Y));
            AutoHotkey.ExecSimple("sleep 100 ");
            AutoHotkey.ExecSimple(string.Format("click {0}, {1} ", p.X, p.Y));
        }



        public static void Sleep(int milSec)
        {
            AutoHotkey.ExecSimple(string.Format("sleep {0} ", milSec));
        }


        public static Point ImageSearch(string image, int intensityVariation, Point p1, Point p2)
        {
            AutoHotkey.SetVar("OutputVarX", "0");
            AutoHotkey.SetVar("OutputVarY", "0");
            AutoHotkey.ExecSimple(
                string.Format("ImageSearch OutputVarX, OutputVarY, {0}, {1}, {2}, {3}, *{4} {5} ",
                p1.X, p1.Y, p2.X, p2.Y, intensityVariation, image));
            int erroLevel = -1;
            int.TryParse(AutoHotkey.GetVar("ErrorLevel"), out erroLevel);
            if (erroLevel == 1)
            {
                return Point.Error;
            }
            else
            {
                return new Point(int.Parse(AutoHotkey.GetVar("OutputVarX")), int.Parse(AutoHotkey.GetVar("OutputVarY")));
            }
        }




        public static void MouseDrag(Point p1, Point p2)
        {
            BeginMouseDrag(p1);
            AutoHotkey.ExecSimple(string.Format("mousemove {0}, {1}, 50 ", p2.X, p2.Y));
            AutoHotkey.ExecSimple("sleep 1000 ");
            AutoHotkey.ExecSimple("click up ");

        }
        public static void MouseDrag(Point p, int xDirection, int yDirection)
        {
            MouseDrag(p, new Point(p.X + xDirection, p.Y + yDirection));
        }

        public static void BeginMouseDrag(Point p1, params Point[] points)
        {

            AutoHotkey.ExecSimple(string.Format("mousemove {0}, {1} ", p1.X, p1.Y));
            AutoHotkey.ExecSimple("sleep 50 ");
            AutoHotkey.ExecSimple("click down ");
            AutoHotkey.ExecSimple("sleep 50 ");
            ContinueDrag(points);
        }

        public static void ContinueDrag(params Point[] points)
        {
            foreach (Point p in points)
            {
                AutoHotkey.ExecSimple(string.Format("mousemove {0}, {1}, 2 ", p.X, p.Y));
            }
        }

        public static void Send(string actionStr)
        {
            AutoHotkey.ExecSimple("Send "+ actionStr);
        }

        public static void EndDrag()
        {
            AutoHotkey.ExecSimple("click up ");
        }

        public static string GetColour(Point point)
        {
            AutoHotkey.ExecSimple(string.Format("PixelGetColor, color, {0},  {1} ", point.X, point.Y));
            string ret = AutoHotkey.GetVar("color");
            return ret;
        }
    }
}
