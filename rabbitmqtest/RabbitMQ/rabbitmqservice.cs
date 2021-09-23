using RabbitMQ.Client;

namespace rabbitmqtest
{
    public class RabbitMQService
    {
        private readonly string hostName = "localhost";

        //Eğer url şeklinde olucaksa hostname 
        /*
        ConnectionFactory connectionFactory = new ConnectionFactory()
            {
               Uri = new uri("url")
            };
            return connectionFactory.CreateConnection();
         
         
         */

        public IConnection GetRabbitMQConnection()
        {

            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                HostName = hostName
            };
            return connectionFactory.CreateConnection();
        }

    }
}
