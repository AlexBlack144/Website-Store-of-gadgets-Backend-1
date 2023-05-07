using Azure.Storage.Blobs;
using DataAccessEF.Data;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace DataAccessEF.Repositories
{
    public class GadgetRepositories : GenericRepository<Gadget>, IGadgetRepository
    {
        public GadgetRepositories(asp_tablesContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Gadget> GetAll() => _dbContext.Gadgets.ToList();
        public Gadget GetId(int id)
        {
            return _dbContext.Gadgets.Find(id);
        }
        public IEnumerable<Gadget> GetbyIdCategory(int id)
        {
            return _dbContext.Gadgets.AsEnumerable().Where(x => x.IdCategory == id);
        }
        public IEnumerable<Gadget> GetGadgetByName(string name)
        {
            return _dbContext.Gadgets.AsEnumerable().Where(x => x.Name.ToLower().StartsWith(name)||x.Model.ToLower().StartsWith(name));
        }
        public IEnumerable<Gadget> GetGadgetFilter(string[]? nameModels, int? min, int? max)
        {
            List<Gadget> gadgets = new List<Gadget>();

            foreach (var model in nameModels)
            {
                if (_dbContext.Gadgets.AsEnumerable().Any(x => x.Name == model) == true)
                {
                    gadgets.AddRange(_dbContext.Gadgets.AsEnumerable().Where(x => x.Name == model));
                }
            }
            if (gadgets.Count > 0)
            {
                return gadgets.AsEnumerable().Where(x => x.Price >= min && x.Price <= max);
            }
            else
            {
                gadgets.AddRange(_dbContext.Gadgets);
                
                if (gadgets.AsEnumerable().Where(x => x.Price >= min && x.Price <= max).Count() > 0)
                {
                    return gadgets.AsEnumerable().Where(x => x.Price >= min && x.Price <= max);
                }
                else {
                    return gadgets;
                }
               
            }
        }

        public async Task<string> UploadImg(IFormFile file, string blobName)
        {
            try {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=alexstsorageblops;AccountKey=c3q6k8sqa8heP9SPbGaCzFblGm1c7B5BtrD6sasEgLbzHglLkugLR0PzWQRx6XF2w0nnGhPLG5pR+ASttFIr+A==;EndpointSuffix=core.windows.net");
                CloudBlobClient client = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = client.GetContainerReference("img-gadgets");
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    memoryStream.Position = 0;
                    blobName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    CloudBlockBlob blob = container.GetBlockBlobReference(blobName);
                    string mimeType = "application/unknown";
                    string ext = (blobName.Contains(".")) ?
                                System.IO.Path.GetExtension(blobName).ToLower() : "." + blobName;
                    Microsoft.Win32.RegistryKey regKey =
                                Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
                    if (regKey != null && regKey.GetValue("Content Type") != null)
                        mimeType = regKey.GetValue("Content Type").ToString();

                    memoryStream.ToArray();
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    blob.Properties.ContentType = mimeType;
                    await blob.UploadFromStreamAsync(memoryStream);
                    return blobName;
                }
            } 
            catch (Exception e){
                string catc = e.Message;
                return catc;
            }
            



        }
        public string GetImgUrl(string name)
        {
            string url = null;
            string storageAccount_connectionString = "DefaultEndpointsProtocol=https;AccountName=alexstsorageblops;AccountKey=c3q6k8sqa8heP9SPbGaCzFblGm1c7B5BtrD6sasEgLbzHglLkugLR0PzWQRx6XF2w0nnGhPLG5pR+ASttFIr+A==;EndpointSuffix=core.windows.net";
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageAccount_connectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("img-gadgets");
            try
            {
                CloudBlobDirectory dira = container.GetDirectoryReference(string.Empty);
                var rootDirFolders = dira.ListBlobsSegmentedAsync(true, BlobListingDetails.Metadata, null, null, null, null).Result;
                foreach (var blob in rootDirFolders.Results)
                {
                   
                    if (blob.Uri.ToString().Contains(name))
                    {
                        url = blob.Uri.ToString();
                        break;
                    }
                    
                }
                return url;
            }
            catch (Exception e)
            {
                return "Error";
            }
        }
    }
}
