using AhkWrapper.AHKFunctions;
using GameBot1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBot1.Action.Navigation
{
    abstract class Navigation : Action
    {
        protected bool AreWeHomeYet()
        {
            Point p1 = new Point(360, 160);
            Point p2 = new Point(420, 210);
            Point p = CommandList.ImageSearch(
                @"C:\Users\Achu\Pictures\HomeFarmTopLeftPositionTargetPole.png"
                , 60, p1, p2);
            return (p.X != Point.Error.X);
        }
        //Check if already at home
        internal override bool CheckPreconditions()
        {

            if (!AreWeHomeYet())
            {
                throw new InvalidStateException("cant find HomeFarmTopLeftPositionTargetPole"); 
            }
            return true;
        }

    }
}
