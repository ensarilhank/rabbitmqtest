using System;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;

namespace rabbitmqtest
{
    class Consumer
    {
        private readonly RabbitMQService _rabbitMQService;

        public Consumer(string queueName)
        {                    
                _rabbitMQService = new RabbitMQService();

                using (var connection = _rabbitMQService.GetRabbitMQConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        var consumer = new RabbitMQ.Client.Events.EventingBasicConsumer(channel);

                        consumer.Received += (model, ea) =>
                        {
                            var body = ea.Body;
                            var message = Encoding.UTF8.GetString(body.ToArray());

                            Console.WriteLine("{0} isimli queue üzerinden gelen mesaj: \"{1}\"", queueName, message);
                        };

                        channel.BasicConsume(queueName, true, consumer);
                        Console.ReadLine();
                    }
                
                }
        }
    }
}
