namespace MyFirstAspNetCoreApp.Services
{
    public class CountInstancesService : ICountInstancesService
    {
        private static int _count;
        public CountInstancesService()
        {
            _count++;
        }
        public int Instances => _count;
    }
}