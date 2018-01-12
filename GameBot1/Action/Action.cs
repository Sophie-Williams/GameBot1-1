using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBot1.Action
{
    public abstract class Action
    {
        protected bool ContinueExecuteChildren { get; set; }
        protected bool Repeat { get; set; }

        protected List<Action> Children { get; private set; }

        public Action()
        {
            Children = new List<Action>();
            ContinueExecuteChildren = true;
            Repeat = false;
        }

        public void ExecuteAll(StreamWriter fs)
        {
            do
            {
                fs.Write(this.GetType());
                if (this.CheckPreconditions())
                {
                    fs.Write(": preconditions passed");
                    this.Execute(fs);
                    fs.WriteLine(string.Format(": execution completed Repeat-{0} ContinueExecuteChildren-{1}"
                        , this.Repeat, this.ContinueExecuteChildren));
                    if (this.ContinueExecuteChildren)
                    {
                        foreach (Action a in this.Children)
                        {
                            a.ExecuteAll(fs);
                        }
                    }
                }
                else
                {
                    fs.WriteLine(": preconditions failed");
                    break;
                }
                    
            } while (this.Repeat);
        }
        internal virtual bool CheckPreconditions() 
        {
            return true;
        }

        internal abstract void Execute(StreamWriter fs);
    }
}
