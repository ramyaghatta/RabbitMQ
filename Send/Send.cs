using System;
using System.Text;
using RabbitMQ.Client;
namespace Send
{
    class Send
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
             var factory = new ConnectionFactory() { HostName = "localhost" };
        using(var connection = factory.CreateConnection())
        using(var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "Queue1",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            //string message = "Hello World!Rabbit MQ Message";
            string message;
            Console.WriteLine("Enter Message:");
            message=Console.ReadLine();
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                 routingKey: "hello",
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine(" [x] Sent {0}", message);
        }

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
        }
    }
}

