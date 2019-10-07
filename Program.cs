using System;
using System.Text;
using FanoutExchange;
using MassTransit;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace GettingStartedMassTransit
{
    public class YourMessage
    {
        public string Text { get; set; }
    }

    class Program
    {
        public static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var console = new PublisherConsole("", "", null);
                var action = new Action<string, string, IBasicProperties, byte[]>(channel.BasicPublish);
                console.StartPublisher(action);
            }
        }
    }
}
