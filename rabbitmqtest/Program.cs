using System;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
namespace rabbitmqtest
{
    class Program
    {
        private static readonly string queueName = "test";
        private static publisher _publisher;
        private static Consumer consumer;
        static void Main(string[] args)
        {

            MySqlConnection connection1 = new MySqlConnection("Server=localhost;Database=testdb;Uid=root;Pwd=;SslMode=none;");
            
            connection1.Open();
            MySqlCommand command = new MySqlCommand("Select * from users", connection1);
            command.ExecuteNonQuery();
            MySqlDataReader rdr = command.ExecuteReader();
           
            while (rdr.Read())
            {
                string id = rdr[0].ToString();
                string name = rdr[1].ToString();
                string surname = rdr[2].ToString();
                string mail = rdr[3].ToString();
                _publisher = new publisher(queueName, id +" "+ name +" "+ surname +" "+mail);                  
            }
            consumer = new Consumer(queueName);
            connection1.Close();
            
            Console.ReadLine();

        }
    }
}
