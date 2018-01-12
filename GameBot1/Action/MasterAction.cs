using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameBot1.Action
{
    class MasterNavigationAction : Rescue.Rescue
    {
        public MasterNavigationAction Add(Navigation.Navigation a)
        {
            Children.Add(a);
            return this;
        }
        /// <summary>
        /// THere are no preconditions for the master action
        /// </summary>
        /// <returns></returns>
        internal override bool CheckPreconditions()
        {
            return true;
        }

        internal override void Execute(StreamWriter fs)
        {
            ;
        }
    }
}
