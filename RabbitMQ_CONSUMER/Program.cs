using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory()
{
    HostName = "localhost",  
    UserName = "guest",      
    Password = "guest"      
};

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

string queueName = "medicinesAdd";
channel.QueueDeclare(queue: queueName,
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

Console.WriteLine(" [*] Waiting for messages.");

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($" [x] Received {message}");
};

channel.BasicConsume(queue: queueName,
                     autoAck: true,  
                     consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();