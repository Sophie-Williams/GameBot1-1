using AhkWrapper.AHKFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBot1.Action.Crops
{
    abstract class Crops : Action
    {
        public int FieldPointX = 390, FieldPointY = 322;

        const int swipeX1 = 6;
        const int swipeY1 = 27;
        const int swipeX2 = 960;
        const int swipeY2 = 622;
        const int swipeXIncrements = 25;


        protected Point FieldPoint;

        public Crops()
        {
            FieldPoint = new Point(FieldPointX, FieldPointY);
        }

        public void SwipeAccrossTheFields(Point tool, Point firstField)
        {

            CommandList.BeginMouseDrag(tool);
            CommandList.Sleep(500);
            CommandList.ContinueDrag(firstField);
            CommandList.Sleep(500);
            Point leftTop = new Point(swipeX1, swipeY1);
            Point leftBottom = new Point(swipeX1, swipeY2);

            while(leftTop.X < swipeX2)
            {
                CommandList.ContinueDrag(leftTop, leftBottom);
                leftTop.X += swipeXIncrements;
                leftBottom.X += swipeXIncrements;
            }
            CommandList.EndDrag();
        }
    }
}
