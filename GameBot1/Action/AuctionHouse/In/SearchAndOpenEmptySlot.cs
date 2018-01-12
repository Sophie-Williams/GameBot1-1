using AhkWrapper.AHKFunctions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameBot1.Action.AuctionHouse.In.Repeatable
{
    class SearchAndOpenEmptySlot : InAuctionHouse
    {
        internal SearchAndOpenEmptySlot Add(InSlot.InSlot a)
        {
            Children.Add(a);
            return this;
        }

        internal override bool CheckPreconditions()
        {
            return !FarmQuantities.SiloQuantities.WheetQuantityIsEmpty;
        }

        internal override void Execute(StreamWriter fs)
        {
            Point serchPoint;
            if ((serchPoint = SearchSlotPoint()).X != Point.Error.X)
            {
                CommandList.MouseClick(serchPoint);
                CommandList.Sleep(2000);
                this.Repeat = true;
                this.ContinueExecuteChildren = true;
            }
            else
            {
                this.Repeat = false;
                this.ContinueExecuteChildren = false;
            }
        }

        private Point SearchSlotPoint()
        {
            Point serchPoint;
            serchPoint = CommandList.ImageSearch(
                            @"C:\Users\Achu\Pictures\FreeAuctionSlot.png"
                            , 75
                            , this.SlotSearchLeftTop, this.SlotSearchRightBottom);
            return serchPoint;
        }
    }
}
