using AhkWrapper.AHKFunctions;
using GameBot1.FarmQuantities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameBot1.Action.Crops.Seed
{
    class SeedWheet:Seed
    {
        Point WheetPoint;

        internal SeedWheet()
            :base(120)
        {
            WheetPoint = new Point(-1, -1);
        }


        internal override bool CheckPreconditions()
        {
            CommandList.MouseClick(FieldPoint);
            CommandList.Sleep(3000);

            WheetPoint = CommandList.ImageSearch(@"C:\Users\Achu\Pictures\wheetSample.png"
                , 25
                , new Point(FieldPoint.X - 200, FieldPoint.Y - 200), FieldPoint);

            return (WheetPoint.X > 0);
        }


        internal override void Execute(StreamWriter fs)
        {
            SwipeAccrossTheFields(WheetPoint, FieldPoint);

            //Set the time after seeding
            GrowthStartTime = DateTime.Now;
            SiloQuantities.WheetQuantityIsEmpty = false;
        }
    }
}
