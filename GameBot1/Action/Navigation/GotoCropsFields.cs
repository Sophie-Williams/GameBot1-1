using AhkWrapper.AHKFunctions;
using GameBot1.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBot1.Action.Navigation
{
    class GotoCrops : Navigation
    {
        internal GotoCrops Add(Crops.Crops a)
        {
            this.Children.Add(a);
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        internal override void Execute(StreamWriter fs)
        {
            CommandList.MouseDrag(new Point(900, 300), -850,    0);
            CommandList.MouseDrag(new Point(900, 300), -850,    0);
            CommandList.MouseDrag(new Point(500, 550),    0, -500);
            Point p = CommandList.ImageSearch(@"C:\Users\Achu\Pictures\CropFieldTargetPole.png"
                , 60, new Point(0, 0), new Point(1000, 650));
            if (p.X <= 0) 
            {
                throw new InvalidStateException("Can't Find the crop post");
            }
            CommandList.MouseDrag(p, new Point(1000, 650));
        }
    }
}
