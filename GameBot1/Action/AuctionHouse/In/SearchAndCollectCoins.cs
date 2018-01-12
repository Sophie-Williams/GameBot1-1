using AhkWrapper.AHKFunctions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameBot1.Action.AuctionHouse.In.Repeatable
{
    class SearchAndCollectCoins : InAuctionHouse
    {
        internal override bool CheckPreconditions()
        {
            return true;
        }

        internal override void Execute(StreamWriter fs)
        {
            Point serchPoint;
            while ((serchPoint = SearchSlotPoint()).X != Point.Error.X)
            {
                CommandList.MouseClick(serchPoint);
                CommandList.Sleep(1000);
            }
        }

        private Point SearchSlotPoint()
        {
            Point serchPoint;
            serchPoint = CommandList.ImageSearch(
                            @"C:\Users\Achu\Pictures\SoldAuctionSlot2.png"
                            , 100
                            , this.SlotSearchLeftTop, this.SlotSearchRightBottom);
            return serchPoint;
        }
    }
}
