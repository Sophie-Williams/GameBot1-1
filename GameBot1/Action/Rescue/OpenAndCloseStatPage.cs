using AhkWrapper.AHKFunctions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameBot1.Action.Rescue
{
    //Keep clicking on the blue star position until the 
    //Statistics page open, then close the page
    class OpenAndCloseStatPage:Rescue
    {
        //374 51 - location to open
        internal override void Execute(StreamWriter fs)
        {
            for (int i = 0; i < 5; i++)
            {
                CommandList.MouseClick(new Point(358, 28));
                CommandList.Sleep(5000);
            }

            CloseStatPage();
        }

        private void CloseStatPage()
        {
            Point p = CommandList.ImageSearch(
                @"C:\Users\Achu\Pictures\StatisticPageCloseButton.png"
                ,20, new Point(644,145), new Point(744, 244));
            if (p.X != Point.Error.X)
            {
                CommandList.MouseClick(p);
            }
        }
    }
}
