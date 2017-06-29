using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.Azure;
using System;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Infnet.Azure.Assessment.Data.Azure
{
    public class QueueData
    {
        private string queueName;
        private const string CONNECTION_STRING = "StorageConnectionString";
        public QueueData(string queueName)
        {
            this.queueName = queueName;
        }

        public bool AddToQueue<T>(T itemToQueue) where T : new()
        {
            try
            {
                var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting(CONNECTION_STRING));
                var queueClient = storageAccount.CreateCloudQueueClient();
                var queue = queueClient.GetQueueReference(this.queueName);
                queue.CreateIfNotExists();
                var json = JsonConvert.SerializeObject(itemToQueue);
                var message = new CloudQueueMessage(json);
                queue.AddMessage(message);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public T DequeueItem<T>() where T : new()
        {
            var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting(CONNECTION_STRING));
            var queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference(this.queueName);
            queue.CreateIfNotExists();
            var peekedMessage = queue.GetMessage();

            var item = JsonConvert.DeserializeObject<T>(peekedMessage.AsString);
            queue.DeleteMessage(peekedMessage);

            return item;
        }
    }
}
