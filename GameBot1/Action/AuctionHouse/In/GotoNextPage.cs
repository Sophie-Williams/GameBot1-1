using AhkWrapper.AHKFunctions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameBot1.Action.AuctionHouse.In.Repeatable
{
    class GotoNextPage : InAuctionHouse
    {
        private int TotalRepeats, CurentIteration;

        public GotoNextPage(int repeat) 
        {
            TotalRepeats = repeat;
            CurentIteration = 0;
        }
        internal GotoNextPage Add(InAuctionHouse a)
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
            CommandList.MouseDrag(new Point(207, 367), 540, 0);
            CommandList.Sleep(2000);
            SetRepeat();
        }

        private void SetRepeat()
        {
            if (TotalRepeats <= CurentIteration)
            {
                Repeat = false;
                CurentIteration = 0;
            }
            else 
            { 
                Repeat = true;
                CurentIteration++;
            }
        }
    }
}
