using AutoFire.IView;
using AutoFire.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFire.Presenter
{
    public class AutoFirePresenter
    {
        public IAutoFire View { get; private set; }
        private ScanAndFire service;

        public AutoFirePresenter(IAutoFire view)
        {
            this.View = view;
            service = new ScanAndFire();
            service.ServiceLog = view.PrintMessage;
        }
        
        
    }
}
