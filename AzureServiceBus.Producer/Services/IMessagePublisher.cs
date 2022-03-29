using System.Threading.Tasks;

namespace AzureServiceBus.Producer.Services
{
    public interface IMessagePublisher
    {
        public Task Publish<T>(T obj);

        public Task Publish(string raw);
    }
}