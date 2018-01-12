using AhkWrapper.AHKFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBot1.Action.AuctionHouse.In
{
    abstract class InAuctionHouse:Action
    {
        protected Point SlotSearchLeftTop { get; private set; }
        protected Point SlotSearchRightBottom {get; private set;}


        public InAuctionHouse()
        {
            SlotSearchLeftTop = new Point(187, 235);
            SlotSearchRightBottom = new Point(800, 510);
        }
    }
}
