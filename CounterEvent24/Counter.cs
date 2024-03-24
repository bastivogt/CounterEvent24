using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterEvent24
{
    public class Counter
    {

        public int Start { get; set; }
        public int End { get; set; }
        public int Step { get; set; }

        protected int _count;

        public int Count
        {
            get => this._count;
            protected set => this._count = value;
        }


        public event EventHandler<CounterEventArgs>? CounterStartEvent = null;
        public event EventHandler<CounterEventArgs>? CounterUpdateEvent = null;
        public event EventHandler<CounterEventArgs>? CounterFinishEvent = null;


        public Counter(int start = 0, int end = 10, int step = 1)
        {
            this.Start = start;
            this.End = end;
            this.Step = step;
            this.Count = this.Start;
        }

        protected virtual void OnCounterStart(CounterEventArgs e)
        {
            this.CounterStartEvent?.Invoke(this, e);
        }


        protected virtual void OnCounterUpdate(CounterEventArgs e)
        {
            this.CounterUpdateEvent?.Invoke(this, e);
        }


        protected virtual void OnCounterFinish(CounterEventArgs e)
        {
            this.CounterFinishEvent?.Invoke(this, e);
        }

        public void Run()
        {
            this.Count = this.Start;
            this.OnCounterStart(new CounterEventArgs(this.Count));
            
            for (; this.Count < this.End; this.Count ++)
            {
                this.OnCounterUpdate(new CounterEventArgs(this.Count));
            }
            this.OnCounterFinish(new CounterEventArgs(this.Count));
        }
    }
}
