using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using RedeSocial.Infraestrutura.Files;
using System;
using System.IO;

namespace RedeSocial.Infraestrutura.Files
{
    public interface IPostFileUploader {
        string UploadFile(IFormFile file, string fileName);
    }

    public class PostFileUploader : IPostFileUploader
    {
        public string UploadFile(IFormFile file, string fileName)
        {
            return "";

            var reader = file.OpenReadStream();
            var cloudStorageAccount = CloudStorageAccount.Parse("##");
            var blobClient = cloudStorageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("post-images");
            container.CreateIfNotExists();
            var blob = container.GetBlockBlobReference(fileName);
            blob.UploadFromStream(reader);
            var destinoDaImagemNaNuvem = blob.Uri.ToString();
            return destinoDaImagemNaNuvem;
        }
    }
}
