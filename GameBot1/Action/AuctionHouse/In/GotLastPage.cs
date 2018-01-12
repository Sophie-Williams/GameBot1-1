using AhkWrapper.AHKFunctions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameBot1.Action.AuctionHouse.In
{
    class GotLastPage:InAuctionHouse
    {
        internal override bool CheckPreconditions()
        {
            return true;
        }

        internal override void Execute(StreamWriter fs)
        {
            CommandList.MouseDrag(new Point(741, 367), new Point(207, 367));
            CommandList.MouseDrag(new Point(741, 367), new Point(207, 367));
            CommandList.MouseDrag(new Point(741, 367), new Point(207, 367));
            CommandList.Sleep(2000);
        }
    }
}
