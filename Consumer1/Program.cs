using System;
using System.Collections.Generic;
using Consumer1.Models;
using Consumer1.Services;
using MongoDB.Driver;

namespace AtlasStarter
{    
    class MainClassNoPrompt
    {
        public static void Main(string[] args)
        {
            //ConsumerService consumerService = new ConsumerService();
            //consumerService.Main(args);
            MySQLConsumer mySQLConsumer = new MySQLConsumer();
            mySQLConsumer.getCustomersMySQL();
        }
    }
}

