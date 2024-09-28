using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory()
{
    HostName = "localhost",  // Use your RabbitMQ host here
    UserName = "guest",      // Default RabbitMQ username
    Password = "guest"       // Default RabbitMQ password
};

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

// Declare the queue from which we're going to consume
string queueName = "medicinesAdd";
channel.QueueDeclare(queue: queueName,
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

Console.WriteLine(" [*] Waiting for messages.");

// Create a consumer to receive messages
var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($" [x] Received {message}");
};

// Start consuming messages from the queue
channel.BasicConsume(queue: queueName,
                     autoAck: true,  // Auto acknowledge the message
                     consumer: consumer);

// Keep the console app running to listen for messages
Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();