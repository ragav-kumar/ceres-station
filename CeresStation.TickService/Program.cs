namespace CeresStation.TickService;

internal class Program
{
    private static Mutex? mutex;
    private const string MutexName = "Global\\CERES_STATION_TICK_SERVICE";
    
    public static void Main(string[] args)
    {
        mutex = new Mutex(true, MutexName, out bool createdNew);
        if (!createdNew)
        {
            // Another instance is already running.
            return;
        }
        
        // TODO: Run tick service
        
        mutex.ReleaseMutex();
    }
}
