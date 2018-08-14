namespace EnvelopeDistributorConsole
{
    public class Runner
    {
        public static MockedLiteDbContext Context = new MockedLiteDbContext();
        static void Main(string[] args)
        {
            new EnvelelopeDistributor().Run();
        }

    }
}