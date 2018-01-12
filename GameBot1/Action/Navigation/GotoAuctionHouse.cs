using GameBot1.Action.AuctionHouse.At;
using AhkWrapper.AHKFunctions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBot1.Action.Navigation
{
    class GotoAuctionHouse : Navigation
    {
        public GotoAuctionHouse Add(AtAuctionHouse a) 
        {
            Children.Add(a);
            return this; 
        }

        internal override void Execute(StreamWriter fs)
        {
            CommandList.MouseDrag(new Point(375, 394), new Point(462, 114));
            CommandList.MouseDrag(new Point(166, 416), new Point(218, 35));
            CommandList.MouseDrag(new Point(243, 581), new Point(109, 186));

        }
    }
}
