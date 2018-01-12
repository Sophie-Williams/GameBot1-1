using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameBot1.Action.Crops.Seed
{
    abstract class Seed:Crops
    {
        private int TimeToGrowInSec;
        protected DateTime GrowthStartTime;

        public Seed(int timeToGrowInSec)
        {
            this.TimeToGrowInSec = timeToGrowInSec;
            this.GrowthStartTime = DateTime.MinValue;
        }

        /// <summary>
        /// Blocks the thread until its time for harvest
        /// </summary>
        internal void WaitForHavest()
        {
            DateTime growthEndTime = GrowthStartTime.AddSeconds(TimeToGrowInSec);
            if (growthEndTime > DateTime.Now)
            {
                Thread.Sleep((growthEndTime - DateTime.Now));
            }
        }

    }
}
