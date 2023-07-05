namespace C11_ProxyPattern
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            GumballMonitorTest();
        }

        public static void GumballMonitorTest()
        {
            GumballMachine machine = new GumballMachine("Seattle", 112);
            GumballMonitor monitor = new GumballMonitor(machine);
            
            monitor.Report();
        }
    }
}