using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ_CONSUMER
{
    public class Consumer
    {
        public static void Main()
        {
            // Create a connection factory
            var factory = new ConnectionFactory() { HostName = "localhost" };

            // Establish the connection
            using (var connection = factory.CreateConnection())
            {
                // Create a channel
                using (var channel = connection.CreateModel())
                {
                    // Declare the same queue
                    channel.QueueDeclare(queue: "hello",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    Console.WriteLine(" [*] Waiting for messages.");

                    // Create a consumer event
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine($" [x] Received {message}");
                    };

                    // Start consuming the messages
                    channel.BasicConsume(queue: "hello",
                                         autoAck: true,
                                         consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
        }
    }
}
