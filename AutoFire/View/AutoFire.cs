using AutoFire.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFire.IView
{
    public partial class AutoFire : Form, IAutoFire
    {

        StreamWriter fileWriter;
        public AutoFirePresenter Presenter { get; private set; }
        public AutoFire()
        {
            InitializeComponent();
            this.Presenter = new AutoFirePresenter(this);
            string fileName = @"C:\temp\AutoFireLog_" + DateTime.Now.Ticks + ".txt";
            fileWriter = new StreamWriter(fileName);
            label1.Text = "Logging to: " + fileName;
        }
        
        public void PrintMessage(string message)
        {
            this.Invoke(new Action(() => Print(message)));
        }
        private void Print(string message)
        {
            textBox1.Text = message;
            fileWriter.WriteLine(message);
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            fileWriter.Flush();
            base.OnFormClosing(e);
        }
    }
}
