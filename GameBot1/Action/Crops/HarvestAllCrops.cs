using AhkWrapper.AHKFunctions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameBot1.Action.Crops
{
    class HarvestAllCrops:Crops
    {
        private Point KnifePoint;
        

        internal HarvestAllCrops ()
        {
            KnifePoint = new Point(-1, -1);
        }

        internal HarvestAllCrops Add(Seed.Seed seed)
        {
            Children.Add(seed);
            return this;
        }

        internal override bool CheckPreconditions()
        {
            return true;
        }

        internal override void Execute(StreamWriter fs)
        {
            foreach (Action i in Children)
            {
                if (i is Seed.Seed)
                {
                    ((Seed.Seed)i).WaitForHavest();
                }
            }
            CommandList.MouseClick(FieldPoint);
            CommandList.Sleep(2000);

            KnifePoint = CommandList.ImageSearch(@"C:\Users\Achu\Pictures\HarvestKnife.png"
                , 25, new Point(FieldPoint.X - 200, FieldPoint.Y - 200), FieldPoint);

            if (KnifePoint.X != Point.Error.X)
            {
                SwipeAccrossTheFields(KnifePoint, FieldPoint);
                if (CloseSiloFullMessage()) { fs.Write("###WARNING  Silo is full message"); }
                CommandList.Sleep(200);
            }
            else
            {
                fs.Write("!!!ERROR Knife not found ");
            }
            
        }

        private bool CloseSiloFullMessage()
        {
            Point p = new Point(689,200);
            string color = CommandList.GetColour(p);
            if (color.Equals("0x246AF8"))
            {
                CommandList.MouseClick(p);
                CommandList.Sleep(2000);
                return true;
            }
            return false;
        }
    }
}
