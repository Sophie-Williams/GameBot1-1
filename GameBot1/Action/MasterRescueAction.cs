using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameBot1.Action
{
    class MasterRescueAction : Navigation.Navigation
    {
        private readonly int WaitInMin;
        private readonly int Retries;

        private int RetryIndex;
        public MasterRescueAction(int waitInMin, int retries)
        {
            this.WaitInMin = waitInMin;
            this.Retries = retries;
            RetryIndex = 0;
        }
        internal override void Execute(StreamWriter fs)
        {
            Repeat = true;
            if (AreWeHomeYet())
            {
                RetryIndex = 0;
                Repeat = false;
                return;
            }
            if(this.RetryIndex >= this.Retries)
            {
                throw new ApplicationException("Recovery Failed!");
            }
            this.RetryIndex++;
            Thread.Sleep(new TimeSpan(0, this.WaitInMin, 0));
        }


        internal MasterRescueAction Add(Rescue.Rescue a)
        {
            Children.Add(a);
            return this;
        }
        internal override bool CheckPreconditions()
        {
            return !AreWeHomeYet();
        }
    }
}
