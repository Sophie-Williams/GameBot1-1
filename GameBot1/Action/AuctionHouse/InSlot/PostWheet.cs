using AhkWrapper.AHKFunctions;
using GameBot1.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameBot1.Action.AuctionHouse.InSlot
{
    class PostWheet : InSlot
    {
        
        internal override bool CheckPreconditions()
        {
            string colour = CommandList.GetColour(new Point(295, 210));

            if (colour.Equals("0x05DEFC")) {
                return true;
            }
            else
            {
               FarmQuantities.SiloQuantities.WheetQuantityIsEmpty = true;//Wheet is not on the top of the list
               CloseAuctionPostItemWindow();
               return false;
            }
        }

        private void CloseAuctionPostItemWindow()
        {
            Point p1 = new Point( 722 -70, 143 -70);        
            Point p2 = new Point( 722 +70, 143 +70);

            Point r = CommandList.ImageSearch(@"C:\Users\Achu\Pictures\CloseAuctionPostWindow.png"
                , 10, p1, p2);
            if (r.X == Point.Error.X) { throw new InvalidStateException("Can't Find the  post Auction dialog close button"); }

            CommandList.MouseClick(r);
            CommandList.Sleep(2000);
        }

        internal override void Execute(StreamWriter fs)
        {
            CommandList.MouseClick(new Point(295, 215));
            CommandList.BeginMouseDrag(new Point(566, 350));
            CommandList.Sleep(2000);
            CommandList.EndDrag();

            CommandList.MouseClick(new Point(627, 502));
            CommandList.Sleep(2000);
        }
    }
}
