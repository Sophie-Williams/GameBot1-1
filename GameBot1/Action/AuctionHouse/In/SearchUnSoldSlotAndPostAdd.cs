using AhkWrapper.AHKFunctions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameBot1.Action.AuctionHouse.In
{
    class SearchUnSoldSlotAndPostAdd:InAuctionHouse
    {

        //401, 435
        internal override bool CheckPreconditions()
        {
            return true;
        }

        internal override void Execute(StreamWriter fs)
        {
            Point serchPoint;
            if ((serchPoint = SearchSlotPoint()).X != Point.Error.X)
            {
                CommandList.MouseClick(serchPoint);
                CommandList.Sleep(200);
                if(CheckAddAvailable())
                {
                    CommandList.MouseClick(new Point(495, 400));
                }
                else
                {
                    CommandList.MouseClick(new Point(597, 152));
                }
                CommandList.Sleep(1000);//sleep 1000 ;wait for the add dialog to close
            }
        }

        private bool CheckAddAvailable()
        {
            Point r = CommandList.ImageSearch(
                @"C:\Users\Achu\Pictures\AddAvailable.png"
                , 10, new Point(500, 250), new Point(590, 360));
            return r.X != Point.Error.X;
        }

        private Point SearchSlotPoint()
        {
            Point serchPoint;
            serchPoint = CommandList.ImageSearch(
                            @"C:\Users\Achu\Pictures\UnSoldAuctionSlot.png"
                            , 120
                            , this.SlotSearchLeftTop, this.SlotSearchRightBottom);
            return serchPoint;
        }
    }
}
