using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
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

            if (queueclient.Exists())
            {
                #region Push Message
                //string _mesg = string.Empty;
                //for (int i = 0; i < 5; i++)
                //{
                //    queueclient.SendMessage($"Message {i + 1}");
                //}
                //Console.WriteLine("Message sent.");
                #endregion

                #region Peek Message
                //PeekedMessage[] peekMessage = queueclient.PeekMessages(2);
                //foreach (var _qmessage in peekMessage)
                //{
                //    Console.WriteLine($"MessageID-{ _qmessage.MessageId}");
                //    Console.WriteLine($"InsertedOn-{ _qmessage.InsertedOn}");
                //    Console.WriteLine($"Body-{ _qmessage.Body}");
                //}
                #endregion
                #region Receive Message and Delete Message
                QueueMessage queueMessage = queueclient.ReceiveMessage();
                Console.WriteLine($"The Received Message - {queueMessage.Body}");
                queueclient.DeleteMessage(queueMessage.MessageId, queueMessage.PopReceipt);
                Console.WriteLine("Message Deleted.");
                #endregion
            }

            Console.ReadKey();
        }
    }
}
