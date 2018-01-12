using AhkWrapper.AHKFunctions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameBot1.Action.Navigation
{
    class GotoHomePosition : Navigation 
    {
        const int x1 = 90, y1=90;
        protected int Distance;

        public GotoHomePosition(int distance)
        {
            this.Distance = distance;
        }

        internal override bool CheckPreconditions()
        {
            return true;
        }

        internal override void Execute(StreamWriter fs)
        {
            for (int i = 0; i < Distance; i++)
            {
                CommandList.MouseDrag(new Point(x1, y1), Point.Max);
            }
            CommandList.Sleep(1000);
        }


    }
}
