using AhkWrapper.AHKFunctions;
using GameBot1.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameBot1.Action.AuctionHouse.In
{
    class CloseAuctionHouse:InAuctionHouse
    {
        internal override bool CheckPreconditions()
        {
            return true;
        }

        internal override void Execute(StreamWriter fs)
        {
            Point p = CommandList.ImageSearch(@"C:\Users\Achu\Pictures\CloseAuctionHouse.png"
                , 10
                , new Point(868 - 70, 121 - 70)
                , new Point(868 + 70, 121 + 70));
            if (p.X == Point.Error.X)
            {
                throw new InvalidStateException("Cant find Auction house close button");
            }
            CommandList.MouseClick(p);
        }
    }
}
