using System;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;

namespace rabbitmqtest
{
   public class publisher
    {
        private readonly RabbitMQService _rabbitMQService;
        public publisher(string queueName,string message)
        {
            _rabbitMQService = new RabbitMQService();

            using(var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                using(var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queueName, false, false, true, null);
                    channel.BasicPublish("",queueName, null, Encoding.UTF8.GetBytes(message));
                    Console.WriteLine("{0} queue ' su üzerine,\"{1}\" mesajı yazıldı",queueName,message);
                }
            }

        }

    }
}
