using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterEvent24
{
    public class CounterEventArgs : EventArgs
    {
        private int _count;
        public int Count {
            get => this._count;
            private set => this._count = value;        }
        public CounterEventArgs(int count):base() { 
            this.Count = count;
        }
    }
}
