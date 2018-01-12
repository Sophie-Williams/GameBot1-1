using AhkWrapper.AHKFunctions;
using GameBot1.Action.AuctionHouse.In;
using GameBot1.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameBot1.Action.AuctionHouse.At
{
    class OpenAuctionHouse:AtAuctionHouse
    {
        private Point AuctionHousePoint;


        public OpenAuctionHouse() 
        {
            this.AuctionHousePoint = Point.Error;
        }

        internal OpenAuctionHouse Add(InAuctionHouse a)
        {
            Children.Add(a);
            return this;
        }

        internal override bool CheckPreconditions()
        {
            this.AuctionHousePoint = CommandList.ImageSearch(
                @"C:\Users\Achu\Pictures\AuctionHouse.png"
                , 50,
                Point.Min, Point.Max);
            if(this.AuctionHousePoint.X == Point.Error.X)
            {
                throw new InvalidStateException("Cant find the auction house");
            }
            return true;

        }

        internal override void Execute(StreamWriter fs)
        {
            CommandList.MouseClick(AuctionHousePoint);
            CommandList.Sleep(2000);

        }
    }
}
