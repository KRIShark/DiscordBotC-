using System.Threading.Tasks;

namespace DcBeamMpBot
{
    class Program
    {
        public static Task Main(string[] args)
            => Startup.RunAsync(args);
    }
}
