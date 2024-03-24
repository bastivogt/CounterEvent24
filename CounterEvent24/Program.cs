namespace CounterEvent24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new();

            counter.CounterStartEvent += (Object? sender, CounterEventArgs e) =>
            {
        
                Console.WriteLine($"COUNTER_START count: {e.Count}");
            };

            counter.CounterUpdateEvent += (Object? sender, CounterEventArgs e) =>
            {
                Console.WriteLine($"COUNTER_UPDATE count: {e.Count}");
            };

            //counter.CounterFinishEvent += (Object? sender, CounterEventArgs e) => 
            //{
            //    Counter? c = (Counter?) sender;
            //    Console.WriteLine($"COUNTER_FINISH count: {c?.Count}");
            //};

            counter.CounterFinishEvent += counter_CounterFinishEventHandler;
            counter.Run();
        }

        static void counter_CounterFinishEventHandler(Object? sender, CounterEventArgs e)
        {
            Counter? c = (Counter?)sender;
            Console.WriteLine($"COUNTER_FINISH count: {c?.Count}");
        }
    }
}
