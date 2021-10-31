using Azure.Storage.Queues;
using System;

namespace AZStorage
{
    class Program
    {
        static string connectionstring = "DefaultEndpointsProtocol=https;AccountName=tksstorageaccount;AccountKey=yM4b9KOYPcEPbgayFfEm68KBST0NUA4gtTapET1c/Ix1XxTe6dKIMDjnxuD0NElTyloVkYLxQCfnGKwyVTpBmg==;EndpointSuffix=core.windows.net";
        static string queuname = "tksqueue";
        static void Main(string[] args)
        {
            QueueClient queueclient = new QueueClient(connectionstring, queuname);

            string _mesg = string.Empty;
            for (int i = 0; i < 5; i++)
            {
                queueclient.SendMessage($"Message {i + 1}");
            }

            Console.WriteLine("Message sent.");
            Console.ReadKey();
        }
    }
}
