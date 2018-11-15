using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using RestTest.Interfaces;

namespace RestTest.Storage
{
    public class StorageService : IStorageService
    {
        // PUBLIC

        // types

        public class CONFIG
        {
            public string ConnectionString { get; set; } = "";
            public string ContainerName { get; set; } = "";
        }

        // constructor

        public StorageService(CONFIG config)
        {
            // TODO: Add logging for failure/success
            CloudStorageAccount.TryParse(config.ConnectionString, out mAccount);
            mContainerName = config.ContainerName;
        }

        // methods

        public override bool IsConnected()
        {
            return mAccount != null;
        }

        public async override Task<bool> AddFile()
        {
            Task<CloudBlobContainer> container = GetContainer();

            await container;

            return true;
        }

        // PRIVATE

        // members

        private readonly CloudStorageAccount mAccount;
        private readonly string mContainerName;

        // methods

        private async Task<IEnumerable<CloudBlobContainer>> GetAllContainers()
        {
            CloudBlobClient blobClient = mAccount.CreateCloudBlobClient();

            BlobContinuationToken continuationToken = null;
            List<CloudBlobContainer> results = new List<CloudBlobContainer>();
            do
            {
                var response = await blobClient.ListContainersSegmentedAsync(continuationToken);
                continuationToken = response.ContinuationToken;
                results.AddRange(response.Results);
            }
            while (continuationToken != null);

            return results;
        }

        private async Task<CloudBlobContainer> GetContainer()
        {
            CloudBlobClient blobClient = mAccount.CreateCloudBlobClient();

            // try and get a container with the provided name
            CloudBlobContainer container = blobClient.GetContainerReference(mContainerName);

            // create the container if it doesn't yet exist
            bool containerCreated = await container.CreateIfNotExistsAsync();

            // set container permissions
            {
                BlobContainerPermissions permissions = new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                };
                await container.SetPermissionsAsync(permissions);
            }


            return container;
        }
    }
}
